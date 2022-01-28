using System.Collections;
using System.Collections.Generic;
using ummisco.gama.unity.messages;
using ummisco.gama.unity.Network;
using ummisco.gama.unity.Scene;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt.Messages;
//using UnityEngine.UIElements;


public class SliderControl : MonoBehaviour
{
    public int curseur_value = 0;
    public string curseur_name = "curseur_";
    public string curseur_topic = "topic_curseur_";

    int n;
    public Text myText;
    public Slider mySlider;
   

    void Start()
    {
        
    }
       
    void Update()
    {
        if(curseur_value != mySlider.value) {
            setCurseurValue((int) mySlider.value);
        }
    }
     

    [SerializeField]
    public void setCurseurValue(int value)
    {
        curseur_value = value;
        myText.text = "Current Value : " + curseur_value;
        string msg = GamaListenReplay.BuildToListenReplay(curseur_name, curseur_value);
        GamaManager.connector.Publish(curseur_topic, msg);
        
        Debug.Log(" Message sent! on topic " + curseur_topic);
    }

    public MQTTConnector CreateConnector(string serverUrl, int serverPort, string userId, string password)
    {
        MQTTConnector connection = GameObject.Find(IMQTTConnector.MQTT_CONNECTOR).GetComponent<MQTTConnector>();
        connection.Connect(serverUrl, serverPort, userId, password);        
        return connection;
    }

}
