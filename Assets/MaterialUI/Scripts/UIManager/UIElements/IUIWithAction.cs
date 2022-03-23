using System;
namespace MaterialUI.UIElements
{ 
	public interface IUIWithAction<T>
	{
		string Topic { get; set; }

		T ActionCode { get; set; }

		void SetTopic(string _topic);
	}
}
