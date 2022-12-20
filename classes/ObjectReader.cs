using System.Globalization;

namespace OpenOBJ_CSharp.classes
{
    public class ObjectReader
    {
        private List<string> lines;

        public ObjectReader(string _pathObject)
        {
            string[] file = File.ReadAllLines(_pathObject);
            lines = RemoveDoubleSpaces(file);
        }

        public LoadedObject BindReadingToAnObject()
        {
            LoadedObject lo = new LoadedObject
            (
                GetAllVertex(),
                GetAllNormalVector(),
                GetAllFaces()
            );

            return lo;
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

        private float[] GetAllVertex()
        {
            float[] _vArray = new float[] {};
            string[] auxString;
            float auxFloat;
            
            foreach(string line in this.lines)
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

        private float[] GetAllNormalVector()
        {
            float[] _vnArray = new float[] {};
            string[] auxString;
            float auxFloat;
            
            foreach(string line in this.lines)
            {
                auxString = line.Split(" ");
                if(auxString[0] == "vn")
                {
                    int i = 1;
                    while(i < auxString.Length)
                    {
                        auxFloat = float.Parse(auxString[i], CultureInfo.InvariantCulture.NumberFormat);
                        _vnArray = _vnArray.Concat(new float[] { auxFloat }).ToArray();
                        i++;
                    }
                }

            }

            return _vnArray;
        }

        private int[] GetAllFaces()
        {
            int[] _fArray = new int[] {};
            string[] auxString;
            int auxInt;
            
            foreach(string line in this.lines)
            {
                auxString = line.Split(" ");
                if(auxString[0] == "f")
                {
                    int i = 1;
                    while(i < auxString.Length)
                    {
                        string[] group = auxString[i].Split("/");
                        auxInt = Int32.Parse(group[0]);
                        _fArray = _fArray.Concat(new int[] { (auxInt-1) }).ToArray();
                        if(group[1] != "")
                        {
                            auxInt = Int32.Parse(group[1]);
                            _fArray = _fArray.Concat(new int[] { (auxInt-1) }).ToArray();
                        }
                        else
                        {
                            _fArray = _fArray.Concat(new int[] { 0 }).ToArray();
                        }
                        auxInt = Int32.Parse(group[2]);
                        _fArray = _fArray.Concat(new int[] { (auxInt-1) }).ToArray();
                        i++;
                    }
                }

            }

            return _fArray;
        }

        public void ShowVertices()
        {
            float[] _fA = GetAllVertex();
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
            float[] _fA = GetAllNormalVector();
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
            int[] _fA = GetAllFaces();
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
    }
}