using System;
using System.Collections.Generic;

namespace FamilyBudget
{
    public class User
    {   // поля
        private string login;    //логин
        private string password; //пароль
        // если забыли пароль
        private string question; //контрольный вопрос 
        private string answer;   //ответ

        private List<Persons> family;             //члены семьи
        private List<Account> accounts;           //счета семьи (например, наличные, карточка, заначка и т.д.)
        private List<string> categories_income;   // категории доходов         "доходы:"                        далее названия
        private List<string> categories_expenses; // категории расходов
        private List<Month> months;               //месяцы (12 элементов - для 1 года)
        // свойства              
        public string Login { get { return login; } }
        public string Password { get { return password; } }
        public string Question { get { return question; } }
        public string Answer { get { return answer; } }
        public List<Persons> Family { get { return family; } set { family = value; } }
        public List<Account> Accounts { get { return accounts; } set { accounts = value; } }
        public List<string> Categories_income { get { return categories_income; } set { categories_income = value; } } 
        public List<string> Categories_expenses { get { return categories_expenses; } set { categories_expenses = value; } }
        public List <Month> Months { get { return months; } set { months = value; } }

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

        public Month Month
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Account Account1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        // конструктор
        // если регистрация (создание нового профиля)
        public User(string login, string password, string question, string answer)
        {
            this.login = login;             //логин
            this.password = password;       //пароль
            this.question = question;       //вопрос
            this.answer = answer;           //ответ
            family=new List<Persons>();   //список членов семьи
            accounts = new List<Account>(); //список счетов
            categories_expenses = new List<string>(); categories_expenses.Add("Категории расходов: ");
            categories_income = new List<string>();   categories_income.Add("Категории доходов: ");
            months = new List<Month>();
            for (int i=1; i<=12; i++)
            {  Month m = new Month(i, categories_income, categories_expenses);   months.Add(m); }        
        }
        
        // конструктор
        // вход в ранее созданный профиль
        public User(string login, string password, string question, string answer, List<Persons>family, List<Account>accounts,
            List<string> categories_income, List<string> categories_expenses, List<Month> months)
        {
            this.login = login;                               //логин
            this.password = password;                         //пароль
            this.question = question;                         //вопрос
            this.answer = answer;                             //ответ
            this.family = family;                             //список членов семьи
            this.accounts = accounts;                         //список счетов
            this.categories_income = categories_income;       //список категорий доходов
            this.categories_expenses = categories_expenses;   //cписок категорий расходов
            this.months = months;                             //список месяцев
        }
      
        public void AddPerson(Persons p)       //добавление члена семьи в список
        { family.Add(p);      }
        public void RemovePerson(Persons p)    //удаление члена семьи из списка
        { family.Remove(p);   }
        public void AddAccount(Account a)      //добавление счёта в список
        { accounts.Add(a);    }
        public void RemoveAccount(Account a)   //удаление счёта из списка
        { accounts.Remove(a); }
        public double Budget()                 // метод, выполняющий подсчёт общего бюджета семьи
        {   double summa = 0;
            for (int i = 0; i < Accounts.Count; i++) { summa = summa + Accounts[i].Money; }
            return summa;
        }
    }
}
