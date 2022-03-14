using UnityEngine;
using System.Collections;

namespace MaterialUI.UIElements
{
	public class UISlider : UIElement, IUIWithAction
	{
		public string topic { get; set; }

		public UISlider(GameObject parent, string uiId, Vector3 position, float height, float width, float size, int state) : base(parent, uiId, position, height, width, size, state)
		{

		}
		
		public void SetTopic(string _topic)
		{
			this.topic = _topic;
		}
	}
}

