using System.Data;
using System.Reflection;

public static class ListExtensions
{
    public static DataTable ToDataTable<T>(this List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);

        // گرفتن تمام property های عمومی کلاس T
        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in props)
        {
            // اضافه کردن ستون‌ها بر اساس نوع property
            dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        if (items?.Count > 0)
        {
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null) ?? DBNull.Value;
                }
                dataTable.Rows.Add(values);
            }
        }

        return dataTable;
    }
}
