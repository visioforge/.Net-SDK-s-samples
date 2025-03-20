// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlUtil.cs" company="VisioForge">
//   VisioForge (c) 2006 - 2015
// </copyright>
// <summary>
//   Helper class for work with XML.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageComparer
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public static class XmlUtility
    {
        /// <summary>
        /// Serialize object to string.
        /// </summary>
        /// <param name="obj">
        /// Object.
        /// </param>
        /// <param name="nameSpace">
        /// Namespace.
        /// </param>
        /// <returns>
        /// Returns string.
        /// </returns>
        public static string Obj2XmlStr(object obj, string nameSpace)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            XmlSerializer sr = SerializerCache.GetSerializer(obj.GetType()); 

            StringBuilder sb = new StringBuilder();
            StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture);

            // ReSharper disable RedundantExplicitArrayCreation
            sr.Serialize(
                w, 
                obj, 
                new XmlSerializerNamespaces(
                    new XmlQualifiedName[] 
                        {
                            new XmlQualifiedName(string.Empty, nameSpace)
                        }
                    ));
            // ReSharper restore RedundantExplicitArrayCreation

            return sb.ToString();
        }

        /// <summary>
        /// Serialize object to string.
        /// </summary>
        /// <param name="obj">
        /// Object.
        /// </param>
        /// <returns>
        /// Returns string.
        /// </returns>
        public static string Obj2XmlStr(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            XmlSerializer sr = SerializerCache.GetSerializer(obj.GetType()); 

            StringBuilder sb = new StringBuilder();
            StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture);

            // ReSharper disable RedundantExplicitArrayCreation
            sr.Serialize(
                w,
                obj,
                new XmlSerializerNamespaces(new XmlQualifiedName[] {new XmlQualifiedName(string.Empty)}));
            // ReSharper restore RedundantExplicitArrayCreation

            return sb.ToString();
        }

        /// <summary>
        /// Deserialize string to object.
        /// </summary>
        /// <typeparam name="T">
        /// Typeparam.
        /// </typeparam>
        /// <param name="xml">
        /// XML string.
        /// </param>
        /// <returns>
        /// Returns object.
        /// </returns>
        public static T XmlStr2Obj<T>(string xml)
        {
            if (xml == null)
            {
                return default(T);
            }

            if (string.IsNullOrEmpty(xml))
            {
                return (T) Activator.CreateInstance(typeof(T));
            }

            StringReader reader = new StringReader(xml);
            XmlSerializer sr = SerializerCache.GetSerializer(typeof(T));
            return (T)sr.Deserialize(reader);
        }
        
        /// <summary>
        /// Convert XML string to XmlElement.
        /// </summary>
        /// <param name="xml">XML.</param>
        /// <returns>Returns XmlElement.</returns>
        public static XmlElement XmlStr2XmlDom(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }

        /// <summary>
        /// Convert object to XmlElement.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <param name="namespace">Namespace.</param>
        /// <returns>Returns XmlElement.</returns>
        public static XmlElement Obj2XmlDom(object obj, string @namespace)
        {
            return XmlStr2XmlDom(Obj2XmlStr(obj, @namespace));
        }
    }

    /// <summary>
    /// Cache.
    /// </summary>
    internal static class SerializerCache
    {
        private static readonly Hashtable Hash = new Hashtable();
        public static XmlSerializer GetSerializer(Type type)
        {
            XmlSerializer res;
            lock (Hash)
            {
                res = Hash[type.FullName] as XmlSerializer;
                if (res == null)
                {
                    res = new XmlSerializer(type);
                    Hash[type.FullName] = res;
                }
            }

            return res;
        }
    }
}