using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOBJ_CSharp.classes
{
    public class LoadedObject
    {
        private float[] vertices = new float[] {};
        private float[] normalVectors = new float[] {};
        private float[] verticesAndNormals = new float[] {};
        private int[] faces = new int[] {};
        private int[] indexFaces = new int[] {};

        public LoadedObject(float[] _vertices, float[] _normalVectors, int[] _faces)
        {
            Vertices = _vertices;
            NormalVectors = _normalVectors;
            Faces = _faces;
            InterpolateVertexAndNormalVector();
            GenerateIndexFaces();
        }

        public LoadedObject()
        {
            
        }

        private void InterpolateVertexAndNormalVector()
        {
            int i = 0;
            while(i < Faces.Length/9)
            {
                int j = i*9;
                //0 3 6  -  8
                AddVertexToInterpolateOnIndex(Faces[j]);
                AddVertexToInterpolateOnIndex(Faces[j+3]);
                AddVertexToInterpolateOnIndex(Faces[j+6]);

                AddNormalVectorToInterpolateOnIndex(Faces[j+8]);

                i += 9;
            }
        }

        private void AddVertexToInterpolateOnIndex(int index)
        {
            index = index*3;
            VerticesAndNormalVectors = VerticesAndNormalVectors.Concat(new float[] {Vertices[index]}).ToArray();
            VerticesAndNormalVectors = VerticesAndNormalVectors.Concat(new float[] {Vertices[index+1]}).ToArray();
            VerticesAndNormalVectors = VerticesAndNormalVectors.Concat(new float[] {Vertices[index+2]}).ToArray();
        }

        private void AddNormalVectorToInterpolateOnIndex(int index)
        {
            index = index*3;
            VerticesAndNormalVectors = VerticesAndNormalVectors.Concat(new float[] {NormalVectors[index]}).ToArray();
            VerticesAndNormalVectors = VerticesAndNormalVectors.Concat(new float[] {NormalVectors[index+1]}).ToArray();
            VerticesAndNormalVectors = VerticesAndNormalVectors.Concat(new float[] {NormalVectors[index+2]}).ToArray();
        }

        private void GenerateIndexFaces()
        {
            int i = 0;
            while(i < Faces.Length/9)
            {
                IndexFaces = IndexFaces.Concat(new int[] {Faces[i]}).ToArray();
                IndexFaces = IndexFaces.Concat(new int[] {Faces[i+3]}).ToArray();
                IndexFaces = IndexFaces.Concat(new int[] {Faces[i+6]}).ToArray();

                i += 9;
            }
        }

        public float[] Vertices
        {
            get{return this.vertices;}
            set{this.vertices = value;}
        }

        public float[] NormalVectors
        {
            get{return this.normalVectors;}
            set{this.normalVectors = value;}
        }

        public float[] VerticesAndNormalVectors
        {
            get{return this.normalVectors;}
            private set{this.normalVectors = value;}
        }

        public int[] Faces
        {
            get{return this.faces;}
            set{this.faces = value;}
        }

        public int[] IndexFaces
        {
            get{return this.indexFaces;}
            set{this.indexFaces = value;}
        }
    }
}