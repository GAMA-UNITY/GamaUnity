using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using ummisco.gama.unity.Scene;

namespace ummisco.gama.unity.geometry
{
    public class Triangulator
    {
        public static int triangles_nbr = 1;

        // liste des verticies du polygon (2D)
        public List<Vector2> m_points = new List<Vector2>();

        public List<Vector2> all_points = new List<Vector2>();

        public Vector3[] vertices3D;

        public Triangulator(Vector2[] points)
        {
            m_points = new List<Vector2>(points);
        }

        public void SetPoints(Vector2[] points)
        {
            m_points = new List<Vector2>(points);
        }

        public void SetAllPoints(Vector2[] points)
        {
            all_points = new List<Vector2>(points);
        }

        public int[] Triangulate()
        {
            List<int> indices = new List<int>();

            int n = m_points.Count;
            if (n < 3)
                return indices.ToArray();

            int[] V = new int[n];
            if (Area() > 0)
            {
                for (int v = 0; v < n; v++)
                    V[v] = v;
            }
            else
            {
                for (int v = 0; v < n; v++)
                    V[v] = (n - 1) - v;
            }

            int nv = n;
            int count = 2 * nv;
            for (int m = 0, v = nv - 1; nv > 2;)
            {
                if ((count--) <= 0)
                    return indices.ToArray();

                int u = v;
                if (nv <= u)
                    u = 0;
                v = u + 1;
                if (nv <= v)
                    v = 0;
                int w = v + 1;
                if (nv <= w)
                    w = 0;

                if (Snip(u, v, w, nv, V))
                {
                    int a, b, c, s, t;
                    a = V[u];
                    b = V[v];
                    c = V[w];
                    indices.Add(a);
                    indices.Add(b);
                    indices.Add(c);
                    m++;
                    for (s = v, t = v + 1; t < nv; s++, t++)
                        V[s] = V[t];
                    nv--;
                    count = 2 * nv;
                }
            }

            indices.Reverse();
            return indices.ToArray();
        }

        private float Area()
        {
            int n = m_points.Count;
            float A = 0.0f;
            for (int p = n - 1, q = 0; q < n; p = q++)
            {
                Vector2 pval = m_points[p];
                Vector2 qval = m_points[q];
                A += pval.x * qval.y - qval.x * pval.y;
            }
            return (A * 0.5f);
        }

        private bool Snip(int u, int v, int w, int n, int[] V)
        {
            int p;
            Vector2 A = m_points[V[u]];
            Vector2 B = m_points[V[v]];
            Vector2 C = m_points[V[w]];
            if (Mathf.Epsilon > (((B.x - A.x) * (C.y - A.y)) - ((B.y - A.y) * (C.x - A.x))))
                return false;
            for (p = 0; p < n; p++)
            {
                if ((p == u) || (p == v) || (p == w))
                    continue;
                Vector2 P = m_points[V[p]];
                if (InsideTriangle(A, B, C, P))
                    return false;
            }
            return true;
        }

        private bool InsideTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
        {
            float ax, ay, bx, by, cx, cy, apx, apy, bpx, bpy, cpx, cpy;
            float cCROSSap, bCROSScp, aCROSSbp;

            ax = C.x - B.x; ay = C.y - B.y;
            bx = A.x - C.x; by = A.y - C.y;
            cx = B.x - A.x; cy = B.y - A.y;
            apx = P.x - A.x; apy = P.y - A.y;
            bpx = P.x - B.x; bpy = P.y - B.y;
            cpx = P.x - C.x; cpy = P.y - C.y;

            aCROSSbp = ax * bpy - ay * bpx;
            cCROSSap = cx * apy - cy * apx;
            bCROSScp = bx * cpy - by * cpx;

            return ((aCROSSbp >= 0.0f) && (bCROSScp >= 0.0f) && (cCROSSap >= 0.0f));
        }



        public Vector3[] VerticesWithElevation(float elevation, Vector3 shiftMesh)
        {

            Vector3[] vertices = new Vector3[m_points.Count * 2];

            for (int i = 0; i < m_points.Count; i++)
            {
                
                // front vertex
                vertices[i].x = -IGamaManager.x_axis_transform * (m_points[i].x - shiftMesh.x);
                vertices[i].y = -IGamaManager.y_axis_transform * (m_points[i].y - shiftMesh.y);
                vertices[i].z = IGamaManager.z_axis_transform * (-elevation - shiftMesh.z);
                //vertices[i].z = IGamaManager.z_axis_transform * (IGamaManager.z_axis_elevation - shiftMesh.z);


                // back vertex
                vertices[i + m_points.Count].x = -IGamaManager.x_axis_transform * (m_points[i].x - shiftMesh.x);
                vertices[i + m_points.Count].y = -IGamaManager.y_axis_transform * (m_points[i].y - shiftMesh.y);
                vertices[i + m_points.Count].z = IGamaManager.z_axis_transform * (IGamaManager.z_axis_elevation - shiftMesh.z);
                //vertices[i + m_points.Count].z = IGamaManager.z_axis_transform * (- elevation - shiftMesh.z);
                

                /*
                // front vertex
                vertices[i].x = - IGamaManager.x_axis_transform * (m_points[i].x - shiftMesh.x);
                vertices[i].y = - IGamaManager.y_axis_transform * (m_points[i].y - shiftMesh.y);
                //vertices[i].z = IGamaManager.z_axis_transform * (-elevation - shiftMesh.z);
                vertices[i].z = IGamaManager.z_axis_transform * (IGamaManager.z_axis_elevation - shiftMesh.z);


                // back vertex
                vertices[i + m_points.Count].x = - IGamaManager.x_axis_transform * (m_points[i].x - shiftMesh.x);
                vertices[i + m_points.Count].y = - IGamaManager.y_axis_transform * (m_points[i].y - shiftMesh.y);
                //vertices[i + m_points.Count].z = IGamaManager.z_axis_transform * (IGamaManager.z_axis_elevation - shiftMesh.z);
                vertices[i + m_points.Count].z = IGamaManager.z_axis_transform * (- elevation - shiftMesh.z);
                */
            }

            vertices3D = vertices;

            return vertices;
        }

        public Vector3[] VerticesWithElevation(float elevation)
        {
            return VerticesWithElevation(elevation, new Vector3(0, 0, 0));
        }


        public Vector2[] Convert2dTo3dVertices()
        {
            Vector2[] vertex3D = new Vector2[m_points.Count * 2];
            for (int i = 0; i < m_points.Count; i++)
            {
                // front vertex
                vertex3D[i].x = m_points[i].x;
                vertex3D[i].y = m_points[i].y;

                // back vertex  
                vertex3D[i + m_points.Count].x = m_points[i].x;
                vertex3D[i + m_points.Count].y = m_points[i].y;
            }
            return vertex3D;
        }


        public List<Vector3> Get3dVerticesList(float elevation)
        {
            Vector3[] vertices = new Vector3[m_points.Count * 2];

            for (int i = 0; i < m_points.Count; i++)
            {
                //vertices[i].x = IGamaManager.x_axis_transform * m_points[i].x;
                //vertices[i].y = IGamaManager.y_axis_transform * m_points[i].y;
                //vertices[i].z = IGamaManager.z_axis_transform * 0;  //- elevation; // front vertex

                //vertices[i + m_points.Count].x = IGamaManager.x_axis_transform * m_points[i].x;
                //vertices[i + m_points.Count].y = IGamaManager.y_axis_transform * m_points[i].y;
                //vertices[i + m_points.Count].z = IGamaManager.z_axis_transform * elevation; // 0; // elevation;  // back vertex

                vertices[i].x = IGamaManager.x_axis_transform * m_points[i].x;
                vertices[i].y = IGamaManager.y_axis_transform * m_points[i].y;
                vertices[i].z = IGamaManager.z_axis_transform * - elevation; // front vertex

                vertices[i + m_points.Count].x = IGamaManager.x_axis_transform * m_points[i].x;
                vertices[i + m_points.Count].y = IGamaManager.y_axis_transform * m_points[i].y;
                vertices[i + m_points.Count].z = IGamaManager.z_axis_transform * 0; // elevation;  // back vertex    
            }

            return vertices.OfType<Vector3>().ToList();
        }




        public int[] GetTriangules()
        {
            // convert polygon to triangles

            int[] tris = Triangulate();

            int[] triangles = new int[tris.Length * 2 + m_points.Count * 6];
            int count_tris = 0;
            for (int i = 0; i < tris.Length; i += 3)
            {
                triangles[i] = tris[i];
                triangles[i + 1] = tris[i + 1];
                triangles[i + 2] = tris[i + 2];
            } // front vertices
            count_tris += tris.Length;
            for (int i = 0; i < tris.Length; i += 3)
            {
                triangles[count_tris + i] = tris[i + 2] + m_points.Count;
                triangles[count_tris + i + 1] = tris[i + 1] + m_points.Count;
                triangles[count_tris + i + 2] = tris[i] + m_points.Count;


            } // back vertices
            count_tris += tris.Length;
            for (int i = 0; i < m_points.Count; i++)
            {
                // triangles around the perimeter of the object
                int n = (i + 1) % m_points.Count;
                triangles[count_tris] = i;
                triangles[count_tris + 1] = i + m_points.Count;
                triangles[count_tris + 2] = n;


                triangles[count_tris + 3] = n;
                triangles[count_tris + 4] = n + m_points.Count;
                triangles[count_tris + 5] = i + m_points.Count;

                count_tris += 6;
            }
            return triangles;
        }


        public List<int> GetTriangulesList()
        {
            return Triangulate3dMesh().OfType<int>().ToList();
        }


        //Is a triangle in 2d space oriented clockwise or counter-clockwise
        //https://math.stackexchange.com/questions/1324179/how-to-tell-if-3-connected-points-are-connected-clockwise-or-counter-clockwise
        //https://en.wikipedia.org/wiki/Curve_orientation
        public bool IsTriangleOrientedClockwise(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            bool isClockWise = true;

            float determinant = p1.x * p2.y + p3.x * p1.y + p2.x * p3.y - p1.x * p3.y - p3.x * p2.y - p2.x * p1.y;

            // determinant = (p2.y - p1.y) * (p3.x - p2.x) - (p2.x - p1.x) * (p3.y - p2.y);

            if (determinant >= 0f)
            {
                isClockWise = false;
                Debug.Log(" No IT IS NOT CLOCKWISE --------------------------->>> [" + p1 + ";" + p2 + ";" + p3 + "] ->  " + determinant);
                Debug.Log(" Total triangles are: ---->>> " + triangles_nbr);
            }
            else
            {
                Debug.Log(" YES IT IS CLOCKWISE ------------------------------>>> [" + p1 + ";" + p2 + ";" + p3 + "] ->  " + determinant);
                Debug.Log(" Total triangles are: ---->>> " + triangles_nbr);
                triangles_nbr++;
            }
            return isClockWise;
        }


        public bool IsClockwise(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            bool isClockWise = true;

            float determinant = p1.x * p2.y + p3.x * p1.y + p2.x * p3.y - p1.x * p3.y - p3.x * p2.y - p2.x * p1.y;
            if (determinant >= 0f)
            {
                isClockWise = false;
                Debug.Log(" No IT IS NOT CLOCKWISE --------------------------->>> [" + p1 + ";" + p2 + ";" + p3 + "] ->  " + determinant);
                Debug.Log(" Total triangles are: ---->>> " + triangles_nbr);
            }
            else
            {
                Debug.Log(" YES IT IS CLOCKWISE ------------------------------>>> [" + p1 + ";" + p2 + ";" + p3 + "] ->  " + determinant);
                Debug.Log(" Total triangles are: ---->>> " + triangles_nbr);
                triangles_nbr++;
            }
            return isClockWise;
        }


        // To find orientation of ordered triplet (p1, p2, p3). 
        // The function returns following values 
        // 0 --> p, q and r are colinear 
        // 1 --> Clockwise 
        // 2 --> Counterclockwise 
        public int Orientation(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            // See 10th slides from following link for derivation 
            // of the formula 
            float val = (p2.y - p1.y) * (p3.x - p2.x) - (p2.x - p1.x) * (p3.y - p2.y);

            if (val == 0) return 0;  // colinear 

            return (val > 0) ? 1 : 2; // clock or counterclock wise 
        }



        public int[] CheckClockWise(int[] tr, Vector3 p1, Vector3 p2, Vector3 p3)
        {


            for (int i = 0; i < tr.Length; i += 3)
            {

                if (IsTriangleOrientedClockwise(p1, p2, p3))
                {
                    // Debug.Log("Yes it is ClockWise ->- {" + tr[i + 0] + "},{" + tr[i + 1] + "},{" + tr[i + 2] + "}");

                }
                else
                {
                    int n = tr[i + 1];
                    tr[i + 1] = tr[i + 2];
                    tr[i + 2] = n;
                }
            }
            return tr;
        }




        public int[] Triangulate3dMesh()
        {
            // convert the initial polygon to triangles
            int[] tris = Triangulate();

            // Array to contain all the triangules of the mesh
            int[] triangles = new int[tris.Length * 2 + m_points.Count * 6];


            // Compute triangules of front vertices
            int count_tris = 0;
            for (int i = 0; i < tris.Length; i += 3)
            {
                triangles[i + 0] = tris[i + 0];
                triangles[i + 1] = tris[i + 1];
                triangles[i + 2] = tris[i + 2];

            }

            // Compute triangules of back vertices
            count_tris += tris.Length;
            for (int i = 0; i < tris.Length; i += 3)
            {
                triangles[count_tris + i + 0] = tris[i + 2] + m_points.Count;
                triangles[count_tris + i + 1] = tris[i + 1] + m_points.Count;
                triangles[count_tris + i + 2] = tris[i + 0] + m_points.Count;

            }


            count_tris += tris.Length;
            for (int i = 0; i < m_points.Count; i++)
            {
                // triangles around the perimeter of the object
                int n = (i + 1) % m_points.Count;
                //triangles[count_tris + 0] = i;
                //triangles[count_tris + 1] = i + m_points.Count;
                //triangles[count_tris + 2] = n;

                //triangles[count_tris + 0] = n;
                //triangles[count_tris + 1] = i + m_points.Count;
                //triangles[count_tris + 2] = i;

                // correct
                triangles[count_tris + 0] = n;
                triangles[count_tris + 1] = i;
                triangles[count_tris + 2] = i + m_points.Count;

                // triangles[count_tris + 3] = i + m_points.Count;
                // triangles[count_tris + 4] = i;
                // triangles[count_tris + 5] = n;
                triangles[count_tris + 3] = i + m_points.Count;
                int i2 = (i + m_points.Count + 1) < (m_points.Count * 2) ? (i + m_points.Count + 1) : m_points.Count;
                triangles[count_tris + 4] = i2;
                triangles[count_tris + 5] = n;

                count_tris += 6;
            }

            return triangles;
        }


        public int[] Triangulate3dMesh2(Vector3[] vertices)
        {
            // convert the initial polygon to triangles
            int[] tris = Triangulate();

            // points of a triangle
            Vector3 p1, p2, p3;

            // Array to contain all the triangules of the mesh
            int[] triangles = new int[tris.Length * 2 + m_points.Count * 6];


            // Compute triangules of front vertices
            int count_tris = 0;
            for (int i = 0; i < tris.Length; i += 3)
            {

                triangles[i + 0] = tris[i + 0];
                triangles[i + 1] = tris[i + 1];
                triangles[i + 2] = tris[i + 2];

                p1 = vertices[triangles[i + 0]];
                p2 = vertices[triangles[i + 1]];
                p3 = vertices[triangles[i + 2]];

                if (Orientation(p1, p2, p3) == 2) // The triangle is Conter ClockWise. Need to Clock wise it.
                {
                    int n = triangles[i + 1];
                    triangles[i + 1] = triangles[i + 2];
                    triangles[i + 2] = n;
                }

            }



            // Compute triangules of back vertices
            count_tris += tris.Length;
            for (int i = 0; i < tris.Length; i += 3)
            {
                triangles[count_tris + i + 0] = tris[i + 2] + m_points.Count;
                triangles[count_tris + i + 1] = tris[i + 1] + m_points.Count;
                triangles[count_tris + i + 2] = tris[i + 0] + m_points.Count;

                p1 = vertices[triangles[count_tris + i + 0]];
                p2 = vertices[triangles[count_tris + i + 1]];
                p3 = vertices[triangles[count_tris + i + 2]];

                if (Orientation(p1, p2, p3) == 1) //  // The triangle is ClockWise. Need to Counter clockwise it (back vertices).
                {
                    int n = triangles[count_tris + i + 1];
                    triangles[count_tris + i + 1] = triangles[count_tris + i + 2];
                    triangles[count_tris + i + 2] = n;
                }

            }


            count_tris += tris.Length;
            for (int i = 0; i < m_points.Count; i++)
            {
                // triangles around the perimeter of the object
                int n = (i + 1) % m_points.Count;
                int n2 = (i + m_points.Count + 1) % (m_points.Count * 2);
                // false
                //triangles[count_tris + 0] = i;
                //triangles[count_tris + 1] = i + m_points.Count;
                //triangles[count_tris + 2] = n;

                // Correct for Building elevation
                triangles[count_tris + 0] = n;
                triangles[count_tris + 1] = i + m_points.Count;
                triangles[count_tris + 2] = i;


                // correct // false with building elvation
                //triangles[count_tris + 0] = n;
                //triangles[count_tris + 1] = i;
                //triangles[count_tris + 2] = i + m_points.Count;

                //building elevation
                triangles[count_tris + 3] = n;//i + m_points.Count;
                int i2 = (n2 >= m_points.Count) ? (n2) : m_points.Count;
                triangles[count_tris + 4] = i2; //i;
                triangles[count_tris + 5] = i + m_points.Count;//n2;

                count_tris += 6;
            }

            return triangles;

        }



        public int[] Get3DTriangulesFrom2DOld()
        {
            // convert the initial polygon to triangles
            int[] tris = Triangulate();

            // Array to contain all the triangules of the mesh
            int[] triangles = new int[tris.Length * 2 + m_points.Count * 6];


            // Compute triangules of front vertices
            int count_tris = 0;
            for (int i = 0; i < tris.Length; i += 3)
            {
                triangles[i + 0] = tris[i + 0];
                triangles[i + 1] = tris[i + 1];
                triangles[i + 2] = tris[i + 2];
            }

            // Compute triangules of back vertices
            count_tris += tris.Length;
            for (int i = 0; i < tris.Length; i += 3)
            {
                triangles[count_tris + i + 0] = tris[i + 2] + m_points.Count;
                triangles[count_tris + i + 1] = tris[i + 1] + m_points.Count;
                triangles[count_tris + i + 2] = tris[i + 0] + m_points.Count;

            }


            count_tris += tris.Length;
            for (int i = 0; i < m_points.Count; i++)
            {
                // triangles around the perimeter of the object
                int n = (i + 1) % m_points.Count;
                triangles[count_tris + 0] = i;
                triangles[count_tris + 1] = i + m_points.Count;
                triangles[count_tris + 2] = n;


                triangles[count_tris + 3] = n;
                triangles[count_tris + 4] = n + m_points.Count;
                triangles[count_tris + 5] = i + m_points.Count;

                count_tris += 6;
            }
            return triangles;
        }





        public Mesh ClockwiseMesh(Mesh mesh)
        {
            int[] triangles = mesh.triangles;
            Vector3[] vertices = mesh.vertices;

            mesh.Clear();

            for (int i = 0; i < triangles.Length; i += 3)
            {
                Vector3 p1 = vertices[triangles[i]];
                Vector3 p2 = vertices[triangles[i + 1]];
                Vector3 p3 = vertices[triangles[i + 2]];

                if (Orientation(p1, p2, p3) == 2)
                {
                    int n = triangles[i + 1];
                    triangles[i + 1] = triangles[i + 2];
                    triangles[i + 2] = n;
                }
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;

            return mesh;
        }




    }




}