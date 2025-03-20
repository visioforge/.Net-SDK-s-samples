namespace VisioForge_MMT.Classes
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Helper класс для работы с XML
    /// </summary>
    public class XmlUtility
    {
        /// <summary>
        /// Сериализует объект в строку XML
        /// </summary>
        public static string Obj2XmlStr(object obj, string nameSpace)
        {
            if (obj == null) return string.Empty;
            XmlSerializer sr = SerializerCache.GetSerializer(obj.GetType()); 
			
            StringBuilder sb = new StringBuilder();
            StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture);
			
            sr.Serialize(
                w, 
                obj, 
                new XmlSerializerNamespaces(
                    new XmlQualifiedName[] 
                        {
                            new XmlQualifiedName("", nameSpace)
                        }
                    ));
            return sb.ToString();
        }

        /// <summary>
        /// Сериализует объект в строку XML
        /// </summary>
        public static string Obj2XmlStr(object obj)
        {
            if (obj == null) return string.Empty;
            XmlSerializer sr = SerializerCache.GetSerializer(obj.GetType()); 
			
            StringBuilder sb = new StringBuilder();
            StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture);
			
            sr.Serialize(
                w, 
                obj, 
                new XmlSerializerNamespaces( new XmlQualifiedName[] { new XmlQualifiedName(string.Empty) } ) );

            return sb.ToString();
        }

        /// <summary>
        /// Десериализует строку XML в объект заданного типа
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T XmlStr2Obj<T>(string xml) 
        {
            if (xml == null) return default(T);
            if (xml == string.Empty) return (T)Activator.CreateInstance(typeof(T));

            StringReader reader = new StringReader(xml);
            XmlSerializer sr = SerializerCache.GetSerializer(typeof(T));
            return (T)sr.Deserialize(reader);
        }
		
        /// <summary>
        /// Преобразует строку XML в XmlElement
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static  XmlElement XmlStr2XmlDom(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }

        /// <summary>
        /// Преобразует объект в XmlElement
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        public static  XmlElement Obj2XmlDom(object obj, string nameSpace)
        {
            return XmlStr2XmlDom(Obj2XmlStr(obj, nameSpace));
        }

		
		
    }

    /// <summary>
    /// Кэш для используемых сериалайзеров 
    /// </summary>
    internal class SerializerCache
    {
        private static readonly Hashtable Hash = new Hashtable();
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