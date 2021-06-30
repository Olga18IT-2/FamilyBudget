using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FamilyBudget
{    public partial class MyPersons : Form
    {
        private User MyFamily;
        public MyPersons(User MyFamily)
        {   InitializeComponent();   this.MyFamily = MyFamily;   }
        private void button4_Click(object sender, EventArgs e) // новый пользователь, или сохранение изменений данных пользователя 
        {
            int x; if (Int32.TryParse(textBox5.Text, out x))  // обработка исключений
            {
                int i = Convert.ToInt32(textBox5.Text);
                //проверка по номеру пользователя - существует ли он уже в списке?:
                if (i > MyFamily.Family.Count) // - нет, тогда создаётся новый Person
                {   //создание нового объекта
                    if (textBox3.Text == "м" || textBox3.Text == "ж")
                    {   Persons p = new Persons(textBox2.Text, textBox3.Text, Convert.ToDateTime(dateTimePicker1.Value), textBox4.Text);
                        MyFamily.AddPerson(p);               //добавление его как нового члена семьи  
                        textBox5.Text = Convert.ToString(MyFamily.Family.Count + 1);
                        textBox2.Text = "";                  //очистка ячейки                            - имя 
                        textBox3.Text = "";                  //очистка ячейки                            - пол     
                        dateTimePicker1.Value = DateTime.Now;//очистка ячейки до сегодняйшей даты        - дата
                        textBox4.Text = "";                  //очистка ячейки                            - коммент
                        ShowListPersons(MyFamily);           //вывод изменённого списка
                        int ind = MyFamily.Family.Count;
                        string s = "Пользователь № " + i + "\n" + MyFamily.Family[ind - 1].Info();
                        MessageBox.Show(s, "Пользователь успешно добавлен!");
                    }
                    else
                    {   MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность введённого пола)!!!\n" +
                        "***** Введите: \nж - если желаете выбрать женский пол\nили \nм-если желаете выбрать мужской пол");
                    }
                }
                else       // - да, тогда изменяется ранее созданный Person
                {
                    MyFamily.Family[i - 1].Name = textBox2.Text;
                    MyFamily.Family[i - 1].Date_birthday = dateTimePicker1.Value;
                    MyFamily.Family[i - 1].More_info = textBox4.Text;
                    textBox6.Text = "";                  //очистка ячейки                            - номер
                    textBox5.Text = Convert.ToString(MyFamily.Family.Count + 1);
                    textBox2.Text = "";                  //очистка ячейки                            - имя 
                    textBox3.Text = "";                  //очистка ячейки                            - пол     
                    dateTimePicker1.Value = DateTime.Now;//очистка ячейки до сегодняйшей даты        - дата
                    textBox4.Text = "";                  //очистка ячейки                            - коммент
                    ShowListPersons(MyFamily);           //вывод изменённого списка
                    string s = "Пользователь № " + i + "\n" + MyFamily.Family[i - 1].Info();
                    MessageBox.Show(s, "Информация о пользователе успешна изменена!");
                }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера пользователя)!!!"); }
        }
        private void button2_Click_1(object sender, EventArgs e)   // изменение пользователя
        {
            int x; if (Int32.TryParse(textBox6.Text, out x)) // обработка исключений
            {
                int i = Convert.ToInt32(textBox6.Text);
                // проверка на то,входит ли введённый номер в ряд возможных для изменения?
                if (0 < i && i <= MyFamily.Family.Count) // - да...
                {
                    textBox5.Text = Convert.ToString(i);                         //номер
                    textBox2.Text = MyFamily.Family[i - 1].Name;                 //имя
                    textBox3.Text = MyFamily.Family[i - 1].Pol + " !нельзя изменить!"; //пол
                    dateTimePicker1.Value = MyFamily.Family[i - 1].Date_birthday;//дата
                    textBox4.Text = MyFamily.Family[i - 1].More_info;            //коммент
                }
                else // - нет.
                { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера пользователя)!!!"); }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера пользователя)!!!"); }
        }
        private void button3_Click(object sender, EventArgs e)      // удаление пользователя
        {
            int x; if (Int32.TryParse(textBox7.Text, out x)) // обработка исключений
            {
                int i = Convert.ToInt32(textBox7.Text);
                // проверка на то,входит ли введённый номер в ряд возможных для удаления?
                if (0 < i && i <= MyFamily.Family.Count) // - да.
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите удалить пользователя №" +
                    i + " (" + MyFamily.Accounts[i - 1].Name + ") ???", "Внимание!!!", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {MyFamily.RemovePerson(MyFamily.Family[i - 1]);
                    ShowListPersons(MyFamily);
                    MessageBox.Show("Пользователь №"+i+" успешно удалён!!!");
                    }         //вывод изменённого списка 
                }
                else // - нет.
                { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера пользователя)!!!"); }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера пользователя)!!!"); }
        }
        public void ShowListPersons(User MyFamily)    //вывод списка членов семьи (объектов Person в списке MyFamily.Family)
        {
            richTextBox1.Clear();
            for (int i = 0; i < MyFamily.Family.Count; i++)
            {
                richTextBox1.Text = richTextBox1.Text + (i + 1) + ")   ";  // вывод номера i+1
                richTextBox1.Text += (MyFamily.Family[i]).Info();          // вывод информации о пользователе из списка в номером i
                // так как номера в списке начинаются с 0, а выводится список будет, начиная с 1.
            }
        }

        // Обработчик события "Загрузить форму"
        private void MyPersons_Load(object sender, EventArgs e)
        {
            textBox1.Text = MyFamily.Login;
            textBox5.Text = Convert.ToString(MyFamily.Family.Count + 1);
            ShowListPersons(MyFamily);
        }

    }
}