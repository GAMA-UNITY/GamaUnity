using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MaterialUI
{
	public class TextAction : MonoBehaviour
	{

		public string textId = "";
		public Vector3 position = new Vector3(0, 0, 0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string text_content = "This is a free text element";
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

		public void SetText(string _textId, Vector3 _position, float _heigth, float _width, string _text_content, int _actionCode, float _size, int _state)
		{			
			this.textId = _textId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.text_content = _text_content;
			this.actionCode = _actionCode;
			this.size = _size;
			this.state = _state;

			SetId(_textId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetWidthHeigth(_width, _heigth);
			SetText(text_content);
		}
		
		public void SetId(string _textId)
		{
			gameObject.name = _textId;
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

		public void SetText(string _texte_content)
		{
			gameObject.GetComponent<Text>().text = _texte_content;
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
