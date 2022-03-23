using UnityEngine;
using System.Collections;

namespace MaterialUI.UIElements
{
	public class UITextInput : UIElement, IUIWithAction<string>
	{
		public string Topic { get; set; }
		public string ActionCode { get; set; }

		public UITextInput(GameObject parent, string uiId, Vector3 position, float height, float width, float size, int state) : base(parent, uiId, position, height, width, size, state)
		{

		}
		
		public void SetTopic(string _topic)
		{
			this.Topic = _topic;
		}
	}
}

