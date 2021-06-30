using System;
using System.Collections.Generic;

namespace FamilyBudget
{   public class Persons
    {// поля
        public string name; //имя
        public string pol;  //пол
        public DateTime date_birsday; //дата рождения
        public string more_info; //комментарий
        // свойства
        public string Name { get { return name; } set { name = value; } }
        public string Pol { get { return pol; } }
        public DateTime Date_birthday { get { return date_birsday; } set { date_birsday = value; } }
        public string More_info { get { return more_info; } set { more_info = value; } }
        // конструктор
        public Persons(string name, string pol, DateTime date_birsday, string more_info)
        {
            this.name = name; this.pol = pol;
            this.date_birsday = date_birsday;
            this.more_info = more_info;
        }
        // информация о персонах
        public string Info()
        {
            string s = "";
            s += string.Format("Имя: {0}\n", name);
            s += string.Format("Пол: {0}\n", pol);
            s += string.Format("Дата рождения: {0}\n", date_birsday.ToShortDateString());
            if (more_info!="")
            s += string.Format("Комментарий: {0}\n", more_info);
            s += "\n";
            return s;
        }
    }
}
