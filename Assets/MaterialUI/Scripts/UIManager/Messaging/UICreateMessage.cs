using System;
using System.Collections;
using ummisco.gama.unity.datastructure;
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

		public int redColor;
		public int greenColor;
		public int blueColor;
		public int alphaColor;

		public string content_text;

		public Hashtable option_action = new Hashtable();

		public int size;
		public int state;

		public UICreateMessage()
		{


		}

		public RGBColor GetRGBColor() {

			//if(redColor != 255 && greenColor != 0 && blueColor != 255) { 
				int red_color = redColor; //!= 0 ? redColor : 255;
				int green_color = greenColor; // != 0 ? greenColor : 255; ;
				int blue_color = blueColor; // != 0 ? blueColor : 255; ;
				int alpha_color = alphaColor; // != 0 ? alphaColor : 255; ;
				RGBColor rbgColor = new RGBColor(red_color, green_color, blue_color, alpha_color);
				return rbgColor;
			//}
			//return new RGBColor(255, 255, 255, 255);	
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

			Debug.Log("--> redColor : " + redColor);
			Debug.Log("--> greenColor : " + greenColor);
			Debug.Log("--> blueColor : " + blueColor);
			Debug.Log("--> alphaColor : " + alphaColor);
	

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
