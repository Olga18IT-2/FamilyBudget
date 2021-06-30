using System;
using System.Windows.Forms;
using System.IO;
namespace FamilyBudget
{   public partial class Login : Form
    {   public Login()
        { InitializeComponent();}
        private void button2_Click(object sender, EventArgs e)   // если нажата кнопка Продолжить (для входа)
        {   label10.Visible = false;  // скрытие надписи "Неправильный логин"
            label9.Visible = false;   // скрытие надписи "Неправильный пароль"
            string login = textBox1.Text;
            Files file = new Files(login);
            if (file.FileExist())   
                // проверка на то, существует ли файл с опеределённым названием 
                // название файла - это логин.txt в папке FamilyBudget\bin\Degub\Users
            {   if (file.TrueParol(textBox2.Text)) // проверка на то, правильно ли введён пароль ? ...
                    // ... - да ...
                {   Hide();                     // скрытие родительской (главной) формы
                    User MyFamily = file.OpenFile(); 
                    FamilyBudget f2 = new FamilyBudget(MyFamily); f2.ShowDialog();   // переход на следующею форму
                    Close();                    // закрываем эту форму
                }
                    // ... - нет ...
                else label9.Visible = true;          // вывод надписи "Неправильный пароль"
            }
            else // если файла не существует - то, следовательно, логин введён неверно
            label10.Visible = true;                  // вывод надписи "Неправильный логин"
        }
        private void button1_Click(object sender, EventArgs e) // если нажата кнопка зарегистрировать
        {
            label6.Visible = false;// скрытие надписи "Такой логин уже существует"
            label7.Visible = false;// скрытие надписи "Не все поля заполнены"
            label8.Visible = false;// скрытие надписи "Пароли не совпадают"
            label11.Visible = false;// скрытие надписи "Пользователь успешно зарегистрирован"
            string login = textBox3.Text;
            Files file = new Files(login);
            if (file.FileExist()) // если существуеm файл с названием *login*.txt ,
            label6.Visible = true; // отображение надписи "Такой логин уже существует"
            else // если файл с этим названием уже существует, то ...
            {  if (login != null && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {  if (textBox4.Text == textBox5.Text) // если 2 введённых пароля совпадают, то ...
                    {   file.NewFamily(textBox4.Text, textBox7.Text, textBox6.Text);
                        label11.Visible = true; // отображение надписи "Пользователь успешно зарегистрирован"
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        // произошла очистка ячеек с введёнными ранее данными
                    }
                    else // если введённые пароли не совпадают
                        label8.Visible = true; // отображенеи надписи "Пароли не совпадают"
                }
                else // если одно или несколько из полей незаполнены, то ...
                    label7.Visible = true; // отображение надписи "Не все поля заполнены" }
            }
        }
        // Если вы забыли пароль:
        private void button3_Click(object sender, EventArgs e) // ввели пароль и нажали ок : ...
        {   label19.Visible = false;     label20.Visible = false;
            label21.Visible = false;     label22.Visible = false;
            label23.Visible = false;
            textBox9.Visible = false;    textBox10.Visible = false;
            textBox11.Visible = false;   button4.Visible = false;
            string login = textBox8.Text; // введённый логин
            Files file = new Files(login);
            if (file.FileExist())
            // проверка на то, существует ли файл с опеределённым названием 
            // название файла - это логин.txt в папке FamilyBudget\bin\Degub\Users
            {   textBox9.Visible = true;  textBox10.Visible = true;
                label20.Visible = true;   label23.Visible = true; button4.Visible = true;
                textBox9.Text = file.ShowQuestion();
            }
            else // если файл не существует, следовательно, логин введён неверно и ...
                label19.Visible = true; // отображение надписи "Неверный логин"
        }
        private void button4_Click(object sender, EventArgs e) // ввели ответ и нажали ок: ... 
        {
            label19.Visible = false;   label21.Visible = false;
            label22.Visible = false;   textBox11.Visible = false;
            string login = textBox8.Text;
            Files file = new Files(login);
            string answer = file.ShowAnswer();
            if (file.TrueAnswer(textBox10.Text)) // если введённый ответ на вопрос - верен, то...
            {   label22.Visible = true;   textBox11.Visible = true; textBox11.Text = file.ShowParol();  }
            else // если введённый ответ на вопрос - неверен, то ...
                label21.Visible = true;
        }
        // Обработчик события "Загрузить форму"
        private void Login_Load(object sender, EventArgs e)
        {  textBox1.Text = "Chukova"; textBox2.Text = "Chukova";
           /*StreamReader fr;  string login = textBox1.Text; fr = new StreamReader(@"users\" + textBox1.Text + ".txt");
                string parol = fr.ReadLine();   // пароль профиля, который должен быть введён для входа
                fr.Close();
                Hide();                         // скрытие родительской (главной) формы
                Files file = new Files("Chukova"); User MyFamily = file.OpenFile();
                FamilyBudget f2 = new FamilyBudget(MyFamily); f2.ShowDialog();   // переход на следующею форму
                Close();                        // закрываем эту форму       */   
        }

       
    }
 }

