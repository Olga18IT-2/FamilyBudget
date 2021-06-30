using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
namespace FamilyBudget
{    public partial class MyTransactions : Form
    {   private User MyFamily; 
        public MyTransactions(User MyFamily)
        {   InitializeComponent();   this.MyFamily = MyFamily;   }
        private void Income_Click(object sender, EventArgs e) // добавить доходы
        {
            string name = comboBox1.SelectedItem.ToString();
            string[] read = name.Split('\t');
            name = read[0];
            Account account = null;
            for (int i=0; i<MyFamily.Accounts.Count; i++)     // определение, какой аккаунт (счёт) выбран
            {   if (MyFamily.Accounts[i].Name == name)
                { account = MyFamily.Accounts[i]; break; }
            }
            name = comboBox2.SelectedItem.ToString();         // определение, какой пользователей выбран
            Persons person = null;
            for (int i = 0; i < MyFamily.Family.Count; i++)
            {   if (MyFamily.Family[i].Name == name)
                { person = MyFamily.Family[i]; break; }
            }       
            string type = comboBox3.SelectedItem.ToString();  // выбранная категория
            string summa = textBox1.Text;                     // введённая сумма
            string date = textBox7.Text;// дата
            string more_info = textBox2.Text;                 // комментарий
            string date_now = DateTime.Now.ToShortDateString();
            if (Convert.ToDateTime(date) > Convert.ToDateTime(date_now))
            {   MessageBox.Show("Введённая дата позже сегодняшней дате!!!\n Введите другую дату и повторите попытку!!!",
                                 "Ошибка!!!");
            }
            else
            { double y; if (double.TryParse(summa, out y) && y>0)
                {   Income tr = new Income(person.Name, double.Parse(summa), Convert.ToDateTime(date),  account.Name, type, more_info);
                    tr.AddIncome(MyFamily, tr);
                    int m = Convert.ToDateTime(date).Month;
                    MyFamily.Months[m - 1].SortTransactions();
                    MessageBox.Show(tr.Info(MyFamily), "Операция дохода успешно добавлена!!!");
                    textBox1.Text = ""; textBox2.Text = ""; // очистка ячеек
                    textBox7.Text = DateTime.Now.ToShortDateString();
                }
                else { MessageBox.Show("Неверно введена сумма!!!\nВведите корректно сумму и повторите попытку!!!",
                                       "Ошибка!!!"); }
            }
        }
        private void Expenses_Click(object sender, EventArgs e) // добавить расходы
        {
            string name = comboBox6.SelectedItem.ToString();
            string[] read = name.Split('\t');
            name = read[0];
            Account account = null;
            for (int i = 0; i < MyFamily.Accounts.Count; i++) // определение, какой аккаунт (счёт) выбран
            {
                if (MyFamily.Accounts[i].Name == name)
                { account = MyFamily.Accounts[i]; break; }
            }
            name = comboBox5.SelectedItem.ToString();         // определение, какой пользователей выбран
            Persons person = null;
            for (int i = 0; i < MyFamily.Family.Count; i++)
            {
                if (MyFamily.Family[i].Name == name)
                { person = MyFamily.Family[i]; break; }
            }
            string type = comboBox4.SelectedItem.ToString();  // выбранная категория
            string summa = textBox3.Text;                     // введённая сумма
            string date = textBox8.Text;                      // дата
            string more_info = textBox4.Text;                 // комментарий
            string date_now = DateTime.Now.ToShortDateString();
            if (Convert.ToDateTime(date) > Convert.ToDateTime(date_now))
            {  MessageBox.Show("Введённая дата позже сегодняшней дате!!!\n Введите другую дату и повторите попытку!!!",
                                "Ошибка!!!");
            }
            else
            {
                double y; if (double.TryParse(summa, out y) && y>0) // обработка исключительной ситуации
                {   if (account.TrueRemoveMoney(double.Parse(summa)))
                    {
                        Expenses tr = new Expenses(person.Name, double.Parse(summa), Convert.ToDateTime(date),  account.Name, type, more_info);
                        tr.AddExpenses(MyFamily, tr);
                        MyFamily.Months[Convert.ToDateTime(date).Month - 1].SortTransactions();
                        MessageBox.Show(tr.Info(MyFamily), "Операция расхода успешно добавлена!!!");
                        textBox3.Text = ""; textBox4.Text = ""; // очистка ячеек
                        textBox8.Text = DateTime.Now.ToShortDateString();
                    }
                else {
                        MessageBox.Show("На счёте имеется : "+account.Money +" "+ account.Valyta+"\n"+
                            " А необходимо : "+summa+"Br,\n Не хватает : "+(double.Parse(summa)-account.Money)+" Br\n\n"+
                            "Выберите другой счёт или введите другую сумму и повторите попытку!!!",
                            "Ошибка!!! Недостаточно средств на счёте"); }
                }
                else
                {
                    MessageBox.Show("Неверно введена сумма!!!\nВведите корректно сумму и повторите попытку!!!",
                                    "Ошибка!!!");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) // добавить счёт
        {   MyAccounts f1 = new MyAccounts(MyFamily);  f1.ShowDialog(); }
        private void button1_Click(object sender, EventArgs e) // обновить список счетов
        { comboBox1.Items.Clear();  for (int i = 0; i < MyFamily.Accounts.Count; i++)
          comboBox1.Items.Add(MyFamily.Accounts[i].Name + "\t   (" + MyFamily.Accounts[i].Money + " " + MyFamily.Accounts[i].Valyta + ")"); }
        private void button4_Click(object sender, EventArgs e) // добавить пользователя
        {   MyPersons f1 = new MyPersons(MyFamily); f1.ShowDialog();    }
        private void button3_Click(object sender, EventArgs e) // обновить список пользователей
        { comboBox2.Items.Clear(); comboBox2.DataSource = MyFamily.Family; comboBox2.DisplayMember = "Name"; }
        private void button6_Click(object sender, EventArgs e) // добавить категорию
        {  Categories f1 = new Categories(MyFamily); f1.ShowDialog();       }
        private void button5_Click(object sender, EventArgs e) // обновить список категорий доходов
        { comboBox3.Items.Clear(); comboBox3.DataSource = MyFamily.Categories_income;     }
        private void button12_Click(object sender, EventArgs e)//добавить счёт
        { MyAccounts f1 = new MyAccounts(MyFamily); f1.ShowDialog(); }
        private void button11_Click(object sender, EventArgs e) // обновить список счетов
        {  comboBox6.Items.Clear(); for (int i = 0; i < MyFamily.Accounts.Count; i++)
           comboBox6.Items.Add(MyFamily.Accounts[i].Name + "\t   (" + MyFamily.Accounts[i].Money + " " + MyFamily.Accounts[i].Valyta + ")"); ;
        }
        private void button10_Click(object sender, EventArgs e)//добавить пользователя
        { MyPersons f1 = new MyPersons(MyFamily); f1.ShowDialog(); }
        private void button9_Click_1(object sender, EventArgs e)// обновить список пользователей
        { comboBox5.Items.Clear();  comboBox2.DataSource = MyFamily.Family; comboBox5.DisplayMember = "Name"; }
        private void button8_Click_1(object sender, EventArgs e)// добавить категорию
        { Categories f1 = new Categories(MyFamily); f1.ShowDialog(); }
        private void button7_Click_1(object sender, EventArgs e)// обновить список категорий расходов
        { comboBox4.Items.Clear();  comboBox4.DataSource = MyFamily.Categories_expenses; }
        private void button17_Click(object sender, EventArgs e) // выполнить перевод с счета на счет
        {   string name = comboBox8.SelectedItem.ToString(); //откуда
            string[] read = name.Split('\t');
            name = read[0];
            Account a1 = null;
            for (int i = 0; i < MyFamily.Accounts.Count; i++) // определение, какой аккаунт (счёт) выбран
            {   if (MyFamily.Accounts[i].Name == name)
                { a1 = MyFamily.Accounts[i]; break; }
            }
            name = comboBox7.SelectedItem.ToString();
            read = name.Split('\t');
            name = read[0];
            Account a2 = null;
            for (int i = 0; i < MyFamily.Accounts.Count; i++) // определение, какой аккаунт (счёт) выбран
            {   if (MyFamily.Accounts[i].Name == name)
                { a2 = MyFamily.Accounts[i]; break; }
            }
            string summa = textBox11.Text;
            double y; if (double.TryParse(summa, out y) && y>0)
            { a1.TransportingMoney(double.Parse(summa), a1, a2);  }
            else { MessageBox.Show("Неверно введена сумма!!!\nВведите корректно сумму и повторите попытку!!!", "Ошибка!!!"); }
            


        }
        private void button16_Click(object sender, EventArgs e)//добавить счёт
        { MyAccounts f1 = new MyAccounts(MyFamily); f1.ShowDialog();  }
        private void button15_Click(object sender, EventArgs e)//обновить список счетов
        {   comboBox7.Items.Clear(); comboBox8.Items.Clear();
            for (int i = 0; i < MyFamily.Accounts.Count; i++)
            {   comboBox7.Items.Add(MyFamily.Accounts[i].Name + "\t   (" + MyFamily.Accounts[i].Money + " " + MyFamily.Accounts[i].Valyta + ")");
                comboBox8.Items.Add(MyFamily.Accounts[i].Name + "\t   (" + MyFamily.Accounts[i].Money + " " + MyFamily.Accounts[i].Valyta + ")");
            }
        }
        // Обработчик события "Загрузить форму"
        private void MyTransaction_Load(object sender, EventArgs e)
        {
            textBox9.Text = MyFamily.Login;
            textBox5.Text = " Br ";
            textBox6.Text = " Br ";
            /* доходы*/
            textBox7.Text = DateTime.Now.ToShortDateString();
            //список счетов
            for (int i = 0; i < MyFamily.Accounts.Count; i++)
                comboBox1.Items.Add(MyFamily.Accounts[i].Name + "\t   (" + MyFamily.Accounts[i].Money + " " + MyFamily.Accounts[i].Valyta + ")");
            //список пользователей
            for (int i = 0; i < MyFamily.Family.Count; i++)
                comboBox2.Items.Add(MyFamily.Family[i].Name);
            //список категорий доходов
            for (int i = 1; i < MyFamily.Categories_income.Count; i++)
                comboBox3.Items.Add(MyFamily.Categories_income[i]);
            /*расходы*/
            textBox8.Text = DateTime.Now.ToShortDateString();
            //список счетов
            for (int i = 0; i < MyFamily.Accounts.Count; i++)
                comboBox6.Items.Add(MyFamily.Accounts[i].Name + "\t   (" + MyFamily.Accounts[i].Money + " " + MyFamily.Accounts[i].Valyta + ")");
            //список пользователей
            for (int i = 0; i < MyFamily.Family.Count; i++)
                comboBox5.Items.Add(MyFamily.Family[i].Name);
            //список категорий расходов
            for (int i = 1; i < MyFamily.Categories_expenses.Count; i++)
                comboBox4.Items.Add(MyFamily.Categories_expenses[i]);
            /*перевод*/
            textBox10.Text = "Br";
            for (int i = 0; i < MyFamily.Accounts.Count; i++)
            {
                comboBox8.Items.Add(MyFamily.Accounts[i].Name + "\t   (" + MyFamily.Accounts[i].Money + " " + MyFamily.Accounts[i].Valyta + ")");
                comboBox7.Items.Add(MyFamily.Accounts[i].Name + "\t   (" + MyFamily.Accounts[i].Money + " " + MyFamily.Accounts[i].Valyta + ")");
            }
        }


    }
}