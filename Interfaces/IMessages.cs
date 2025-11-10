using System.Collections.Generic;
using Interface_Osennikov.Models;

namespace Interface_Osennikov.Interfaces
{
    internal interface IMessages
    {
        void All(out List<Messages> messages);
        void Save(bool update = false);
        void Delete();
    }
}
