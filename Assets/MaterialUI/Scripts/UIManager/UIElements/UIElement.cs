
using UnityEngine;
using System.Collections;

namespace MaterialUI.UIElements
{
	public abstract class UIElement : MonoBehaviour
	{
		public GameObject Group_parent { get; set; } // group parent. 
		public string UiId { get; set; }
		public Vector3 Position { get; set; }
		public float Height { get; set; }
		public float Width { get; set; }
		public float Size { get; set; }
		public int State { get; set; }
		public Color Color_ { get; set; }
		
		public UIElement(GameObject group_parent, string uiId, Vector3 position, float height, float width, float size, int state)
		{
			this.Group_parent = group_parent;
			this.UiId = uiId;
			this.Position = position;
			this.Height = height;
			this.Width = width;
			this.Size = size;
			this.State = state;
			Initialized();
		}

		public void Initialized()
		{
			SetParent(Group_parent);
			SetId(UiId);
			SetPosition(Position);
			SetHeigth(Height);
			SetWidth(Width);


		}
		public void SetParent(GameObject _group_parent)
		{
			if (Group_parent != null)
				gameObject.transform.SetParent(Group_parent.transform);
		}
		public void SetId(string _uiId)
		{
			gameObject.name = "parent_" + _uiId;
		}

		public void SetPosition(Vector3 _position)
		{
			RectTransform m_RectTransform = gameObject.GetComponent<RectTransform>();
			SetRecTransformDefault(m_RectTransform);
			m_RectTransform.anchoredPosition = _position;
		}

		public void SetSize(float _size)
		{
			if(_size != 1) {
				Group_parent.transform.localScale = new Vector3(_size, _size, _size);
			}			
		}
		public void SetHeigth(float _height)
		{
			if (_height != 0.0) {
				RectTransform rt = (RectTransform)Group_parent.transform;
				float width = rt.rect.width;
				rt.sizeDelta = new Vector2(width, _height);
			}
		}

		public void SetWidth(float _width)
		{
			if(_width != 0.0) {
				RectTransform rt = (RectTransform)Group_parent.transform;
				float height = rt.rect.height;
				rt.sizeDelta = new Vector2(_width, height);
			}
			
		}

		public void SetWidthHeigth(float _width, float _height)
		{
			if (_height != 0.0 && _width != 0.0) {
				RectTransform rt = (RectTransform)Group_parent.transform;
				rt.sizeDelta = new Vector2(_width, _height);
			}
		}

		public void SetLabel(string _label)
		{

		}
		public void SetColor(Color _color)
		{

		}

		public void SetState(int _state)
		{

		}


		void SetRecTransformDefault(RectTransform _mRect)
		{
			_mRect.anchorMin = new Vector2(0, 1);
			_mRect.anchorMax = new Vector2(0, 1);
			_mRect.pivot = new Vector2(0.5f, 0.5f);
		}
	}
}
