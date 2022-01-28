using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AssemblyCSharp.Assets.GamaSceneManagingScript.Utils.Serializer
{
    [XmlRoot("Languages")]
    public class DictionarySerializable<TKey, TValue> : Dictionary<string, string>, IXmlSerializable
    {
        public XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement) { return; }

            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement) {
                object key = reader.GetAttribute("Title");
                object value = reader.GetAttribute("Value");
                this.Add((string)key, (string)value);
                reader.Read();
            }
        }

		

		public void WriteXml(XmlWriter writer)
        {
            foreach (var key in this.Keys) {
                writer.WriteStartElement("Language");
                writer.WriteAttributeString("Title", key.ToString());
                writer.WriteAttributeString("Value", this[key].ToString());
                writer.WriteEndElement();
            }
        }

		
		XmlSchema IXmlSerializable.GetSchema()
		{
			throw new NotImplementedException();
		}
	}
}
