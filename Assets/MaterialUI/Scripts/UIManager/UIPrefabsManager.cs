using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaterialUI
{
	public class UIPrefabsManager : MonoBehaviour
	{
		public int cmp = 0;
		public GameObject MainPanel;
		public GameObject MainCanvas;
		public GameObject App_Bar;
		public GameObject Background;
		public GameObject Button_Flat;
		public GameObject Button_Raised;
		public GameObject Canvas;
		public GameObject Checkbox;
		public GameObject DialogBox_Normal;
		public GameObject DialogBox_Scroll;
		public GameObject DialogBox_Simple;
		public GameObject Divider_Dark;
		public GameObject Divider_Light;
		public GameObject EventSystem;
		public GameObject Nav_Drawer;
		public GameObject Panel;
		public GameObject RadioGroup;
		public GameObject Round_Button_Flat;
		public GameObject Round_Button_Raised;
		public GameObject Round_Button_Small_Flat;
		public GameObject Round_Button_Small_Raised;
		public GameObject Screen_;
		public GameObject ScreenManager;
		public GameObject SelectionBox_Flat;
		public GameObject SelectionBox;
		public GameObject Slider;
		public GameObject Slider_label;
		public GameObject Slider_label_value;
		public GameObject SpinnyArrow_Button;
		public GameObject Switch;
		public GameObject Text;
		public GameObject TextInput;
		public GameObject List_Item_Double_Avatar;
		public GameObject List_Item_Double_Icon_Avatar;
		public GameObject List_Item_Double_Icon;
		public GameObject List_Item_Double;
		public GameObject List_Item_Single_Avatar;
		public GameObject List_Item_Single_Icon_Avatar;
		public GameObject List_Item_Single_Icon;
		public GameObject List_Item_Single;
		public GameObject List_Item_Triple_Avatar;
		public GameObject List_Item_Triple_Icon_Avatar;
		public GameObject List_Item_Triple_Icon;
		public GameObject List_Item_Triple;
		public GameObject ListView;
		public GameObject Subheader;
		public GameObject UnderShadow;

		Dictionary<string, GameObject> UIList = new Dictionary<string, GameObject>();
		public Vector2 rectVector2  = new Vector2( 0.0f,  0.0f);




		// Start is called before the first frame update
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


			UIList.Add("Button_Flat", Button_Flat);
			UIList.Add("Button_Raised", Button_Raised);
			UIList.Add("Checkbox", Checkbox);
			UIList.Add("DialogBox_Normal", DialogBox_Normal);
			UIList.Add("Divider_Dark", Divider_Dark);
			UIList.Add("RadioGroup", RadioGroup);
			UIList.Add("Round_Button_Raised", Round_Button_Raised);
			UIList.Add("Round_Button_Small_Raised", Round_Button_Small_Raised);
			UIList.Add("SelectionBox_Flat", SelectionBox_Flat);
			UIList.Add("SelectionBox", SelectionBox);
			UIList.Add("Slider", Slider);
			UIList.Add("Slider_label", Slider_label);
			UIList.Add("Slider_label_value", Slider_label_value);
			UIList.Add("SpinnyArrow_Button", SpinnyArrow_Button);
			UIList.Add("Switch", Switch);
			UIList.Add("Text", Text);
			UIList.Add("TextInput", TextInput);
			/*
			foreach (KeyValuePair<string, GameObject> kvp in UIList) {
				Debug.Log("Key = " + kvp.Key + " Value = " + kvp.Value.name);
			}
			*/
		}

		// Update is called once per frame
		void Update()
		{

		}

		void SetRecTransformDefault(RectTransform _mRect)
		{
			_mRect.anchorMin = new Vector2(0f, 1f);
			_mRect.anchorMax = new Vector2(0f, 1f);
			_mRect.pivot = new Vector2(0f, 1f);

			//_mRect.anchoredPosition = _parent.position;
			_mRect.anchorMin = new Vector2(0, 1);
			_mRect.anchorMax = new Vector2(0, 1);
			_mRect.pivot = new Vector2(0.5f, 0.5f);
			//_mRect.transform.SetParent(_parent);
	
		}

		void SetRecTransform(RectTransform rectT, Vector2 anchorMin, Vector2 anchorMax, Vector2 pivot)
		{
			rectT.anchorMin = anchorMin;
			rectT.anchorMax = anchorMax;
			rectT.pivot = pivot;
		}


		void OnGUI()
		{
			if (GUI.Button(new Rect(10, 20, 180, 20), "Button_Raised*")) {
				Debug.Log(" -  Button Raised - ");
				Create_Button_Raised("Button_Raised", MainPanel, "button1", new Vector3(264, -38, 0), 10f, 10f, "Button Test", 12, 1, 1);
			}		

			if (GUI.Button(new Rect(10, 50, 180, 20), "Checkbox*")) {
				Debug.Log(" - Checkbox  - ");
				Create_Checkbox("Checkbox", MainPanel, "checkbox1", new Vector3(337, -	66, 0), 10f, 10f, "CheckBox On__", "CheckBox Off___", 12, 1, 1);
			}

			if (GUI.Button(new Rect(10, 80, 180, 20), "DialogBox_Normal*")) {
				Debug.Log(" -  DialogBox_Normal - ");
				Vector3 position = new Vector3(917, 0, 0);
				GameObject obj = Create_DialogBox_Normal("DialogBox_Normal", MainPanel, "dialogbox1", new Vector3(917, 0, 0), 10f, 10f, "_Dialog Title_", "_Dialog content: The is the dialog box content area. Your informative text, or questions, should be put here", "_YES_", "_NO_", 12, 1, 1);
				RectTransform m_RectTransform = obj.GetComponent<RectTransform>();
				SetRecTransformDefault(m_RectTransform);
				m_RectTransform.anchoredPosition = position;
			}


			if (GUI.Button(new Rect(10, 120, 180, 20), "Divider_Dark")) {
				Debug.Log(" - Divider_Dark  - ");
				Create_Divider_Dark("Divider_Dark", MainPanel, new Vector3(345, -132, 0));
			}

			if (GUI.Button(new Rect(10, 150, 180, 20), "RadioGroup")) {
				Debug.Log(" - RadioGroup  - ");
				Create_RadioGroup("RadioGroup", MainPanel, new Vector3(623, -115, 0));
			}

			if (GUI.Button(new Rect(10, 180, 180, 20), "Round_Button_Raised")) {
				Debug.Log(" -  Round_Button_Raised - ");
				Create_Round_Button_Raised("Round_Button_Raised", MainPanel, new Vector3(459, -186, 0));
			}

			if (GUI.Button(new Rect(10, 210, 180, 20), "Round_Button_Small_Raised")) {
				Debug.Log(" - Round_Button_Small_Raised  - ");
				Create_Round_Button_Small_Raised("Round_Button_Small_Raised", MainPanel, new Vector3(389, -208, 0));
			}

			if (GUI.Button(new Rect(10, 240, 180, 20), "SelectionBox_Flat")) {
				Debug.Log(" -  SelectionBox_Flat - ");
				Create_SelectionBox_Flat("SelectionBox_Flat", MainPanel, new Vector3(294, -228, 0));
			}

			if (GUI.Button(new Rect(10, 270, 180, 20), "SelectionBox")) {
				Debug.Log(" -  SelectionBox - ");
				Create_SelectionBox("SelectionBox", MainPanel, new Vector3(294, -276, 0));
			}

			if (GUI.Button(new Rect(10, 300, 180, 20), "Slider")) {
				Debug.Log(" -  Slider - ");
				Create_Slider("Slider", MainPanel, new Vector3(598, -296, 0));
			}

			if (GUI.Button(new Rect(10, 330, 180, 20), "Slider_label")) {
				Debug.Log(" - Slider_label  - ");
				Create_Slider_label("Slider_label", MainPanel, new Vector3(594, -329, 0));
			}

			if (GUI.Button(new Rect(10, 360, 180, 20), "Slider_label_value*")) {
				Debug.Log(" - Slider_label_value  - ");
				Create_Slider_label_value("Slider_label_value", MainPanel, "slider1", new Vector3(588, -362, 0), 10f, 10f, "My Slider label", 12, 1, 1);
			}

			if (GUI.Button(new Rect(10, 390, 180, 20), "SpinnyArrow_Button")) {
				Debug.Log(" - SpinnyArrow_Button  - ");
				Create_SpinnyArrow_Button("SpinnyArrow_Button", MainPanel, new Vector3(406, -400, 0));
			}

			if (GUI.Button(new Rect(10, 420, 180, 20), "Switch*")) {
				Debug.Log(" - Switch  - ");
				Create_Switch("Switch", MainPanel, "switch1", new Vector3(254, -430, 0), 10f, 10f, "Switch ON Text__", "Switch OFF Text__", 12, 1, 1);
			}

			if (GUI.Button(new Rect(10, 450, 180, 20), "Text")) {
				Debug.Log(" - Text  - ");
				Create_Text("Text", MainPanel, "text1", new Vector3(301, -460, 0), 10f, 10f, "This is a free text element", 12, 1, 1);
			}


			if (GUI.Button(new Rect(10, 480, 180, 20), "TextInput")) {
				Debug.Log(" -  TextInput - ");
				Create_TextInput("TextInput", MainPanel, "textInput1", new Vector3(322, -514, 0), 10f, 10f, "This is a free text input element", 12, 1, 1);
			}


			/*
			Button_Raised
			Checkbox
			DialogBox_Normal
			Divider_Dark
			RadioGroup
			Round_Button_Raised
			Round_Button_Small_Raised
			SelectionBox_Flat
			SelectionBox
			Slider
			Slider_label
			Slider_label_value
			SpinnyArrow_Button
			Switch
			Text
			TextInput
			*/

			if (GUI.Button(new Rect(20, 650, 200, 20), "Send to listen")) {
				cmp++;
				Debug.Log("Another step ... cmp " + cmp);
				int local_cmp = 0;
				foreach (KeyValuePair<string, GameObject> kvp in UIList) {
					local_cmp++;
					Debug.Log("Key = " + kvp.Key + " Value = " + kvp.Value.name);
					GameObject objToInstantiate = kvp.Value;
					Debug.Log("GameObject Name : " + objToInstantiate.name);
					if (local_cmp == cmp) {
						GameObject obj = Instantiate(objToInstantiate, new Vector3(0, 0, 0), Quaternion.identity);
						obj.transform.SetParent(MainCanvas.transform);
						obj.transform.position = new Vector3(0, 0, 0);
						
						RectTransform m_RectTransform = obj.GetComponent<RectTransform>();
						SetRecTransformDefault(m_RectTransform);
						
						float m_XAxis = 0.5f;
						float m_YAxis = 0.5f;
						m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);

						break;
					}
				}
			}
		}

		// ----------------- Methods to create the prefabs
		/*
		GameObject Create_Button_Raised(string prefabName, GameObject parent, Vector3 position, Vector2 recTransform)
		{
			GameObject obj;
			try {
				GameObject objToInstantiate = UIList[prefabName];
				obj = Instantiate(objToInstantiate, new Vector3(0, 0, 0), Quaternion.identity);
				obj.transform.SetParent(parent.transform);
				obj.transform.position = position;
				RectTransform m_RectTransform = obj.GetComponent<RectTransform>();
				m_RectTransform.anchoredPosition = recTransform;
				return obj;
			} catch {
				return null;
			}
		}
		*/

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

				//obj.transform.localPosition = new Vector3(0,0,0);

				/*
				float offSet = 10f;
				float parentWidth = parent.GetComponent<RectTransform>().rect.width;
				float parentHeight = parent.GetComponent<RectTransform>().rect.height;

				obj.transform.SetParent(parent.transform);
				obj.transform.localScale = new Vector3(1, 1, 1);

				float myHeight = obj.GetComponent<RectTransform>().rect.height;
				float myWidth = obj.GetComponent<RectTransform>().rect.width;

				float tempX = -(parentWidth / 2) + ((myWidth / 2) + offSet);
				float tempY = (parentHeight / 2) - ((myHeight / 2) + offSet);
				obj.transform.localPosition = new Vector3(tempX, tempY, obj.transform.localPosition.z);
				*/

				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Button_Raised(string prefabName, GameObject parent, string buttonId, Vector3 position, float height, float length, string text, int actionCode, float size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "parent_" + buttonId;
				GameObject child = obj.transform.GetChild(1).gameObject;
				child.GetComponent<ButtonAction>().SetButton(obj, buttonId, position, height, length, text, actionCode, size, state) ;
				return obj;
			} catch {
				return null;
			}
		}
				
		GameObject Create_Checkbox(string prefabName, GameObject parent, string checkBoxId, Vector3 position, float height, float length, string text_on, string text_off, int actionCode, float size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "parent_" + checkBoxId;
				GameObject toggleChild = obj.transform.GetChild(0).gameObject;
				GameObject textChild = obj.transform.GetChild(1).gameObject;
				textChild.GetComponent<ToggleTextChanger>().SetText(text_on, text_off);
				toggleChild.GetComponent<CheckBoxAction>().SetCheckBox(obj, textChild, checkBoxId, position, height, length, text_on, text_off, actionCode, size, state);
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_DialogBox_Normal(string prefabName, GameObject parent, string dialogBoxId, Vector3 position, float height, float length, string dialog_title, string dialog_content, string yes_text, string no_text, int actionCode, float size, int state)
		{
		
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "parent_" + dialogBoxId;
				GameObject dialogLayer = obj.transform.GetChild(2).gameObject;
				dialogLayer.GetComponent<DialogBoxAction>().SetDialogBox(obj, dialogBoxId, position, height, length, dialog_title, dialog_content, yes_text, no_text, actionCode, size, state);

				RectTransform m_RectTransform = obj.GetComponent<RectTransform>();
				SetRecTransformDefault(m_RectTransform);
				m_RectTransform.anchoredPosition = position;
				return obj;
			} catch {
				return null;
			}
		}

		GameObject Create_Divider_Dark(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
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


		GameObject Create_Round_Button_Raised(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
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


		GameObject Create_SelectionBox(string prefabName, GameObject parent, Vector3 position)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
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

		GameObject Create_Slider_label_value(string prefabName, GameObject parent, string sliderId, Vector3 position, float heighh, float width, string slider_label, int actionCode, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.GetComponent<SliderLabelValueAction>().SetSlider(parent, sliderId, position, heighh, width, slider_label, actionCode, size, state);
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


		GameObject Create_Switch(string prefabName, GameObject parent, string switchId, Vector3 position, float height, float width, string switch_text_on, string switch_text_off, int actionCode, int size, int state)
		{
			GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "parent_" + switchId;
				GameObject switchToggle = obj.transform.GetChild(0).gameObject;
				switchToggle.GetComponent<SwitchAction>().SetSwitch(obj, switchId, position, height, width, switch_text_on, switch_text_off, actionCode, size, state);
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


		GameObject Create_TextInput(string prefabName, GameObject parent, string textInputId, Vector3 position, float height, float width, string text_content, int actionCode, int size, int state)
		{
					GameObject obj;
			try {
				obj = CreateDafault(prefabName, parent, position);
				obj.name = "parent_" + textInputId;
				GameObject inputField = obj.transform.GetChild(0).gameObject;
				inputField.GetComponent<TextInputAction>().SetTextInput(obj, textInputId, position, height, width, text_content, actionCode, size, state);
				return obj;
			} catch {
				return null;
			}
		}
			


		/*
			Button_Raised
			Checkbox
			DialogBox_Normal
			Divider_Dark
			RadioGroup
			Round_Button_Raised
			Round_Button_Small_Raised
			SelectionBox_Flat
			SelectionBox
			Slider
			Slider_label
			Slider_label_value
			SpinnyArrow_Button
			Switch
			Text
			TextInput
		*/

	}
}
