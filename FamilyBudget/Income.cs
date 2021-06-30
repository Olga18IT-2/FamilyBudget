using System;

namespace FamilyBudget
{
    class Income : Transactions //класс Доходы - наследник класса Транзакции
    {   public Income( string chelovek, double summa, DateTime date, string bank_account, string type, string more_info) 
        : base(chelovek, summa, date, bank_account, type, more_info)
        {  Name = "Доходы";           
        }
        public void AddIncome(User MyFamily, Income income) // все операции при добавление операции расхода
        {
            int m = income.Date.Month;// номер месяца 
            Account a = null;
            // определение того, какой аккаунт был выбран
            for (int i=0; i<MyFamily.Accounts.Count;i++)
            { if (income.Bank_account == MyFamily.Accounts[i].Name)
                { a = MyFamily.Accounts[i]; }
            }

            a.AddMoney(income.Summa); // на счёт добавляем сумма
            // определение того, какая категория выбрана  и добавление соответствующей суммы в список
            for (int i=1;i<MyFamily.Categories_income.Count; i++)
            {   if (MyFamily.Categories_income[i] == income.Type)
                { MyFamily.Months[m-1].Income_this_month[i] += income.Summa; break; }
            }
            // добавление дохода в список всех операций
            MyFamily.Months[m-1].Transactions_this_month.Add(income);
        }
        


    }
}
