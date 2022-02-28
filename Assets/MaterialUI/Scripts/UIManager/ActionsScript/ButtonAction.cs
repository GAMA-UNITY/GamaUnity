using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace MaterialUI
{
	public class ButtonAction : MonoBehaviour
	{
		public Button _Button;
		public string buttonId = "";
		public Vector3 position = new Vector3(0,0,0);
		public float height = 0.0f;
		public float length = 0.0f;
		public string text = "Button";
		public int actionCode = 0;
		public int state = 1;

		void Start()
		{
			Button btn = _Button.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}

		void TaskOnClick()
		{
			Debug.Log("You have clicked the mono action button! The action code is : "+ actionCode);
		}

		public void SetButton(string _buttonId, Vector3 _position, float _heigth, float _length, string _text, int _actionCode, int _state)
		{
			this.buttonId = _buttonId;
			this.position = _position;
			this.height = _heigth;
			this.length = _length;
			this.text = _text;
			this.actionCode = _actionCode;
			this.state = _state;

			gameObject.name = buttonId;
		}
	}
}