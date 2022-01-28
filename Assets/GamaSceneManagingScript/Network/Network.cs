using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AssemblyCSharp.Assets.GamaSceneManagingScript.Utils.Serializer;
using ummisco.gama.unity.messages;
using ummisco.gama.unity.Scene;
using UnityEngine;

public class Network : MonoBehaviour
{
    public int intVar = 0;

    [SerializeField]
    public void setIntVar(int value)
    {
        intVar = value;
        string msg = GamaListenReplay.BuildToListenReplay("intVar", intVar);
        //GamaManager.connector.Publish("receiver", msg);

        //GamaManager.connector.Publish("receiver", SerializeDictionary());

        GamaManager.connector.Publish("receiver", MsgSerialization.SerializationPlainXml(SerializeDictionary()));

        //SerializeDictionary2();


        /*
        string txtToPublish = MsgSerialization.SerializationPlainXml2(SerializeDictionary());
        txtToPublish = texte;
        Debug.Log(" 1 --> " + txtToPublish);
        int stringSize = txtToPublish.Length;

        //txtToPublish = txtToPublish.Substring(30, stringSize - 39);
        //txtToPublish = texte;
        Debug.Log(" 2 --> " + txtToPublish);
        // <? xml version = "1.0" ?>
        // < string >
        GamaManager.connector.Publish("receiver", txtToPublish);
        //SerializeDictionary()
      */  
       //  TestSerialization();
    }




    void TestSerialization()
	{
        IDictionary Dic = new Dictionary<string, string>();
        Dic.Add("REQUEST", "Add cell");
        Dic.Add("name", "MyName");
        Dic.Add("age", "12");
        Dic.Add("attribute2", "Value 2");


        GamaReponseMessage msg = new GamaReponseMessage("sender11", "receivers12", "Content15243", "emissionTimeStamp");
        // string txtToPublish = ToXmlString(msg);
        string txtToPublish = "sender" +
            "receiver" +
            "";



        txtToPublish += MsgSerialization.ToXML(msg);
   
        Debug.Log(" 1 --> " + txtToPublish);
     
        /*
        // -------------
        // Create two different encodings.
        Encoding ascii = Encoding.ASCII;
        Encoding unicode = Encoding.Unicode;
        Encoding utf8code = Encoding.UTF8;

        byte[] asciiBytes = Encoding.ASCII.GetBytes(txtToPublish);

        byte[] newMsg = Encoding.Convert(utf8code, ascii, asciiBytes);

        char[] asciiChars = Encoding.ASCII.GetChars(newMsg);
        string asciiString = new string(asciiChars);
        // -------------
        */

        GamaManager.connector.Publish("receiver", txtToPublish);
    }

    [SerializeField]
    public string stringVar {
        get { return m_stringVar; }
        set {
            m_stringVar = value;
            string msg = GamaListenReplay.BuildToListenReplay("stringVar", stringVar);
            GamaManager.connector.Publish("setexp", msg);
        }
    }

    [SerializeField]
    public float floatVar {
        get { return m_floatVar; }
        set {
            m_floatVar = value;
            string msg = GamaListenReplay.BuildToListenReplay("floatVar", floatVar);
            GamaManager.connector.Publish("setexp", msg);
        }
    }

    [SerializeField]
    public bool boolVar {
        get { return m_boolVar; }
        set {
            m_boolVar = value;
            string msg = GamaListenReplay.BuildToListenReplay("boolVar", boolVar);
            GamaManager.connector.Publish("setexp", msg);
        }
    }


    public string m_stringVar = "";
    public float m_floatVar = 0.0f;
    public bool m_boolVar = false;



    void Start()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 380, 250, 20), "Send Network message")) {
            setIntVar(intVar += 2);
        }
    }

    void Update()
    {
    }



    XmlDocument SerializeDictionary()
    {
        Debug.Log("-- -- Hellow World from TestCode -- --");

        IDictionary Dic = new Dictionary<string, string>();
        Dic.Add("REQUEST", "Add cell");
        Dic.Add("name", "MyName");
        Dic.Add("age", "12");
        Dic.Add("attribute2", "Value 2");


        XmlDocument doc = new XmlDocument();

        // <ummisco.gama.network.common.CompositeGamaMessage>
        XmlNode gamaMsg = doc.CreateElement("ummisco.gama.network.common.CompositeGamaMessage");
        doc.AppendChild(gamaMsg);

        //  <unread>true</unread>
        XmlNode unread = doc.CreateElement("unread");
        XmlNode unreadValue = doc.CreateTextNode("true");
        unread.AppendChild(unreadValue);
        gamaMsg.AppendChild(unread);

        // <sender class="string">sender</sender>
        XmlNode sender = doc.CreateElement("sender");
        XmlAttribute senderStringAttribute = doc.CreateAttribute("class");
        senderStringAttribute.Value = "string";
        sender.Attributes.SetNamedItem(senderStringAttribute);
        XmlNode senderValue = doc.CreateTextNode("sender");
        sender.AppendChild(senderValue);
        gamaMsg.AppendChild(sender);

        // <receivers class="string">receiver</receivers>
        XmlNode receivers = doc.CreateElement("receivers");
        XmlAttribute receiversStringAttribute = doc.CreateAttribute("class");
        receiversStringAttribute.Value = "string";
        receivers.Attributes.SetNamedItem(receiversStringAttribute);
        XmlNode receiversValue = doc.CreateTextNode("receiver");
        receivers.AppendChild(receiversValue);
        gamaMsg.AppendChild(receivers);

        // <contents class="string"> ... </contents>
        XmlNode contents = doc.CreateElement("contents");
        XmlAttribute contentsAttribute = doc.CreateAttribute("class");
        contentsAttribute.Value = "string";
        contents.Attributes.SetNamedItem(contentsAttribute);
        gamaMsg.AppendChild(contents);


        //  <msi.gama.util.GamaMap> ...  </msi.gama.util.GamaMap>
        XmlNode gamaMap = doc.CreateElement("msi.gama.util.GamaMap");
        contents.AppendChild(gamaMap);

        // <keysType class="msi.gaml.types.GamaStringType">
        //    < GamaType > string </ GamaType >
        // </ keysType >
        XmlNode keysType = doc.CreateElement("keysType");
        XmlAttribute keysTypeAttribute = doc.CreateAttribute("class");
        keysTypeAttribute.Value = "msi.gaml.types.GamaStringType";
        keysType.Attributes.SetNamedItem(keysTypeAttribute);
        XmlNode gamaType = doc.CreateElement("GamaType");
        XmlNode gamaTypeValue = doc.CreateTextNode("string");
        gamaType.AppendChild(gamaTypeValue);
        keysType.AppendChild(gamaType);
        gamaMap.AppendChild(keysType);

        //  <dataType class="msi.gaml.types.GamaStringType" reference="../keysType"/>
        XmlNode dataType = doc.CreateElement("dataType");
        XmlAttribute dataTypeClassAttribute = doc.CreateAttribute("class");
        dataTypeClassAttribute.Value = "msi.gaml.types.GamaStringType";
        dataType.Attributes.SetNamedItem(dataTypeClassAttribute);
        XmlAttribute dataTypeReferenceAttribute = doc.CreateAttribute("reference");
        dataTypeReferenceAttribute.Value = "../keysType";
        dataType.Attributes.SetNamedItem(dataTypeReferenceAttribute);
        gamaMap.AppendChild(dataType);

        //  <valuesMapReducer>  ...  </valuesMapReducer>
        XmlNode valuesMapReducer = doc.CreateElement("valuesMapReducer");
        gamaMap.AppendChild(valuesMapReducer);



        foreach (object key in Dic.Keys) {
            Debug.Log(" Dic Elt : Key> " + key + " value> " + Dic[key]);
            XmlNode entryNode = doc.CreateElement("entry");
            valuesMapReducer.AppendChild(entryNode);

            XmlNode stringNameNode = doc.CreateElement("string");
            entryNode.AppendChild(stringNameNode);
            XmlNode typeNode = doc.CreateTextNode("string");
            typeNode.Value = (string)key;
            stringNameNode.AppendChild(typeNode);


            XmlNode stringValueNode = doc.CreateElement("string");
            entryNode.AppendChild(stringValueNode);
            XmlNode valueNode = doc.CreateTextNode("string");
            valueNode.Value = (string)Dic[key];
            stringValueNode.AppendChild(valueNode);
        }

        //< emissionTimeStamp > 0 </ emissionTimeStamp >
        XmlNode emissionTimeStamp = doc.CreateElement("emissionTimeStamp");
        XmlNode emissionTimeStampValue = doc.CreateTextNode("0");
        emissionTimeStamp.AppendChild(emissionTimeStampValue);
        gamaMsg.AppendChild(emissionTimeStamp);

        Debug.Log(" le contenu XML from Doc est : " + doc.OuterXml);

        return doc;
    }
}

