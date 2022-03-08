using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using wox.serial;

namespace MaterialUI
{
	public class ButtonAction : MonoBehaviour
	{
		public GameObject parent;
		public Button _Button;
		public string topic = DefaultSettings.DEFAULT_TOPIC;
		public string buttonId = "";
		public Vector3 position = new Vector3(0,0,0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string text = "Button";
		public int actionCode = 0;
		public float size = 1; // the scale
		public int state = 1;

		void Start()
		{
			Button btn = _Button.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}

		void TaskOnClick()
		{
			Debug.Log("You have clicked the mono action button (" + buttonId + ")! The action code is : " + actionCode);
			UIActionMessage msg = new UIActionMessage(buttonId, actionCode, topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is : " + serial);
			GameObject.Find("MainUIManager").GetComponent<MainUIManager>().connector.Publish(topic, serial);
		}
	
		public void SetButton(string _topic, GameObject _parent, string _buttonId, Vector3 _position, float _heigth, float _width, string _text, int _actionCode, float _size, int _state)
		{
			SetTopic(_topic);
			SetButton(_parent, _buttonId, _position, _heigth, _width, _text, _actionCode, _size, _state);
		}

			public void SetButton(GameObject _parent, string _buttonId, Vector3 _position, float _heigth, float _width, string _text, int _actionCode, float _size, int _state)
		{
			this.parent = _parent;
			this.buttonId = _buttonId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.text = _text;
			this.actionCode = _actionCode;
			this.size = _size;
			this.state = _state;

			SetId(_buttonId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetText(_text);


		}

		public void SetTopic(string _topic)
		{
			this.topic = _topic;
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

		public void SetText(string _text)
		{
			gameObject.GetComponentInChildren<Text>().text = _text;
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