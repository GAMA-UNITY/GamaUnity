using System.IO;
using System.Xml;
using System.Xml.Linq;
using ummisco.gama.unity.messages;
using ummisco.gama.unity.Scene;
using UnityEngine;

public class ExposeVariables : MonoBehaviour
{
    /*
    [SerializeField]
    public int intVar {
        get { return m_intVar; }
        set {
            m_intVar = value;
            string msg = GamaListenReplay.BuildToListenReplay("intVar", intVar);
            GamaManager.connector.Publish("setexp", msg);
        }
    }
    public int m_intVar = 0;
    */
    public int intVar = 0;

    [SerializeField]
    public void setIntVar(int value) {
        intVar = value;
        string msg = GamaListenReplay.BuildToListenReplay("intVar", intVar);
        GamaManager.connector.Publish("setexp", msg);
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
        if (GUI.Button(new Rect(50, 350, 250, 20), "Send From ExposeVariables script")) {
            setIntVar(intVar += 2);
        }
    }

    void Update()
    {       
    }
}