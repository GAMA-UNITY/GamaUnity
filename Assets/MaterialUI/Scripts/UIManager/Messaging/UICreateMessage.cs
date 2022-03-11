using System;
using System.Collections;
using UnityEngine;

namespace MaterialUI
{
	public class UICreateMessage
	{
		public string topic;
		public string uiType;
		public string parent;
		public string uiId;
		public float x;
		public float y;
		public float z;
		public float height;
		public float width;
		public string label;
		public string content_text;

		public Hashtable option_action = new Hashtable();

		public int size;
		public int state;

		public UICreateMessage()
		{


		}

		public void printClass()
		{
			Debug.Log("--> topic : " + topic);
			Debug.Log("--> uiType : " + uiType);
			Debug.Log("--> parent : " + parent);
			Debug.Log("--> uiId : " + uiId);
			Debug.Log("--> x : " + x);
			Debug.Log("--> y : " + y);
			Debug.Log("--> z : " + z);
			Debug.Log("--> height : " + height);
			Debug.Log("--> width : " + width);
			Debug.Log("--> label : " + label);
			Debug.Log("--> content_text : " + content_text);
					
			string str = "";
		
			Debug.Log("--> option_label : " + str);

			str = "";
			foreach (DictionaryEntry st in option_action) {
				str += " \n      - key= " + st.Key + " value= " + st.Value;
			}
			Debug.Log("--> option_action : " + str);
			Debug.Log("--> size : " + size);
			Debug.Log("--> state : " + state);
		}
	}
}
