using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Nextzen.VectorData;
using System.Xml.Serialization;

namespace ummisco.gama.unity.GamaAgent
{
    [XmlRoot("msi.gama.extensions.messaging.GamaMessage")]
    [XmlInclude(typeof(Content))]
    public class UnityAgent
    {
        public string unread { get; set; }
        public string sender { get; set; }
        public string receivers { get; set; }
        public int emissionTimeStamp { get; set; }
        public Content contents { get; set; }


        public UnityAgent(string agentName)
        {

        }

        public UnityAgent()
        {

        }

        public Agent GetAgent()
        {
            Agent agent = new Agent(this.contents.agentName);

            agent.isDrawed = false;
            agent.isRotate = false;
            agent.species = this.contents.species;

            agent.geometry = this.contents.geometryType;
            agent.height = this.contents.height;
            agent.color = this.contents.color;
            agent.agentCoordinate = getCoordinateSequence();

            return agent;
        }



        public GamaCoordinateSequence getCoordinateSequence()
        {
            List<GamaPoint> listPoints = new List<GamaPoint>();

            foreach (GamaPoint point in contents.vertices)
            {
                point.y = -point.y;
                listPoints.Add(point);
            }

            GamaCoordinateSequence coordinateSequence = new GamaCoordinateSequence(listPoints);
            ajustPointsList(coordinateSequence.Points);
            return coordinateSequence;
        }

        public void ajustPointsList(List<GamaPoint> list)
        {
            if ((this.contents.geometryType.Equals(IGeometry.POLYGON)) & (list.Count >= 2))
            {
                list.Remove(list[list.Count - 1]);
            }

        }
    }

    [XmlRoot("UnityAgent")]
    public class Content
    {
        [XmlElement("agentName")]
        public string agentName { get; set; }
        [XmlElement("species")]
        public string species { get; set; }
        [XmlElement("geometryType")]
        public string geometryType { get; set; }
        public List<GamaPoint> vertices { get; set; }
        public GamaColor color { get; set; }
        [XmlElement("height")]
        public float height { get; set; }

        public Content()
        {

        }
    }







}

