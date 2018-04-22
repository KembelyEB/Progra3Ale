using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ExamenWEBSERVER
{
    public static class ParseHelpers
    {
        public static Stream ToStream(this string texto)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(texto);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static T ParseXML<T>(this string texto) where T : class
        {
            var reader = System.Xml.XmlReader.Create(texto.Trim().ToStream(),
                new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;


        }
    }
    }
