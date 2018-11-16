using System;
using System.IO;

namespace PoLaKoSz.Deezer.Tests.Integration.EndPoints
{
    abstract class BaseEndPoint
    {
        private readonly string _dirPath;



        public BaseEndPoint(string subFolder)
        {
            _dirPath = Path.Combine("StaticResources", subFolder);
        }



        protected string GetData(string fileName)
        {
            return File.ReadAllText(Path.Combine(_dirPath, fileName));
        }
    }
}
