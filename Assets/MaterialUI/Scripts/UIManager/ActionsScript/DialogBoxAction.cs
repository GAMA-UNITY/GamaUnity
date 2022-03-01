using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace MaterialUI
{
	public class DialogBoxAction : MonoBehaviour
	{
		public GameObject parent;
		public GameObject dialogTitleObject;
		public GameObject dialogContentObject;
		public GameObject buttonYes;
		public GameObject buttonNo;
		

		public string dialogBoxId = "";
		
		
		public Vector3 position = new Vector3(0,0,0);
		public float height = 0.0f;
		public float width = 0.0f;
		public string title = "Dialog Box Title";
		public string text = "Dialog Box body text. Dialog Box body text 1. Dialog Box body text 2. Dialog Box body text 3. Dialog Box body text 4. ";
		public string buttonYesText = "Yes";
		public string buttonNoText = "No";
		public int actionCode = 0;
		public float size = 1; // the scale
		public int state = 1;

		void Start()
		{
			
		}

	
		public void SetDialogBox(GameObject _parent, string _dialogBoxId, Vector3 _position, float _heigth, float _width, string _dialog_title, string _dialog_content, string _text_yes, string _text_no, int _actionCode, float _size, int _state)
		{
			this.parent = _parent;
			this.dialogBoxId = _dialogBoxId;
			this.position = _position;
			this.height = _heigth;
			this.width = _width;
			this.title = _dialog_title;
			this.text = _dialog_content;
			this.buttonYesText = _text_yes;
			this.buttonNoText = _text_no;
			this.actionCode = _actionCode;
			this.size = _size;
			this.state = _state;

			SetId(dialogBoxId);
			SetSize(_size);
			//SetHeigth(_heigth);
			//SetWidth(_width);
			SetDialogTitleText(_dialog_title);
			SetDialogContentText(_dialog_content);
			SetButtonYesNoText(_text_yes, _text_no);


		}

		public void SetParent(GameObject _parent)
		{
			this.parent = _parent;
		}

		public void SetId(string _dialogBoxId)
		{
			gameObject.name = _dialogBoxId;
		}

		public void SetHeigth(float _height)
		{
			RectTransform rt = (RectTransform)parent.transform;
			float width = rt.rect.width;
			rt.sizeDelta = new Vector2(width, _height);
		}

		public void SetWidth(float _width)
		{
			RectTransform rt = (RectTransform)parent.transform;
			float height = rt.rect.height;
			rt.sizeDelta = new Vector2(_width, height);
		}

		public void SetWidthHeigth(float _width, float _height)
		{
			RectTransform rt = (RectTransform)parent.transform;
			rt.sizeDelta = new Vector2(_width, _height);
		}

		public void SetDialogTitleText(string dialog_title)
		{
			dialogTitleObject.GetComponent<Text>().text = dialog_title;
		}

		public void SetDialogContentText(string dialog_content)
		{
			dialogContentObject.GetComponent<Text>().text = dialog_content;
		}

		public void SetButtonYesNoText(string _text_yes, string _text_no)
		{
			buttonYes.GetComponent<Text>().text = _text_yes;
			buttonNo.GetComponent<Text>().text = _text_no;
		}



		public void SetActionCode(int _actionCode)
		{
			this.actionCode = _actionCode;
		}

		public void SetSize(float _size)
		{
			parent.transform.localScale = new Vector3(_size, _size, _size);
		}

		public void SetState(int _state)
		{
			this.state = _state;
		}

	}
}