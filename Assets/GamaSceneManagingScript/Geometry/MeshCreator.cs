﻿using System;
using ummisco.gama.unity.utils;
using UnityEngine;

namespace ummisco.gama.unity.geometry
{
    public class MeshCreator
    {
        public MeshCreator()
        {

        }


        public Mesh CreateMesh(float elevation, Vector2[] vect)
        {
            Mesh mesh = new Mesh();
            Triangulator tri = new Triangulator(vect);
            tri.setAllPoints(tri.Convert2dTo3dVertices());
            mesh.vertices = tri.VerticesWithElevation(elevation);
            mesh.triangles = tri.Triangulate3dMesh();

            // For Android Build
            // Unwrapping.GenerateSecondaryUVSet(m);

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            // For Android Build
            // MeshUtility.Optimize(m);
            return mesh;
        }
    }
}