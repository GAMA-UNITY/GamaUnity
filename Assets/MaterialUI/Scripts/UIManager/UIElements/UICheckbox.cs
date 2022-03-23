using UnityEngine;
using System.Collections;

namespace MaterialUI.UIElements
{
	public class UICheckbox : UIElement, IUIWithAction<bool>
	{
		public string Topic { get; set; }
		public bool ActionCode { get; set; }

		public UICheckbox(GameObject parent, string uiId, Vector3 position, float height, float width, float size, int state) : base(parent, uiId, position, height, width, size, state)
		{

		}

		public void SetTopic(string _topic)
		{
			this.Topic = _topic;
		}

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		
	}
}
