using System;
using System.IO;

namespace PoLaKoSz.Deezer.Tests.Integration.EndPoints
{
    abstract class BaseEndPoint
    {
        private readonly string _dirPath;



        public BaseEndPoint()
        {
            _dirPath = "StaticResources/";
        }



        protected string GetData(string fileName)
        {
            return File.ReadAllText(Path.Combine(_dirPath, fileName));
        }
    }
}
