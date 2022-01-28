using System;
using System.Collections;
using UnityEngine;
using wox.serial;
using Object = System.Object;

/**
 * This class provides an example of a class with some primitive
 * fields, and an array of Course objects. The main method uses the
 * Easy class to serialize a Student object to XML (save method);
 * and to de-serialize the XML to a Student object back again (load method).
 * http://woxserializer.sourceforge.net/
 *
 * Authors: Carlos R. Jaimez Gonzalez
 *          Simon M. Lucas
 * Version: Student.cs - 1.0
 */
public class Student
{
    private String name;
    private Int32 registrationNumber;
    private Course[] courses;
    private Hashtable mapCourse = new Hashtable();
   
    public Student()
    {
    }

    public Student(String name, Int32 registrationNumber, Course[] courses, Hashtable map)
    {
        this.name = name;
        this.registrationNumber = registrationNumber;
        this.courses = courses;
        this.mapCourse = map;
    }

    public override string ToString()
    {
        return "name: " + name + ", registrationNumber, " + registrationNumber +
               ", courses: \n" + printArray(courses);
    }


    public String printArray(Object[] ob)
    {
        String coursesStr = "";
        if (courses == null) {
            return coursesStr;
        } else {
            for (int i = 0; i < ob.Length; i++) {
                coursesStr = coursesStr + ob[i] + "\n";
            }
            return coursesStr;
        }
    }

    /**
     * This method shows how easy is to serialize and de-serialize C# objects
     * to/from XML. The XML representation of the objects is a standard WOX represntation.
     * For more information about the XML representation please visit:
     * http://woxserializer.sourceforge.net/
     */
    public static void testStudent()
    {
        Course[] courses = {new Course(6756, "XML and Related Technologies", 2),
                            new Course(9865, "Object Oriented Programming", 2),
                            new Course(1134, "E-Commerce Programming", 3)};

        Hashtable map = new Hashtable();
        map.Add(6756, new Course(6756, "XML and Related Technologies", 3));
        map.Add(9865, new Course(9865, "Object Oriented Programming", 2));
        map.Add(1134, new Course(1134, "E-Commerce Programming", 2));
        map.Add(4598, new Course(4598, "Enterprise Component Architecture", 3));

        Student student = new Student("Carlos Jaimez", 76453, courses, map);

        String filename = "TestStudent2.xml";
        //print the Student object
        Console.Out.WriteLine(student);
        //object to standard XML
        WoxSerializer.save(student, filename);
        //get the object back from the XML file
        string objectFromString = "<object type=\"Student2\" dotnettype=\"Student2, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"0\"><field name=\"name\" type=\"string\" value=\"Carlos Jaimez\" /><field name=\"registrationNumber\" type=\"int\" value=\"76453\" /><field name=\"courses\"><object type=\"array\" elementType=\"Course\" length=\"3\" id=\"1\"><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"2\"><field name=\"code\" type=\"int\" value=\"6756\" /><field name=\"name\" type=\"string\" value=\"XML and Related Technologies\" /><field name=\"term\" type=\"int\" value=\"2\" /></object><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"3\"><field name=\"code\" type=\"int\" value=\"9865\" /><field name=\"name\" type=\"string\" value=\"Object Oriented Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"4\"><field name=\"code\" type=\"int\" value=\"1134\" /><field name=\"name\" type=\"string\" value=\"E-Commerce Programming\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object></field><field name=\"mapCourse\"><object type=\"map\" id=\"5\"><object type=\"entry\"><object type=\"int\" value=\"4598\" id=\"6\" /><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"7\"><field name=\"code\" type=\"int\" value=\"4598\" /><field name=\"name\" type=\"string\" value=\"Enterprise Component Architecture\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"9865\" id=\"8\" /><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"9\"><field name=\"code\" type=\"int\" value=\"9865\" /><field name=\"name\" type=\"string\" value=\"Object Oriented Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"6756\" id=\"10\" /><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"11\"><field name=\"code\" type=\"int\" value=\"6756\" /><field name=\"name\" type=\"string\" value=\"XML and Related Technologies\" /><field name=\"term\" type=\"int\" value=\"3\" /></object></object><object type=\"entry\"><object type=\"int\" value=\"1134\" id=\"12\" /><object type=\"Course\" dotnettype=\"Course, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\" id=\"13\"><field name=\"code\" type=\"int\" value=\"1134\" /><field name=\"name\" type=\"string\" value=\"E-Commerce Programming\" /><field name=\"term\" type=\"int\" value=\"2\" /></object></object></object></field></object>";

        Student newStudent = (Student)WoxSerializer.load(filename);

        Debug.Log("------ load done... -----");

        Student newStudent2 = (Student)WoxSerializer.deserializeFromString(objectFromString);
        //print the new object - it is the same as before
        Console.Out.WriteLine(newStudent2);

        Debug.Log("------ Deserialization done... -----");
    }

    public static Student deserializeFromString(string content)
    {
        Debug.Log("------ Deserialization begin ... -----");
        Student st = (Student)WoxSerializer.deserializeFromString(content);
        Debug.Log("------ Deserialization done. -----");

        return st;
    }


    public string printStudent()
	{
        string textToPrint = "";
        textToPrint+=" \n ------- Printing the Student info -------";
        textToPrint += " \n  Name : " + name;
        textToPrint += " \n  registrationNumber : " + registrationNumber;
        foreach(Course course in courses) {
            textToPrint += " \n      Course from array: " + course.ToString();
        }
        foreach(DictionaryEntry course in mapCourse) {
            textToPrint += " \n      Course from map : key= " + course.Key + " value= "+ course.Value + " The course : " + course.ToString();
        }

        return textToPrint;
    }


    public static void serializeToFile(string filename)
    {
        Course[] courses = {new Course(6756, "XML and Related Technologies", 2),
                            new Course(9865, "Object Oriented Programming", 2),
                            new Course(1134, "E-Commerce Programming", 3)};

        Hashtable map = new Hashtable();
        map.Add(6756, new Course(6756, "XML and Related Technologies", 3));
        map.Add(9865, new Course(9865, "Object Oriented Programming", 2));
        map.Add(1134, new Course(1134, "E-Commerce Programming", 2));
        map.Add(4598, new Course(4598, "Enterprise Component Architecture", 3));

        Student student = new Student("Carlos Jaimez", 76453, courses, map);

        //object to standard XML
        WoxSerializer.save(student, filename);
        
        Debug.Log("------ Deserialization done... -----");
    }

    public static Student getNewStudent()
    {
        Course[] courses = {new Course(6756, "XML and Related Technologies", 2),
                            new Course(9865, "Object Oriented Programming", 2),
                            new Course(1134, "E-Commerce Programming", 3)};

        Hashtable map = new Hashtable();
        map.Add(6756, new Course(6756, "XML and Related Technologies", 3));
        map.Add(9865, new Course(9865, "Object Oriented Programming", 2));
        map.Add(1134, new Course(1134, "E-Commerce Programming", 2));
        map.Add(4598, new Course(4598, "Enterprise Component Architecture", 3));

        Student student = new Student("Carlos Jaimez", 76453, courses, map);

        return student;
    }

}

