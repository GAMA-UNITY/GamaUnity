using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ummisco.gama.unity.datastructure;

namespace MaterialUI
{
	public class DividerAction : MonoBehaviour
	{

		public string dividerId = "";
		public Vector3 position = new Vector3(0, 0, 0);
		public float height = 0.0f;
		public float width = 0.0f;
		public RGBColor color;
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

		public void SetDivider(string _dividerId, Vector3 _position, RGBColor _color, float _heigth, float _width, float _size, int _state)
		{
			this.color = _color;
			SetDivider(_dividerId, _position, _heigth, _width, _size, _state);		
			SetColor(color);
		}

		public void SetDivider(string _dividerId, Vector3 _position, float _heigth, float _width, float _size, int _state)
		{
			this.dividerId = _dividerId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.size = _size;
			this.state = _state;

			SetId(dividerId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetWidthHeigth(width, height);
		}

		public void SetId(string _dividerId)
		{
			gameObject.name = _dividerId;
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

		public void SetColor(RGBColor _color)
		{
			gameObject.GetComponent<Image>().color = color.GetRGBColor(); 
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
