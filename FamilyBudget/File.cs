using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;

namespace FamilyBudget
{
    public class Files // класс файлы 
        //используется для сохранение данных в файлы(как общих данных,так и отчётов) 
        //и внесения данных из файла в программу
    {
        private string name;      // наименование файла
        private string full_name; // наименование + расширением
        private User person;      // пользователь, данные которого нужно сохранить
       public Files (User person)
       { this.person = person;  }
        public Files (string name,  User person)
       { this.name = name; this.person = person; full_name = name+".txt"; }
        public Files (string name)
        { this.name = name;  full_name = name+".txt"; person = null; }

        public void NewFamily(string parol, string question, string answer)  
            // метод для внесения первоначальных данных в новый файл о новой семье
        {   if (FileExist()==false)
            {
                StreamWriter fr = new StreamWriter(File.Create(@"users\" + full_name)); // создаётся новый файл
                fr.WriteLine(parol); // в файл записывается пароль
                fr.WriteLine(question); // в файл записывается вопрос
                fr.WriteLine(answer); // в файл записывается ответ
                fr.Close();
            }
        }
        public bool FileExist()   // проверка на то,существует ли файл?
        {   if (File.Exists(@"users\"+full_name)) return true;   else return false;  }
        public bool TrueParol(string my_parol)// проверка на то, правильно ли введён пароль при входе в программу ? 
        {   if (my_parol == ShowParol()) return true; else return false;        }
        public bool TrueAnswer(string answer)//проверка на то, правильно ли введён ответ на вопрос при восстановлении пароля?
        { if (answer == ShowAnswer()) return true; else return false; }
        public string ShowParol() // вывод пароля,который введён в 1-ую строку файла
        {   StreamReader fr = new StreamReader(@"users\"+full_name); return fr.ReadLine();     }
        public string ShowQuestion()// вывод вопроса,который введён в 2-ую строку файла
        {   StreamReader fr = new StreamReader(@"users\"+full_name);
            fr.ReadLine(); string question = fr.ReadLine(); return question;                  }
        public string ShowAnswer()// вывод ответа,который введён в 3-юю строку файла
        {   StreamReader fr = new StreamReader(@"users\"+full_name);
            fr.ReadLine();fr.ReadLine(); string answer = fr.ReadLine(); return answer;        }
        public User OpenFile()       // открыть файл с сохранёнными данными (входные данные программы)
        {   StreamReader fr = new StreamReader(@"users\"+full_name); // создаётся новый файл
            string parol = fr.ReadLine();     //пароль
            string question = fr.ReadLine();  //вопрос для восстановления пароля
            string answer = fr.ReadLine();    //ответ на него
            fr.ReadLine();                    //чтение новой строчки(пропуск пустой строчки)
            string n = fr.ReadLine();         //чтение новой строчки
            // если она не равна "Пользователи:", то файл дальше пустой-можно закрывать файл
            if (n != "Пользователи:") { fr.Close(); return new User(name, parol, question, answer); }
            else // иначе...
            {   //Пользователи
                List<Persons> persons = new List<Persons>();
                n = fr.ReadLine();
                //производится построчное чтение до тех пор,пока не встретится пустая строка
                while (!string.IsNullOrEmpty(n))
                {
                    string[] read = n.Split('\t');
                    // имя, пол, дата рождения, комментарий
                    persons.Add(new Persons(read[0], read[1], DateTime.Parse(read[2]), read[3]));
                    n = fr.ReadLine();
                }
                n = fr.ReadLine(); //чтение новой строчки(пропуск пустой строчки)
                // Аккаунты (счета)
                List<Account> accounts = new List<Account>();
                if (n == "Аккаунты:")
                {
                    n = fr.ReadLine();
                    //производится построчное чтение до тех пор,пока не встретится пустая строка
                    while (!string.IsNullOrEmpty(n))
                    {
                        string[] read = n.Split('\t');
                        accounts.Add(new Account(read[0], double.Parse(read[1]), read[2]));
                        n = fr.ReadLine();
                    }
                }
                // Категории доходов
                List<string> income = new List<string>();
                n = fr.ReadLine(); string[] income_name = n.Split('\t');
                for (int i = 0; i < income_name.Length; i++) { income.Add(income_name[i]); }
                fr.ReadLine(); //чтение новой строчки(пропуск пустой строчки)
                // Категории расходов
                List<string> expenses = new List<string>();
                n = fr.ReadLine(); string[] expenses_name = n.Split('\t');
                for (int i = 0; i < expenses_name.Length; i++) { expenses.Add(expenses_name[i]); }
                fr.ReadLine(); //чтение новой строчки(пропуск пустой строчки)
                // Месяцы
                n = fr.ReadLine();
                List<Month> months = new List<Month>();
                for (int i = 1; i <= 12; i++) months.Add(null);
                if (n == "Месяцы:")
                {
                    n = fr.ReadLine();
                    while (n == "Месяц номер") // если там написано число, то...
                    {
                        int y = Convert.ToInt32(fr.ReadLine());
                        n = fr.ReadLine();
                        ArrayList transactions = new ArrayList();
                        if (n == "Транзакции:")
                        {
                            n = fr.ReadLine();
                            // построчное чтение, пока не встретиться пустая строка
                            if (!string.IsNullOrEmpty(n))
                            {
                                while (!string.IsNullOrEmpty(n))
                                {
                                    string[] read = n.Split('\t');
                                    // если это доход
                                    if (read[0] == "Доходы")
                                    {
                                        transactions.Add(new Income(read[1], double.Parse(read[2]),
                                       DateTime.Parse(read[3]), read[6], read[5], read[4]));
                                        //string chelovek, double summa, DateTime date, string bank_account, string type, string more_info
                                        //Доходы	Ольга	10	07.04.2020		Вернули долг	Копилка
                                    }
                                    // если это расход
                                    if (read[0] == "Расходы")
                                    {//string chelovek, double summa, DateTime date,  string bank_accoint, string type, string more_info
                                        //Расходы	Ольга	2,4	07.04.2020		Поездки (транспорт, такси)	Наличные
                                        transactions.Add(new Expenses(read[1], double.Parse(read[2]),
                                        DateTime.Parse(read[3]), read[6], read[5], read[4]));
                                    }

                                    n = fr.ReadLine(); // чтение новой(следующей) строки
                                }
                            }
                            else fr.ReadLine();
                        }
                        // Доходы за этот месяц по категориям
                        n = fr.ReadLine(); List<double> income_this_month = new List<double>();
                        if (n == "Доходы по категориям:")
                        {
                            string[] read = fr.ReadLine().Split('\t');
                            for (int i = 0; i < read.Length; i++) { income_this_month.Add(double.Parse(read[i])); }
                        }
                        //Расходы за этот месяц по категориям
                        n = fr.ReadLine(); List<double> expenses_this_month = new List<double>();
                        if (n == "Расходы по категориям:")
                        { 
                            string[] read = fr.ReadLine().Split('\t');
                            for (int i = 0; i < read.Length; i++) { expenses_this_month.Add(double.Parse(read[i])); }
                        }
                        fr.ReadLine();
                        n = fr.ReadLine();
                        // Планирование
                        List<double> plan_exp = new List<double>(); List<double> plan_inc = new List<double>();
                        List<string> more_plan_exp = new List<string>(); List<string> more_plan_inc = new List<string>();
                        if (n == "Планирование:")
                        { n = fr.ReadLine();
                            if (n == "Доходы по категориям:")
                            {   string[] read = fr.ReadLine().Split('\t');
                                for (int i = 0; i < read.Length; i++) { plan_inc.Add(double.Parse(read[i])); }
                                read = fr.ReadLine().Split('\t');
                                for (int i = 0; i < read.Length; i++) { more_plan_inc.Add(read[i]); }
                            }
                            //Расходы за этот месяц по категориям
                            n = fr.ReadLine(); 
                            if (n == "Расходы по категориям:")
                            {   string[] read = fr.ReadLine().Split('\t');
                                for (int i = 0; i < read.Length; i++) { plan_exp.Add(double.Parse(read[i])); }
                                read = fr.ReadLine().Split('\t');
                                for (int i = 0; i < read.Length; i++) { more_plan_exp.Add(read[i]); }
                            }
                            fr.ReadLine();
                        }
                        months[y - 1] = new Month(y, transactions, income_this_month, 
                            expenses_this_month, plan_exp, plan_inc, more_plan_exp, more_plan_inc);
                        n = fr.ReadLine();
                    }
                }
                for (int i = 1; i <= 12; i++)
                { if (months[i - 1] == null) months[i - 1] = new Month(i, income, expenses); }
                User MyFamily = new User(name, parol, question, answer, persons, accounts,
                    income, expenses, months);
                fr.Close();
                return MyFamily;
            }
        }
        public void SaveFile(string m, string year, DataGridView inc, string[,]mas1, DataGridView exp, string[,]mas2) 
            // сохранение данных(отчёта) в эксель
        {   Excel.Application ex = new Excel.Application();
            Excel.Workbook exWorkBook;
            exWorkBook = ex.Workbooks.Add(Type.Missing);
            Worksheet exWorksheet = (Excel.Worksheet)exWorkBook.Sheets[1];
            exWorksheet.Columns.AutoFit();
            exWorksheet.Name = "Результаты";	//переименовывает активный лист
            int x = 0, y = 0; // координаты ячейки в таблице
            x = 1; ex.Cells[x, 2] = "Cемья"; ex.Cells[x, 3] = person.Login;
            x ++;  ex.Cells[x, 1] = "Месяц"; ex.Cells[x, 2] = m; ex.Cells[x, 4] = year;
            x += 2;
            for (int i = 1; i < inc.Columns.Count + 1; i++)	//заполнение заголовков datagridview
            { exWorksheet.Cells[x, i] = inc.Columns[i - 1].HeaderText;
                (exWorksheet.Cells[x, i] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.LightGray;
            }
            for (int i = 0; i < inc.Rows.Count; i++)	//заполнение строк и столбцов datagridview
            {   x = x + 1; y = 1;
                for (int j = 0; j < inc.Columns.Count; j++)
                {  ex.Cells[x, j + y] = inc.Rows[i].Cells[j].Value;
                    if ( inc.Rows[i].Cells[j].Style.BackColor == Color.YellowGreen  ||
                         inc.Rows[i].Cells[j].Style.BackColor == Color.Pink         ||
                         inc.Rows[i].Cells[j].Style.BackColor == Color.LightSkyBlue ||
                         inc.Rows[i].Cells[j].Style.BackColor == Color.LawnGreen    ||
                         inc.Rows[i].Cells[j].Style.BackColor == Color.LightCoral   ||
                         inc.Rows[i].Cells[j].Style.BackColor == Color.LightCyan)
                        (exWorksheet.Cells[x, j+y] as Microsoft.Office.Interop.Excel.Range).Interior.Color = inc.Rows[i].Cells[j].Style.BackColor;
                }
            }
            for (int i=0; i<4; i++)  // заполнение строк и стотбцов значениями из двухмерного массива
            {   x = x + 1; y = 1;
                for (int j=0; j<3; j++ )
                {  ex.Cells[x, y + j] = mas1[i, j];  }
            }
            x += 2; for (int i = 1; i < exp.Columns.Count + 1; i++)	//заполнение заголовков datagridview
            { exWorksheet.Cells[x, i] = exp.Columns[i - 1].HeaderText;
             (exWorksheet.Cells[x, i] as Microsoft.Office.Interop.Excel.Range).Interior.Color = Color.LightGray;
            }
            for (int i = 0; i < exp.Rows.Count; i++)	//заполнение строк и столбцов datagridview
            {   x = x + 1; y = 1;
                for (int j = 0; j < exp.Columns.Count; j++)
                { ex.Cells[x, j + y] = exp.Rows[i].Cells[j].Value;
                    if (exp.Rows[i].Cells[j].Style.BackColor == Color.YellowGreen   ||
                         exp.Rows[i].Cells[j].Style.BackColor == Color.Pink         ||
                         exp.Rows[i].Cells[j].Style.BackColor == Color.LightSkyBlue ||
                         exp.Rows[i].Cells[j].Style.BackColor == Color.LawnGreen    ||
                         exp.Rows[i].Cells[j].Style.BackColor == Color.LightCoral   ||
                         exp.Rows[i].Cells[j].Style.BackColor == Color.LightCyan  )
                    (exWorksheet.Cells[x, j+y] as Microsoft.Office.Interop.Excel.Range).Interior.Color = exp.Rows[i].Cells[j].Style.BackColor;
                }
            }
            for (int i = 0; i < 4; i++) // заполнение строк и стотбцов значениями из двухмерного массива
            {
                x = x + 1; y = 1;
                for (int j = 0; j < 3; j++)
                ex.Cells[x, y + j] = mas2[i, j]; 
            }
            exWorksheet.Columns.AutoFit();
            MessageBox.Show("Данные успешно перенесены в Excel !");
            ex.Visible = true;
            ex.UserControl = true;
            
            

        }
        public void SaveFile() // сохранение данных в файл
        {
            string login = person.Login;
            StreamWriter fr = new StreamWriter(@"users\" + full_name);
            fr.WriteLine(person.Password);
            fr.WriteLine(person.Question);
            fr.WriteLine(person.Answer);
            fr.WriteLine();
            // пользователи
            fr.WriteLine("Пользователи:");
            for (int i = 0; i < person.Family.Count; i++)
            {
                fr.WriteLine(person.Family[i].Name + "\t" + person.Family[i].Pol + "\t" +
                person.Family[i].Date_birthday.ToShortDateString() + "\t" + person.Family[i].More_info);
            }
            fr.WriteLine();
            //счета
            fr.WriteLine("Аккаунты:");
            for (int i = 0; i < person.Accounts.Count; i++)
            { fr.WriteLine(person.Accounts[i].Name + "\t" + person.Accounts[i].Money + "\t" + person.Accounts[i].More_info); }
            fr.WriteLine();
            //категории доходов
            for (int i = 0; i < person.Categories_income.Count; i++)
            {
                if (i < person.Categories_income.Count - 1)
                { fr.Write(person.Categories_income[i] + "\t"); }
                else { fr.Write(person.Categories_income[i] + "\n"); }
            }
            fr.WriteLine();
            //категории расходов
            for (int i = 0; i < person.Categories_expenses.Count; i++)
            {
                if (i < person.Categories_expenses.Count - 1)
                { fr.Write(person.Categories_expenses[i] + "\t"); }
                else { fr.Write(person.Categories_expenses[i] + "\n"); }
            }
            fr.WriteLine();
            // Месяцы
            fr.WriteLine("Месяцы:");
            for (int i = 1; i <= 12; i++)
            {
                if (person.Months[i-1].True_planning() )
                {
                    fr.WriteLine("Месяц номер");
                    fr.WriteLine(i);
                    fr.WriteLine("Транзакции:");
                    int count = person.Months[i - 1].Transactions_this_month.Count;
                    if (count == 0) fr.WriteLine();
                    else
                    {
                        for (int j = 0; j < count; j++)
                        {
                            if (person.Months[i - 1].Transactions_this_month[j] is Income)
                            {//string chelovek, double summa, DateTime date, string bank_account, string type, string more_info
                             //Доходы	Ольга	10	07.04.2020		Вернули долг	Копилка
                                Income income = (Income)person.Months[i - 1].Transactions_this_month[j];
                                fr.WriteLine("Доходы\t" + income.Chelovek + "\t" + income.Summa + "\t" +
                                income.Date.ToShortDateString() + "\t" + income.More_info + "\t" +
                                income.Type + "\t" + income.Bank_account);
                            }
                            if (person.Months[i - 1].Transactions_this_month[j] is Expenses)
                            {
                                Expenses expenses = (Expenses)person.Months[i - 1].Transactions_this_month[j];
                                fr.WriteLine("Расходы\t" + expenses.Chelovek + "\t" + expenses.Summa + "\t" +
                                expenses.Date.ToShortDateString() + "\t" + expenses.More_info + "\t" +
                                expenses.Type + "\t" + expenses.Bank_account);
                            }
                        }
                    }
                    fr.WriteLine();

                    fr.WriteLine("Доходы по категориям:");
                    for (int k = 0; k < person.Months[i - 1].Income_this_month.Count; k++)
                    {
                        if (k < person.Months[i - 1].Income_this_month.Count - 1)
                        { fr.Write(person.Months[i - 1].Income_this_month[k] + "\t"); }
                        else { fr.Write(person.Months[i - 1].Income_this_month[k] + "\n"); }
                    }
                    fr.WriteLine("Расходы по категориям:");
                    for (int l = 0; l < person.Months[i - 1].Expenses_this_month.Count; l++)
                    {
                        if (l < person.Months[i - 1].Expenses_this_month.Count - 1)
                        { fr.Write(person.Months[i - 1].Expenses_this_month[l] + "\t"); }
                        else { fr.Write(person.Months[i - 1].Expenses_this_month[l] + "\n"); }
                    }
                    fr.WriteLine();
                    fr.WriteLine("Планирование:");
                    fr.WriteLine("Доходы по категориям:"); // планирование доходов по категориям
                    for (int k = 0; k < person.Months[i - 1].Plan_income_this_month.Count; k++)
                    {
                        if (k < person.Months[i - 1].Plan_income_this_month.Count - 1)
                        { fr.Write(person.Months[i - 1].Plan_income_this_month[k] + "\t"); }
                        else { fr.Write(person.Months[i - 1].Plan_income_this_month[k] + "\n"); }
                    } // дополнительная информация по планируемым доходам по категориям
                    for (int k = 0; k < person.Months[i - 1].More_info_plan_inc.Count; k++)
                    {
                        if (k < person.Months[i - 1].More_info_plan_inc.Count - 1)
                        { fr.Write(person.Months[i - 1].More_info_plan_inc[k] + "\t"); }
                        else { fr.Write(person.Months[i - 1].More_info_plan_inc[k] + "\n"); }
                    }
                    fr.WriteLine("Расходы по категориям:"); //планирование расходов по категориям
                    for (int l = 0; l < person.Months[i - 1].Plan_expenses_this_month.Count; l++)
                    {
                        if (l < person.Months[i - 1].Plan_expenses_this_month.Count - 1)
                        { fr.Write(person.Months[i - 1].Plan_expenses_this_month[l] + "\t"); }
                        else { fr.Write(person.Months[i - 1].Plan_expenses_this_month[l] + "\n"); }
                    }
                    // дополнительная информация по планируемым расходам по категориям
                    for (int k = 0; k < person.Months[i - 1].More_info_plan_exp.Count; k++)
                    {
                        if (k < person.Months[i - 1].More_info_plan_exp.Count - 1)
                        { fr.Write(person.Months[i - 1].More_info_plan_exp[k] + "\t"); }
                        else { fr.Write(person.Months[i - 1].More_info_plan_exp[k] + "\n"); }
                    }
                    fr.WriteLine();
                }
            }
            fr.Close();
        }




    }
}
