using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlProvider
{
    public static class XmlExtension
    {
        
        private static readonly Dictionary<RuntimeTypeHandle, XmlSerializer> ms_serializers = new Dictionary<RuntimeTypeHandle, XmlSerializer>();
 
        public static string ToXml<T>(this T value)
            where T : new()
        {
            var _serializer = GetValue(typeof(T));
            using (var _stream = new MemoryStream())
            {
                using (var _writer = new XmlTextWriter(_stream, new UTF8Encoding()))
                {
                    _serializer.Serialize(_writer, value);
                    return Encoding.UTF8.GetString(_stream.ToArray());
                }
            }
        }

        public static T DeserializeXML<T>(this string value) 
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(value))
                return (T)ser.Deserialize(sr);
        }

        public static void ToXml<T>(this T value, Stream stream)
            where T : new()
        {
            var _serializer = GetValue(typeof(T));
            _serializer.Serialize(stream, value);
        }

        public static T FromXml<T>(this string srcString)
            where T : new()
        {
            var _serializer = GetValue(typeof(T));
            using (var _stringReader = new StringReader(srcString))
            {
                using (XmlReader _reader = new XmlTextReader(_stringReader))
                {
                    return (T)_serializer.Deserialize(_reader);
                }
            }
        }
 
        public static T FromXml<T>(this Stream source)
            where T : new()
        {
            var _serializer = GetValue(typeof(T));
            return (T)_serializer.Deserialize(source);
        }
 
        private static XmlSerializer GetValue(Type type)
        {
            XmlSerializer _serializer;
            if (!ms_serializers.TryGetValue(type.TypeHandle, out _serializer))
            {
                lock (ms_serializers)
                {
                    if (!ms_serializers.TryGetValue(type.TypeHandle, out _serializer))
                    {
                        _serializer = new XmlSerializer(type);
                        ms_serializers.Add(type.TypeHandle, _serializer);
                    }
                }
            }
            return _serializer;
        }
 
    }
}
