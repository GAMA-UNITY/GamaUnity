using System;
namespace MaterialUI.UIElements
{ 
	public interface IUIWithAction
	{
		string topic { get; set; }
		void SetTopic(string _topic);
	}
}
