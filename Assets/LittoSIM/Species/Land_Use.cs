﻿using System.Collections;
using System.Collections.Generic;
using ummisco.gama.unity.GamaAgent;
using ummisco.gama.unity.utils;
using UnityEngine;
using UnityEngine.UI;

namespace ummisco.gama.unity.littosim
{
    public class Land_Use : MonoBehaviour
    {
        public int id;
        public string lu_name;
        public int lu_code;
        public string dist_code;
        public Color my_color;
        public int population;
        public float mean_alt;
        public string density_class;
        public int expro_cost;
        public bool is_urban_type;
        public bool is_adapted_type;
        public bool is_in_densification = false;
        public bool focus_on_me = false;
        public int meshElevation = 30;

        public Vector3 localScale = new Vector3(0.2f, 0.2f, 0.2f);


        private CanvasGroup cg;

        Ray ray;
        RaycastHit hit;

        // Start is called before the first frame update
        void Start()
        {
            cg = GameObject.Find("Canvas_Tips").GetComponent<CanvasGroup>();
        }

        public void UAInit(UnityAgent unityAgent)
        {
           
        }
               
        // Update is called once per frame
        void Update()
        {

        }

        public void showTip()
        {
            Debug.Log("Test is Test");
        }

        void OnMouseDown()
        {

            Debug.Log("This on mouse down -> " + gameObject.name);
        }

        void OnMouseOver()
        {

            Vector3 vect = worldToUISpace(GameObject.Find("Canvas_Tips").GetComponent<Canvas>(), Input.mousePosition);
            vect.z = -400f;
            GameObject.Find("Tips").GetComponent<RectTransform>().transform.position = vect;

            SetInfo();
            cg.interactable = true;
            cg.alpha = 1;
        }

        public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
        {
            Vector3 screenPos = worldPos;
            Vector2 movePos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);

            return parentCanvas.transform.TransformPoint(movePos);
        }

        void OnMouseExit()
        {

            ResetSetInfo();
            cg.interactable = false;
            cg.alpha = 0;

        }

        void SetInfo()
        {
            GameObject.Find("attribute_1").GetComponent<Text>().text = "ID: " + id;
            GameObject.Find("attribute_2").GetComponent<Text>().text = "Name: " + lu_name;
            GameObject.Find("attribute_3").GetComponent<Text>().text = "Code: " + lu_code;
            GameObject.Find("attribute_4").GetComponent<Text>().text = "District Code: " + dist_code;
            GameObject.Find("attribute_5").GetComponent<Text>().text = "Population: " + population;
            GameObject.Find("attribute_6").GetComponent<Text>().text = "Mean alt: " + mean_alt;

        }


        void ResetSetInfo()
        {
            GameObject.Find("attribute_1").GetComponent<Text>().text = "ID: ";
            GameObject.Find("attribute_2").GetComponent<Text>().text = "Name: ";
            GameObject.Find("attribute_3").GetComponent<Text>().text = "Code: ";
            GameObject.Find("attribute_4").GetComponent<Text>().text = "District Code: ";
            GameObject.Find("attribute_5").GetComponent<Text>().text = "Population: ";
            GameObject.Find("attribute_6").GetComponent<Text>().text = "Mean alt: ";

        }



        public Vector3 GetNewPosition()
        {
            return new Vector3(-2218, -963f, 100f);
        }

    }
}