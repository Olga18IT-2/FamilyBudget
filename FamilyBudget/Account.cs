using System;
using System.Windows.Forms;

namespace FamilyBudget
{
    public class Account //счёт
    {   //поля
        private string name; //наименование счёта
        private double money;//сумма на счёте
        private string more_info;//примечания
        private const string valyta = "Br";//валюта - основная-Br (бел.руб.)
        //свойства
        public string Name { get { return name; } set { name = value; } }
        public double Money { get { return money; }  }
        public string More_info { get { return more_info; } set { more_info = value; } }
        public string Valyta { get { return valyta; } }

        public Account(string name, double money, string more_info) // конструктор
        {
            this.name = name;
            this.money = money;
            this.more_info = more_info;
        }
        public void AddMoney(double x) //пополнить счет на х
        { money += x;   }
        public bool TrueRemoveMoney(double x) //можно ли списать со счёта х ден.ед.?
        { if (x <= Money) return true; else return false; }
        public void RemoveMoney(double x)//списать со счета х
        { money -= x; }
        public void TransportingMoney(double x, Account a1, Account a2) // перевод суммы x с счёта а1 на счёт а2
        {  if (a1 == a2) { MessageBox.Show("Выбраны одинаковые аккаунты!!!"+
                "\n Выберите корректно аккаунты и повторите попытку!","Ошибка!!!"); }
            else
            { if (a1.Money < x) { MessageBox.Show("Недостаточно средств на счёте!"+
                "\nНа счёте имеется : "+a1.Money+" "+a1.Valyta+
                "\nНеобходимо : "+ x + "Br" +
                "\nНе хватает : " + (x-a1.Money)+" Br"+
                "\nВыберите другой счёт, или введите другую сумму и повторите попытку!!!", "Ошибка!!!"); }
                 else
                { a1.RemoveMoney(x); a2.AddMoney(x);
                    MessageBox.Show("   Счёт:\n"+a1.Info()+
                    "\n   Счёт:\n"+a2.Info(), "Операция перевода средств выполнена успешна!!!");
                }
            }
        }
        public string Info() // информация о счёте
        {
            string s = "";
            s += string.Format("Наименование: {0}\n", name);
            s += string.Format("Сумма на счёте на данный момент времени: {0} {1}\n", money,valyta);
            if (more_info != "")
                s += string.Format("Примечания: {0}\n", more_info);
            s += "\n";
            return s;
        }



    }
}
