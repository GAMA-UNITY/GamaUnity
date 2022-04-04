using System;
using System.Xml.Serialization;
using UnityEngine;

namespace ummisco.gama.unity.datastructure
{
   
    public struct RGBColor
    {

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Alpha { get; set; }

        public RGBColor(int red, int green, int blue, int alpha)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Alpha = alpha;
        }


        public string ToString()
		{
            return (" Red : " + Red + " Green : " + Green + " Blue : " + Blue + " Alpha : " + Alpha);
		}

        public Color GetRGBColor()
		{
            return new Color(Red / 255f, Green / 255f, Blue / 255f, Alpha / 255f);

        }
    }
}