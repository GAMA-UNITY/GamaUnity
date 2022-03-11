using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using System.Text;
using wox.serial;
using System.Reflection;
using UnityEngine;
using Object = System.Object;


/**
 * The Easy class is used to serialize/de-serialize objects to/from XML.
 * It has two static methods. The save method serializes an object to XML
 * and stores it in an XML file; and the load method de-serializes an object
 * from an XML file.
 *
 * Authors: Carlos R. Jaimez Gonzalez
 *          Simon M. Lucas
 * Version: Easy.cs - 1.0
 */
namespace wox.serial
{
    public class WoxSerializer
    {

        public static void save(Object ob, String filename)
        {
            //this creates an XML writer, which will be used to serialize an object to XML
            XmlTextWriter writer = new XmlTextWriter(filename, null);
            //this creates the WOX writer
            ObjectWriter woxWriter = new SimpleWriter();
            //writes the object to XML
            woxWriter.write(ob, writer);
            writer.Close();
            Console.Out.WriteLine("Saved object to " + filename);                      
        }

        public static Object load(String filename)
        {
            //this creates an XML reader, which will be used to de-serialize the object
            XmlTextReader xmlReader = new XmlTextReader(filename);
            //this creates the WOX reader
            ObjectReader woxReader = new SimpleReader();
            //Read the next node from the Stream. In this case it will be the Root Element
            xmlReader.Read();
            //reads the object from the XML file. We pass the xmlReader positioned in the first node!
            Object ob = woxReader.read(xmlReader);
            xmlReader.Close();
            return ob;
        }


        public static Object loadFromString(String content)
        {
            XmlTextReader xmlReader = new XmlTextReader(new System.IO.StringReader(content));
          
            //this creates the WOX reader
            ObjectReader woxReader = new SimpleReader();
            //Read the next node from the Stream. In this case it will be the Root Element
            xmlReader.Read();
            //reads the object from the XML file. We pass the xmlReader positioned in the first node!
            Object ob = woxReader.read(xmlReader);
            xmlReader.Close();
            return ob;
        }

        public static Object deserialize(String content)
        {
            Debug.Log("Load object from " + content);
            content = content.Replace("data.AgentClass", "AgentClass");
            Debug.Log("New content is " + content);

            //this creates an XML reader, which will be used to de-serialize the object
            //XmlTextReader xmlReader2 = new XmlTextReader(new System.IO.StringReader(content));
            XmlReader xmlReader2 = XmlReader.Create(new StringReader(content));

            while (xmlReader2.Read()) {
                    if (xmlReader2.HasAttributes) {
                    try {
                        string elType = xmlReader2.GetAttribute(Serial.TYPE);

                        string id = xmlReader2.GetAttribute("id");
                        string type = xmlReader2.GetAttribute("type");
                        string elementXml = xmlReader2.ReadOuterXml();
                        Debug.Log(" ID : " + id + " Type : " + type + " elementXml : " + elementXml);

                    } catch {

                    }
                   
                }
            }


            XmlReader xmlReader = XmlReader.Create(new StringReader(content));
            //reader.Read();
            //string inner = reader.ReadInnerXml();


            //XmlTextReader xmlReader = new XmlTextReader(content);
            //this creates the WOX reader
            ObjectReader woxReader = new SimpleReader();
            //Read the next node from the Stream. In this case it will be the Root Element
            xmlReader.Read();
            //reads the object from the XML file. We pass the xmlReader positioned in the first node!
            Object ob = woxReader.read(xmlReader);
            xmlReader.Close();
            Console.Out.WriteLine("Load object from " + content);
            return ob;
        }

		public static string serializeObject(Object st)
		{
            //string serializedObject = "";
            StringBuilder builder = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter(builder)) {
                using (XmlTextWriter writer = new XmlTextWriter(stringWriter)) {
                    ObjectWriter woxWriter = new SimpleWriter();
                    //writes the object to XML
                    woxWriter.write(st, writer);
                }
            }
            if(builder.ToString()!= null)
                return builder.ToString();
            else
                return "";           
        }

		public static Object deserializeFromString(String content)
        {
            content = content.Replace("\"data.Student\"", "\"Student\"");
            content = content.Replace("\"data.Course\"", "\"Course\"");

            //this creates an XML reader, which will be used to de-serialize the object
            //XmlTextReader xmlReader2 = new XmlTextReader(new System.IO.StringReader(content));
            //XmlReader xmlReader2 = XmlReader.Create(new StringReader(content));

            XmlReader xmlReader = XmlReader.Create(new StringReader(content));
            //reader.Read();
            //string inner = reader.ReadInnerXml();


            //XmlTextReader xmlReader = new XmlTextReader(content);
            //this creates the WOX reader
            ObjectReader woxReader = new SimpleReader();
            //Read the next node from the Stream. In this case it will be the Root Element
            xmlReader.Read();
            //reads the object from the XML file. We pass the xmlReader positioned in the first node!
            Object ob = woxReader.read(xmlReader);
            xmlReader.Close();
            //Console.Out.WriteLine("Load object from " + content);
            return ob;
        }

        public static Object deserializeFromJavaString(String content, String javaClassPath, String unityClassPath)
        {
            content = content.Replace("\"data.Student\"", "\"Student\" dotnettype=\"Student, Assembly-CSharp, Version = 0.0.0.0, Culture = neutral, PublicKeyToken = null\"  ");
            content = content.Replace("\"data.Course\"", "\"Course\" dotnettype=\"Course, Assembly-CSharp, Version = 0.0.0.0, Culture = neutral, PublicKeyToken = null\" ");

            //content = content.Replace("\"ummisco.gama.unity.client.messages.UICreateMessage\"", "\"MaterialUI.UICreateMessage\" dotnettype=\"MaterialUI.UICreateMessage, Assembly-CSharp, Version = 0.0.0.0, Culture = neutral, PublicKeyToken = null\" ");

            content = content.Replace(javaClassPath, unityClassPath);

            //this creates an XML reader, which will be used to de-serialize the object
            //XmlTextReader xmlReader2 = new XmlTextReader(new System.IO.StringReader(content));
            //XmlReader xmlReader2 = XmlReader.Create(new StringReader(content));

            XmlReader xmlReader = XmlReader.Create(new StringReader(content));
            //reader.Read();
            //string inner = reader.ReadInnerXml();

            //XmlTextReader xmlReader = new XmlTextReader(content);
            //this creates the WOX reader
            ObjectReader woxReader = new SimpleReader();
            //Read the next node from the Stream. In this case it will be the Root Element
            xmlReader.Read();
            //reads the object from the XML file. We pass the xmlReader positioned in the first node!
            Object ob = woxReader.read(xmlReader);
            xmlReader.Close();
            //Console.Out.WriteLine("Load object from " + content);
            return ob;
        }


        public static Object deserializeFromJavaString(String content)
        {
            content = content.Replace("\"data.Student\"", "\"Student\" dotnettype=\"Student, Assembly-CSharp, Version = 0.0.0.0, Culture = neutral, PublicKeyToken = null\"  ");
            content = content.Replace("\"data.Course\"", "\"Course\" dotnettype=\"Course, Assembly-CSharp, Version = 0.0.0.0, Culture = neutral, PublicKeyToken = null\" ");

            
            //this creates an XML reader, which will be used to de-serialize the object
            //XmlTextReader xmlReader2 = new XmlTextReader(new System.IO.StringReader(content));
            //XmlReader xmlReader2 = XmlReader.Create(new StringReader(content));

            XmlReader xmlReader = XmlReader.Create(new StringReader(content));
            //reader.Read();
            //string inner = reader.ReadInnerXml();

            //XmlTextReader xmlReader = new XmlTextReader(content);
            //this creates the WOX reader
            ObjectReader woxReader = new SimpleReader();
            //Read the next node from the Stream. In this case it will be the Root Element
            xmlReader.Read();
            //reads the object from the XML file. We pass the xmlReader positioned in the first node!
            Object ob = woxReader.read(xmlReader);
            xmlReader.Close();
            //Console.Out.WriteLine("Load object from " + content);
            return ob;
        }

    }

    

}
