namespace VisioForge_MMT.Classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Serialize and Deserialize Lists of any object type to CSV.
    /// </summary>
    public class CsvSerializer<T> where T : class, new()
    {
        private List<PropertyInfo> _properties;

        #region Properties
        public bool IgnoreEmptyLines { get; set; } = true;

        public bool IgnoreReferenceTypesExceptString { get; set; } = true;

        public string NewlineReplacement { get; set; } = ((char)0x254).ToString();

        public string Replacement { get; set; } = ((char)0x255).ToString();

        public string RowNumberColumnTitle { get; set; } = "RowNumber";

        public char Separator { get; set; } = ',';

        public bool UseEofLiteral { get; set; }

        public bool UseLineNumbers { get; set; } = true;

        public bool UseTextQualifier { get; set; }

        #endregion Properties

        /// <summary>
        /// Csv Serializer
        /// Initialize by selected properties from the type to be de/serialized
        /// </summary>
        public CsvSerializer()
        {
            var type = typeof(T);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance
                | BindingFlags.GetProperty | BindingFlags.SetProperty);


            IEnumerable<System.Reflection.PropertyInfo> q = properties.AsQueryable();

            if (IgnoreReferenceTypesExceptString)
            {
                q = q.Where(a => a.PropertyType.IsValueType || a.PropertyType.Name == "String");
            }

            var r = from a in q
                    where a.GetCustomAttribute<CsvIgnoreAttribute>() == null
                    orderby a.Name
                    select a;

            _properties = r.ToList();
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="stream">stream</param>
        /// <returns></returns>
        /// <summary>
        /// Deserialize.
        /// </summary>
        public IList<T> Deserialize(Stream stream)
        {
            string[] columns;
            string[] rows;

            try
            {
                using (var sr = new StreamReader(stream))
                {
                    var headerLine = sr.ReadLine();
                    if (headerLine == null)
                    {
                        throw new InvalidCsvFormatException("The CSV File is empty or has no header line.");
                    }
                    columns = headerLine.Split(Separator);
                    rows = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                }

            }
            catch (InvalidCsvFormatException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidCsvFormatException("The CSV File is Invalid. See Inner Exception for more inoformation.", ex);
            }

            var data = new List<T>();

            for (int row = 0; row < rows.Length; row++)
            {
                var line = rows[row];

                if (IgnoreEmptyLines && string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                else if (!IgnoreEmptyLines && string.IsNullOrWhiteSpace(line))
                {
                    throw new InvalidCsvFormatException(string.Format(@"Error: Empty line at line number: {0}", row));
                }

                var parts = line.Split(Separator);

                var firstColumnIndex = UseLineNumbers ? 2 : 1;
                if (parts.Length == firstColumnIndex && parts[firstColumnIndex - 1] != null && parts[firstColumnIndex - 1] == "EOF")
                {
                    break;
                }

                var datum = new T();

                var start = UseLineNumbers ? 1 : 0;
                for (int i = start; i < parts.Length; i++)
                {
                    // Skip if index exceeds column count (malformed CSV)
                    if (i >= columns.Length)
                    {
                        continue;
                    }

                    var value = parts[i];
                    var column = columns[i];

                    // continue of deviant RowNumber column condition
                    // this allows for the deserializer to implicitly ignore the RowNumber column
                    if (column.Equals(RowNumberColumnTitle) && !_properties.Any(a => a.Name.Equals(RowNumberColumnTitle)))
                    {
                        continue;
                    }

                    value = value
                        .Replace(Replacement, Separator.ToString())
                        .Replace(NewlineReplacement, Environment.NewLine).Trim();

                    var p = _properties.FirstOrDefault(a => a.Name.Equals(column, StringComparison.InvariantCultureIgnoreCase));


                    // Ignore property csv column - Property not found on targeting type
                    if (p == null)
                    {
                        continue;
                    }

                    if (UseTextQualifier && value.Length > 0)
                    {
                        if (value.IndexOf("\"") == 0)
                            value = value.Substring(1);

                        if (value.Length > 0 && value[value.Length - 1].ToString() == "\"")
                            value = value.Substring(0, value.Length - 1);
                    }

                    var converter = TypeDescriptor.GetConverter(p.PropertyType);
                    var convertedvalue = converter.ConvertFrom(value);

                    p.SetValue(datum, convertedvalue);
                }

                data.Add(datum);
            }

            return data;
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="stream">stream</param>
        /// <param name="data">data</param>
        /// <summary>
        /// Serialize.
        /// </summary>
        public void Serialize(Stream stream, IList<T> data)
        {
            var sb = new StringBuilder();
            var values = new List<string>();

            sb.AppendLine(GetHeader());

            var row = 1;
            foreach (var item in data)
            {
                values.Clear();

                if (UseLineNumbers)
                {
                    values.Add(row++.ToString());
                }

                foreach (var p in _properties)
                {
                    var raw = p.GetValue(item);
                    var value = raw == null ? "" :
                        raw.ToString()
                        .Replace(Separator.ToString(), Replacement)
                        .Replace(Environment.NewLine, NewlineReplacement);

                    if (UseTextQualifier)
                    {
                        value = string.Format("\"{0}\"", value);
                    }

                    values.Add(value);
                }
                sb.AppendLine(string.Join(Separator.ToString(), values.ToArray()));
            }

            if (UseEofLiteral)
            {
                values.Clear();

                if (UseLineNumbers)
                {
                    values.Add(row++.ToString());
                }

                values.Add("EOF");

                sb.AppendLine(string.Join(Separator.ToString(), values.ToArray()));
            }

            using (var sw = new StreamWriter(stream))
            {
                sw.Write(sb.ToString().Trim());
            }
        }

        /// <summary>
        /// Get Header
        /// </summary>
        /// <returns></returns>
        private string GetHeader()
        {
            var header = _properties.Select(a => a.Name);

            if (UseLineNumbers)
            {
                header = new string[] { RowNumberColumnTitle }.Union(header);
            }

            return string.Join(Separator.ToString(), header.ToArray());
        }
    }

    public class CsvIgnoreAttribute : Attribute { }

    public class InvalidCsvFormatException : Exception
    {
        /// <summary>
        /// Invalid Csv Format Exception
        /// </summary>
        /// <param name="message">message</param>
        public InvalidCsvFormatException(string message)
            : base(message)
        {
        }

        public InvalidCsvFormatException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
