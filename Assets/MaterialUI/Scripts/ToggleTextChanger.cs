//  Copyright 2014 Invex Games http://invexgames.com
//	Licensed under the Apache License, Version 2.0 (the "License");
//	you may not use this file except in compliance with the License.
//	You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//	Unless required by applicable law or agreed to in writing, software
//	distributed under the License is distributed on an "AS IS" BASIS,
//	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//	See the License for the specific language governing permissions and
//	limitations under the License.

using MaterialUI;
using UnityEngine;
using UnityEngine.UI;
using wox.serial;

[ExecuteInEditMode]
public class ToggleTextChanger : MonoBehaviour
{
	private Text thisText;

	public GameObject checkBoxObj; 
	
	public string onText;
	public string offText;


	void Awake ()
	{
		thisText = gameObject.GetComponent<Text>();
	}


	public void ToggleText(bool isToggledOn)
	{
		string topic = checkBoxObj.GetComponent<CheckBoxAction>().topic;
		
		if (isToggledOn) {
			thisText.text = onText;
	
			Debug.Log("You have clicked the checkbox '"+ checkBoxObj.GetComponent<CheckBoxAction>().checkBoxId +
				"' ! Toggle is On. The action code is : " + checkBoxObj.GetComponent<CheckBoxAction>().GetActionOn());

			UIActionMessage msg = new UIActionMessage(checkBoxObj.GetComponent<CheckBoxAction>().checkBoxId,
				checkBoxObj.GetComponent<CheckBoxAction>().GetActionOn(), topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is : " + serial);
			GameObject.Find("MainUIManager").GetComponent<MainUIManager>().connector.Publish(topic, serial);

		} else {
			thisText.text = offText;
			Debug.Log("You have clicked the checkbox '" + checkBoxObj.GetComponent<CheckBoxAction>().checkBoxId +
				"' ! Toggle is On. The action code is : "+ checkBoxObj.GetComponent<CheckBoxAction>().GetActionOff());
			UIActionMessage msg = new UIActionMessage(checkBoxObj.GetComponent<CheckBoxAction>().checkBoxId,
				checkBoxObj.GetComponent<CheckBoxAction>().GetActionOff(), topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is : " + serial);
			GameObject.Find("MainUIManager").GetComponent<MainUIManager>().connector.Publish(topic, serial);
		}
		
	}


	public void SetToggleTextChanger()
	{
		this.onText = checkBoxObj.GetComponent<CheckBoxAction>().GetTextOn();
		this.offText = checkBoxObj.GetComponent<CheckBoxAction>().GetTextOff();
	}
}
