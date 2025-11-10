using Interface_Osennikov.Interfaces;
using Interface_Osennikov.Models;
using System.Collections.Generic;

namespace Interface_Osennikov.Classes
{
    public class UsersContext : Users, IUsers
    {
        public List<Users> AllUsers;
        public UsersContext() => All(out AllUsers);

        public void All(out List<Users> users)
        {
            users = new List<Users>
            {
                new Users(1, "Аликина Ольга"),
                new Users(2, "Бояркин Данил"),
                new Users(3, "Бурмантов Владислав"),
                new Users(4, "Дылдин Максим"),
                new Users(5, "Квдокимов Даниил"),
                new Users(6, "Костюнин Никита"),
                new Users(7, "Кучин Данил"),
                new Users(8, "Мотырев Александр"),
                new Users(9, "Мухров Далер"),
                new Users(10, "Ослов Николай"),
                new Users(11, "Саблин Константин"),
                new Users(12, "Субботин Валерий"),
                new Users(13, "Сукрушев Егор"),
                new Users(14, "Торсунов Даниил"),
                new Users(15, "Бобров Евгений"),
                new Users(16, "Мохова Алена"),
                new Users(17, "Чернокомазов Анвар"),
                new Users(18, "Чечеткина Ольга"),
                new Users(19, "Чумачечий Владислав"),
                new Users(20, "Шиншилов Дима")
            };
        }
    }
}
