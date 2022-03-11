using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace MaterialUI
{
	public class DialogBoxAction : MonoBehaviour
	{
		public GameObject parent;
		public GameObject dialogTitleObject;
		public GameObject dialogContentObject;
		public GameObject buttonYes;
		public GameObject buttonNo;

		public string topic;
		public string dialogBoxId = "";
		
		
		public Vector3 position = new Vector3(0,0,0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string title = "Dialog Box Title";
		public string text = "Dialog Box body text. Dialog Box body text 1. Dialog Box body text 2. Dialog Box body text 3. Dialog Box body text 4. ";
		Hashtable option_action = new Hashtable();
		public float size = 1; // the scale
		public int state = 1;

		void Start()
		{
			
		}

		public void SetDialogBox(string _topic, GameObject _parent, string _dialogBoxId, Vector3 _position, float _heigth, float _width, string _dialog_title, string _dialog_content, Hashtable _option_action, float _size, int _state)
		{
			SetTopic(_topic);
			SetDialogBox(_parent, _dialogBoxId, _position, _heigth, _width, _dialog_title, _dialog_content, _option_action, _size, _state);
		}

		private void SetTopic(string _topic)
		{
			this.topic = _topic;
		}

		public void SetDialogBox(GameObject _parent, string _dialogBoxId, Vector3 _position, float _heigth, float _width, string _dialog_title, string _dialog_content, Hashtable _option_action, float _size, int _state)
		{
			this.parent = _parent;
			this.dialogBoxId = _dialogBoxId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.title = _dialog_title;
			this.text = _dialog_content;
			this.option_action = _option_action;
			this.size = _size;
			this.state = _state;

			SetId(dialogBoxId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetDialogTitleText(_dialog_title);
			SetDialogContentText(_dialog_content);
			SetButtonYesNoText();


		}

		public void SetParent(GameObject _parent)
		{
			this.parent = _parent;
		}

		public void SetId(string _dialogBoxId)
		{
			gameObject.name = _dialogBoxId;
		}

		public void SetHeigth(float _height)
		{
			RectTransform rt = (RectTransform)parent.transform;
			float width = rt.rect.width;
			rt.sizeDelta = new Vector2(width, _height);
		}

		public void SetWidth(float _width)
		{
			RectTransform rt = (RectTransform)parent.transform;
			float height = rt.rect.height;
			rt.sizeDelta = new Vector2(_width, height);
		}

		public void SetWidthHeigth(float _width, float _height)
		{
			RectTransform rt = (RectTransform)parent.transform;
			rt.sizeDelta = new Vector2(_width, _height);
		}

		public void SetDialogTitleText(string dialog_title)
		{
			dialogTitleObject.GetComponent<Text>().text = dialog_title;
		}

		public void SetDialogContentText(string dialog_content)
		{
			dialogContentObject.GetComponent<Text>().text = dialog_content;
		}

		public void SetButtonYesNoText()
		{
			buttonYes.GetComponent<Text>().text = GetTextYes(); ;
			buttonNo.GetComponent<Text>().text = GetTextNo();

		}

		public void SetSize(float _size)
		{
			parent.transform.localScale = new Vector3(_size, _size, _size);
		}

		public void SetState(int _state)
		{
			this.state = _state;
		}


		public int GetActionYes()
		{
			int cmp = 0;
			int actionOn = 0;
			foreach (DictionaryEntry st in option_action) {
				cmp++;
				if (cmp > 2) break;
				if (cmp == 1) actionOn = Int32.Parse((string)st.Key);
			}
			return actionOn;
		}

		public int GetActionNo()
		{
			int cmp = 0;
			int actionOff = 0;
			foreach (DictionaryEntry st in option_action) {
				cmp++;
				if (cmp > 2) break;
				if (cmp == 2) actionOff = Int32.Parse((string)st.Key);
			}
			return actionOff;
		}

		public string GetTextYes()
		{
			int cmp = 0;
			string textOn = "Yes";
			foreach (DictionaryEntry st in option_action) {
				cmp++;
				if (cmp > 2) break;
				if (cmp == 1) textOn = (string)st.Value;
			}
			return textOn;
		}

		public string GetTextNo()
		{
			int cmp = 0;
			string textOff = "No";
			foreach (DictionaryEntry st in option_action) {
				cmp++;
				if (cmp > 2) break;
				if (cmp == 2) textOff = (string)st.Value;
			}
			return textOff;
		}

	}
}