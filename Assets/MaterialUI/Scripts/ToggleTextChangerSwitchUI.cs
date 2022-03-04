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
public class ToggleTextChangerSwitchUI: MonoBehaviour
{
	private Text thisText;

	public GameObject switchObj; 
	
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
			
			switchObj.GetComponent<SwitchAction>().actionCode = 1;
			Debug.Log("You have clicked the switch box '"+ switchObj.GetComponent<SwitchAction>().switchId +
				"' ! Toggle is On. The action code is : " + switchObj.GetComponent<SwitchAction>().actionCode);

			UIActionMessage msg = new UIActionMessage(switchObj.GetComponent<SwitchAction>().switchId,
				switchObj.GetComponent<SwitchAction>().actionCode, switchObj.GetComponent<SwitchAction>().topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is (SwitchBox) : " + serial);

		} else {
			thisText.text = offText;
			switchObj.GetComponent<CheckBoxAction>().actionCode = 0;
			Debug.Log("You have clicked the switch box '" + switchObj.GetComponent<SwitchAction>().switchId +
				"' ! Toggle is On. The action code is : "+ switchObj.GetComponent<SwitchAction>().actionCode);
			UIActionMessage msg = new UIActionMessage(switchObj.GetComponent<SwitchAction>().switchId,
				switchObj.GetComponent<SwitchAction>().actionCode, switchObj.GetComponent<SwitchAction>().topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is :  (SwitchBox)" + serial);
		}
		
	}



	public void ToggleText()
	{
		bool isToggledOn = switchObj.GetComponent<SwitchAction>().isToggledOn;

		if (isToggledOn) {
			thisText.text = onText;
			switchObj.GetComponent<SwitchAction>().actionCode = 1;
			Debug.Log("You have clicked the switch box '" + switchObj.GetComponent<SwitchAction>().switchId +
				"' ! Toggle is On. The action code is : " + switchObj.GetComponent<SwitchAction>().actionCode);

			UIActionMessage msg = new UIActionMessage(switchObj.GetComponent<SwitchAction>().switchId,
				switchObj.GetComponent<SwitchAction>().actionCode, switchObj.GetComponent<SwitchAction>().topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is (SwitchBox) : " + serial);

			switchObj.GetComponent<SwitchAction>().SetToggledOn(false);
		} else {
			thisText.text = offText;
			switchObj.GetComponent<SwitchAction>().actionCode = 0;
			Debug.Log("You have clicked the switch box '" + switchObj.GetComponent<SwitchAction>().switchId +
				"' ! Toggle is On. The action code is : " + switchObj.GetComponent<SwitchAction>().actionCode);
			UIActionMessage msg = new UIActionMessage(switchObj.GetComponent<SwitchAction>().switchId,
				switchObj.GetComponent<SwitchAction>().actionCode, switchObj.GetComponent<SwitchAction>().topic);
			string serial = WoxSerializer.serializeObject(msg);
			Debug.Log("Serialized Object is :  (SwitchBox)" + serial);

			switchObj.GetComponent<SwitchAction>().SetToggledOn(true);
		}

	}


	public void SetToggleTextChanger()
	{
		this.onText = switchObj.GetComponent<SwitchAction>().text_on;
		this.offText = switchObj.GetComponent<SwitchAction>().text_off;
	}
}
