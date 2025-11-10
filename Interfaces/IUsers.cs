using Interface_Osennikov.Models;
using System.Collections.Generic;

namespace Interface_Osennikov.Interfaces
{
    internal interface IUsers
    {
        void All(out List<Users> users);
    }
}
