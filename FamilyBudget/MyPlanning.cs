using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilyBudget
{   public partial class MyPlanning : Form
    {   private User MyFamily;
        public MyPlanning(User MyFamily)
        {   InitializeComponent();
            this.MyFamily = MyFamily;  }
        private void button6_Click(object sender, EventArgs e)// стрелка вправо (+1месяц)
        {   int m = Convert.ToInt32(textBox3.Text); m = m + 1; if(m<=12)ShowForm(m, true, true);            }

        private void button5_Click(object sender, EventArgs e)// стрелка влево (-1месяц)
        {   int m = Convert.ToInt32(textBox3.Text); m = m - 1; if(m>=1)ShowForm(m, true, true);            }

        private void button2_Click(object sender, EventArgs e) // добавить новую категорию
        {  Categories f1 = new Categories(MyFamily); f1.ShowDialog();  }

        private void button3_Click(object sender, EventArgs e) // обновить данные формы
        {   int m = DateTime.Now.Month; ShowForm(m, true, true);  }

        private void button17_Click(object sender, EventArgs e) // сохранить изменения расходов
        {
            int m = Convert.ToInt32(textBox3.Text);
            List<double> list = new List<double>();
            list.Add(m); 
            for (int j = 1; j < MyFamily.Categories_expenses.Count; j++) list.Add(0);
            for (int i = 1; i < list.Count; i++)
            { double s;
                if (dataGridView1.Rows[i - 1].Cells[2].Value!=null)
                { if (double.TryParse(dataGridView1.Rows[i - 1].Cells[2].Value.ToString(), out s)) { list[i] = s; } }
            } MyFamily.Months[m - 1].Plan_expenses_this_month.Clear();
            for (int k = 0; k < list.Count; k++)       MyFamily.Months[m - 1].Plan_expenses_this_month.Add(list[k]);

            List<string> list_more = new List<string>();
            list_more.Add(textBox3.Text);
            for (int j = 1; j < MyFamily.Categories_expenses.Count; j++) list_more.Add("");
            for (int i = 1; i < list_more.Count; i++)
            {
                if (dataGridView1.Rows[i - 1].Cells[5].Value != null)
                {  list_more[i] = dataGridView1.Rows[i - 1].Cells[5].Value.ToString(); }
            }
            MyFamily.Months[m - 1].More_info_plan_exp.Clear();
            for (int k = 0; k < list_more.Count; k++) MyFamily.Months[m - 1].More_info_plan_exp.Add(list_more[k]);

            ShowForm(m, true, false);
        }

        private void button1_Click(object sender, EventArgs e) // сохранить изменения доходов
        {   int m = Convert.ToInt32(textBox3.Text);
            List<double> list = new List<double>();
            list.Add(m);
            for (int j = 1; j < MyFamily.Categories_income.Count; j++) list.Add(0);

            for (int i = 1; i < list.Count; i++)
            {   double s;
                if (dataGridView2.Rows[i - 1].Cells[2].Value != null)
                {   if (double.TryParse(dataGridView2.Rows[i - 1].Cells[2].Value.ToString(), out s)) { list[i] = s; } }
            }
            MyFamily.Months[m - 1].Plan_income_this_month.Clear();

            for (int k = 0; k < list.Count; k++)
                MyFamily.Months[m - 1].Plan_income_this_month.Add(list[k]);

            List<string> list_more = new List<string>();
            list_more.Add(textBox3.Text);
            for (int j = 1; j < MyFamily.Categories_income.Count; j++) list_more.Add("");
            for (int i = 1; i < list_more.Count; i++)
            {
                if (dataGridView2.Rows[i - 1].Cells[5].Value != null)
                { list_more[i] = dataGridView2.Rows[i - 1].Cells[5].Value.ToString(); }
            }
            MyFamily.Months[m - 1].More_info_plan_inc.Clear();
            for (int k = 0; k < list_more.Count; k++) MyFamily.Months[m - 1].More_info_plan_inc.Add(list_more[k]);

            ShowForm(m, false, true);
        }



        // добавление строк в таблицу
        private void AddRows(DataGridView d, List<string> list)
        { for (int i = 1; i < list.Count; i++) d.Rows.Add(); }

        // заносим данные в столбец таблицы
        // ... числовые данные
        private void WriteColumn(int m, DataGridView d, List<string> list)
        { for (int i = 1; i < list.Count; i++) d.Rows[i - 1].Cells[m].Value = list[i]; }

        // заносим данные в столбец таблицы
        // ... строковые данные
        private void WriteColumn(int m, DataGridView d, List<double> list)
        {
            if (list == null) { for (int j = 0; j < d.Rows.Count - 1; j++) d.Rows[j].Cells[m].Value = "-----"; }
            else
            {   if (list.Count == 0) { for (int j = 0; j < d.Rows.Count - 1; j++) d.Rows[j].Cells[m].Value = "-----"; }
                else { for (int i = 1; i < list.Count; i++) d.Rows[i - 1].Cells[m].Value = list[i]; }
            }
        }
        // заносим данные в столбец таблицы
        // ... числовые данные с цветом
        private void WriteColumn(int m, DataGridView  d, List<double> list, Color pol, Color otr, Color nol)
        { for (int i = 1; i < list.Count; i++)
            {   d.Rows[i - 1].Cells[m].Value = list[i];
                if (list[i] < 0) d.Rows[i - 1].Cells[m].Style.BackColor = otr;
                if (list[i] > 0) d.Rows[i - 1].Cells[m].Style.BackColor = pol;
                if (list[i] ==0) d.Rows[i - 1].Cells[m].Style.BackColor = nol;
            }
        }
        // сделать столбцы только для чтения
        private void ReadOnlyColumn (DataGridView d, int m)
        { d.Columns[m].ReadOnly = true; }

        private void ShowTable(int m, bool exp, bool inc) // вывод информации в 2 таблицы по номеру месяца
        {
            m = m - 1;
            if (exp)
            {   //расходы
                dataGridView1.Rows.Clear();
                AddRows(dataGridView1, MyFamily.Categories_expenses);
                WriteColumn(0, dataGridView1, MyFamily.Categories_expenses); ReadOnlyColumn(dataGridView1, 0);
                if (m >= 1)
                { WriteColumn(1, dataGridView1, MyFamily.Months[m - 1].Expenses_this_month); }
                else { List<double> list = new List<double>(); WriteColumn(1, dataGridView1, list); }
                ReadOnlyColumn(dataGridView1, 1);
                WriteColumn(3, dataGridView1, MyFamily.Months[m].Expenses_this_month);
                ReadOnlyColumn(dataGridView1, 3);
                if (MyFamily.Months[m].Plan_expenses_this_month.Count != 0)
                    WriteColumn(2, dataGridView1, MyFamily.Months[m].Plan_expenses_this_month);

                List<double> list_exp = new List<double>(); list_exp.Add(m); // план-факт
                for(int i=1; i<MyFamily.Categories_expenses.Count; i++)
                {   if (MyFamily.Months[m].Plan_expenses_this_month.Count > m)
                    { list_exp.Add(MyFamily.Months[m].Plan_expenses_this_month[i] - MyFamily.Months[m].Expenses_this_month[i]); }
                    else  list_exp.Add(0-MyFamily.Months[m].Expenses_this_month[i]);
                }
                WriteColumn(4, dataGridView1, list_exp, Color.YellowGreen, Color.Pink, Color.LightSkyBlue);
                ReadOnlyColumn(dataGridView1, 4);

                if (MyFamily.Months[m].More_info_plan_exp.Count != 0)
                    WriteColumn(5, dataGridView1, MyFamily.Months[m].More_info_plan_exp);

            }
            if (inc)
            {   //доходы
                dataGridView2.Rows.Clear();
                AddRows(dataGridView2, MyFamily.Categories_income); 
                WriteColumn(0, dataGridView2, MyFamily.Categories_income); ReadOnlyColumn(dataGridView2, 0);
                if (m != 0)
                { WriteColumn(1, dataGridView2, MyFamily.Months[m - 1].Income_this_month); }
                else { List<double> list = new List<double>(); WriteColumn(1, dataGridView2, list); }
                ReadOnlyColumn(dataGridView2, 1);
                WriteColumn(3, dataGridView2, MyFamily.Months[m].Income_this_month);
                ReadOnlyColumn(dataGridView2, 3);
                if (MyFamily.Months[m].Plan_income_this_month.Count != 0)
                    WriteColumn(2, dataGridView2, MyFamily.Months[m].Plan_income_this_month);

                List<double> list_inc = new List<double>(); list_inc.Add(m); // факт-план
                for (int i = 1; i < MyFamily.Categories_income.Count; i++)
                {
                    if (MyFamily.Months[m].Plan_income_this_month.Count > m)
                    { list_inc.Add( - MyFamily.Months[m].Plan_income_this_month[i] + MyFamily.Months[m].Income_this_month[i]); }
                    else list_inc.Add( - 0 + MyFamily.Months[m].Income_this_month[i]);
                }
                WriteColumn(4, dataGridView2, list_inc, Color.YellowGreen, Color.Pink, Color.LightSkyBlue);
                ReadOnlyColumn(dataGridView2, 4);

                if (MyFamily.Months[m].More_info_plan_inc.Count != 0)
                    WriteColumn(5, dataGridView2, MyFamily.Months[m].More_info_plan_inc);
            }
        }

        private void ShowForm(int m, bool exp, bool inc)
        {   if (m < 10) textBox3.Text = "0" + m.ToString();
            else textBox3.Text = m.ToString();
            ShowTable(m, exp, inc);
            string name_month = ""; switch (m)
            {   case 1: name_month = "январь"; break;
                case 2: name_month = "февраль"; break;
                case 3: name_month = "март"; break;
                case 4: name_month = "апрель"; break;
                case 5: name_month = "май"; break;
                case 6: name_month = "июнь"; break;
                case 7: name_month = "июль"; break;
                case 8: name_month = "август"; break;
                case 9: name_month = "сентябрь"; break;
                case 10: name_month = "октябрь"; break;
                case 11: name_month = "ноябрь"; break;
                case 12: name_month = "декабрь"; break;
            }
            textBox1.Text = name_month; textBox2.Text = name_month;
            if (exp)
            {   textBox5.Text = MyFamily.Months[m - 1].Summa_expenses_plan().ToString(); // сумма план расходов
                textBox6.Text = MyFamily.Months[m - 1].Summa_expenses_fact().ToString(); // сумма факт расходов
                // разница расходов
                double s = MyFamily.Months[m - 1].Razn_expenses();
                textBox7.Text = s.ToString();
                if (s > 0) { textBox7.BackColor = Color.GreenYellow; }
                if (s < 0) { textBox7.BackColor = Color.Pink; }
                if (s == 0) { textBox7.BackColor = Color.White; }
            }
            if (inc)
            {   textBox10.Text = MyFamily.Months[m - 1].Summa_income_plan().ToString(); // сумма план доходов
                textBox9.Text = MyFamily.Months[m - 1].Summa_income_fact().ToString(); // сумма факт доходов
                // разница доходов
                double s1 = MyFamily.Months[m - 1].Razn_income();
                textBox8.Text = s1.ToString();
                if (s1 > 0) { textBox8.BackColor = Color.GreenYellow; }
                if (s1 < 0) { textBox8.BackColor = Color.Pink; }
                if (s1 == 0) { textBox8.BackColor = Color.White; }
            }
        }
        private void MyPlanning_Load(object sender, EventArgs e) // загрузка формы
        { int m = DateTime.Now.Month; ShowForm(m, true, true); }
    }
}
