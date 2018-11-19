using PoLaKoSz.Deezer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoLaKoSz.Deezer.EndPoints
{
    public interface IUserGetter
    {
        Task<List<Album>> Albums();
    }
}
