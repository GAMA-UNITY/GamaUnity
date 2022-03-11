using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace MaterialUI
{
	public class CheckBoxAction : MonoBehaviour
	{
		public GameObject parent;
		public GameObject checkText;
		public GameObject checkBoxToggle;
		public string topic = DefaultSettings.DEFAULT_TOPIC;
		public string checkBoxId = "";
		
		
		public Vector3 position = new Vector3(0,0,0);
		public float height = 0.0f;
		public float width = 0.0f;
		public Hashtable option_action;
		public float size = 1; // the scale
		public int state = 1;

		void Start()
		{
			
		}


		public void SetCheckBox(string topic, GameObject _parent, GameObject textGameObject, string _checkBoxId, Vector3 _position, float _heigth, float _width, Hashtable _option_action, float _size, int _state)
		{
			SetCheckBox(_parent, textGameObject, _checkBoxId, _position, _heigth, _width, _option_action, _size, _state);
			SetTopic(topic);			
		}

		private void SetTopic(string _topic)
		{
			this.topic = _topic;
		}

		public void SetCheckBox(GameObject _parent, GameObject textGameObject, string _checkBoxId, Vector3 _position, float _heigth, float _width, Hashtable _option_action, float _size, int _state)
		{
			this.parent = _parent;
			this.checkText = textGameObject;
			this.checkBoxId = _checkBoxId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.option_action = _option_action;
			this.size = _size;
			this.state = _state;

			SetId(_checkBoxId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetActions(_option_action);
		}

		public void SetParent(GameObject _parent)
		{
			this.parent = _parent;
		}

		public void SetId(string _checkboxId)
		{
			gameObject.name = checkBoxId;
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

		public void SetActions(Hashtable _option_action)
		{
			Debug.Log("GameObject Name is " + gameObject.name);
			int cmp = 0;
			string _text_on = "On";
			string _text_off = "Off";

			foreach (DictionaryEntry st in option_action) {
				cmp++;
				if (cmp > 2) break;
				if (cmp == 1) _text_on = (string) st.Value;
				if (cmp == 2) _text_off = (string)st.Value;
			}
			checkText.GetComponent<ToggleTextChanger>().onText = _text_on;
			checkText.GetComponent<ToggleTextChanger>().offText = _text_off;
		}

		public int GetActionOn()
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

		public int GetActionOff()
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

		public string GetTextOn()
		{
			int cmp = 0;
			string textOn = "On";
			foreach (DictionaryEntry st in option_action) {
				cmp++;
				if (cmp > 2) break;
				if (cmp == 1) textOn = (string)st.Value;
			}
			return textOn;
		}

		public string GetTextOff()
		{
			int cmp = 0;
			string textOff = "Off";
			foreach (DictionaryEntry st in option_action) {
				cmp++;
				if (cmp > 2) break;
				if (cmp == 2) textOff = (string)st.Value;
			}
			return textOff;
		}


		public void SetSize(float _size)
		{
			parent.transform.localScale = new Vector3(_size, _size, _size);
		}

		public void SetState(int _state)
		{
			this.state = _state;
		}

		
	}
}