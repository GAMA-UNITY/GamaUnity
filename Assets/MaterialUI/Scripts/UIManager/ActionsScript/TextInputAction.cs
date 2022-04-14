using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace MaterialUI
{
	public class TextInputAction : MonoBehaviour
	{

		public GameObject parent;
		public Text placeholderText;

		public string topic;
		public string textInputId = "";
		public Vector3 position = new Vector3(0, 0, 0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string text_content = "This is a free text input element";
		public int actionCode = 12;
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

		public void SetTextInput(string _topic, GameObject _parent, string _textInputId, Vector3 _position, float _heigth, float _width, string _text_content, int _actionCode, float _size, int _state)
		{
			SetTopic(_topic);
			SetTextInput(_parent, _textInputId, _position, _heigth, _width, _text_content, _actionCode, _size, _state);
		}

		private void SetTopic(string _topic)
		{
			this.topic = _topic;
		}

		public void SetTextInput(GameObject _parent, string _textInputId, Vector3 _position, float _heigth, float _width, string _text_content, int _actionCode, float _size, int _state)
		{

			this.parent = _parent;
			this.textInputId = _textInputId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.text_content = _text_content;
			this.actionCode = _actionCode;
			this.size = _size;
			this.state = _state;

			SetId(textInputId);
			SetSize(size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetWidthHeigth(_width, _heigth);
			SetText(text_content);


		}
		
		public void SetId(string _textInputId)
		{
			gameObject.name = _textInputId;
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
			RectTransform rt = (RectTransform)parent.transform;
			rt.sizeDelta = new Vector2(_width, _height);
		}

		public void SetText(string _texte_content)
		{
			placeholderText.text = _texte_content;
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
