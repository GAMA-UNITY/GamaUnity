﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ummisco.gama.unity.littosim
{
    public class UIManager : MonoBehaviour
    {
        public static string activePanel = IUILittoSim.UA_PANEL;

        private Sprite selectedOnglet;
        private Sprite notSelectedOnglet;

        public UIManager()
        {

        }
        void Awake()
        {
            activePanel = IUILittoSim.UA_PANEL;
            selectedOnglet = Resources.Load<Sprite>("images/ihm/onglet_selectionne");
            notSelectedOnglet = Resources.Load<Sprite>("images/ihm/onglet_non_selectionne");
    }

        void Start()
        {
            setActivePanel(IUILittoSim.ONGLET_AMENAGEMENT);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void SetUp()
        {

        }

        public void setActivePanel(string panelName)
        {
            if (panelName.Equals(IUILittoSim.ONGLET_AMENAGEMENT))
            {
                setCanvasVisible(IUILittoSim.UA_PANEL);
                setCanvasVisible(IUILittoSim.UA_MAP_PANEL);
                setCanvasInvisible(IUILittoSim.DEF_COTE_PANEL);
                setCanvasInvisible(IUILittoSim.DEF_COTE_MAP_PANEL);

                SetSpriteSelected(IUILittoSim.ONGLET_AMENAGEMENT);

                SetTargetInvisible(GameObject.Find(IUILittoSim.DEF_COTE_PANEL));
                SetTargetInvisible(GameObject.Find(IUILittoSim.DEF_COTE_MAP_PANEL));
                SetTargetVisible(GameObject.Find(IUILittoSim.UA_PANEL));
                SetTargetVisible(GameObject.Find(IUILittoSim.UA_MAP_PANEL));

                SetSpriteDeselected(IUILittoSim.ONGLET_DEFENSE);

                activePanel = IUILittoSim.UA_PANEL;

            }
            else if (panelName.Equals(IUILittoSim.ONGLET_DEFENSE))
            {
                setCanvasVisible(IUILittoSim.DEF_COTE_PANEL);
                setCanvasVisible(IUILittoSim.DEF_COTE_MAP_PANEL);
                setCanvasInvisible(IUILittoSim.UA_PANEL);
                setCanvasInvisible(IUILittoSim.UA_MAP_PANEL);

                SetSpriteSelected(IUILittoSim.ONGLET_DEFENSE);

                SetTargetInvisible(GameObject.Find(IUILittoSim.UA_PANEL));
                SetTargetInvisible(GameObject.Find(IUILittoSim.UA_MAP_PANEL));
                SetTargetVisible(GameObject.Find(IUILittoSim.DEF_COTE_PANEL));
                SetTargetVisible(GameObject.Find(IUILittoSim.DEF_COTE_MAP_PANEL));

                SetSpriteDeselected(IUILittoSim.ONGLET_AMENAGEMENT);

                activePanel = IUILittoSim.DEF_COTE_PANEL;
            }
        }


        public void SetSpriteSelected(string ongletName)
        {
            GameObject.Find(ongletName).GetComponent<Image>().sprite = selectedOnglet;
        }

        public void SetSpriteDeselected(string ongletName)
        {
            GameObject.Find(ongletName).GetComponent<Image>().sprite = notSelectedOnglet;
        }

        void SetTargetInvisible(GameObject Target)
        {
            foreach (Renderer r in Target.GetComponentsInChildren(typeof(Renderer)))
            {
                r.enabled = false;
            }
        }

        void SetTargetVisible(GameObject Target)
        {
            foreach (Renderer r in Target.GetComponentsInChildren(typeof(Renderer)))
            {
                r.enabled = true;
            }
        }

        public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
        {
            Vector3 screenPos = worldPos;
            Vector2 movePos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);

            return parentCanvas.transform.TransformPoint(movePos);
        }

        public void setCanvasVisible(string name)
        {
            GameObject panel = GameObject.Find(name);
            CanvasGroup canvas = panel.GetComponent<CanvasGroup>();
            canvas.alpha = 1f;
            canvas.blocksRaycasts = true;
        }

        public void setCanvasInvisible(string name)
        {
            GameObject panel = GameObject.Find(name);
            CanvasGroup canvas = panel.GetComponent<CanvasGroup>();
            canvas.alpha = 0f;
            canvas.blocksRaycasts = false;
        }

        public string getActivePanel()
        {
            return activePanel;
        }

        public static string getActiveMapPanel()
        {
            if (activePanel.Equals(IUILittoSim.DEF_COTE_PANEL)) {
                return IUILittoSim.DEF_COTE_MAP_PANEL;
            }
            else
            {
                return IUILittoSim.UA_MAP_PANEL;
            }

        }

        public static void HideObject(string object_name)
        {
            Debug.Log("The introduced object name is " + object_name);
        }

        public static void HideObjectNoParameter()
        {
            Debug.Log("The Methode is without parameter ");
        }

    }
}