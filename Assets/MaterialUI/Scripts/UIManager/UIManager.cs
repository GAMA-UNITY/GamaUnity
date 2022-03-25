using System;
using System.Collections;
using System.Collections.Generic;
using ummisco.gama.unity.datastructure;
using UnityEngine;
using UnityEngine.UI;

namespace MaterialUI
{
	public class UIManager : MonoBehaviour
	{
		public int cmp = 0;

		[Space(5)]
		[Header("---- Main GameObjects ----")]

		public GameObject MainPanel;
		public GameObject MainCanvas;
		public GameObject MainManager;

		[Space(5)]
		[Header("---- GUI Elements ----")]
		//public GameObject App_Bar;
		//public GameObject Background;
		//public GameObject Button_Flat;
		public GameObject Button_Raised;
		//public GameObject Canvas;
		public GameObject Checkbox;
		public GameObject DialogBox_Normal;
		//public GameObject DialogBox_Scroll;
		//public GameObject DialogBox_Simple;
		public GameObject Divider_Dark;
		//public GameObject Divider_Light;
		//public GameObject EventSystem;
		//public GameObject Nav_Drawer;
		//public GameObject Panel;
		//public GameObject RadioGroup;
		//public GameObject Round_Button_Flat;
		public GameObject Round_Button_Raised;
		//public GameObject Round_Button_Small_Flat;
		//public GameObject Round_Button_Small_Raised;
		//public GameObject Screen_;
		//public GameObject ScreenManager;
		//public GameObject SelectionBox_Flat;
		public GameObject SelectionBox;
		//public GameObject Slider;
		//public GameObject Slider_label;
		public GameObject Slider_label_value;
		//public GameObject SpinnyArrow_Button;
		public GameObject Switch;
		public GameObject Text;
		public GameObject TextInput;
		//public GameObject List_Item_Double_Avatar;
		//public GameObject List_Item_Double_Icon_Avatar;
		//public GameObject List_Item_Double_Icon;
		//public GameObject List_Item_Double;
		//public GameObject List_Item_Single_Avatar;
		//public GameObject List_Item_Single_Icon_Avatar;
		//public GameObject List_Item_Single_Icon;
		//public GameObject List_Item_Single;
		//public GameObject List_Item_Triple_Avatar;
		//public GameObject List_Item_Triple_Icon_Avatar;
		//public GameObject List_Item_Triple_Icon;
		//public GameObject List_Item_Triple;
		//public GameObject ListView;
		//public GameObject Subheader;
		//public GameObject UnderShadow;

		//[Space(5)]
		[Header("---- Local Variables ----")]

		Dictionary<string, GameObject> UIList = new Dictionary<string, GameObject>();
		public Vector2 rectVector2 = new Vector2(0.0f, 0.0f);

		private const string UIButtonRaised = "Button";
		private const string UICheckbox = "Checkbox";
		private const string UIDialogBox = "DialogBox";
		private const string UIDivider = "Divider";
		private const string UIRoundButton = "RoundButton";
		private const string UISelectionBox = "SelectionBox";
		private const string UISlider = "Slider";
		private const string UISwitch = "Switch";
		private const string UIText = "Text";
		private const string UITextInput = "TextInput";

		private bool isTest = false;


		void Start()
		{

			//UIList.Add("App_Bar", App_Bar);
			//UIList.Add("Background", Background);
			//UIList.Add("Canvas", Canvas);
			//UIList.Add("DialogBox_Scroll", DialogBox_Scroll);
			//UIList.Add("DialogBox_Simple", DialogBox_Simple);
			//UIList.Add("Divider_Light", Divider_Light);
			//UIList.Add("EventSystem", EventSystem);
			//UIList.Add("Nav_Drawer", Nav_Drawer);
			//UIList.Add("Panel", Panel);
			//UIList.Add("Round_Button_Flat", Round_Button_Flat);
			//UIList.Add("Round_Button_Small_Flat", Round_Button_Small_Flat);
			//UIList.Add("Screen_", Screen_);
			//UIList.Add("ScreenManager", ScreenManager);
			//UIList.Add("List_Item_Double_Avatar", List_Item_Double_Avatar);
			//UIList.Add("List_Item_Double_Icon_Avatar", List_Item_Double_Icon_Avatar);
			//UIList.Add("List_Item_Double_Icon", List_Item_Double_Icon);
			//UIList.Add("List_Item_Double", List_Item_Double);
			//UIList.Add("List_Item_Single_Avatar", List_Item_Single_Avatar);
			//UIList.Add("List_Item_Single_Icon_Avatar", List_Item_Single_Icon_Avatar);
			//UIList.Add("List_Item_Single_Icon", List_Item_Single_Icon);
			//UIList.Add("List_Item_Single", List_Item_Single);
			//UIList.Add("List_Item_Triple_Avatar", List_Item_Triple_Avatar);
			//UIList.Add("List_Item_Triple_Icon_Avatar", List_Item_Triple_Icon_Avatar);
			//UIList.Add("List_Item_Triple_Icon", List_Item_Triple_Icon);
			//UIList.Add("List_Item_Triple", List_Item_Triple);
			//UIList.Add("ListView", ListView);
			//UIList.Add("Subheader", Subheader);
			//UIList.Add("UnderShadow", UnderShadow);

			//UIList.Add("Button_Flat", Button_Flat);
			//UIList.Add("RadioGroup", RadioGroup);
			//UIList.Add("Round_Button_Small_Raised", Round_Button_Small_Raised);
			//UIList.Add("SelectionBox_Flat", SelectionBox_Flat);
			//UIList.Add("Slider", Slider);
			//UIList.Add("Slider_label", Slider_label);
			//UIList.Add("SpinnyArrow_Button", SpinnyArrow_Button);

			UIList.Add("Button_Raised", Button_Raised);
			UIList.Add("Checkbox", Checkbox);
			UIList.Add("DialogBox_Normal", DialogBox_Normal);
			UIList.Add("Divider_Dark", Divider_Dark);
			UIList.Add("Round_Button_Raised", Round_Button_Raised);
			UIList.Add("SelectionBox", SelectionBox);
			UIList.Add("Slider_label_value", Slider_label_value);
			UIList.Add("Switch", Switch);
			UIList.Add("Text", Text);
			UIList.Add("TextInput", TextInput);

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void UICreate(UICreateMessage msg)
		{
			switch (msg.uiType) {
				case UIButtonRaised:
					Create_Button_Raised(msg.topic, "Button_Raised", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.label, 11, msg.size, msg.state);
					break;
				case UICheckbox:
					Create_Checkbox(msg.topic, "Checkbox", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.option_action, msg.size, msg.state);
					break;
				case UIDialogBox:
					Create_DialogBox_Normal(msg.topic, "DialogBox_Normal", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.label, msg.content_text, msg.option_action, msg.size, msg.state);
					break;
				case UIDivider:
					Create_Divider_Dark("Divider_Dark", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, new RGBColor(msg.redColor, msg.greenColor, msg.blueColor, msg.alphaColor), msg.size, msg.state);
					break;
				case UIRoundButton:
					Create_Round_Button_Raised(msg.topic, "Round_Button_Raised", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.content_text, 1, msg.size, msg.state);
					break;
				case UISelectionBox:
					Create_SelectionBox(msg.topic, "SelectionBox", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.label, msg.option_action, msg.size, msg.state);
					break;
				case UISlider:
					Create_Slider_label_value(msg.topic, "Slider_label_value", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.label, 15, msg.size, msg.state);
					break;
				case UISwitch:
					Create_Switch(msg.topic, "Switch", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.option_action, msg.size, msg.state);
					break;
				case UIText:
					Create_Text("Text", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.label, 17, msg.size, msg.state);
					break;
				case UITextInput:
					Create_TextInput(msg.topic, "TextInput", MainPanel, msg.uiId, new Vector3(msg.x, msg.y, msg.z), msg.height, msg.width, msg.label, 18, msg.size, msg.state);
					break;
				default:
					Debug.LogWarning("The Topic is not covered by the GameObject " + gameObject.name);
					break;
			}
		}

		void SetRecTransformDefault(RectTransform _mRect)
		{
			_mRect.anchorMin = new Vector2(0, 1);
			_mRect.anchorMax = new Vector2(0, 1);
			_mRect.pivot = new Vector2(0.5f, 0.5f);
		}

		void SetRecTransform(RectTransform rectT, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot)
		{
			rectT.anchorMin = anchorMin;
			rectT.anchorMax = anchorMax;
			rectT.pivot = pivot;
		}

		void OnGUI()
		{
			if (isTest) {
				if (GUI.Button(new Rect(10, 50, 180, 20), "Checkbox*")) {
					Debug.Log(" - Checkbox  - ");
					Hashtable option_action = new Hashtable();
					option_action.Add(1, "On");
					option_action.Add(0, "Off");
					Create_Checkbox("UITopic", "Checkbox", MainPanel, "checkbox1", new Vector3(337, -66, 0), 10f, 10f, option_action, 1, 1);
				}

				if (GUI.Button(new Rect(10, 80, 180, 20), "DialogBox_Normal*")) {
					Debug.Log(" -  DialogBox_Normal - ");
					Vector3 position = new Vector3(1252, 1282, 0); //Vector3(917, 0, 0)
					Hashtable option_action = new Hashtable();
					option_action.Add(1, "Yes Option");
					option_action.Add(0, "No Option");
					Create_DialogBox_Normal("UITopic", "DialogBox_Normal", MainPanel, "dialogbox1", new Vector3(1252, 1282, 0), 10f, 10f, "_Dialog Title_", "_Dialog content: The is the dialog box content area. Your informative text, or questions, should be put here", option_action, 1, 1);
				}

				if (GUI.Button(new Rect(10, 120, 180, 20), "Divider_Dark*")) {
					Debug.Log(" - Divider_Dark  - ");
					Create_Divider_Dark("Divider_Dark", MainPanel, "divider1", new Vector3(345, -132, 0), 2f, 300f, new RGBColor(255,255,255,255), 1, 1);
				}

				if (GUI.Button(new Rect(10, 180, 180, 20), "Round_Button_Raised*")) {
					Debug.Log(" -  Round_Button_Raised - ");
					Create_Round_Button_Raised("UITopic", "Round_Button_Raised", MainPanel, "buttonRound1", new Vector3(459, -186, 0), 10f, 10f, "ihm/I_urbanise_adapte", 14, 1, 1);
				}

				if (GUI.Button(new Rect(10, 220, 180, 20), "Button_Raised*")) {
					Debug.Log(" -  Button Raised - ");
					Create_Button_Raised("UITopic", "Button_Raised", MainPanel, "button1", new Vector3(264, -200, 0), 10f, 10f, "Button Test", 11, 1, 1);
				}

				if (GUI.Button(new Rect(10, 270, 180, 20), "SelectionBox*")) {
					Debug.Log(" -  SelectionBox - ");
					Hashtable option_action = new Hashtable();
					option_action.Add(0, "A OP -----");
					option_action.Add(1, "B OP -----");
					option_action.Add(2, "C OP -----");
					option_action.Add(3, "D OP -----");
					option_action.Add(4, "E OP -----");
					option_action.Add(5, "F OP -----");
					Create_SelectionBox("UITopic", "SelectionBox", MainPanel, "selectionboxId1", new Vector3(294, -276, 0), 10f, 10f, "_SELECTION_", option_action, 1, 1);
				}

				if (GUI.Button(new Rect(10, 360, 180, 20), "Slider_label_value*")) {
					Debug.Log(" - Slider_label_value  - ");
					Create_Slider_label_value("UITopic", "Slider_label_value", MainPanel, "slider1", new Vector3(588, -362, 0), 10f, 10f, "My Slider label", 15, 1, 1);
				}

				if (GUI.Button(new Rect(10, 420, 180, 20), "Switch*")) {
					Debug.Log(" - Switch  - ");
					Hashtable option_action = new Hashtable();
					option_action.Add(1, "Switch On");
					option_action.Add(0, "Switch Off");
					Create_Switch("UITopic", "Switch", MainPanel, "switch1", new Vector3(254, -430, 0), 10f, 10f, option_action, 1, 1);
				}

				if (GUI.Button(new Rect(10, 450, 180, 20), "Text*")) {
					Debug.Log(" - Text  - ");
					Create_Text("Text", MainPanel, "text1", new Vector3(301, -460, 0), 10f, 10f, "This is a free text element", 17, 1, 1);
				}

				if (GUI.Button(new Rect(10, 330, 180, 20), "TextInput*")) {
					Debug.Log(" -  TextInput - ");
					Create_TextInput("UITopic", "TextInput", MainPanel, "textInput1", new Vector3(594, -329, 0), 10f, 10f, "This is a free text input element", 18, 1, 1);
				}
			}
		}

		GameObject CreateDafault(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				GameObject objToInstantiate = UIList[prefabName];
				obj = Instantiate(objToInstantiate, new Vector3(0, 0, 0), Quaternion.identity);
				if (parent != null)
					obj.transform.SetParent(parent.transform);
				RectTransform m_RectTransform = obj.GetComponent<RectTransform>();
				SetRecTransformDefault(m_RectTransform);
				m_RectTransform.anchoredPosition = position;

				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Button_Raised(string topic, string prefabName, GameObject parent, string buttonId, Vector3 position, float height, float width, string text, int actionCode, float size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "group_parent_" + buttonId;
				GameObject child = obj.transform.GetChild(1).gameObject;
				child.GetComponent<ButtonAction>().SetButton(topic, obj, buttonId, position, height, width, text, actionCode, size, state);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Checkbox(string topic, string prefabName, GameObject parent, string checkBoxId, Vector3 position, float height, float width, Hashtable option_action, float size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "group_parent_" + checkBoxId;
				GameObject toggleChild = obj.transform.GetChild(0).gameObject;
				toggleChild.GetComponent<CheckBoxAction>().SetCheckBox(topic, obj, checkBoxId, position, height, width, option_action, size, state);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_DialogBox_Normal(string topic, string prefabName, GameObject parent, string dialogBoxId, Vector3 position, float height, float width, string dialog_title, string dialog_content, Hashtable option_action, float size, int state)
		{

			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "group_parent_" + dialogBoxId;
				GameObject dialogLayer = obj.transform.GetChild(2).gameObject;
				dialogLayer.GetComponent<DialogBoxAction>().SetDialogBox(topic, obj, dialogBoxId, position, height, width, dialog_title, dialog_content, option_action, size, state);

				RectTransform m_RectTransform = obj.GetComponent<RectTransform>();
				SetRecTransformDefault(m_RectTransform);
				m_RectTransform.anchoredPosition = position;

				SetRecTransform(m_RectTransform, new Vector2(0, 1), new Vector2(0, 1), new Vector2(1f, 1f));
				m_RectTransform.anchoredPosition = position;

				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Divider_Dark(string prefabName, GameObject parent, string dividerId, Vector3 position, float height, float width, RGBColor color, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.GetComponent<DividerAction>().SetDivider(dividerId, position, height, width, color, size, state);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_RadioGroup(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Round_Button_Raised(string topic, string prefabName, GameObject parent, string buttonId, Vector3 position, float height, float width, string buttonIcon, int actionCode, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "group_parent_" + buttonId;
				GameObject child = obj.transform.GetChild(1).gameObject;
				child.GetComponent<RoundButtonAction>().SetRoundButton(topic, obj, buttonId, position, height, width, buttonIcon, actionCode, size, state);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Round_Button_Small_Raised(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_SelectionBox_Flat(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_SelectionBox(string topic, string prefabName, GameObject parent, string selectionBoxId, Vector3 position, float height, float width, string selection_label, Hashtable option_action, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "group_parent_" + selectionBoxId;
				GameObject child = obj.transform.GetChild(2).gameObject;
				child.GetComponent<SelectionBoxAction>().SetSelectionBox(topic, obj, selectionBoxId, position, height, width, selection_label, option_action, size, state);

				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Slider(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Slider_label(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Slider_label_value(string topic, string prefabName, GameObject parent, string sliderId, Vector3 position, float heighh, float width, string slider_label, int actionCode, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.GetComponent<SliderLabelValueAction>().SetSlider(topic, parent, sliderId, position, heighh, width, slider_label, actionCode, size, state);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_SpinnyArrow_Button(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Switch(string topic, string prefabName, GameObject parent, string switchId, Vector3 position, float height, float width, Hashtable option_action, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "group_parent_" + switchId;
				GameObject switchToggle = obj.transform.GetChild(0).gameObject;
				switchToggle.GetComponent<SwitchAction>().SetSwitch(topic, obj, switchId, position, height, width, option_action, size, state);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Text(string prefabName, GameObject parent, string textId, Vector3 position, float height, float width, string text_content, int actionCode, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.GetComponent<TextAction>().SetText(textId, position, height, width, text_content, actionCode, size, state);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_TextInput(string topic, string prefabName, GameObject parent, string textInputId, Vector3 position, float height, float width, string text_content, int actionCode, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "group_parent_" + textInputId;
				GameObject inputField = obj.transform.GetChild(0).gameObject;
				inputField.GetComponent<TextInputAction>().SetTextInput(topic, obj, textInputId, position, height, width, text_content, actionCode, size, state);
				return obj;
			} catch {
				return null;
			}
		}
	}
}
