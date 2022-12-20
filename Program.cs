using System;
using OpenOBJ_CSharp.classes;
using System.Collections.Generic;
using System.Globalization;

namespace OpenOBJ_CSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pathFile = @"C:\Users\Vondal\Documents\MeusProjetos\OpenOBJ-CSharp\files\cube.obj";
            ObjectReader objReader = new ObjectReader(pathFile);
            objReader.ShowNormalVector();
            LoadedObject loadObj = new LoadedObject();

            loadObj = objReader.BindReadingToAnObject();
            // loadObj.ShowInterpolated();
            // loadObj.ShowNormalVector();
            

            // string s = "1//2";
            // string[] v = s.Split("/");
            // foreach(string i in v)
            // {
            //     Console.WriteLine(i);
            // }
        }
    }
}