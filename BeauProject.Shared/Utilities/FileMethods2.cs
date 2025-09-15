using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Text;

namespace BeauProject.Shared.Utilities
{
    public class FileMethods2
    {
        public string? base64data { get; set; }
        public string? contentType { get; set; }
        public string? fileName { get; set; }
        public List<byte[]?> ByteDataList = new List<byte[]?>(); //for Image
        public List<FileMethods2> FilesBase64 = new List<FileMethods2>();

        public enum OutDataType
        {
            ByteDataList, FilesBase64, All
        }
        public class Contents
        {
            public Size Size { get; set; } = new Size(258, 258);
            public IReadOnlyList<IBrowserFile> Files { get; set; }
            public OutDataType OutDataType { get; set; }
        }

        public async Task UploadImagesAsync(Contents contents)
        {
            FilesBase64.Clear();
            ByteDataList.Clear();
            foreach (var file in contents.Files)
            {
                var resizedFile = await file.RequestImageFileAsync(file.ContentType, contents.Size.Width, contents.Size.Height); // resize the image file
                byte[]? buf = new byte[resizedFile.Size]; // allocate a buffer to fill with the file's data
                using (var stream = resizedFile.OpenReadStream())
                {
                    await stream.ReadAsync(buf); // copy the stream to the buffer
                }
                if (contents.OutDataType == OutDataType.ByteDataList || contents.OutDataType == OutDataType.All)
                    FilesBase64.Add(new FileMethods2 { base64data = Convert.ToBase64String(buf), contentType = file.ContentType, fileName = file.Name }); // convert to a base64 string!!
                if (contents.OutDataType == OutDataType.FilesBase64 || contents.OutDataType == OutDataType.All)
                    ByteDataList.Add(buf);
            }
            await Task.CompletedTask;
        }

        //path:Directory.GetCurrentDirectory()
        public async Task<byte[]> ToByteAsync(IFormFile file, string path, bool SaveFile = false)
        {
            Stream memoryStream = new MemoryStream();
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(path, filename);
            using (FileStream fs = File.Create(filepath))
            {
                await file.CopyToAsync(fs);
                memoryStream = file.OpenReadStream();
                if (SaveFile == false) File.Delete(filepath);
                return await StreamToByteAsync(memoryStream);
            }
        }

        public Stream ToFile(byte[] bytes)
        {
            var f = (Byte[])(bytes);
            var stream = new MemoryStream(f);
            return stream;
        }

        private async Task<byte[]> StreamToByteAsync(Stream stream)
        {
            byte[] bytes;
            using (var reader = new StreamReader(stream))
            {
                bytes = Encoding.UTF8.GetBytes(await reader.ReadToEndAsync());
            }
            return bytes;
        }

        public async Task<byte[]> CreateFileAsync(string word)
        {
            byte[] b = Encoding.ASCII.GetBytes(word);
            string base64 = System.Convert.ToBase64String(b);
            b = Encoding.ASCII.GetBytes(base64);
            var txtStream = new MemoryStream(b);
            return await StreamToByteAsync(txtStream);
        }
    }
}
