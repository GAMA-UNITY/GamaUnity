﻿using System;
using System.Collections.Generic;
using System.Linq;
using ummisco.gama.unity.GamaAgent;
using ummisco.gama.unity.littosim;
using ummisco.gama.unity.utils;
using UnityEditor;
using UnityEngine;

namespace Nextzen.Unity
{
    public class SceneGraph :MonoBehaviour
    {


        // Merged mesh data for each game object group
        private Dictionary<GameObject, MeshData> gameObjectMeshData;

        // The root game object
        private GameObject regionMap;

        // Group options for grouping
        private SceneGroupType groupOptions;

        // The leaf group of the hierarchy
        private SceneGroupType leafGroup;

        // The game object options (physics, static, ...)
        private GameObjectOptions gameObjectOptions;

        // The list of feature mesh generated by the tile task
        private List<FeatureMesh> features;

        public SceneGraph(GameObject regionMap, SceneGroupType groupOptions, GameObjectOptions gameObjectOptions, List<FeatureMesh> features)
        {
            this.gameObjectMeshData = new Dictionary<GameObject, MeshData>();
            this.regionMap = regionMap;
            this.groupOptions = groupOptions;
            this.gameObjectOptions = gameObjectOptions;
            this.features = features;
            this.leafGroup = groupOptions.GetLeaf();
        }

        private GameObject AddGameObjectGroup(SceneGroupType groupType, GameObject parentGameObject, FeatureMesh featureMesh)
        {
            GameObject gameObject = null;

            string name = featureMesh.GetName(groupType);

            // No name for this group in the feature, use the parent name
            if (name.Length == 0)
            {
                name = parentGameObject.name;
            }

            Transform transform = parentGameObject.transform.Find(name);

            if (transform == null)
            {
                // No children for this name, create a new game object
                gameObject = new GameObject(name);
                gameObject.transform.parent = parentGameObject.transform;
            }
            else
            {
                // Reuse the game object found the the group name in the hierarchy
                gameObject = transform.gameObject;
            }


            return gameObject;
        }

        private void MergeMeshData(GameObject gameObject, FeatureMesh featureMesh)
        {
            // Merge the mesh data from the feature for the game object
            if (gameObjectMeshData.ContainsKey(gameObject))
            {
                gameObjectMeshData[gameObject].Merge(featureMesh.Mesh);
            }
            else
            {
                MeshData data = new MeshData();
                data.Merge(featureMesh.Mesh, true);
                gameObjectMeshData.Add(gameObject, data);

               
            }
        }

        public void Generate()
        {
            // 1. Generate the game object hierarchy in the scene graph
            if (groupOptions == SceneGroupType.Nothing)
            {
                // Merge every game object created to the 'root' element being the map region
                foreach (var featureMesh in features)
                {
                    MergeMeshData(regionMap, featureMesh);

                }
            }
            else
            {
                GameObject currentGroup;

                // Generate all game object with the appropriate hiarchy
                foreach (var featureMesh in features)
                {
                    currentGroup = regionMap;

                    foreach (SceneGroupType group in Enum.GetValues(typeof(SceneGroupType)))
                    {
                        // Exclude 'nothing' and 'everything' group
                        if (group == SceneGroupType.Nothing || group == SceneGroupType.Everything)
                        {
                            continue;
                        }

                        if (groupOptions.Includes(group))
                        {
                            // Use currentGroup as the parentGroup for the current generation
                            var parentGroup = currentGroup;
                            var newGroup = AddGameObjectGroup(group, parentGroup, featureMesh);

                            // Top down of the hierarchy, merge the game objects
                            if (group == leafGroup)
                            {
                                MergeMeshData(newGroup, featureMesh);
                            }

                            currentGroup = newGroup;
                        }
                    }
                }
            }

            // 2. Initialize game objects and associate their components (physics, rendering)
            foreach (var pair in gameObjectMeshData)
            {
                var meshData = pair.Value;
                var root = pair.Key;

                // Create one game object per mesh object 'bucket', each bucket is ensured to
                // have less that 65535 vertices (valid under Unity mesh max vertex count).
                for (int i = 0; i < meshData.Meshes.Count; ++i)
                {
                    var meshBucket = meshData.Meshes[i];
                    GameObject gameObject;

                    if (meshData.Meshes.Count > 1)
                    {
                        gameObject = new GameObject(root.name + "_Part" + i);
                        gameObject.transform.parent = root.transform;
                    }
                    else
                    {
                        gameObject = root.gameObject;
                    }

                    gameObject.isStatic = gameObjectOptions.IsStatic;

                    var mesh = new Mesh();
                    mesh.Clear();
                    mesh.SetVertices(meshBucket.Vertices);
                    mesh.SetUVs(0, meshBucket.UVs);
                    mesh.subMeshCount = meshBucket.Submeshes.Count;
                    for (int s = 0; s < meshBucket.Submeshes.Count; s++)
                    {
                        mesh.SetTriangles(meshBucket.Submeshes[s].Indices, s);
                    }

                    //Unwrapping.GenerateSecondaryUVSet(mesh);

                    mesh.RecalculateNormals();
                    mesh.RecalculateBounds();
                    //MeshUtility.Optimize(mesh);

                    // Associate the mesh filter and mesh renderer components with this game object

                    var materials = meshBucket.Submeshes.Select(s => s.Material).ToArray();
                    var meshFilterComponent = gameObject.AddComponent<MeshFilter>();
                    var meshRendererComponent = gameObject.AddComponent<MeshRenderer>();

                    meshRendererComponent.materials = materials;
                    meshFilterComponent.mesh = mesh;

                    if (gameObjectOptions.GeneratePhysicMeshCollider)
                    {
                        var meshColliderComponent = gameObject.AddComponent<MeshCollider>();
                        meshColliderComponent.material = gameObjectOptions.PhysicMaterial;
                        meshColliderComponent.sharedMesh = mesh;
                    }


                }
            }
        }

        public void DrawFromGama()
        {
            // 1. Generate the game object hierarchy in the scene graph
            if (groupOptions == SceneGroupType.Nothing)
            {
                // Merge every game object created to the 'root' element being the map region
                foreach (var featureMesh in features)
                {
                    MergeMeshData(regionMap, featureMesh);

                }
            }
            else
            {
                GameObject currentGroup;

                // Generate all game object with the appropriate hiarchy
                foreach (var featureMesh in features)
                {
                    currentGroup = regionMap;

                    foreach (SceneGroupType group in Enum.GetValues(typeof(SceneGroupType)))
                    {
                        // Exclude 'nothing' and 'everything' group
                        if (group == SceneGroupType.Nothing || group == SceneGroupType.Everything)
                        {
                            continue;
                        }

                        if (groupOptions.Includes(group))
                        {
                            // Use currentGroup as the parentGroup for the current generation
                            var parentGroup = currentGroup;
                            var newGroup = AddGameObjectGroup(group, parentGroup, featureMesh);

                            // Top down of the hierarchy, merge the game objects
                            if (group == leafGroup)
                            {
                                MergeMeshData(newGroup, featureMesh);
                            }

                            currentGroup = newGroup;
                        }
                    }
                }
            }

            // 2. Initialize game objects and associate their components (physics, rendering)
            foreach (var pair in gameObjectMeshData)
            {
                var meshData = pair.Value;
                var root = pair.Key;

                // Create one game object per mesh object 'bucket', each bucket is ensured to
                // have less that 65535 vertices (valid under Unity mesh max vertex count).
                for (int i = 0; i < meshData.Meshes.Count; ++i)
                {
                    var meshBucket = meshData.Meshes[i];
                    GameObject gameObject;
                    GameObject ggg;
                    if (meshData.Meshes.Count > 1)
                    {
                        //gameObject = new GameObject(root.name + "_Part" + i);
                        gameObject = new GameObject(root.name);
                        gameObject.transform.parent = root.transform;
                    }
                    else
                    {
                        gameObject = root.gameObject;
                    }

                    //  GameObject UaPrefab = (GameObject)Resources.Load("LittoSIM/Prefabs/UI/UA", typeof(GameObject));
                    //  gameObject = Instantiate(UaPrefab);
     

                    //meshBucket.meshGeometry = "LineString";
                    //-----------------------------------
          

                    if (meshBucket.gamaAgent.geometry.Equals(IGeometry.LINESTRING))
                    {
                        gameObject.AddComponent<LineRenderer>();
                        LineRenderer line = (LineRenderer)gameObject.GetComponent(typeof(LineRenderer));
                        line.positionCount = meshBucket.Vertices.Count;
                        line.SetPositions(meshBucket.Vertices.ToArray());
                        line.positionCount = meshBucket.Vertices.Count / 2;
                        Material mat = Utils.getMaterialByName("Green");
                        if (mat != null)
                        {
                            line.material = mat;
                        }

                        line.material = new Material(Shader.Find("Particles/Additive"));
                        Color c1 = Color.green;
                        Color c2 = new Color(1, 1, 1, 0);
                        line.startColor = c1;
                        line.endColor = c1;
                        line.startWidth = 5.0f;
                        line.endWidth = 5.0f;
                    }
                    else if (meshBucket.gamaAgent.geometry.Equals(IGeometry.POINTS))
                    {
                        Transform tr = gameObject.transform.parent;
                        string name = gameObject.name;
                        gameObject.name = gameObject.name + "Old";

                        gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        gameObject.name = name;
                        gameObject.transform.parent = tr;
                        gameObject.transform.position = meshBucket.Vertices[0];
                        gameObject.transform.localScale = new Vector3(10, 10, 10);
                        //gameObject.AddComponent<LineRenderer>();
                        Color col = Utils.getColorFromGamaColor(meshBucket.gamaAgent.color);

                        Renderer rend = gameObject.GetComponent<Renderer>();
                        rend.material.color = UnityEngine.Random.ColorHSV();// Color.green; //("green");//col;

                       
                    }
                    else if (meshBucket.gamaAgent.geometry.Equals(IGeometry.POLYGON))
                    {

                        gameObject.name = meshBucket.gamaAgent.agentName;
                        gameObject.AddComponent<MeshRenderer>();
                        gameObject.AddComponent<MeshFilter>();
                        gameObject.AddComponent<RectTransform>();
                        gameObject.AddComponent<CheckIfContainedInCanvas>();


                        var materials = meshBucket.Submeshes.Select(s => s.Material).ToArray();
                        var meshFilter = gameObject.GetComponent<MeshFilter>();
                        var meshRenderer = gameObject.GetComponent<MeshRenderer>();
                        
                        RectTransform _parent = GameObject.Find(IUILittoSim.UA_MAP_PANEL).GetComponent<RectTransform>();
                        RectTransform _mRect = gameObject.GetComponent<RectTransform>();

                        _mRect.transform.SetParent(_parent);
                        _mRect.anchoredPosition = meshBucket.gamaAgent.location;

                        _mRect.anchorMin = new Vector2(0, 0);
                        _mRect.anchorMax = new Vector2(0, 0);
                        _mRect.pivot = new Vector2(0.5f, 0.5f);
                        _mRect.sizeDelta = new Vector2(2, 2);  //_parent.rect.size;

                        //_mRect.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        //_mRect.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                        meshFilter.mesh.name = "CostumeMesh";
                        meshFilter.mesh.vertices = worldToUISpaceMeshVertices(GameObject.Find("MapCanvas").GetComponent<Canvas>(), meshFilter.mesh.vertices);

                        Material mat = new Material(Shader.Find("Standard"));
                        mat.color = meshBucket.gamaAgent.color.getColorFromGamaColor();
                        meshRenderer.material = mat;
                        meshRenderer.materials = materials;

                        meshFilter.mesh.SetVertices(meshBucket.Vertices);
                        meshFilter.mesh.SetUVs(0, meshBucket.UVs);
                        meshFilter.mesh.subMeshCount = meshBucket.Submeshes.Count;
                                                                                                                                                         
                        for (int s = 0; s < meshBucket.Submeshes.Count; s++)
                        {
                            meshFilter.mesh.SetTriangles(meshBucket.Submeshes[s].Indices, s);
                        }
                        meshFilter.mesh = clockwiseMesh(meshFilter.mesh);
                                        

                        // For Android Build
                        // Unwrapping.GeneratePerTriangleUV(meshFilter.mesh);
                        // Unwrapping.GenerateSecondaryUVSet(meshFilter.mesh);

                        // For Android Build
                        // MeshUtility.Optimize(meshFilter.mesh);
                        // -------------------------------------


                        meshFilter.mesh.RecalculateBounds();
                        meshFilter.mesh.RecalculateNormals();
                        meshFilter.mesh.RecalculateTangents();
                        
                        if (gameObjectOptions.GeneratePhysicMeshCollider)
                        {
                            var meshColliderComponent = gameObject.AddComponent<MeshCollider>();
                            meshColliderComponent.material = gameObjectOptions.PhysicMaterial;
                            meshColliderComponent.sharedMesh = meshFilter.mesh;
                        }
                                       
                    }


                }
            }
        }


        public Vector3[] worldToUISpaceMeshVertices(Canvas parentCanvas, Vector3[] vertices)
        {
            Vector3[] vert = new Vector3[vertices.Length];
            
            for(int i=0; i< vertices.Length; i++)
            {
                Vector3 v = vertices[i]; 
                //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
                Vector3 screenPos = Camera.main.WorldToScreenPoint(v);
                Vector2 movePos;
                //Convert the screenpoint to ui rectangle local point
                RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
                //Convert the local point to world point
                vert[i] = parentCanvas.transform.TransformPoint(movePos);
            }

            return vert;
        }



        private void Destroy(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        private Mesh DrawLineMesh(List<Vector3> points)
        {
            Mesh m = new Mesh();
            m.Clear();
            Vector3[] verticies = new Vector3[points.Count];

            for (int i = 0; i < verticies.Length; i++)
            {
                verticies[i] = points[i];
            }

            int[] triangles = new int[((points.Count / 2) - 1) * 6];
            //Works on linear patterns tn = bn+c
            int position = 6;
            for (int i = 0; i < (triangles.Length / 6); i++)
            {
               
                triangles[i * position] = 2 * i;
                triangles[i * position + 3] = 2 * i;

                triangles[i * position + 1] = 2 * i + 3;
                triangles[i * position + 4] = (2 * i + 3) - 1;

                triangles[i * position + 2] = 2 * i + 1;
                triangles[i * position + 5] = (2 * i + 1) + 2;
            }

            m.vertices = verticies;
            m.triangles = triangles;

            // For Android Build
            //            Unwrapping.GenerateSecondaryUVSet(m);

            m.RecalculateNormals();
            m.RecalculateBounds();

            // For Android Build
            //            MeshUtility.Optimize(m);

           
            return m;
        }




        public Mesh clockwiseMesh(Mesh mesh)
        {
            if (1 == 2)
                for (int i = 0; i < mesh.vertices.Length - 3; i += 3)
                {
                    Vector3 v0 = mesh.vertices[i + 0]; Vector3 v1 = mesh.vertices[i + 1]; Vector3 v2 = mesh.vertices[i + 2];
                    if (!IsClockwise(mesh.vertices[i], mesh.vertices[i + 1], mesh.vertices[i + 2]))
                    {
                        v0 = mesh.vertices[i + 0];
                        v1 = mesh.vertices[i + 1];
                        v2 = mesh.vertices[i + 2];
                        mesh.vertices[i + 0] = v0;
                        mesh.vertices[i + 1] = v2;
                        mesh.vertices[i + 2] = v1;
                        if (!IsClockwise(mesh.vertices[i], mesh.vertices[i + 1], mesh.vertices[i + 2]))
                        {
                            v0 = mesh.vertices[i + 0];
                            v1 = mesh.vertices[i + 1];
                            v2 = mesh.vertices[i + 2];
                            mesh.vertices[i + 0] = v1;
                            mesh.vertices[i + 1] = v2;
                            mesh.vertices[i + 2] = v0;
                            if (!IsClockwise(mesh.vertices[i], mesh.vertices[i + 1], mesh.vertices[i + 2]))
                            {
                                v0 = mesh.vertices[i + 0];
                                v1 = mesh.vertices[i + 1];
                                v2 = mesh.vertices[i + 2];
                                mesh.vertices[i + 0] = v1;
                                mesh.vertices[i + 1] = v0;
                                mesh.vertices[i + 2] = v2;
                                if (!IsClockwise(mesh.vertices[i], mesh.vertices[i + 1], mesh.vertices[i + 2]))
                                {
                                    v0 = mesh.vertices[i + 0];
                                    v1 = mesh.vertices[i + 1];
                                    v2 = mesh.vertices[i + 2];
                                    mesh.vertices[i + 0] = v2;
                                    mesh.vertices[i + 1] = v1;
                                    mesh.vertices[i + 2] = v0;
                                    if (!IsClockwise(mesh.vertices[i], mesh.vertices[i + 1], mesh.vertices[i + 2]))
                                    {
                                        v0 = mesh.vertices[i + 0];
                                        v1 = mesh.vertices[i + 1];
                                        v2 = mesh.vertices[i + 2];
                                        mesh.vertices[i + 0] = v2;
                                        mesh.vertices[i + 1] = v0;
                                        mesh.vertices[i + 2] = v1;
                                    }
                                }
                            }
                        }
                    }
                }

            return mesh;
        }



        public bool IsClockwise(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            bool isClockWise = true;

            float determinant = p1.x * p2.y + p3.x * p1.y + p2.x * p3.y - p1.x * p3.y - p3.x * p2.y - p2.x * p1.y;
            if (determinant >= 0f)
            {
                isClockWise = false;
               
            }
            else
            {
                
            }
            return isClockWise;
        }



    }
}