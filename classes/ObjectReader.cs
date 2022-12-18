using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOBJ_CSharp.classes
{
    public class ObjectReader
    {
        private List<string> lines;

        public ObjectReader(string _pathObject)
        {
            string[] file = File.ReadAllLines(_pathObject);
            lines = RemoveDoubleSpaces(file);
            ShowFloatArray(GetAllVertex(lines));
            // ShowStringList(lines);
        }

        private List<string> RemoveDoubleSpaces(string[] _s)
        {
            List<string> trimStringList = new List<string>();
            string s;

            foreach(string line in _s)
            {  
                s = line;
                s = s.Trim();
                while(s.IndexOf("  ") != -1)
                    s = s.Replace("  ", " ");

                trimStringList.Add(s);
            }

            return trimStringList;
        }

        private float[] GetAllVertex(List<string> _sL)
        {
            float[] _vArray = new float[] {};
            string[] auxString;
            float auxFloat;
            
            foreach(string line in _sL)
            {
                auxString = line.Split(" ");
                if(auxString[0] == "v")
                {
                    int i = 1;
                    while(i < auxString.Length)
                    {
                        auxFloat = float.Parse(auxString[i], CultureInfo.InvariantCulture.NumberFormat);
                        _vArray = _vArray.Concat(new float[] { auxFloat }).ToArray();
                        i++;
                    }
                }

            }

            return _vArray;
        }

        private void ShowStringList(List<string> _sL)
        {
            foreach(string index in _sL)
            {
                Console.WriteLine(index);
            }
        }

        private void ShowFloatArray(float[] _fA)
        {
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
    }
}