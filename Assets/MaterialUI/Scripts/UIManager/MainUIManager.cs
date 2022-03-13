﻿using System.Collections.Generic;
using UnityEngine;
using ummisco.gama.unity.messages;
using ummisco.gama.unity.notification;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;
using System.Linq;
using ummisco.gama.unity.topics;

using ummisco.gama.unity.GamaAgent;
using ummisco.gama.unity.littosim;
using ummisco.gama.unity.Network;
using wox.serial;

namespace MaterialUI
{
    public class MainUIManager : MonoBehaviour
    {
        private static MainUIManager m_Instance;
        public static GameObject MainCamera;
        public static MainUIManager Instance { get { return m_Instance; } }

        [Space(5)]
        [Header("---- Main GameObjects ----")]

        public GameObject mainManager;
        public GameObject targetGameObject;
        public GameObject topicGameObject;
        private GameObject mainTopicManager;
        private GameObject agentCreator;


        [Space(5)]
        [Header("---- Material elements ----")]
        public Material matGreen;
        public Material matGreenLighter;
        public Material matBlue;
        public Material matBlueLighter;
        public Material matRed;
        public Material matRedLighter;
        public Material matYellow;
        public Material matYellowLighter;
        public Material matWhite;

        public Transform parentObjectTransform;

        [Space(5)]
        [Header("---- Local variables ----")]

        public string receivedMsg = "";
        public object[] obj;
        public static Dictionary<string, string> agentsTopicDic = new Dictionary<string, string>();
        public MQTTConnector connector;

        [Space(5)]
        [Header("---- GameObjects instances  ----")]

        public bool isColorTopic = true;
        public bool isPositionTopic = true;
        public bool isSetTopic = true;
        public bool isGetTopic = true;
        public bool isMonoFreeTopic = true;
        public bool isMultiFreeTopic = true;
        public bool isCreateTopic = true;
        public bool isDestroyTopic = true;
        public bool isMoveTopic = true;
        public bool isNotificationTopic = true;
        public bool isPropertyTopic = true;
        public bool isMainTopic = true;
        void Awake()
        {
            m_Instance = this;
            if (m_Instance == null)
                m_Instance = this;
            else if (m_Instance != this)
                Destroy(gameObject);

            mainManager = gameObject;
            MainCamera = GameObject.Find("MainCamera");

            // Create the Topic's manager GameObjects
            new GameObject(IMQTTConnector.COLOR_TOPIC_MANAGER).AddComponent<SerializeTopic>();
            if (isColorTopic) new GameObject(IMQTTConnector.COLOR_TOPIC_MANAGER).AddComponent<ColorTopic>();
            if (isPositionTopic) new GameObject(IMQTTConnector.POSITION_TOPIC_MANAGER).AddComponent<PositionTopic>();
            if (isSetTopic) new GameObject(IMQTTConnector.SET_TOPIC_MANAGER).AddComponent<SetTopic>();
            if (isGetTopic) new GameObject(IMQTTConnector.GET_TOPIC_MANAGER).AddComponent<GetTopic>();
            if (isMonoFreeTopic) new GameObject(IMQTTConnector.MONO_FREE_TOPIC_MANAGER).AddComponent<MonoFreeTopic>();
            if (isMultiFreeTopic) new GameObject(IMQTTConnector.MULTIPLE_FREE_TOPIC_MANAGER).AddComponent<MultipleFreeTopic>();
            if (isCreateTopic) new GameObject(IMQTTConnector.CREATE_TOPIC_MANAGER).AddComponent<CreateTopic>();
            if (isDestroyTopic) new GameObject(IMQTTConnector.DESTROY_TOPIC_MANAGER).AddComponent<DestroyTopic>();
            if (isMoveTopic) new GameObject(IMQTTConnector.MOVE_TOPIC_MANAGER).AddComponent<MoveTopic>();
            if (isNotificationTopic) new GameObject(IMQTTConnector.NOTIFICATION_TOPIC_MANAGER).AddComponent<NotificationTopic>();
            if (isPropertyTopic) new GameObject(IMQTTConnector.PROPERTY_TOPIC_MANAGER).AddComponent<PropertyTopic>();

            new GameObject(IMQTTConnector.MQTT_CONNECTOR).AddComponent<MQTTConnector>();

            (mainTopicManager = new GameObject(IMQTTConnector.MAIN_TOPIC_MANAGER)).AddComponent<MainTopic>();
        }

        // Use this for initialization
        [Obsolete]
        void Start()
        {
            connector = GameObject.Find(IMQTTConnector.MQTT_CONNECTOR).GetComponent<MQTTConnector>().CreateConnector(MQTTConnector.SERVER_URL, MQTTConnector.SERVER_PORT, MQTTConnector.DEFAULT_USER, MQTTConnector.DEFAULT_PASSWORD);
            //connector = CreateConnector("vmpams.ird.fr", 1935, MQTTConnector.DEFAULT_USER, MQTTConnector.DEFAULT_PASSWORD);
            //connector.Subscribe("gui");
           
        }

        void FixedUpdate()
        {
            HandleMessage();
        }


        public void HandleMessage()
        {

            while (connector.HasNextMessage()) {
                MqttMsgPublishEventArgs e = connector.GetNextMessage();
                /*
				if (!IMQTTConnector.getTopicsInList().Contains(e.Topic))
				{
				    Debug.Log("-> The Topic '" + e.Topic + "' doesn't exist in the defined list. Please check! (the message will be deleted!)");
				    msgList.Remove(e);
				    return;
				}
				*/

                receivedMsg = System.Text.Encoding.UTF8.GetString(e.Message);

                Debug.Log("-> Received Message is : " + receivedMsg + " On topic : " + e.Topic);

                if (agentsTopicDic.Keys.Contains(e.Topic)) {

                    // DO Not DELETE
                    /*
					string serialisedObject = new XStream().ToXml(receivedMsg);
					GamaExposeMessage deserialisedObject = (GamaExposeMessage) new XStream().FromXml(serialisedObject);
					*/
                    Debug.Log("It concerns an exposed variable on :  " + e.Topic);
                    GamaExposeMessage exposeMessage = new GamaExposeMessage(receivedMsg);


                } else
                    switch (e.Topic) {
                        //case "listdata":
                        //    break;
                        case IMQTTConnector.MAIN_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("  -> Topic to deal with is : " + IMQTTConnector.MAIN_TOPIC);

                            UnityAgent unityAgent = (UnityAgent)MsgSerialization.FromXML(receivedMsg, new UnityAgent());
                            Agent agent = unityAgent.GetAgent();

                            switch (agent.Species) {
                                case IUILittoSim.LAND_USE:
                                    agent.Height = 10;
                                    //agentCreator.GetComponent<AgentCreator>().CreateAgent(agent, Land_Use_Transform, matRed, IUILittoSim.LAND_USE_ID, true, ILittoSimConcept.LAND_USE_TAG, -60);
                                    agentCreator.GetComponent<AgentCreator>().CreateGenericPolygonAgent(agent, true, IUILittoSim.LAND_USE, 0, false);//-60);

                                    break;
                                case IUILittoSim.COASTAL_DEFENSE:
                                    agent.Height = 10;
                                    //agentCreator.GetComponent<AgentCreator>().CreateAgent(agent, Land_Use_Transform, matYellow, IUILittoSim.COASTAL_DEFENSE_ID, true, ILittoSimConcept.COASTAL_DEFENSE_TAG, -80);
                                    agentCreator.GetComponent<AgentCreator>().CreateGenericPolygonAgent(agent, true, IUILittoSim.COASTAL_DEFENSE, -80);
                                    break;
                                case IUILittoSim.DISTRICT:
                                    agent.Height = 10;
                                    //agentCreator.GetComponent<AgentCreator>().CreateAgent(agent, Land_Use_Transform, matBlue, IUILittoSim.DISTRICT_ID, true, ILittoSimConcept.DISTRICT_TAG, -40);
                                    agentCreator.GetComponent<AgentCreator>().CreateGenericPolygonAgent(agent, true, IUILittoSim.DISTRICT, -40);
                                    break;
                                case IUILittoSim.FLOOD_RISK_AREA:
                                    agent.Height = 10;
                                    //agentCreator.GetComponent<AgentCreator>().CreateAgent(agent, Land_Use_Transform, matRed, IUILittoSim.FLOOD_RISK_AREA_ID, true, ILittoSimConcept.FLOOD_RISK_AREA_TAG, -100);
                                    agentCreator.GetComponent<AgentCreator>().CreateGenericPolygonAgent(agent, true, IUILittoSim.FLOOD_RISK_AREA, -100);
                                    break;
                                case IUILittoSim.PROTECTED_AREA:
                                    agent.Height = 10;
                                    //agentCreator.GetComponent<AgentCreator>().CreateAgent(agent, Land_Use_Transform, matGreenLighter, IUILittoSim.PROTECTED_AREA_ID, true, ILittoSimConcept.PROTECTED_AREA_TAG, -100);
                                    agentCreator.GetComponent<AgentCreator>().CreateGenericPolygonAgent(agent, true, IUILittoSim.PROTECTED_AREA, -100);
                                    break;
                                case IUILittoSim.ROAD:
                                    agent.Height = 0;
                                    //agentCreator.GetComponent<AgentCreator>().CreateAgent(agent, Land_Use_Transform, mat, IUILittoSim.ROAD_ID, false);
                                    //agentCreator.GetComponent<AgentCreator>().CreateLineAgent(agent, Land_Use_Transform, matWhite, IUILittoSim.ROAD_ID, false, 10f, ILittoSimConcept.ROAD_TAG, -151);
                                    agentCreator.GetComponent<AgentCreator>().CreateGenericLineAgent(agent, 10f, IUILittoSim.ROAD, -151);
                                    break;
                                default:
                                    targetGameObject = GameObject.Find(unityAgent.receivers);
                                    if (targetGameObject == null) {
                                        Debug.LogError(" Sorry, requested gameObject is null (" + unityAgent.receivers + "). Please check you code! ");
                                        break;
                                    } else {
                                        Debug.Log("Generic Object creation : " + unityAgent.contents.agentName);
                                        obj = new object[] { unityAgent, targetGameObject };
                                        mainTopicManager.GetComponent<MainTopic>().ProcessTopic(obj);
                                        //mainTopicManager.GetComponent(IMQTTConnector.MAIN_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                                    }
                                    break;
                            }

                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.MONO_FREE_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.MONO_FREE_TOPIC);
                            MonoFreeTopicMessage monoFreeTopicMessage = (MonoFreeTopicMessage)MsgSerialization.FromXML(receivedMsg, new MonoFreeTopicMessage());
                            targetGameObject = GameObject.Find(monoFreeTopicMessage.objectName);
                            obj = new object[] { monoFreeTopicMessage, targetGameObject };

                            if (targetGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + monoFreeTopicMessage.objectName + "). Please check your code! ");
                                break;
                            }
                            //    Debug.Log("The message is to " + monoFreeTopicMessage.objectName + " about the methode " + monoFreeTopicMessage.methodName + " and attribute " + monoFreeTopicMessage.attribute);
                            GameObject.Find(IMQTTConnector.MONO_FREE_TOPIC_MANAGER).GetComponent(IMQTTConnector.MONO_FREE_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.MULTIPLE_FREE_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.MULTIPLE_FREE_TOPIC);

                            MultipleFreeTopicMessage multipleFreetopicMessage = (MultipleFreeTopicMessage)MsgSerialization.FromXML(receivedMsg, new MultipleFreeTopicMessage());



                            targetGameObject = GameObject.Find(multipleFreetopicMessage.objectName);

                            Debug.Log("-> Concerned Game Object is : " + multipleFreetopicMessage.objectName);

                            obj = new object[] { multipleFreetopicMessage, targetGameObject };

                            if (targetGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + multipleFreetopicMessage.objectName + "). Please check you code! ");
                                break;
                            }

                            GameObject.Find(IMQTTConnector.MULTIPLE_FREE_TOPIC_MANAGER).GetComponent(IMQTTConnector.MULTIPLE_FREE_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.POSITION_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.POSITION_TOPIC);

                            PositionTopicMessage positionTopicMessage = (PositionTopicMessage)MsgSerialization.FromXML(receivedMsg, new PositionTopicMessage());
                            targetGameObject = GameObject.Find(positionTopicMessage.objectName);
                            obj = new object[] { positionTopicMessage, targetGameObject };

                            if (targetGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + positionTopicMessage.objectName + "). Please check you code! ");
                                break;
                            } else {
                                GameObject.Find(IMQTTConnector.POSITION_TOPIC_MANAGER).GetComponent(IMQTTConnector.POSITION_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);

                            }

                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.MOVE_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.MOVE_TOPIC);
                            Debug.Log("-> the message is : " + receivedMsg);
                            MoveTopicMessage moveTopicMessage = (MoveTopicMessage)MsgSerialization.FromXML(receivedMsg, new MoveTopicMessage());
                            Debug.Log("-> the position to move to is : " + moveTopicMessage.position);
                            Debug.Log("-> the speed is : " + moveTopicMessage.speed);
                            Debug.Log("-> the object to move is : " + moveTopicMessage.objectName);
                            targetGameObject = GameObject.Find(moveTopicMessage.objectName);
                            obj = new object[] { moveTopicMessage, targetGameObject };

                            if (targetGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + moveTopicMessage.objectName + "). Please check you code! ");
                                break;
                            }

                            GameObject.Find(IMQTTConnector.MOVE_TOPIC_MANAGER).GetComponent(IMQTTConnector.MOVE_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.COLOR_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.COLOR_TOPIC);

                            ColorTopicMessage colorTopicMessage = (ColorTopicMessage)MsgSerialization.FromXML(receivedMsg, new ColorTopicMessage());
                            targetGameObject = GameObject.Find(colorTopicMessage.objectName);
                            obj = new object[] { colorTopicMessage, targetGameObject };

                            if (targetGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + colorTopicMessage.objectName + "). Please check you code! ");
                                break;
                            }

                            GameObject.Find(IMQTTConnector.COLOR_TOPIC_MANAGER).GetComponent(IMQTTConnector.COLOR_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);

                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.GET_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.GET_TOPIC);
                            string value = null;

                            GetTopicMessage getTopicMessage = (GetTopicMessage)MsgSerialization.FromXML(receivedMsg, new GetTopicMessage());
                            targetGameObject = GameObject.Find(getTopicMessage.objectName);


                            if (targetGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + getTopicMessage.objectName + "). Please check you code! ");
                                break;
                            }

                            obj = new object[] { getTopicMessage, targetGameObject, value };

                            GameObject.Find(IMQTTConnector.GET_TOPIC_MANAGER).GetComponent(IMQTTConnector.GET_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                           
                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.SET_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.SET_TOPIC);

                            SetTopicMessage setTopicMessage = (SetTopicMessage)MsgSerialization.FromXML(receivedMsg, new SetTopicMessage());
                            // Debug.Log("-> Target game object name: " + setTopicMessage.objectName);
                            Debug.Log("-> Message: " + receivedMsg);
                            targetGameObject = GameObject.Find(setTopicMessage.objectName);

                            if (targetGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + setTopicMessage.objectName + "). Please check you code! ");
                                break;
                            }

                            obj = new object[] { setTopicMessage, targetGameObject };

                            GameObject.Find(IMQTTConnector.SET_TOPIC_MANAGER).GetComponent(IMQTTConnector.SET_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.PROPERTY_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.PROPERTY_TOPIC);

                            try {

                            } catch (Exception er) {
                                Debug.Log("Error : " + er.Message);
                            }

                            PropertyTopicMessage propertyTopicMessage = (PropertyTopicMessage)MsgSerialization.FromXML(receivedMsg, new PropertyTopicMessage());
                            Debug.Log("-> Target game object name: " + propertyTopicMessage.objectName);
                            targetGameObject = GameObject.Find(propertyTopicMessage.objectName);

                            if (targetGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + propertyTopicMessage.objectName + "). Please check you code! ");
                                break;
                            }

                            obj = new object[] { propertyTopicMessage, targetGameObject };

                            GameObject.Find(IMQTTConnector.PROPERTY_TOPIC_MANAGER).GetComponent(IMQTTConnector.PROPERTY_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                            //------------------------------------------------------------------------------
                            break;

                        case IMQTTConnector.CREATE_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.CREATE_TOPIC);
                            Debug.Log("-> Message: " + receivedMsg);
                            CreateTopicMessage createTopicMessage = (CreateTopicMessage)MsgSerialization.FromXML(receivedMsg, new CreateTopicMessage());
                            obj = new object[] { createTopicMessage };

                            GameObject.Find(IMQTTConnector.CREATE_TOPIC_MANAGER).GetComponent(IMQTTConnector.CREATE_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.DESTROY_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.DESTROY_TOPIC);

                            DestroyTopicMessage destroyTopicMessage = (DestroyTopicMessage)MsgSerialization.FromXML(receivedMsg, new DestroyTopicMessage());
                            obj = new object[] { destroyTopicMessage };

                            if (topicGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + destroyTopicMessage.objectName + "). Please check you code! ");
                                break;
                            }

                            GameObject.Find(IMQTTConnector.DESTROY_TOPIC_MANAGER).GetComponent(IMQTTConnector.DESTROY_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);
                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.NOTIFICATION_TOPIC:
                            //------------------------------------------------------------------------------
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.NOTIFICATION_TOPIC);

                            NotificationTopicMessage notificationTopicMessage = (NotificationTopicMessage)MsgSerialization.FromXML(receivedMsg, new NotificationTopicMessage());
                            obj = new object[] { notificationTopicMessage };


                            if (topicGameObject == null) {
                                Debug.LogError(" Sorry, requested gameObject is null (" + notificationTopicMessage.objectName + "). Please check you code! ");
                                break;
                            }

                            GameObject.Find(IMQTTConnector.NOTIFICATION_TOPIC_MANAGER).GetComponent(IMQTTConnector.NOTIFICATION_TOPIC_SCRIPT).SendMessage("ProcessTopic", obj);

                            //------------------------------------------------------------------------------
                            break;
                        case IMQTTConnector.SERIALIZATION_TOPIC:
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.SERIALIZATION_TOPIC);
                            Debug.Log("Load object from " + receivedMsg);


                            Debug.Log("New received message -> " + receivedMsg);
                            Student resultedObject = (Student)WoxSerializer.deserializeFromString(receivedMsg);
                            Debug.Log("--> Result is : " + resultedObject.printStudent());
                            break;
                        case IMQTTConnector.SERIALIZATION_JAVA_TOPIC:
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.SERIALIZATION_JAVA_TOPIC);
                            Debug.Log("Load object from " + receivedMsg);

                            Debug.Log("New received message -> " + receivedMsg);
                            Student studentJava = (Student)WoxSerializer.deserializeFromJavaString(receivedMsg);
                            Debug.Log("--> Result is : " + studentJava.printStudent());
                            break;
                        case IMQTTConnector.TOPIC_UI_CREATE:
                            Debug.Log("-> Topic to deal with is : " + IMQTTConnector.TOPIC_UI_CREATE);
                            Debug.Log("Load object from " + receivedMsg);

                            Debug.Log("New received message -> " + receivedMsg);
                            string javaClassPath = "\"ummisco.gama.unity.client.messages.UICreateMessage\"";
                            string unityClassPath = "\"MaterialUI.UICreateMessage\" dotnettype=\"MaterialUI.UICreateMessage, Assembly-CSharp, Version = 0.0.0.0, Culture = neutral, PublicKeyToken = null\" ";
                            UICreateMessage msg = (UICreateMessage)WoxSerializer.deserializeFromJavaString(receivedMsg, javaClassPath, unityClassPath);
                            msg.printClass();
                            GameObject.Find("UIManager").GetComponent<UIManager>().UICreate(msg);                       
                            break;
                        default:
                            //------------------------------------------------------------------------------
                            Debug.Log("--> Topic to deal with is : " + IMQTTConnector.DEFAULT_TOPIC);

                            //------------------------------------------------------------------------------
                            break;
                    }

            }
           
        }

        void OnGUI()
        {
            if (Application.platform == RuntimePlatform.Android) {
                if (GUI.Button(new Rect(20, 25, 200, 20), "Quitter! (Android)")) {
                    //connector.Disconnect();
                    Application.Quit();
                }
            }

            if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) {
                if (GUI.Button(new Rect(20, 25, 120, 20), "Quitter! (MacOS)")) {
                    //connector.Disconnect();
                    Application.Quit();
                }

                if (GUI.Button(new Rect(160, 25, 120, 20), "Local brocker")) {
                    connector = GameObject.Find(IMQTTConnector.MQTT_CONNECTOR).GetComponent<MQTTConnector>().CreateConnector("localhost", 1883, MQTTConnector.DEFAULT_USER, MQTTConnector.DEFAULT_PASSWORD);
                    connector.Subscribe("littosim");
                }

                if (GUI.Button(new Rect(300, 25, 140, 20), "Brocker on vmpams")) {
                    connector = GameObject.Find(IMQTTConnector.MQTT_CONNECTOR).GetComponent<MQTTConnector>().CreateConnector(MQTTConnector.SERVER_URL, MQTTConnector.SERVER_PORT, MQTTConnector.DEFAULT_USER, MQTTConnector.DEFAULT_PASSWORD);
                    connector.Subscribe("littosim");
                }

                if (GUI.Button(new Rect(460, 25, 140, 20), "Send Hellow World!")) {
                    connector.Publish("UITopic", "Hellow World");
                }

                if (GUI.Button(new Rect(620, 25, 100, 20), "Disconnect")) {
                    connector.Disconnect();
                }

               


            }



        }

        public void Tester()
        {
            connector.Publish("test", "Good, Bug fixed -> Sending from Unity3D!!! Good");
        }

        public void SendGotBoxMsg()
        {
            GamaReponseMessage msg = new GamaReponseMessage(connector.clientId, "GamaAgent", "Message from Unity", DateTime.Now.ToString());
            string message = MsgSerialization.ToXML(msg);
            connector.Publish("replay", message);
        }

       
        void OnDestroy()
        {
            m_Instance = null;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public string GetReplayNotificationMessage(NotificationEntry el)
        {
            NotificationMessage msg = new NotificationMessage("Unity", el.agentId, "Contents Not set", DateTime.Now.ToString(), el.notificationId);
            string message = MsgSerialization.SerializationPlainXml(msg);
            return message;
        }
        
        public void SubscribeToTopic(object args)
        {
            object[] obj = (object[])args;
            string agentName = (string)obj[0];
            string topic = (string)obj[1];
            connector.Subscribe(topic);
            agentsTopicDic.Add(topic, agentName);
        }

        
    }
}