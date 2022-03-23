using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using wox.serial;
using System;

namespace MaterialUI.UIElements
{
	public class UIButton : UIElement, IUIWithAction<int>
	{
		public Button _Button;
		public string text { get; set; }

		public string Topic { get; set; }

		public int ActionCode { get; set; }


		public UIButton(GameObject parent, string uiId, Vector3 position, float height, float width, float size, int state) : base(parent, uiId, position, height, width, size, state)
		{

		}

		void Start()
		{
			Button btn = _Button.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}

		void TaskOnClick()
		{
			Debug.Log("You have clicked the mono action button (" + UiId + ")! The action code is : " + ActionCode);
			UIActionMessage msg = new UIActionMessage(UiId, ActionCode, Topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is : " + serial);
			GameObject.Find("MainUIManager").GetComponent<MainUIManager>().connector.Publish(Topic, serial);
		}

		public void SetButton(string _topic, GameObject _parent, string _buttonId, Vector3 _position, float _heigth, float _width, string _text, int _actionCode, float _size, int _state)
		{
			SetTopic(_topic);
			SetButton(_parent, _buttonId, _position, _heigth, _width, _text, _actionCode, _size, _state);
		}

		public void SetButton(GameObject _parent, string _buttonId, Vector3 _position, float _heigth, float _width, string _text, int _actionCode, float _size, int _state)
		{
			base.Group_parent = _parent;
			base.UiId = _buttonId;
			base.Position = _position;
			base.Height = _heigth;
			base.Width = _width;
			this.text = _text;
			this.ActionCode = _actionCode;
			base.Size = _size;
			base.State = _state;

			base.SetId(_buttonId);
			base.SetSize(Size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			base.SetLabel(_text);


		}

	

		public void SetText(string _text)
		{
			gameObject.GetComponentInChildren<Text>().text = _text;
		}

		public void SetActionCode(int _actionCode)
		{
			this.ActionCode = _actionCode;
		}




		public void SetTopic(string _topic)
		{
			this.Topic = _topic;
		}

		public new void SetLabel(string _text)
		{
			gameObject.GetComponentInChildren<Text>().text = _text;
		}
	}	
}

