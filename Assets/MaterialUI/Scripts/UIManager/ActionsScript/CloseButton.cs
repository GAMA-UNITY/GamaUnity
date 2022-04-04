using UnityEngine;
using System.Collections;

public class CloseButton: MonoBehaviour
{
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void CloseApp()
	{
		// Application.Quit();
	}

	void TaskOnClick()
	{
		 Application.Quit();
	}
}
