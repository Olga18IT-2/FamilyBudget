using System;
using System.Windows.Forms;
using System.Drawing;

namespace FamilyBudget
{   public partial class FamilyBudget : Form
    {
        private User MyFamily;
        public FamilyBudget(User MyFamily)
        {   InitializeComponent();   this.MyFamily = MyFamily;        }


        private void Users_Click(object sender, EventArgs e) //переход на вкладку пользователей
            //(возможность просмотра / создание новых / редактирования / удаления пользователей)
        {   MyPersons f1 = new MyPersons(MyFamily);       f1.ShowDialog();       }
        private void Accounts_Click(object sender, EventArgs e) //переход на вкладку счетов
             //(возможность просмотра / создание новых / редактирования / удаления счетов)
        {   MyAccounts f1 = new MyAccounts(MyFamily);    f1.ShowDialog();        }
        private void Categories_Click(object sender, EventArgs e) //переход на вкладку категории
        {  Categories f1 = new Categories(MyFamily);     f1.ShowDialog();        }
        private void Transactions_Click(object sender, EventArgs e) //переход на вкладку транзакции
        {   MyTransactions f1 = new MyTransactions(MyFamily);  f1.ShowDialog();  }
        private void Planning_Click(object sender, EventArgs e) //планирование
        {   MyPlanning f1 = new MyPlanning(MyFamily); f1.ShowDialog();            }
        private void Reports_Click(object sender, EventArgs e)  // отчёты
        {  Output f1 = new Output( MyFamily ); f1.ShowDialog();                            }
        private void button4_Click(object sender, EventArgs e) //сохранить данные
        {
            Files file = new Files(MyFamily.Login, MyFamily); // создание объекта с атрибутами - названием и объектом User
            file.SaveFile();                                  // cохранение данных атрибута User класса File в файл в названием name.txt
            MessageBox.Show("Данные успешно сохранены!!!");   // уведомление - успешное завершение сохранения
        }
        private void button3_Click(object sender, EventArgs e) //выход из приложения
        { Application.Exit(); /* закрытие приложения */} 
        private void button2_Click(object sender, EventArgs e) //выход в главное меню
        {   Hide();                         // скрытие формы
            Login first_form = new Login(); first_form.ShowDialog(); // переход на форму
            Close();    }                   //закрытие текущей формы
        private void button1_Click(object sender, EventArgs e) // обновить данные
        {   textBox1.Text = MyFamily.Login;      // вывод фамилии
            double summa = MyFamily.Budget();    // подсчёт и вывод общего бюджета семьи
            textBox2.Text = (Convert.ToString(summa) + " Br   ");
            int m = DateTime.Now.Month;          // определение номера месяца на данный момент времени
            dataGridView1.Rows.Clear();          // очистка ячеек таблицы
            ShowTransactions(m);                 // заполнение ячеек таблицы
            if (m < 10) textBox3.Text = "0" + m.ToString(); // вывод номера месяца 
            else textBox3.Text = m.ToString();  // (если меньше 10 - то 01,  ..., 09, иначе -  10, 11, 12)
        }
        
        private void ShowTransactions(int m)   // вывод операций в таблицу
        {   m = m - 1; // отнимаем 1,так как месяцы начинаются с 1, а индекс списков - с 0
            for (int  j=MyFamily.Months[m].Transactions_this_month.Count-1; j>=0; j--) // вывод операций с конца к началу
            {   
                if (MyFamily.Months[m].Transactions_this_month[j] is Income) // если данная операция - операция-доход, то...
                {
                    Income income = (Income)MyFamily.Months[m].Transactions_this_month[j]; // преобразуем операцию в соответствующий объект
                    // создаём строку
                    string[] Stroka = { "Доходы", income.Type, income.Chelovek, (income.Summa.ToString()+" "+income.Valyta),
                        income.Bank_account, income.Date.ToShortDateString(), income.More_info };
                    //добавляем ее в таблицу    
                    dataGridView1.Rows.Add(Stroka);
                    //определяем цвет данной строчки(зелёный)
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.BackColor = Color.LightGreen; 
                    }
                if (MyFamily.Months[m].Transactions_this_month[j] is Expenses) // если данная операция - операция-расход, то...
                {
                    Expenses expenses = (Expenses)MyFamily.Months[m].Transactions_this_month[j];//преобразуем оберацию в соответствующий объект
                    //создаем строку
                    string[] Stroka = { "Расходы", expenses.Type, expenses.Chelovek, (expenses.Summa.ToString()+" "+expenses.Valyta),
                    expenses.Bank_account, expenses.Date.ToShortDateString(), expenses.More_info};
                    //добавляем ее в таблицу
                    dataGridView1.Rows.Add(Stroka);
                    //опеределяем цвет данной строки(розовый)
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Pink;
                }
            }
        }
        // Обработчик события "Загрузить форму"
        private void FamilyBudget_Load(object sender, EventArgs e)
        {   textBox1.Text = MyFamily.Login;      // вывод фамилии
            double summa = MyFamily.Budget();    // подсчёт и вывод общего бюджета семьи
            textBox2.Text = (Convert.ToString(summa) + " Br   ");
            int m = DateTime.Now.Month;          // определение номера месяца на данный момент времени
            dataGridView1.Rows.Clear();          // очистка ячеек таблицы
            ShowTransactions(m);                 // заполнение ячеек таблицы
            if (m < 10) textBox3.Text = "0" + m.ToString(); // вывод номера месяца 
            else textBox3.Text = m.ToString();  // (если меньше 10 - то 01,  ..., 09,иначе -  10, 11, 12)
        }
        private void button6_Click(object sender, EventArgs e) // увеличение на 1 номер месяца (стрелочка вправо)
        {   int m = Convert.ToInt32(textBox3.Text); // преобразуем месяц из ячейки
            if (m <= 11) // если месяц равен 12 - то увеличить нельзя, иначе...
            {
                m = m + 1; // увеличиваем номер месяца на 1
                dataGridView1.Rows.Clear(); // очищаем ячейки таблицы
                ShowTransactions(m); // выводим данные об операциях за данный месяц в таблицу
                if (m < 10) textBox3.Text = "0" + m.ToString();// вывод номера месяца 
                else textBox3.Text = m.ToString();// (если меньше 10 - то 01,  ..., 09, иначе -  10, 11, 12)
            }
        }
        private void button5_Click(object sender, EventArgs e) // уменьшение на 1 номер месяца (стрелочка влево)
        {   int m = Convert.ToInt32(textBox3.Text);// преобразуем месяц из ячейки
            if (m >= 2)// если месяц равен 1 - то уменьшить нельзя, иначе...
            {   m = m - 1; // уменьшаем номер месяца на 1
                dataGridView1.Rows.Clear();// очищаем ячейки таблицы
                ShowTransactions(m);// выводим данные об операциях за данный месяц в таблицу
                if (m < 10) textBox3.Text = "0" + m.ToString();// вывод номера месяца 
                else textBox3.Text = m.ToString();// (если меньше 10 - то 01,  ..., 09, иначе -  10, 11, 12)
            }
        }
        



    }
}