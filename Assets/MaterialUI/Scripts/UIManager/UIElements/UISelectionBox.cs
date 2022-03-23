using UnityEngine;
using System.Collections;

namespace MaterialUI.UIElements
{
	public class UISelectionBox : UIElement, IUIWithAction<int>
	{
		public string Topic { get; set; }
		public int ActionCode { get; set;}

		public UISelectionBox(GameObject parent, string uiId, Vector3 position, float height, float width, float size, int state) : base(parent, uiId, position, height, width, size, state)
		{

		}
		
		public void SetTopic(string _topic)
		{
			this.Topic = _topic;
		}
	}
}

