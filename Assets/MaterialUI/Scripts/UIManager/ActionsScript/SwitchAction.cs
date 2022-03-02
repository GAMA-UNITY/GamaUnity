using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MaterialUI
{
	public class SwitchAction : MonoBehaviour
	{

		public GameObject parent;
		public string switchId = "";
		public Vector3 position = new Vector3(0, 0, 0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string text_on = "Switch On text";
		public string text_off = "Switch Off text";
		public float actionCode = 0;
		public float size = 1; // the scale
		public int state = 1;



		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void SetSwitch(GameObject _parent, string _switchId, Vector3 _position, float _heigth, float _width, string _text_on, string _text_off, float _actionCode, float _size, int _state)
		{
			this.parent = _parent;
			this.switchId = _switchId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.text_on = _text_on;
			this.text_off = _text_off;
			this.actionCode = _actionCode;
			this.size = _size;
			this.state = _state;

			SetId(_switchId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetText(text_on, text_off);


		}

		public void SetParent(GameObject _parent)
		{
			this.parent = _parent;
		}

		public void SetId(string _sliderId)
		{
			gameObject.name = _sliderId;
		}

		public void SetHeigth(float _height)
		{
			RectTransform rt = (RectTransform)gameObject.transform;
			float width = rt.rect.width;
			rt.sizeDelta = new Vector2(width, _height);
		}

		public void SetWidth(float _width)
		{
			RectTransform rt = (RectTransform)gameObject.transform;
			float height = rt.rect.height;
			rt.sizeDelta = new Vector2(_width, height);
		}

		public void SetWidthHeigth(float _width, float _height)
		{
			RectTransform rt = (RectTransform)gameObject.transform;
			rt.sizeDelta = new Vector2(_width, _height);
		}

		public void SetText(string _switch_on_text, string _switch_off_text)
		{
			parent.transform.GetChild(1).gameObject.GetComponent<ToggleTextChanger>().onText = _switch_on_text;
			parent.transform.GetChild(1).gameObject.GetComponent<ToggleTextChanger>().offText = _switch_off_text;

		}

		public void SetActionCode(int _actionCode)
		{
			this.actionCode = _actionCode;
		}

		public void SetSize(float _size)
		{
			gameObject.transform.localScale = new Vector3(_size, _size, _size);
		}

		public void SetState(int _state)
		{
			this.state = _state;
		}

	}
}
