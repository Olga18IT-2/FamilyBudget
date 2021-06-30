using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace FamilyBudget
{    public partial class Categories : Form
    { private User MyFamily;
        public Categories(User MyFamily)
        {   InitializeComponent();   this.MyFamily = MyFamily;   }
        private void button4_Click(object sender, EventArgs e) // добавить категорию доходов
        {   label18.Visible = false; label19.Visible = false;
            int x;  if (Int32.TryParse(textBox5.Text, out x)) // обработка исключения
            {
                int i = Convert.ToInt32(textBox5.Text);
                if (i >= MyFamily.Categories_income.Count) // если эта категория уже существовала(происходило изменение её),то...
                {
                    MyFamily.Categories_income.Add(textBox3.Text);
                    MyFamily.Months[DateTime.Now.Month -1].Income_this_month.Add(0);
                    textBox3.Text = ""; textBox5.Text = Convert.ToString(MyFamily.Categories_income.Count);
                    ShowList(MyFamily.Categories_income, richTextBox1);
                    for (int j=0; j<MyFamily.Months.Count; j++)
                    { MyFamily.Months[j].Income_this_month.Add(0); MyFamily.Months[j].Plan_income_this_month.Add(0);
                      MyFamily.Months[j].More_info_plan_inc.Add("");
                    }
                    MessageBox.Show("Категория успешна добавлена!");
                }
                //иначе(происходило добавление новой категории)...
                else { MyFamily.Categories_income[i] = textBox3.Text; textBox6.Text = "";
                    textBox3.Text = ""; textBox5.Text = Convert.ToString(MyFamily.Categories_income.Count);
                    ShowList(MyFamily.Categories_income, richTextBox1);
                    MessageBox.Show("Категория успешна изменена!");
                }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
        }
        private void button1_Click(object sender, EventArgs e) // добавить категорию расходов
        {
            label18.Visible = false; label19.Visible = false;
            int x; if (Int32.TryParse(textBox2.Text, out x)) // обработка исключения
            {
                int i = Convert.ToInt32(textBox2.Text);
                if (i >= MyFamily.Categories_expenses.Count) // если эта категория уже существовала(происходило изменение её),то...
                {
                    MyFamily.Categories_expenses.Add(textBox4.Text);
                    MyFamily.Months[DateTime.Now.Month - 1].Expenses_this_month.Add(0);
                    textBox4.Text = ""; textBox2.Text = Convert.ToString(MyFamily.Categories_expenses.Count);
                    ShowList(MyFamily.Categories_expenses, richTextBox2);
                    for (int j = 0; j < MyFamily.Months.Count; j++)
                    { MyFamily.Months[j].Expenses_this_month.Add(0); }
                    MessageBox.Show("Категория успешна добавлена!");
                }
                //иначе(происходило добавление новой категории)...
                else
                { MyFamily.Categories_expenses[i] = textBox4.Text; textBox7.Text = "";
                    textBox4.Text = ""; textBox2.Text = Convert.ToString(MyFamily.Categories_expenses.Count);
                    ShowList(MyFamily.Categories_expenses, richTextBox2);
                    MessageBox.Show("Категория успешна изменена!");
                }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
        }
        private void button2_Click(object sender, EventArgs e) // изменить категорию доходов
        {   label18.Visible = false; label19.Visible = false;
            int x; if (Int32.TryParse(textBox6.Text, out x)) // обработка исключений
            {
                int i = Convert.ToInt32(textBox6.Text);
                if (0 < i && i <= MyFamily.Categories_income.Count)
                {
                    textBox5.Text = Convert.ToString(i);
                    textBox3.Text = MyFamily.Categories_income[i];
                    ShowList(MyFamily.Categories_income, richTextBox1);
                }
                else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
        }
        private void button5_Click(object sender, EventArgs e) // удалить категорию доходов
        {
            label18.Visible = false; label19.Visible = false;
            int x; if (Int32.TryParse(textBox8.Text, out x)) // обработка исключений
            {
                int i = Convert.ToInt32(textBox8.Text);
                if (0 < i && i < MyFamily.Categories_income.Count)
                {
                    bool remove = true;
                    for (int j = 0; j < MyFamily.Months.Count; j++)
                    { if (MyFamily.Months[j].Income_this_month[i] != 0) { remove = false; break; }
                    }
                    if (remove == false)
                    { label18.Visible = true; }
                    else
                    {
                        DialogResult result = MessageBox.Show("Вы действительно хотите удалить категорию №" +
                    i + " (" + MyFamily.Categories_income[i] + ") ???", "Внимание!!!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            MyFamily.Categories_income.Remove(MyFamily.Categories_income[i]);
                            for (int j = 0; j < MyFamily.Months.Count; j++)
                            MyFamily.Months[j].Income_this_month.Remove(MyFamily.Months[j].Income_this_month[i]);
                            ShowList(MyFamily.Categories_income, richTextBox1);
                            textBox5.Text = Convert.ToString(MyFamily.Categories_income.Count);     // номер категории доходов
                            textBox8.Text = "";
                            MessageBox.Show("Категория №"+i+" успешна удалена!!!");
                        }
                    }
                }
                else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
        }
        private void button3_Click(object sender, EventArgs e) // изменить категорию расходов
        {
            label18.Visible = false; label19.Visible = false;
            int x; if (Int32.TryParse(textBox7.Text, out x)) // обработка исключений
            {
                int i = Convert.ToInt32(textBox7.Text);
                if (0 < i && i <= MyFamily.Categories_expenses.Count)
                {
                    textBox2.Text = Convert.ToString(i);
                    textBox4.Text = MyFamily.Categories_expenses[i];
                    ShowList(MyFamily.Categories_expenses, richTextBox2);
                }
                else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
        }
        private void button6_Click(object sender, EventArgs e) // удалить категорию расходов
        {
            label18.Visible = false; label19.Visible = false;
            int x; if (Int32.TryParse(textBox9.Text, out x)) // обработка исключений
            {
                int i = Convert.ToInt32(textBox9.Text);
                if (0 < i && i <= MyFamily.Categories_expenses.Count)
                {
                    bool remove = true;
                    for (int j = 0; j < MyFamily.Months.Count; j++)
                    { if (MyFamily.Months[j].Expenses_this_month[i] != 0) { remove = false; break; } }
                        if (remove == false)
                        { label19.Visible = true; }
                        else
                        {
                            DialogResult result = MessageBox.Show("Вы действительно хотите удалить категорию №" +
                       i + " (" + MyFamily.Categories_expenses[i] + ") ???", "Внимание!!!", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                MyFamily.Categories_expenses.Remove(MyFamily.Categories_expenses[i]);
                                for (int j = 0; j < MyFamily.Months.Count; j++)
                                MyFamily.Months[j].Expenses_this_month.Remove(MyFamily.Months[j].Expenses_this_month[i]);
                                ShowList(MyFamily.Categories_expenses, richTextBox2);
                                textBox2.Text = Convert.ToString(MyFamily.Categories_expenses.Count);   // номер категории расходов
                                textBox9.Text = "";
                                MessageBox.Show("Категория №" + i + " успешна удалена!!!");
                            }
                        }
                    }
                else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
            }
            else { MessageBox.Show(" Неверно введённые данные!!! \n(проверьте корректность номера категории)!!!"); }
        }
        private void ShowList (List<string> list, RichTextBox box) // вывести список категорий
        {   box.Clear();
            for (int i = 1; i < list.Count; i++)
            { box.Text = box.Text + i + ")   " + list[i] + "\n"; }
        }
        // Обработчик события "Загрузить форму"
        private void Categories_Load(object sender, EventArgs e)
        {
            textBox1.Text = MyFamily.Login;
            textBox5.Text = Convert.ToString(MyFamily.Categories_income.Count);     // номер категории доходов
            textBox2.Text = Convert.ToString(MyFamily.Categories_expenses.Count);   // номер категории расходов
            ShowList(MyFamily.Categories_income, richTextBox1);
            ShowList(MyFamily.Categories_expenses, richTextBox2);
        }
        


    }
}