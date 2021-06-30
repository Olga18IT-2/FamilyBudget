using System;
using System.Collections.Generic;
using System.Collections;

namespace FamilyBudget
{   public class Month // месяц
    {// поля
        private int number;                       // номер месяца
        private ArrayList transactions_this_month;// расходы и доходы за текущий месяц 
        private List<double> income_this_month;   // доходы в этом месяце по категориям
        private List<double> expenses_this_month; // расходы в этом месяце по категориям
        private List<double> plan_expenses_this_month;//планирование расходов по категориям
        private List<double> plan_income_this_month;// планирование доходов по категориям
        private List<string> more_info_plan_exp;    // комментарии к планированию расходов по категориям
        private List<string> more_info_plan_inc;    // комментарии к планированию доходов по категориям
        // свойства
        public List<double> Income_this_month { get { return income_this_month; } set { income_this_month = value; } }
        public List<double> Expenses_this_month { get { return expenses_this_month; } set { expenses_this_month = value; } }
        public ArrayList Transactions_this_month { get { return transactions_this_month; } set { transactions_this_month = value; } }
        public List<double> Plan_expenses_this_month { get { return plan_expenses_this_month; } set { plan_expenses_this_month = value; } }
        public List<double> Plan_income_this_month { get { return plan_income_this_month; } set { plan_income_this_month = value; } }
        public List<string> More_info_plan_exp { get { return more_info_plan_exp; } set { more_info_plan_exp = value; } }
        public List<string> More_info_plan_inc { get { return more_info_plan_inc; } set { more_info_plan_inc = value; } }

        internal Transactions Transactions
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
        public Month (int number, List<string> income, List<String> expenses)
        {   this.number = number;
            transactions_this_month = new ArrayList(); 
            income_this_month = new List<double>(); plan_income_this_month = new List<double>(); more_info_plan_inc = new List<string>();
            income_this_month.Add(number); plan_income_this_month.Add(number); more_info_plan_inc.Add(number.ToString());
            for (int j = 1; j < income.Count; j++)
            {
                income_this_month.Add(0); plan_income_this_month.Add(0); more_info_plan_inc.Add("");
            }
            expenses_this_month = new List<double>(); plan_expenses_this_month = new List<double>(); more_info_plan_exp = new List<string>();
            expenses_this_month.Add(number); plan_expenses_this_month.Add(number); more_info_plan_exp.Add(number.ToString());
            for (int i = 1; i < expenses.Count; i++)
            {
                expenses_this_month.Add(0); plan_expenses_this_month.Add(0); more_info_plan_exp.Add("");
            }
        }
        public Month (int number,                                       ArrayList transactions_this_month, 
                      List<double> income_this_month,                   List<double> expenses_this_month,
                      List<double> plan_expenses_this_month,            List<double> plan_income_this_month,
                      List<string> more_info_plan_exp,                  List<string> more_info_plan_inc)
            
        {   this.number = number; this.transactions_this_month = transactions_this_month; this.income_this_month = income_this_month;
            this.expenses_this_month = expenses_this_month;
            this.plan_expenses_this_month = plan_expenses_this_month; this.plan_income_this_month = plan_income_this_month;
            this.more_info_plan_exp = more_info_plan_exp; this.more_info_plan_inc = more_info_plan_inc;
        }
        public double Summa_expenses_fact()  // сумма расходов (факт)
        { double s = 0; for (int i=1;i<Expenses_this_month.Count; i++) { s = s + Expenses_this_month[i]; } return s; }
        public double Summa_expenses_plan()  // сумма расходов (план)
        { double s = 0; for (int i = 1; i < Plan_expenses_this_month.Count; i++) { s = s + Plan_expenses_this_month[i]; } return s; }
        public double Summa_income_fact()   // сумма доходов (факт)
        { double s = 0; for (int i = 1; i < Income_this_month.Count; i++) { s = s + Income_this_month[i]; } return s; }
        public double Summa_income_plan()   // сумма доходов (план)
        { double s = 0; for (int i = 1; i < Plan_income_this_month.Count; i++) { s = s + Plan_income_this_month[i]; } return s; }
        public double Razn_expenses()  // отклонение от плана по расходам = план - факт
        { return Summa_expenses_plan() - Summa_expenses_fact(); }
        public double Razn_income()    // отклонение от плана по доходам = факт - план
        { return Summa_income_fact() - Summa_income_plan(); }
        public bool True_planning()    // проверка на то, имеются ли данные о планировании за данный месяц
            //(необходимо для того,чтобы понять, нужно ли заносить эти данные в файл)
        {
            int k = 0; int m = 0; // k, m - счётчики, 
            // k=0 , если в списке планирования по расходам за данный месяц нет никаких данных, иначе k=1
            // m=0 , если в списке планирования по доходам за данный месяц нет никаких данных, иначе m=1
            for (int i=1; i < plan_expenses_this_month.Count; i++) { if (plan_expenses_this_month[i]!=0 || more_info_plan_exp[i]!="") { k = 1; break; } }
            for (int j=1; j<plan_income_this_month.Count; j++) { if (plan_income_this_month[j]!=0 || more_info_plan_inc[j]!="") { m = 1; break; } }
            if (Transactions_this_month.Count == 0 && k == 0 && m == 0)
            {   return false;   }
            else { return true; }
        }

        public ArrayList SortTransactions()
        {
            for(int i=0; i<Transactions_this_month.Count;i++)
            {   for (int j=i+1; j<Transactions_this_month.Count; j++)
                {
                    Transactions tr1=null, tr2=null;
                    if (Transactions_this_month[i] is Income)   {   tr1 = (Income) Transactions_this_month[i]; }
                    if (Transactions_this_month[j] is Income)   {   tr2 = (Income)Transactions_this_month[j]; }
                    if (Transactions_this_month[i] is Expenses) {   tr1 = (Expenses)Transactions_this_month[i];}
                    if (Transactions_this_month[j] is Expenses) {   tr2 = (Expenses)Transactions_this_month[j]; }
                    
                        if (tr1.Date > tr2.Date)
                        { Transactions_this_month[i] = tr2; Transactions_this_month[j] = tr1;  }
                }
            }
            return Transactions_this_month;
        }


    }
}
