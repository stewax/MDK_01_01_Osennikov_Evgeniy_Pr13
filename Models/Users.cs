using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Osennikov.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public Users()
        {

        }
        public Users(int id, string fio)
        {
            Id = id;
            FIO = fio;
        }
    }
}
