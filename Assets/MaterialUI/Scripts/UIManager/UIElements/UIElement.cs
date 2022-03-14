
using UnityEngine;
using System.Collections;

namespace MaterialUI.UIElements
{
	public abstract class UIElement : MonoBehaviour
	{
		public GameObject parent { get; set; }
		public string uiId { get; set; }
		public Vector3 position { get; set; }
		public float height { get; set; }
		public float width { get; set; }
		public float size { get; set; }
		public int state { get; set; }
		public Color color { get; set; }
		
		public UIElement(GameObject parent, string uiId, Vector3 position, float height, float width, float size, int state)
		{
			this.parent = parent;
			this.uiId = uiId;
			this.position = position;
			this.height = height;
			this.width = width;
			this.size = size;
			this.state = state;
			Initialized();
		}

		public void Initialized()
		{
			SetParent(parent);
			SetId(uiId);
			SetPosition(position);

		}
		public void SetParent(GameObject _parent)
		{
			if (parent != null)
				gameObject.transform.SetParent(parent.transform);
		}
		void SetId(string _uiId)
		{
			gameObject.name = "parent_" + _uiId;
		}

		public void SetPosition(Vector3 _position)
		{
			RectTransform m_RectTransform = gameObject.GetComponent<RectTransform>();
			SetRecTransformDefault(m_RectTransform);
			m_RectTransform.anchoredPosition = _position;
		}

		public void SetSize(int _size)
		{
			parent.transform.localScale = new Vector3(_size, _size, _size);
		}
		public void SetHeigth(float _height)
		{
			RectTransform rt = (RectTransform)parent.transform;
			float width = rt.rect.width;
			rt.sizeDelta = new Vector2(width, _height);
		}

		public void SetWidth(float _width)
		{
			if(_width != 0.0) {
				RectTransform rt = (RectTransform)parent.transform;
				float height = rt.rect.height;
				rt.sizeDelta = new Vector2(_width, height);
			}
			
		}

		public void SetWidthHeigth(float _width, float _height)
		{
			RectTransform rt = (RectTransform)parent.transform;
			rt.sizeDelta = new Vector2(_width, _height);
		}

		void SetLabel(string _label)
		{

		}
		void SetColor(Color _color)
		{

		}
		
		void SetState(int _state)
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
