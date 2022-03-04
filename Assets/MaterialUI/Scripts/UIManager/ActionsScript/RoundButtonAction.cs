using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using wox.serial;

namespace MaterialUI
{
	public class RoundButtonAction : MonoBehaviour
	{
		public GameObject parent;

		public string topic;
		public string buttonId = "";
		public Vector3 position = new Vector3(0,0,0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string icon = "X";
		public int actionCode = 0;
		public float size = 1; // the scale
		public int state = 1;

		void Start()
		{
			Button btn = gameObject.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}

		public void TaskOnClick()
		{
			Debug.Log("You have clicked the Round Action Button! The action code is : "+ actionCode);
			UIActionMessage msg = new UIActionMessage(buttonId, actionCode, topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is : " + serial);

		}

		public void SetRoundButton(string _topic, GameObject _parent, string _buttonId, Vector3 _position, float _heigth, float _width, string _icon, int _actionCode, float _size, int _state)
		{
			SetTopic(_topic);
			SetRoundButton(_parent, _buttonId, _position, _heigth, _width, _icon, _actionCode, _size, _state);
		}

		private void SetTopic(string _topic)
		{
			this.topic = _topic;
		}

		public void SetRoundButton(GameObject _parent, string _buttonId, Vector3 _position, float _heigth, float _width, string _icon, int _actionCode, float _size, int _state)
		{
			this.parent = _parent;
			this.buttonId = _buttonId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.icon = _icon;
			this.actionCode = _actionCode;
			this.size = _size;
			this.state = _state;
			
			SetId(_buttonId);
			
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetIcon(icon);
			

		}

		public void SetParent(GameObject _parent)
		{
			this.parent = _parent;
		}

		public void SetId(string _buttonId)
		{
			gameObject.name = buttonId;
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

		public void SetIcon(string _icon)
		{
			//gameObject.GetComponentInChildren<Text>().text = _icon;
			Debug.Log(" The game Object name is : " + gameObject.name);
			GameObject child = gameObject.transform.GetChild(0).gameObject;
			Debug.Log(" The game Object child is : " + child.name);
			Sprite buttonSprite = Resources.Load<Sprite>("images/"+_icon) as Sprite;
			
			//gameObject.GetComponent<Image>().sprite = buttonSprite;

			
			gameObject.GetComponent<SpriteSwapper>().sprite1x = buttonSprite;
			gameObject.GetComponent<SpriteSwapper>().sprite2x = buttonSprite;
			gameObject.GetComponent<SpriteSwapper>().sprite4x = buttonSprite;
			
			//child.GetComponent<Image>().sprite = buttonSprite;
			/*
			child.GetComponent<SpriteSwapper>().sprite1x = buttonSprite;
			child.GetComponent<SpriteSwapper>().sprite2x = buttonSprite;
			child.GetComponent<SpriteSwapper>().sprite4x = buttonSprite;
			*/


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