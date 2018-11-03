using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Models.Permissions
{
    public class Permission : IPermission
    {
        public string Name { get; }



        public Permission(string name)
        {
            Name = name;
        }



        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(Permission))
                return false;

            var anotherPermission = (Permission)obj;

            if (!Name.Equals(anotherPermission.Name))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
