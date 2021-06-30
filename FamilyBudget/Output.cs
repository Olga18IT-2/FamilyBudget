using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace FamilyBudget
{    public partial class Output : Form
    { private User MyFamily;
        public Output(User MyFamily)
        {
            this.MyFamily = MyFamily;
            InitializeComponent();
        }
        private void Load_Form(int k, int m)
        {  
            if(k==0)
            {   if (m < 10) textBox3.Text = "0" + m.ToString();
                else textBox3.Text = m.ToString();
                ShowTable(m);
                textBox8.Text = MyFamily.Months[m - 1].Summa_expenses_plan().ToString(); // сумма план расходов
                textBox2.Text = MyFamily.Months[m - 1].Summa_expenses_fact().ToString(); // сумма факт расходов
                // разница расходов
                double s = MyFamily.Months[m - 1].Razn_expenses();
                textBox1.Text = s.ToString();
                if (s > 0) { textBox1.BackColor = Color.GreenYellow; }
                if (s < 0) { textBox1.BackColor = Color.Pink; }
                if (s == 0) { textBox1.BackColor = Color.White; }

                textBox5.Text = MyFamily.Months[m - 1].Summa_income_plan().ToString(); // сумма план доходов
                textBox6.Text = MyFamily.Months[m - 1].Summa_income_fact().ToString(); // сумма факт доходов
                // разница доходов
                double s1 = MyFamily.Months[m - 1].Razn_income();
                textBox7.Text = s1.ToString();
                if (s1 > 0) { textBox7.BackColor = Color.GreenYellow; }
                if (s1 < 0) { textBox7.BackColor = Color.Pink; }
                if (s1 == 0) { textBox7.BackColor = Color.White; }
            }
        }     
        private void ShowTable(int m) // вывод информации в 2 таблицы по номеру месяца
        {   m = m - 1;
               //расходы
                dataGridView1.Rows.Clear();
                AddRows(dataGridView1, MyFamily.Categories_expenses);
                
            int days = 0;
            if (m + 1 == DateTime.Now.Month)
            { days = System.DateTime.Now.Day; }
            else
            { if (m + 1 < DateTime.Now.Month) days = System.DateTime.DaysInMonth(DateTime.Now.Year, m + 1); }
            
            for (int i = 0; i < days; i++)
            { //колонок нехватает - добавляем их пока их будет хватать
                dataGridView1.Columns.Add((i+1).ToString(), (i+1).ToString());
                for (int j=0;j<=dataGridView1.Rows.Count-2;j++) { dataGridView1.Rows[j].Cells[5+i].Value = 0;}
                ReadOnlyColumn(dataGridView1, i + 5);
            }
            if (days != 0)
            {
                for (int i = 0; i < MyFamily.Months[m].Transactions_this_month.Count; i++)
                {
                    if (MyFamily.Months[m].Transactions_this_month[i] is Expenses)
                    {
                        Expenses expenses = (Expenses)MyFamily.Months[m].Transactions_this_month[i];
                        int number = 0;  // определяем номер категории в общем списке (этот номер будет соответствовать номеру строки в таблице)
                        for (int k = 1; k < MyFamily.Categories_expenses.Count; k++)
                        {  if (expenses.Type == MyFamily.Categories_expenses[k])   { number = k; break; }       }
                        int number_data = expenses.Date.Day; // определяем число даты
                        number_data += 4; // вычисляем номер столбика для данного числа даты
                        dataGridView1.Rows[number - 1].Cells[number_data].Value = double.Parse(dataGridView1.Rows[number - 1].Cells[number_data].Value.ToString())+expenses.Summa;
                        // заносим данные в соответствующий столбик

                        double summa = 0; // сумма по данной категории за месяц до данного дня
                        for (int t = 5; t <= number_data; t++) // считаем сумму
                        { summa += double.Parse(dataGridView1.Rows[number - 1].Cells[t].Value.ToString()); }
                        // сравниваем сумму посчитанную с запланированной
                        if (summa < MyFamily.Months[m].Plan_expenses_this_month[number])
                            dataGridView1.Rows[number - 1].Cells[number_data].Style.BackColor = Color.LawnGreen;
                        if (summa > MyFamily.Months[m].Plan_expenses_this_month[number])
                            dataGridView1.Rows[number - 1].Cells[number_data].Style.BackColor = Color.LightCoral;
                        if (summa == MyFamily.Months[m].Plan_expenses_this_month[number])
                            dataGridView1.Rows[number - 1].Cells[number_data].Style.BackColor = Color.LightCyan;
                    }
                }
            }
            // заносим данные в таблицу
            WriteColumn(dataGridView1); ReadOnlyColumn(dataGridView1, 0);
            WriteColumn(1, dataGridView1, MyFamily.Categories_expenses); ReadOnlyColumn(dataGridView1, 1);
            WriteColumn(2, dataGridView1, MyFamily.Months[m].Expenses_this_month); ReadOnlyColumn(dataGridView1, 2);
            WriteColumn(3, dataGridView1, MyFamily.Months[m].Plan_expenses_this_month); ReadOnlyColumn(dataGridView1, 3);

            List<double> list_exp = new List<double>(); list_exp.Add(m); // план-факт
            for (int i = 1; i < MyFamily.Categories_expenses.Count; i++)
            {
                if (MyFamily.Months[m].Plan_expenses_this_month.Count > m)
                { list_exp.Add(MyFamily.Months[m].Plan_expenses_this_month[i] - MyFamily.Months[m].Expenses_this_month[i]); }
                else list_exp.Add(0 - MyFamily.Months[m].Expenses_this_month[i]);
            }
            WriteColumn(4, dataGridView1, list_exp, Color.YellowGreen, Color.Pink, Color.LightSkyBlue);
            ReadOnlyColumn(dataGridView1, 4);
            //доходы
            dataGridView2.Rows.Clear();
                AddRows(dataGridView2, MyFamily.Categories_income);
                WriteColumn(dataGridView2); ReadOnlyColumn(dataGridView2, 0);
                WriteColumn(1, dataGridView2, MyFamily.Categories_income); ReadOnlyColumn(dataGridView2, 1);
                WriteColumn(2, dataGridView2, MyFamily.Months[m].Income_this_month); ReadOnlyColumn(dataGridView2, 2);
                WriteColumn(3, dataGridView2, MyFamily.Months[m ].Plan_income_this_month);  ReadOnlyColumn(dataGridView2, 3);
                
                List<double> list_inc = new List<double>(); list_inc.Add(m); // факт-план
                for (int i = 1; i < MyFamily.Categories_income.Count; i++)
                {
                    if (MyFamily.Months[m].Plan_income_this_month.Count > m)
                    { list_inc.Add(-MyFamily.Months[m].Plan_income_this_month[i] + MyFamily.Months[m].Income_this_month[i]); }
                    else list_inc.Add(-0 + MyFamily.Months[m].Income_this_month[i]);
                }
                WriteColumn(4, dataGridView2, list_inc, Color.YellowGreen, Color.Pink, Color.LightSkyBlue);
                ReadOnlyColumn(dataGridView2, 4);          
        }     
        // добавление строк в таблицу
        private void AddRows(DataGridView d, List<string> list)
        { for (int i = 1; i < list.Count; i++) d.Rows.Add(); }
        // заносим номера (порядковые) в 1-ый(0-ой) столбик в таблицу
        private void WriteColumn(DataGridView d)
        { for (int i = 1; i < d.Rows.Count; i++) d.Rows[i - 1].Cells[0].Value = i; }
        // заносим данные в столбец таблицы      // ... числовые данные
        private void WriteColumn(int m, DataGridView d, List<string> list)
        { for (int i = 1; i < list.Count; i++) d.Rows[i - 1].Cells[m].Value = list[i]; }
        // заносим данные в столбец таблицы      // ... строковые данные
        private void WriteColumn(int m, DataGridView d, List<double> list)
        {if (list == null) { for (int j = 0; j < d.Rows.Count - 1; j++) d.Rows[j].Cells[m].Value = "-----"; }
            else
            {   if (list.Count == 0) { for (int j = 0; j < d.Rows.Count - 1; j++) d.Rows[j].Cells[m].Value = "-----"; }
                else { for (int i = 1; i < list.Count; i++) d.Rows[i - 1].Cells[m].Value = list[i]; }
            }
        }
        // заносим данные в столбец таблицы
        // ... числовые данные с цветом
        private void WriteColumn(int m, DataGridView d, List<double> list, Color pol, Color otr, Color nol)
        {
            for (int i = 1; i < list.Count; i++)
            {   d.Rows[i - 1].Cells[m].Value = list[i];
                if (list[i] < 0) d.Rows[i - 1].Cells[m].Style.BackColor = otr;
                if (list[i] > 0) d.Rows[i - 1].Cells[m].Style.BackColor = pol;
                if (list[i] == 0) d.Rows[i - 1].Cells[m].Style.BackColor = nol;
            }
        }
        // сделать столбцы только для чтения
        private void ReadOnlyColumn(DataGridView d, int m)
        { d.Columns[m].ReadOnly = true; }
        // загрузка формы
        private void Output_Load(object sender, EventArgs e)
        { textBox3.Text = DateTime.Now.Month.ToString(); Load_Form(0, DateTime.Now.Month); }
        private void button5_Click(object sender, EventArgs e)// стрелка влево (-1месяц)
        { int m = Convert.ToInt32(textBox3.Text); m = m - 1;
            if (m >= 1)
            {   while (dataGridView1.ColumnCount>5)
                { dataGridView1.Columns.RemoveAt(dataGridView1.ColumnCount-1);    }
                Load_Form(0, m);
            }
       }
        private void button6_Click(object sender, EventArgs e)// стрелка вправо (+1месяц)
        { int m = Convert.ToInt32(textBox3.Text); m = m + 1;
            if (m <= 12)
            {   while (dataGridView1.ColumnCount > 5)
                { dataGridView1.Columns.RemoveAt(dataGridView1.ColumnCount - 1);   }
                Load_Form(0, m);
            }
        }
        private void button4_Click(object sender, EventArgs e) // сохранить отчёт по дням
        {       string m = textBox3.Text, year = textBox4.Text;
                // преобразуем необходимые данные в двумерные массивы
                string[,] mas1 = new string[4, 3];
                mas1[0, 0] = "Итого: доходы"; mas1[0, 1] = "";            mas1[0, 2] = "";
                mas1[1, 0] = "План:";         mas1[1, 1] = textBox5.Text; mas1[1, 2] = "Br";
                mas1[2, 0] = "Факт:";         mas1[2, 1] = textBox6.Text; mas1[2, 2] = "Br";
                mas1[3, 0] = "Разница:";      mas1[3, 1] = textBox7.Text; mas1[3, 2] = "Br";

                string[,] mas2 = new string[4, 3];
                mas2[0, 0] = label17.Text; mas2[0, 1] = "";            mas2[0, 2] = "";
                mas2[1, 0] = label14.Text; mas2[1, 1] = textBox8.Text; mas2[1, 2] = label11.Text;
                mas2[2, 0] = label13.Text; mas2[2, 1] = textBox2.Text; mas2[2, 2] = label9.Text;
                mas2[3, 0] = label12.Text; mas2[3, 1] = textBox1.Text; mas2[3, 2] = label8.Text;
            // создаём объект
            Files f = new Files(MyFamily);
            // выполняем перенос данных в эксель при помощи метода
            f.SaveFile(m, year, dataGridView2, mas1, dataGridView1, mas2);
        }

    }
}
