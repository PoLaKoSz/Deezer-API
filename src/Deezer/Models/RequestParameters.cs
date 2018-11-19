using System;

namespace PoLaKoSz.Deezer.Models
{
    public class RequestParameters
    {
        public string Slug { get; private set; }



        public RequestParameters()
        {
            Slug = "";
        }

        public RequestParameters(int id)
            : this()
        {
            AddID(id);
        }



        public void Add(string name, string value)
        {
            Slug = string.Format("{0}&{1}={2}", Slug, name, value);
        }

        public void Add(string name, int value)
        {
            Add(name, value.ToString());
        }

        public void AddID(int value)
        {
            Slug = string.Format("{0}{1}/", Slug, value);
        }

        public void AddSegment(string name)
        {
            Slug = string.Format("{0}{1}/", Slug, name);
        }
    }
}
