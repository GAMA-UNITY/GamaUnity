using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace MaterialUI
{
	public class CheckBoxAction : MonoBehaviour
	{
		public GameObject parent;
		public GameObject checkText;
		public GameObject checkBoxToggle;
		public string checkBoxId = "";
		
		
		public Vector3 position = new Vector3(0,0,0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string text_on = "CheckBox On";
		public string text_off = "CheckBox Off";
		public int actionCode = 0;
		public float size = 1; // the scale
		public int state = 1;

		void Start()
		{
			
		}

	
		public void SetCheckBox(GameObject _parent, GameObject textGameObject, string _checkBoxId, Vector3 _position, float _heigth, float _width, string _text_on, string _text_off, int _actionCode, float _size, int _state)
		{
			this.parent = _parent;
			this.checkText = textGameObject;
			this.checkBoxId = _checkBoxId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.text_on = _text_on;
			this.text_off = _text_off;
			this.actionCode = _actionCode;
			this.size = _size;
			this.state = _state;

			SetId(_checkBoxId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetText(_text_on, _text_off);


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

		public void SetText(string _text_on, string _text_off)
		{
			Debug.Log("GameObject Name is " + gameObject.name);
			checkText.GetComponent<ToggleTextChanger>().onText = _text_on;
			checkText.GetComponent<ToggleTextChanger>().offText = _text_off;
		}

		public void SetActionCode(int _actionCode)
		{
			this.actionCode = _actionCode;
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