using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;


    public static class MapUtil
    {
        public static List<T> toList<T>(this DataTable table)
        {
            List<T> list = new List<T>();

                T item ;
                Type listItemType = typeof(T);

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    item = (T) Activator.CreateInstance(listItemType);
                    mapRow(item, table, listItemType, i);
                    list.Add(item);
                }
              return list;
            }

          
       private static void mapRow(object vOb, System.Data.DataTable table, Type type, int row)
        {
            for (int col = 0; col < table.Columns.Count; col++)
            {
                var columnName = table.Columns[col].ColumnName;

                    var prop = type.GetProperty(columnName);
                    object data = getData(prop, table.Rows[row][col]);
                    prop.SetValue(vOb, data, null);

            }
        }

        private static object getData(PropertyInfo prop, object value)
        {
            if (prop.PropertyType.Name.Equals("Int32"))
                return Convert.ToInt32(value);

            if (prop.PropertyType.Name.Equals("Double"))
                return Convert.ToDouble(value);

            if (prop.PropertyType.Name.Equals("DateTime"))
                return Convert.ToDateTime(value);

            return Convert.ToString(value).Trim();
        }



        public static DataTable toDataTable(this IList list)
        {

            DataTable dt = null;
            Type listType = list.GetType();

                if (listType.IsGenericType)
                {
                    Type elementType = listType.GetGenericArguments()[0];
                    dt = new DataTable(elementType.Name + "List");
                    MemberInfo[] miArray = elementType.GetMembers(
                        BindingFlags.Public | BindingFlags.Instance);
                    foreach (MemberInfo mi in miArray)
                    {
                        if (mi.MemberType == MemberTypes.Property)
                        {
                            PropertyInfo pi = mi as PropertyInfo;
                            dt.Columns.Add(pi.Name, pi.PropertyType);
                        }
                        else if (mi.MemberType == MemberTypes.Field)
                        {
                            FieldInfo fi = mi as FieldInfo;
                            dt.Columns.Add(fi.Name, fi.FieldType);
                        }
                    }
                    IList il = list;
                    foreach (object record in il)
                    {
                        int i = 0;
                        object[] fieldValues = new object[dt.Columns.Count];
                        foreach (DataColumn c in dt.Columns)
                        {
                            MemberInfo mi = elementType.GetMember(c.ColumnName)[0];
                            if (mi.MemberType == MemberTypes.Property)
                            {
                                PropertyInfo pi = mi as PropertyInfo;
                                fieldValues[i] = pi.GetValue(record, null);
                            }
                            else if (mi.MemberType == MemberTypes.Field)
                            {
                                FieldInfo fi = mi as FieldInfo;
                                fieldValues[i] = fi.GetValue(record);
                            }
                            i++;
                        }
                        dt.Rows.Add(fieldValues);
                    }
                }
            return dt;
        }
    }
