using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wox.serial;

public class Wox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
           
          
        
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 480, 200, 20), "Load object from xml file ")) {

            //Student.serializeToFile("student.xml");
            //studentUnityUnity();
            //studentGamaUnity();
            studentUnityGama();
        }
    }

    public void studentUnityUnity()
	{
        Debug.Log(" ---- Deserialization from string begin ---- ");

        string objectFromString = "<object type=\"Student\" dotnettype=\"Student, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"0\"><field name=\"name\" type=\"string\" value=\"Carlos Jaimez\" /><field name=\"registrationNumber\" type=\"int\" value=\"76453\" /><field name=\"courses\"><object type=\"array\" elementType=\"Course\" length=\"3\" id=\"1\"><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"2\"><field name=\"code\" type=\"int\" value=\"6756\" /><field name=\"name\" type=\"string\" value=\"XML and Related Technologies\" /><field name=\"term\" type=\"int\" value=\"2\" /></object><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"3\"><field name=\"code\" type=\"int\" value=\"9865\" /><field name=\"name\" type=\"string\" value=\"Object Oriented Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"4\"><field name=\"code\" type=\"int\" value=\"1134\" /><field name=\"name\" type=\"string\" value=\"E-Commerce Programming\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object></field><field name=\"mapCourse\"><object type=\"map\" id=\"5\"><object type=\"entry\"><object type=\"int\" value=\"4598\" id=\"6\" /><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"7\"><field name=\"code\" type=\"int\" value=\"4598\" /><field name=\"name\" type=\"string\" value=\"Enterprise Component Architecture\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"9865\" id=\"8\" /><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"9\"><field name=\"code\" type=\"int\" value=\"9865\" /><field name=\"name\" type=\"string\" value=\"Object Oriented Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"6756\" id=\"10\" /><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"11\"><field name=\"code\" type=\"int\" value=\"6756\" /><field name=\"name\" type=\"string\" value=\"XML and Related Technologies\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"1134\" id=\"12\" /><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"13\"><field name=\"code\" type=\"int\" value=\"1134\" /><field name=\"name\" type=\"string\" value=\"E-Commerce Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object></object></object></field></object>";
        objectFromString = objectFromString.Replace("E-Commerce", "XXXXXXXXXXXXXXXXXX");
        Student st = Student.deserializeFromString(objectFromString);
        Debug.Log("--> Result is : " + st.printStudent());

        Debug.Log(" ---- Deserialization from string is done ---- ");

    }

    public void studentUnityGama()
    {
        //Student.serializeToFile("student.xml");
        Student st = Student.getNewStudent();
        string serializedObject = WoxSerializer.serializeObject(st);
        Debug.Log(" The new Student is " + WoxSerializer.serializeObject(st));
        ummisco.gama.unity.Scene.GamaManager.connector.Publish("serialization", serializedObject);
    }

    public void studentGamaUnity()
    {

        Debug.Log(" ---- Deserialization from java string begin ---- ");

        string studentContent = "<object type=\"data.Student\" id=\"0\"><field name=\"name\" type=\"string\" value=\"Carlos Jaimez\" /><field name=\"registrationNumber\" type=\"int\" value=\"76453\" /><field name=\"courses\"><object type=\"array\" elementType=\"data.Course\" length=\"3\" id=\"1\"><object type=\"data.Course\" id=\"2\"><field name=\"code\" type=\"int\" value=\"6756\" /><field name=\"name\" type=\"string\" value=\"XML and Related Technologies\" /><field name=\"term\" type=\"int\" value=\"2\" /></object><object type=\"data.Course\" id=\"3\"><field name=\"code\" type=\"int\" value=\"9865\" /><field name=\"name\" type=\"string\" value=\"Object Oriented Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object><object type=\"data.Course\" id=\"4\"><field name=\"code\" type=\"int\" value=\"1134\" /><field name=\"name\" type=\"string\" value=\"E-Commerce Programming\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object></field><field name=\"mapCourse\"><object type=\"map\" id=\"5\"><object type=\"entry\"><object type=\"int\" value=\"6756\" id=\"6\" /><object type=\"data.Course\" id=\"7\"><field name=\"code\" type=\"int\" value=\"6756\" /><field name=\"name\" type=\"string\" value=\"XML and Related Technologies\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"4598\" id=\"8\" /><object type=\"data.Course\" id=\"9\"><field name=\"code\" type=\"int\" value=\"4598\" /><field name=\"name\" type=\"string\" value=\"Enterprise Component Architecture\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"9865\" id=\"10\" /><object type=\"data.Course\" id=\"11\"><field name=\"code\" type=\"int\" value=\"9865\" /><field name=\"name\" type=\"string\" value=\"Object Oriented Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"1134\" id=\"12\" /><object type=\"data.Course\" id=\"13\"><field name=\"code\" type=\"int\" value=\"1134\" /><field name=\"name\" type=\"string\" value=\"E-Commerce Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object></object></object></field></object>";
        studentContent = studentContent.Replace("\"data.Student\"", "\"Student\"");
        studentContent = studentContent.Replace("\"data.Course\"", "\"Course\"");
        Student st = Student.deserializeFromString(studentContent);
        Debug.Log("--> Result is : " + st.printStudent());
        Debug.Log(" ---- Deserialization from string is done ---- ");


    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
