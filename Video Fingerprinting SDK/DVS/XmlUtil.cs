namespace VisioForge_MMT.Classes
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Helper class for XML serialization utilities.
    /// </summary>
    public class XmlUtility
    {
        /// <summary>
        /// Serializes an object to an XML string with a specified namespace.
        /// </summary>
        public static string Obj2XmlStr(object obj, string nameSpace)
        {
            if (obj == null) return string.Empty;
            XmlSerializer sr = SerializerCache.GetSerializer(obj.GetType());

            StringBuilder sb = new StringBuilder();
            using (StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture))
            {
                sr.Serialize(
                    w,
                    obj,
                    new XmlSerializerNamespaces(
                        new XmlQualifiedName[]
                            {
                                new XmlQualifiedName("", nameSpace)
                            }
                        ));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Serializes an object to an XML string.
        /// </summary>
        public static string Obj2XmlStr(object obj)
        {
            if (obj == null) return string.Empty;
            XmlSerializer sr = SerializerCache.GetSerializer(obj.GetType());

            StringBuilder sb = new StringBuilder();
            using (StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture))
            {
                sr.Serialize(
                    w,
                    obj,
                    new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty) }));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Deserializes an XML string to an object of type T.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="xml">The XML string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T XmlStr2Obj<T>(string xml)
        {
            if (xml == null) return default(T);
            if (xml == string.Empty) return (T)Activator.CreateInstance(typeof(T));

            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer sr = SerializerCache.GetSerializer(typeof(T));
                return (T)sr.Deserialize(reader);
            }
        }
		
        /// <summary>
        /// Converts an XML string to an XmlElement.
        /// </summary>
        /// <param name="xml">The XML string to convert.</param>
        /// <returns>The root XmlElement of the parsed XML.</returns>
        public static XmlElement XmlStr2XmlDom(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null; // Prevent XXE attacks
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }

        /// <summary>
        /// Serializes an object to an XmlElement with a specified namespace.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="nameSpace">The XML namespace.</param>
        /// <returns>The serialized XmlElement.</returns>
        public static XmlElement Obj2XmlDom(object obj, string nameSpace)
        {
            return XmlStr2XmlDom(Obj2XmlStr(obj, nameSpace));
        }

		
		
    }

    /// <summary>
    /// Cache for XmlSerializer instances to improve performance.
    /// </summary>
    internal class SerializerCache
    {
        private static readonly Hashtable Hash = new Hashtable();
        /// <summary>
        /// Get serializer.
        /// </summary>
        public static XmlSerializer GetSerializer(Type type)
        {
            XmlSerializer res;
            lock(Hash)
            {
                res = Hash[type.FullName] as XmlSerializer;
                if(res == null) 
                {
                    res = new XmlSerializer(type);
                    Hash[type.FullName] = res;
                }
            }
            return res;
        }
    }
}