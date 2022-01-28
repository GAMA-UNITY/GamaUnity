using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AssemblyCSharp.Assets.GamaSceneManagingScript.Utils.Serializer;
using ummisco.gama.unity.messages;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Serialisation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Serialisation (){
        /*
        Debug.Log("-- -- Hellow World from TestCode -- --");

        IDictionary Dic = new Dictionary<string, string>();
        Dic.Add("Request", "Add cell");
        Dic.Add("name", "MyName");
        Dic.Add("age", "12");
        Dic.Add("attribute2", "Value 2");


        XmlDocument doc = new XmlDocument();
        //XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        //doc.AppendChild(docNode);

        XmlNode mapNode = doc.CreateElement("map");
        doc.AppendChild(mapNode);

        foreach (object key in Dic.Keys) {
            Debug.Log(" Dic Elt : Key> " + key + " value> " + Dic[key]);
            XmlNode entryNode = doc.CreateElement("entry");
            mapNode.AppendChild(entryNode);

            XmlNode stringNameNode = doc.CreateElement("String");
            entryNode.AppendChild(stringNameNode);
            XmlNode typeNode = doc.CreateTextNode("String");
            typeNode.Value = (string)key;
            stringNameNode.AppendChild(typeNode);


            XmlNode stringValueNode = doc.CreateElement("String");
            entryNode.AppendChild(stringValueNode);
            XmlNode valueNode = doc.CreateTextNode("String");
            valueNode.Value = (string)Dic[key];
            stringValueNode.AppendChild(valueNode);
        }

        string xmlContent;

        using (var stringWriter = new StringWriter())
        using (var xmlTextWriter = XmlWriter.Create(stringWriter)) {
            doc.WriteTo(xmlTextWriter);
            xmlTextWriter.Flush();
            xmlContent = stringWriter.GetStringBuilder().ToString();
        }
        xmlContent = doc.OuterXml;
        Debug.Log(" le contenu XML est: " + xmlContent);

        */

        Debug.Log("-- -- End -- --");
    }


}
