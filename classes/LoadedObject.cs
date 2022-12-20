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
        private uint[] indexFaces = new uint[] {};

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
                AddNormalVectorToInterpolateOnIndex(Faces[j+2]);

                AddVertexToInterpolateOnIndex(Faces[j+3]);
                AddNormalVectorToInterpolateOnIndex(Faces[j+5]);

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
                IndexFaces = IndexFaces.Concat(new uint[] {Convert.ToUInt32(Faces[i])}).ToArray();
                IndexFaces = IndexFaces.Concat(new uint[] {Convert.ToUInt32(Faces[i+3])}).ToArray();
                IndexFaces = IndexFaces.Concat(new uint[] {Convert.ToUInt32(Faces[i+6])}).ToArray();

                i += 9;
            }
        }

        public void ShowVertices()
        {
            float[] _fA = Vertices;
            int br = 0;
            for(int i = 0; i < _fA.Length; i++)
            {
                Console.Write("["+_fA[i]+"]");
                br++;

                if(br == 3)
                {
                    br = 0;
                    Console.WriteLine("");
                }
            }
        }

        public void ShowNormalVector()
        {
            float[] _fA = NormalVectors;
            int br = 0;
            for(int i = 0; i < _fA.Length; i++)
            {
                Console.Write("["+_fA[i]+"]");
                br++;

                if(br == 3)
                {
                    br = 0;
                    Console.WriteLine("");
                }
            }
        }
        
        public void ShowInterpolated()
        {
            int br = 0;
            for(int i = 0; i < VerticesAndNormalVectors.Length; i++)
            {
                Console.Write("["+VerticesAndNormalVectors[i]+"]");
                br++;
                if(br == 3)
                    Console.Write(" ");

                if(br == 6)
                {
                    br = 0;
                    Console.WriteLine("");
                }
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

        public uint[] IndexFaces
        {
            get{return this.indexFaces;}
            set{this.indexFaces = value;}
        }
    }
}