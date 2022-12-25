using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOBJ_CSharp.classes
{

    public class LoadedObject
    {
        public float[] vertices = new float[] {};
        public float[] normalVectors = new float[] {};
        public float[] verticesAndNormalVectors = new float[] {};
        public int[] faces = new int[] {};
        public uint[] indexFaces = new uint[] {};

        public LoadedObject(float[] _vertices, float[] _normalVectors, int[] _faces)
        {
            vertices = _vertices;
            normalVectors = _normalVectors;
            faces = _faces;
            
            InterpolateVertexAndNormalVector();
            GenerateIndexFaces();
        }


        private void InterpolateVertexAndNormalVector()
        {
            int i = 0;
            while(i < (faces.Length/9))
            {
                int j = i*9;
                //0 2  3 5  6 8
                AddVertexToInterpolateOnIndex(faces[j]);
                AddNormalVectorToInterpolateOnIndex(faces[j+2]);

                AddVertexToInterpolateOnIndex(faces[j+3]);
                AddNormalVectorToInterpolateOnIndex(faces[j+5]);

                AddVertexToInterpolateOnIndex(faces[j+6]);
                AddNormalVectorToInterpolateOnIndex(faces[j+8]);

                i++;
            }
        }

        private void AddVertexToInterpolateOnIndex(int index)
        {
            index = index*3;
            verticesAndNormalVectors = verticesAndNormalVectors.Concat(new float[] {vertices[index]}).ToArray();
            verticesAndNormalVectors = verticesAndNormalVectors.Concat(new float[] {vertices[index+1]}).ToArray();
            verticesAndNormalVectors = verticesAndNormalVectors.Concat(new float[] {vertices[index+2]}).ToArray();
        }

        private void AddNormalVectorToInterpolateOnIndex(int index)
        {
            index = index*3;
            verticesAndNormalVectors = verticesAndNormalVectors.Concat(new float[] {normalVectors[index]}).ToArray();
            verticesAndNormalVectors = verticesAndNormalVectors.Concat(new float[] {normalVectors[index+1]}).ToArray();
            verticesAndNormalVectors = verticesAndNormalVectors.Concat(new float[] {normalVectors[index+2]}).ToArray();
        }

        private void GenerateIndexFaces()
        {
            int i = 0;
            while(i < faces.Length/9)
            {
                int j = i*9;
                indexFaces = indexFaces.Concat(new uint[] {Convert.ToUInt32(faces[j])}).ToArray();
                indexFaces = indexFaces.Concat(new uint[] {Convert.ToUInt32(faces[j+3])}).ToArray();
                indexFaces = indexFaces.Concat(new uint[] {Convert.ToUInt32(faces[j+6])}).ToArray();
                i++;
            }
        }

        public void ShowVertices()
        {
            float[] _fA = this.vertices;
            int br = 0;
            for(int i = 0; i < _fA.Length; i++)
            {
                Console.Write("["+_fA.ElementAt(i)+"]");
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
            float[] _fA = normalVectors;
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

        public void ShowFaces()
        {
            int[] _fA = faces;
            int br = 0;
            for(int i = 0; i < _fA.Length; i++)
            {
                Console.Write("["+_fA[i]+"]");
                br++;

                if(br == 3 || br == 6)
                    Console.Write(" ");
                if(br == 9)
                {
                    br = 0;
                    Console.WriteLine("");
                }
            }
        }
        
        public void ShowInterpolated()
        {
            float[] _fA = verticesAndNormalVectors;
            int br = 0;
            for(int i = 0; i < _fA.Length; i++)
            {
                Console.Write("["+_fA[i]+"]");
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

        public void ShowIndexFaces()
        {
            uint[] _fA = indexFaces;
            int br = 0;
            for(int i = 0; i < _fA.Length; i++)
            {
                Console.Write("["+_fA[i]+"] ");
                br++;

                if(br == 3)
                {
                    br = 0;
                    Console.WriteLine("");
                }
            }
        }

        public float[] VerticesAndNormalVectors
        {
            get{ return this.verticesAndNormalVectors;}
        }

        public uint[] IndexFaces
        {
            get{ return this.indexFaces;}
        }
    }
   
}