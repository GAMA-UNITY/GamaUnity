using System.Collections;
using UnityEngine;
using ummisco.gama.unity.littosim;
using ummisco.gama.unity.datastructure;
using ummisco.gama.unity.geometry;
using System.Collections.Generic;
using ummisco.gama.unity.Scene;

namespace ummisco.gama.unity.GamaAgent
{
    public class Agent : MonoBehaviour

    {
        private string _geometry;

        public string AgentName;
        public GamaCoordinateSequence AgentCoordinate;
        public GamaColor Color;
        public Vector3 Rotation;
        public Vector3 Location;
        public Vector3 InitialLocation;
        public Vector3 Scale;
        public bool IsRotate;
        public bool IsOnInputMove;
        public Rigidbody Rb;
        public float Speed;
        public string Species;
        public int Index;
        public string Nature;
        public string Geometry;
        public List<AgentAttribute> Attributes;
        public string Type;
        public float Height;
        public bool IsDrawed;


        public Agent(string agentName)
        {
            this.AgentName = agentName;
            this.IsDrawed = false;
            this.Height = 0.0f;
        }

        public Vector2[] ConvertVertices()
        {
            Vector3[] vertices = this.AgentCoordinate.GetVector3Coordinates();
            Vector2[] newVertices = new Vector2[vertices.Length];

            GameObject uiManager = GameObject.Find(IUILittoSim.UI_MANAGER);
            Canvas canvas = GameObject.Find("MapCanvas").GetComponent<Canvas>();

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 vect = vertices[i];
                Vector3 p = UIManager.worldToUISpace(canvas, vect);
                Vector2 p2 = p;
                newVertices[i] = p2;
            }
            return newVertices;
        }

        public Agent()
        {
            this.IsDrawed = false;
            this.Height = 0.0f;
        }

        public string GetCollection()
        {
            if (Species != null) return Species;

            switch (Geometry)
            {
                case IGeometry.POLYGON:
                    return "buildings";
                case IGeometry.LINESTRING:
                    return "raouds";
                case IGeometry.POINT:
                    return "objects";
                case IGeometry.WATER:
                    return "water";
                case IGeometry.LANDUSE:
                    return "landuse";
                default:
                    return IGeometry.EARTH;
            }
        }

        public string GetLayer()
        {

            switch (Geometry)
            {
                case IGeometry.POLYGON:
                    return "Buildings";
                case IGeometry.LINESTRING:
                    return "Raouds";
                case IGeometry.POINT:
                    return "Objects";
                case IGeometry.WATER:
                    return "Water";
                case IGeometry.LANDUSE:
                    return "Landuse";
                default:
                    return IGeometry.EARTH;
            }
        }

        public string GetAttributeValue(string atName)
        {
            foreach (AgentAttribute attr in Attributes)
            {
                if (attr.name.Equals(atName))
                {
                    return attr.value;
                }
            }
            return null;
        }


        public void SetAttributes(Agent agent)
        {
            this.name = agent.AgentName;
            this.AgentCoordinate = agent.AgentCoordinate;
            this.Color = agent.Color;
            this.Rotation = agent.Rotation;
            this.Location = TransformGamaCoordinates(agent.Location);
            this.InitialLocation = agent.Location;
            this.Scale = agent.Scale;
            this.IsRotate = agent.IsRotate;
            this.IsOnInputMove = agent.IsOnInputMove;
            this.Rb = agent.Rb;
            this.Speed = agent.Speed;
            this.Species = agent.Species;
            this.Index = agent.Index;
            this.Nature = agent.Nature;
            this.Geometry = agent.Geometry;
            this.Attributes = agent.Attributes;
            this.Height = agent.Height;
            
            Debug.Log(agent.AgentName+ " -----------> Agent color is " + agent.Color.value);
        }

        public Vector3 TransformGamaCoordinates(Vector3 gamaPoint)
        {
            return new Vector3(IGamaManager.x_axis_transform * gamaPoint.x, IGamaManager.y_axis_transform * gamaPoint.y, IGamaManager.z_axis_transform * gamaPoint.z);
        }

        public void InitAgent(RectTransform rtParent, bool elevate, float zAxis)
        {
            SetMeshVerticesPosition(rtParent, elevate, zAxis);
        }


        public void SetMeshVerticesPosition(RectTransform rtParent, bool elevate, float zAxis)
        {
            float elvation = elevate ? this.Height : 0;
            transform.SetParent(rtParent);
            transform.localPosition = new Vector3(this.Location.x, this.Location.y, zAxis);
                       

            MeshCreator meshCreator = new MeshCreator();
            MeshRenderer meshRenderer = (MeshRenderer)gameObject.AddComponent(typeof(MeshRenderer));
            MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));

            meshFilter.mesh.Clear();
            meshFilter.mesh = meshCreator.CreateMesh2(elvation, this.AgentCoordinate.GetVector2Coordinates(), this.InitialLocation);
            meshFilter.mesh.name = "CustomMesh";

            Material mat = new Material(Shader.Find("Specular"))
            {
                color = this.Color.GetRgb()
            };

            meshRenderer.material = mat;
            //meshCollider.sharedMesh = meshFilter.mesh;
            transform.localRotation = Quaternion.Euler(0, 0, 180);

            gameObject.AddComponent<MeshCollider>();
        }


        public Vector3 GetLocation()
        {
            return IGamaManager.TransformGamaLocation(Location);
        }
               
    }
}

