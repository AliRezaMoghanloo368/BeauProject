using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Text;

namespace BeauProject.Shared.Classes
{
    public partial class FileMethods
    {
        #region Excel
        public System.Data.DataTable LoadExcelFile(IFormFile file, List<DataColumn> columns, bool SaveFile = false)
        {
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            using (FileStream fs = File.Create(filepath))
            {
                file.CopyToAsync(fs);
            }
            XLWorkbook workbook = XLWorkbook.OpenFromTemplate(filepath);
            var sheets = workbook.Worksheets.First();
            var rows = sheets.Rows().ToList();
            DataTable dt = loadData(columns, rows);
            if (SaveFile == false) File.Delete(filepath);
            return dt;
        }

        private DataTable loadData(List<DataColumn> DataColumns, List<IXLRow> rows)
        {
            DataTable custTable = new DataTable();
            DataColumn dtColumn;
            DataRow myDataRow;

            //dtColumn = new DataColumn();
            //dtColumn.DataType = typeof(Int32);
            //dtColumn.ColumnName = "id";
            //dtColumn.Caption = "Cust ID";
            //dtColumn.ReadOnly = false;
            //dtColumn.Unique = true;
            //custTable.Columns.Add(dtColumn);

            foreach (var item in DataColumns)
            {
                dtColumn = new DataColumn();
                dtColumn = item;
                //dtColumn.DataType = item.DataType;
                //dtColumn.ColumnName = item.ColumnName;
                //dtColumn.Caption = item.Caption;
                //dtColumn.ReadOnly = item.ReadOnly;
                //dtColumn.Unique = item.Unique;
                custTable.Columns.Add(dtColumn);
            }

            for (int i = 0; i < rows.Count; i++)
            {
                for (int r = 0; r < custTable.Columns.Count; r++)
                {
                    myDataRow = custTable.NewRow();
                    try
                    {
                        myDataRow[i] = rows[i].Cell(r).Value.ToString();
                        custTable.Rows.Add(myDataRow);
                    }
                    catch { }
                }
            }
            return custTable;
        }
        #endregion

        #region File
        public static byte[] ConvertFileToByteAsync(IFormFile file, bool SaveFile = false)
        {
            Stream memoryStream = new MemoryStream();
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            using (FileStream fs = File.Create(filepath))
            {
                file.CopyToAsync(fs);
                memoryStream = file.OpenReadStream();
                if (SaveFile == false) File.Delete(filepath);
                return UseStreamReader(memoryStream);
            }
        }
        private static byte[] UseStreamReader(Stream stream)
        {
            byte[] bytes;

            using (var reader = new StreamReader(stream))
            {
                bytes = Encoding.UTF8.GetBytes(reader.ReadToEnd());
            }

            return bytes;
        }

        public static Stream ConvertByteToFile(byte[] bytes)
        {
            var f = (Byte[])(bytes);
            var stream = new MemoryStream(f);
            return stream;
        }

        public static byte[] CreateFile(string word)
        {
            byte[] b = Encoding.ASCII.GetBytes(word);
            string base64 = System.Convert.ToBase64String(b);
            b = Encoding.ASCII.GetBytes(base64);
            var txtStream = new MemoryStream(b);
            return UseStreamReader(txtStream);
        }
        #endregion

        public static string ByteToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream();
            Stream stream = ConvertByteToFile(bytes);
            stream.CopyTo(ms);
            byte[] byteArray = ms.ToArray();
            var b64String = Convert.ToBase64String(byteArray);
            string imageURL = "data:image/png;base64," + b64String;
            return imageURL;
        }
    }
}
