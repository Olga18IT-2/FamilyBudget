using System;

namespace FamilyBudget
{   class Expenses : Transactions // класс Расходы - наследник от класса Транзакции
    {   public Expenses(string chelovek, double summa, DateTime date,  string bank_accoint, string type, string more_info) 
            : base(chelovek, summa, date, bank_accoint, type,  more_info)
        {   Name = "Расходы";
        }
        public void AddExpenses(User MyFamily, Expenses expense)  // все операции при добавление операции дохода
        {   int m = expense.Date.Month;  // номер месяца 
            Account a = null;            
            // определение того, какой аккаунт был выбран
            for (int i = 0; i < MyFamily.Accounts.Count; i++)
            { if (expense.Bank_account == MyFamily.Accounts[i].Name)
                { a = MyFamily.Accounts[i]; }
            }
            a.RemoveMoney(expense.Summa); // со счёта снимаем сумму
            // определение того, какая категория выбрана  и добавление соответствующей суммы в список
            for (int i = 1; i < MyFamily.Categories_expenses.Count; i++)
            {
                if (MyFamily.Categories_expenses[i] == expense.Type)
                   { MyFamily.Months[m-1].Expenses_this_month[i] += expense.Summa; break; }
            }
            // добавление расхода в список всех операций
            MyFamily.Months[m - 1].Transactions_this_month.Add(expense);
        }
        
    }
}
