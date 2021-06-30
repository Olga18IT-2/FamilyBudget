using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FamilyBudget
{   public partial class MyAccounts : Form
    { private User MyFamily;
        public MyAccounts(User MyFamily)
        {  InitializeComponent();   this.MyFamily = MyFamily;  }
        private void button4_Click(object sender, EventArgs e) //новый счёт, или сохранение изменений данных счёта 
        {
            int x; if (Int32.TryParse(textBox5.Text, out x)) // обработка исключений
            {
                int i = Convert.ToInt32(textBox5.Text);
                //проверка по номеру счёта - существует ли он уже в списке?:
                if (i > MyFamily.Accounts.Count)         // - нет, тогда создаётся новый Account
                {   //создание нового объекта
                    double y; if (double.TryParse(textBox3.Text, out y) && y>0)
                    {
                        Account a = new Account(textBox2.Text, double.Parse(textBox3.Text), textBox4.Text);
                        MyFamily.AddAccount(a);               //добавление его как новый счет семьи 
                        textBox5.Text = Convert.ToString(MyFamily.Accounts.Count + 1);
                        textBox2.Text = "";                  //очистка ячейки                            - имя      
                        textBox3.Text = "";                  //очистка ячейки                            - сумма 
                        textBox4.Text = "";                  //очистка ячейки                            - коммент
                        ShowListAccounts(MyFamily);          //вывод изменённого списка
                        int ind = MyFamily.Accounts.Count;
                        string s = "Счёт № " + i + "\n" + MyFamily.Accounts[ind - 1].Info();
                        MessageBox.Show(s, "Счёт успешно добавлен!");
                    }
                    else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность введённой суммы)!!!"); }
                }
                else                                     // - да, тогда изменяется ранее созданный Account
                {   
                    MyFamily.Accounts[i - 1].Name = textBox2.Text;
                    MyFamily.Accounts[i - 1].More_info = textBox4.Text;
                    textBox6.Text = "";              //очистка ячейки                            - номер счета,который изменялся
                    textBox5.Text = Convert.ToString(MyFamily.Accounts.Count + 1);
                    textBox2.Text = "";                  //очистка ячейки                            - имя      
                    textBox3.Text = "";                  //очистка ячейки                            - сумма 
                    textBox4.Text = "";                  //очистка ячейки                            - коммент
                    ShowListAccounts(MyFamily);          //вывод изменённого списка
                    string s = "Счёт № " + i + "\n" + MyFamily.Accounts[i - 1].Info();
                    MessageBox.Show(s, "Информация о счёте успешна изменена!");
                }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера счёта)!!!"); }
        }
        private void button2_Click(object sender, EventArgs e)     // изменение счёта 
        {
            int x; if (Int32.TryParse(textBox6.Text, out x) && 0 < x && x<= MyFamily.Accounts.Count)
            {       textBox5.Text = Convert.ToString(x);                         //номер
                    textBox2.Text = MyFamily.Accounts[x - 1].Name;                 //имя
                    textBox3.Text = Convert.ToString(MyFamily.Accounts[x - 1].Money) + "(не изменится сумма так!)";
                    textBox4.Text = MyFamily.Accounts[x - 1].More_info;            //коммент
           }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера счёта)!!!"); }
        }
        private void button1_Click(object sender, EventArgs e)    // удаление счёта
        {
            int x; if (Int32.TryParse(textBox7.Text, out x) && 0 < x && x <= MyFamily.Accounts.Count)
            {       DialogResult result = MessageBox.Show( "Вы действительно хотите удалить счёт №" + 
                    x + " (" + MyFamily.Accounts[x-1].Name + ") ???","Внимание!!!", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {   MyFamily.RemoveAccount(MyFamily.Accounts[x - 1]);
                        ShowListAccounts(MyFamily);              //вывод изменённого списка 
                        MessageBox.Show("Счёт №" + x + " успешно удалён!"); }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера счёта)!!!"); }
        }
        public void ShowListAccounts(User MyFamily)    //вывод списка счетов (объектов Account в списке MyFamily.Accounts)
        {   richTextBox1.Clear();
            for (int i = 0; i < MyFamily.Accounts.Count; i++)
            {
                richTextBox1.Text = richTextBox1.Text + (i + 1) + ")   ";  // вывод номера i+1
                richTextBox1.Text += (MyFamily.Accounts[i]).Info();        // вывод информации о счёте из списка в номером i
                // так как номера в списке начинаются с 0, а выводится список будет, начиная с 1.
            }
        }
        // Обработчик события "Загрузить форму"
        private void MyAccounts_Load(object sender, EventArgs e)
        {   textBox1.Text = MyFamily.Login;
            textBox8.Text = " Br "; textBox11.Text = "Br";
            textBox5.Text = Convert.ToString(MyFamily.Accounts.Count + 1);
            ShowListAccounts(MyFamily);
        }

        private void button17_Click(object sender, EventArgs e) // выполнить перевод с счёта на счёт
        {
            int x; if (Int32.TryParse(textBox9.Text, out x) && 0 < x && x <= MyFamily.Accounts.Count)
            { Account a1 = MyFamily.Accounts[x-1];
                int y; if (Int32.TryParse(textBox10.Text, out y) && 0 < y && y <= MyFamily.Accounts.Count)
                { Account a2 = MyFamily.Accounts[y-1];
                    double s; if (double.TryParse(textBox12.Text, out s) && s>0)
                    { a1.TransportingMoney(s, a1, a2); ShowListAccounts(MyFamily);
                    } else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность введённой суммы)!!!"); }
                } else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера счёта, на который необходимо добавить сумму)!!!"); }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера счёта, с которого необходимо списать сумму)!!!"); }
        }
    }
}