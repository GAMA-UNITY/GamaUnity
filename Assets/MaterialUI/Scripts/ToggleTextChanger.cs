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
		
		if (isToggledOn) {
			thisText.text = onText;
			checkBoxObj.GetComponent<CheckBoxAction>().actionCode = 1;
			Debug.Log("You have clicked the checkbox '"+ checkBoxObj.GetComponent<CheckBoxAction>().checkBoxId +
				"' ! Toggle is On. The action code is : " + checkBoxObj.GetComponent<CheckBoxAction>().actionCode);

			UIActionMessage msg = new UIActionMessage(checkBoxObj.GetComponent<CheckBoxAction>().checkBoxId,
				checkBoxObj.GetComponent<CheckBoxAction>().actionCode, checkBoxObj.GetComponent<CheckBoxAction>().topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is : " + serial);

		} else {
			thisText.text = offText;
			checkBoxObj.GetComponent<CheckBoxAction>().actionCode = 0;
			Debug.Log("You have clicked the checkbox '" + checkBoxObj.GetComponent<CheckBoxAction>().checkBoxId +
				"' ! Toggle is On. The action code is : "+ checkBoxObj.GetComponent<CheckBoxAction>().actionCode);
			UIActionMessage msg = new UIActionMessage(checkBoxObj.GetComponent<CheckBoxAction>().checkBoxId,
				checkBoxObj.GetComponent<CheckBoxAction>().actionCode, checkBoxObj.GetComponent<CheckBoxAction>().topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is : " + serial);
		}
		
	}


	public void SetToggleTextChanger()
	{
		this.onText = checkBoxObj.GetComponent<CheckBoxAction>().text_on;
		this.offText = checkBoxObj.GetComponent<CheckBoxAction>().text_off;
	}
}
