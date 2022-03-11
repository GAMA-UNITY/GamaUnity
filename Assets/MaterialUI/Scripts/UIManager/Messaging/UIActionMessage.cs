using System;
namespace MaterialUI
{
	public class UIActionMessage
	{
		public string topic;
		public long messageTime;
		public static int msgNbr;
		public int messageNumber;
		public string elementId;
		public object actionCode;
		public string content;

		private UIActionMessage()
		{
			SetDefault();			
		}

		public UIActionMessage(string _elementId, int _actionCode) : this ()
		{
			SetElementId(_elementId);
			SetActionCode(_actionCode);
			SetContent(" ");
		}

		public UIActionMessage(string _elementId, float _actionCode) : this()
		{
			SetElementId(_elementId);
			SetActionCode(_actionCode);
			SetContent(" ");
		}

		public UIActionMessage(string _elementId, int _actionCode, string _topic): this(_elementId, _actionCode)
		{
			SetTopic(_topic);
		}

		public UIActionMessage(string _elementId, float _actionCode, string _topic) : this(_elementId, _actionCode)
		{
			SetTopic(_topic);
		}

		public UIActionMessage(string _elementId, int _actionCode, string _topic, string _content) : this(_elementId, _actionCode, _topic)
		{
			SetContent(_content);
		}

		private void SetDefault()
		{
			msgNbr++;
			messageNumber = msgNbr;
			messageTime = TimeUtils.ToUnixTimeSeconds();
			topic = DefaultSettings.DEFAULT_TOPIC;
		}

		public void SetElementId(string _elementId)
		{
			this.elementId = _elementId;
		}

		public void SetActionCode(int _actionCode)
		{
			this.actionCode = _actionCode;
		}

		public void SetActionCode(float _actionCode)
		{
			this.actionCode = _actionCode;
		}

		public void SetContent(string _content)
		{
			this.content = _content;
		}

		public void SetTopic(string _topic)
		{
			this.topic = _topic;
		}
	}
}
