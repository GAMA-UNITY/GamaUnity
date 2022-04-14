using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using ummisco.gama.unity.datastructure;

namespace MaterialUI
{
	public class SelectionBoxAction : MonoBehaviour
	{
		public GameObject parent;
		public Text SelectionBoxText;
		public string selectionBoxId = "";

		public string topic;
		public Vector3 position = new Vector3(0,0,0);
		public float height = 0.0f;
		public float width = 0.0f;
		public RGBColor color;
		public string text_label = "Selection Box";
		public Hashtable option_action;
		public int actionCode = 0;
		public float size = 1; // the scale
		public int state = 1;

		void Start()
		{
			
		}

		public void SetSelectionBox(string _topic, GameObject _parent, string _selectionBoxId, Vector3 _position, float _heigth, float _width, string _text_label, Hashtable _option_action, float _size, int _state)
		{
			SetTopic(_topic);
			SetSelectionBox(_parent, _selectionBoxId, _position, _heigth, _width, _text_label, _option_action, _size, _state);
		}

		public void SetSelectionBox(string _topic, GameObject _parent, string _selectionBoxId, Vector3 _position, RGBColor _color, float _heigth, float _width, string _text_label, Hashtable _option_action, float _size, int _state)
		{
			this.color = _color;
			SetTopic(_topic);
			SetSelectionBox(_parent, _selectionBoxId, _position, _heigth, _width, _text_label, _option_action, _size, _state);
			SetColor(color);
		}

		public void SetColor(RGBColor color)
		{
			gameObject.GetComponent<Image>().color = color.GetRGBColor();
		}


		private void SetTopic(string _topic)
		{
			this.topic = _topic;
		}

		public void SetSelectionBox(GameObject _parent, string _selectionBoxId, Vector3 _position, float _heigth, float _width, string _text_label, Hashtable _option_action, float _size, int _state)
		{
			this.parent = _parent;
			this.selectionBoxId = _selectionBoxId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.text_label = _text_label;
			this.option_action = _option_action;
			this.size = _size;
			this.state = _state;

			SetId(selectionBoxId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetSelectionLabel(text_label);
			SetSelectionOption(option_action);


		}

		public void SetParent(GameObject _parent)
		{
			this.parent = _parent;
		}

		public void SetId(string _selectionBoxId)
		{
			gameObject.name = _selectionBoxId;
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

		public void SetSelectionLabel(string _selection_label)
		{
			SelectionBoxText.text = _selection_label;
		}

		public void SetSelectionOption(Hashtable _option_action)
		{
			Debug.Log(_option_action.Count + " - - GameObject Name is ------> " + gameObject.name);
			gameObject.GetComponent<SelectionBoxConfig>().SetListItem(_option_action);
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