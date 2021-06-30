using System;

namespace FamilyBudget
{
    abstract class Transactions   // абстрактный класс - операции(транзакции)
    {// поля
        private string name;      //наименование  (доходы/расходы)
        private string type;      //категория
        private double summa;     //сумма
        private string valyta;    //валюта
        private DateTime date;    //дата
        private string chelovek;  // пользователь - имя
        private string bank_account;//счет - имя
        private string more_info; //примечания
       // конструктор
        public Transactions( string chelovek, double summa, DateTime date, string bank_account, string type, string more_info)
        {
            this.chelovek = chelovek;
            this.summa = summa;
            valyta = " Br";
            this.date = date;
            this.more_info = more_info;
            this.bank_account = bank_account;
            this.type = type;
        }
        // свойства
        public string Name { get { return name; } set { name = value; } }
        public DateTime Date { get { return date; } }
        public string Chelovek { get { return chelovek; } }
        public string More_info { get { return more_info; } }
        public double Summa { get { return summa; } }
        public string Bank_account { get { return bank_account; } }
        public string Type { get { return type; } }
        public string Valyta { get { return valyta; } }

        public Account Account
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Persons Persons
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        // информация о операциях
        public string Info(User MyFamily)
        {
            string s = "";
            s += (Name + ":\n");
            s += ("Категория: " + Type + "\n");
            s += ("Сумма: " + Summa + " " + Valyta + "\n");
            s += ("Дата: " + Date.ToShortDateString() + "\n");
            s += ("Пользователь: " + Chelovek + "\n");
            Account a = null;
            for (int i = 0; i < MyFamily.Accounts.Count; i++) { if (Bank_account == MyFamily.Accounts[i].Name) { a = MyFamily.Accounts[i]; }    }
            s += ("Счёт: " + Bank_account + " ( Остаток на счёте:  " + a.Money + " " + a.Valyta + " ) ");
            if (More_info != "")
                s += ("Комментарий: " + More_info + "\n");
            return s;
        }



    }
}
