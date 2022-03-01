using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MaterialUI
{
	public class SliderLabelValueAction : MonoBehaviour
	{

		public GameObject parent;
		public string sliderId = "";
		public Vector3 position = new Vector3(0, 0, 0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string text_label = "Slider Label";
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

		public void SetSlider(GameObject _parent, string _sliderId, Vector3 _position, float _heigth, float _width, string _text_label, float _actionCode, float _size, int _state)
		{
			this.parent = _parent;
			this.sliderId = _sliderId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.text_label = _text_label;
			this.actionCode = _actionCode;
			this.size = _size;
			this.state = _state;

			SetId(_sliderId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetText(text_label);


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

		public void SetText(string _text_label)
		{
			gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = _text_label;
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
