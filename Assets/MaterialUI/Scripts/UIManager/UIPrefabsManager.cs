using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaterialUI
{
    public class UIPrefabsManager : MonoBehaviour
    {
        public GameObject App_Bar;
        public GameObject Background;
        public GameObject Button_Flat;
        public GameObject Button_Raised;
        public GameObject Canvas;
        public GameObject Checkbox;
        public GameObject DialogBox_Normal;
        public GameObject DialogBox_Scroll;

        public GameObject DialogBox_Simple;
        public GameObject Divider_Dark;
        public GameObject Divider_Light;
        public GameObject EventSystem;
        public GameObject Nav_Drawer;
        public GameObject Panel;
        public GameObject RadioGroup;
        public GameObject Round_Button_Flat;
        public GameObject Round_Button_Raised;
        public GameObject Round_Button_Small_Flat;
        public GameObject Round_Button_Small_Raised;
        public GameObject Screen_;
        public GameObject ScreenManager;
        public GameObject SelectionBox_Flat;
        public GameObject SelectionBox;
        public GameObject Slider;
        public GameObject Slider_label;
        public GameObject Slider_label_value;
        public GameObject SpinnyArrow_Button;
        public GameObject Switch;
        public GameObject Text;
        public GameObject TextInput;

        public GameObject List_Item_Double_Avatar;
        public GameObject List_Item_Double_Icon_Avatar;
        public GameObject List_Item_Double_Icon;
        public GameObject List_Item_Double;
        public GameObject List_Item_Single_Avatar;
        public GameObject List_Item_Single_Icon_Avatar;
        public GameObject List_Item_Single_Icon;
        public GameObject List_Item_Single;
        public GameObject List_Item_Triple_Avatar;
        public GameObject List_Item_Triple_Icon_Avatar;
        public GameObject List_Item_Triple_Icon;
        public GameObject List_Item_Triple;
        public GameObject ListView;
        public GameObject Subheader;
        public GameObject UnderShadow;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(20, 250, 200, 20), "Send to listen")) {

            }
        }
    }
}
