
using UnityEngine;
using System.Collections;

namespace MaterialUI.UIElements
{
	public abstract class UIElement : MonoBehaviour
	{
		public GameObject parent;
		public string topic = DefaultSettings.DEFAULT_TOPIC;
		public string ElementId = "";
		public Vector3 position = new Vector3(0, 0, 0);
		public float height = 0.0f;
		public float width = 0.0f;
		public float size = 1; // the scale
		public int state = 1;

		public UIElement(GameObject parent, string topic, string elementId, Vector3 position, float height, float width, float size, int state)
		{
			this.parent = parent;
			this.topic = topic;
			this.ElementId = elementId;
			this.position = position;
			this.height = height;
			this.width = width;
			this.size = size;
			this.state = state;
		}


		//public abstract void afficheCaracteristiques();

		// Use this for initialization
		void Start()
		{

		}
	
			// Update is called once per 
		
		void Update()
		{

		}
	}
}
