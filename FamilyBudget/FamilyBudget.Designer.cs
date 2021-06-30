namespace FamilyBudget
{
    partial class FamilyBudget
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamilyBudget));
            this.PictureBudget = new System.Windows.Forms.PictureBox();
            this.Planning = new System.Windows.Forms.Button();
            this.Users = new System.Windows.Forms.Button();
            this.Categories = new System.Windows.Forms.Button();
            this.Accounts = new System.Windows.Forms.Button();
            this.Reports = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Transactions = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBudget
            // 
            this.PictureBudget.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBudget.BackgroundImage")));
            this.PictureBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBudget.ErrorImage = null;
            this.PictureBudget.InitialImage = null;
            this.PictureBudget.Location = new System.Drawing.Point(15, 12);
            this.PictureBudget.Name = "PictureBudget";
            this.PictureBudget.Size = new System.Drawing.Size(254, 258);
            this.PictureBudget.TabIndex = 0;
            this.PictureBudget.TabStop = false;
            // 
            // Planning
            // 
            this.Planning.BackColor = System.Drawing.Color.White;
            this.Planning.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Planning.Image = ((System.Drawing.Image)(resources.GetObject("Planning.Image")));
            this.Planning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Planning.Location = new System.Drawing.Point(16, 276);
            this.Planning.Name = "Planning";
            this.Planning.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Planning.Size = new System.Drawing.Size(254, 65);
            this.Planning.TabIndex = 2;
            this.Planning.Text = "Планирование";
            this.Planning.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Planning.UseVisualStyleBackColor = false;
            this.Planning.Click += new System.EventHandler(this.Planning_Click);
            // 
            // Users
            // 
            this.Users.BackColor = System.Drawing.Color.White;
            this.Users.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Users.Image = ((System.Drawing.Image)(resources.GetObject("Users.Image")));
            this.Users.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Users.Location = new System.Drawing.Point(13, 627);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(256, 64);
            this.Users.TabIndex = 3;
            this.Users.Text = "Пользователи";
            this.Users.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Users.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Users.UseVisualStyleBackColor = false;
            this.Users.Click += new System.EventHandler(this.Users_Click);
            // 
            // Categories
            // 
            this.Categories.BackColor = System.Drawing.Color.White;
            this.Categories.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Categories.Image = ((System.Drawing.Image)(resources.GetObject("Categories.Image")));
            this.Categories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Categories.Location = new System.Drawing.Point(14, 487);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(255, 64);
            this.Categories.TabIndex = 4;
            this.Categories.Text = "Категории";
            this.Categories.UseVisualStyleBackColor = false;
            this.Categories.Click += new System.EventHandler(this.Categories_Click);
            // 
            // Accounts
            // 
            this.Accounts.BackColor = System.Drawing.Color.White;
            this.Accounts.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Accounts.Image = ((System.Drawing.Image)(resources.GetObject("Accounts.Image")));
            this.Accounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Accounts.Location = new System.Drawing.Point(13, 557);
            this.Accounts.Name = "Accounts";
            this.Accounts.Size = new System.Drawing.Size(256, 64);
            this.Accounts.TabIndex = 5;
            this.Accounts.Text = "Счета";
            this.Accounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Accounts.UseVisualStyleBackColor = false;
            this.Accounts.Click += new System.EventHandler(this.Accounts_Click);
            // 
            // Reports
            // 
            this.Reports.BackColor = System.Drawing.Color.White;
            this.Reports.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Reports.Image = ((System.Drawing.Image)(resources.GetObject("Reports.Image")));
            this.Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Reports.Location = new System.Drawing.Point(14, 417);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(256, 64);
            this.Reports.TabIndex = 6;
            this.Reports.Text = "Отчёты";
            this.Reports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Reports.UseVisualStyleBackColor = false;
            this.Reports.Click += new System.EventHandler(this.Reports_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1127, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 60);
            this.label1.TabIndex = 9;
            this.label1.Text = "Семья";
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.MonthCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MonthCalendar.Location = new System.Drawing.Point(1113, 143);
            this.MonthCalendar.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1113, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 48);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Category,
            this.User,
            this.Sum,
            this.Account,
            this.Date,
            this.Notes});
            this.dataGridView1.Location = new System.Drawing.Point(304, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(743, 633);
            this.dataGridView1.TabIndex = 12;
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.Name = "Type";
            // 
            // Category
            // 
            this.Category.HeaderText = "Категория";
            this.Category.Name = "Category";
            // 
            // User
            // 
            this.User.HeaderText = "Член семьи";
            this.User.Name = "User";
            // 
            // Sum
            // 
            this.Sum.HeaderText = "Сумма";
            this.Sum.Name = "Sum";
            // 
            // Account
            // 
            this.Account.HeaderText = "Счёт";
            this.Account.Name = "Account";
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            // 
            // Notes
            // 
            this.Notes.HeaderText = "Примечания";
            this.Notes.Name = "Notes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Cyan;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1070, 537);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 33);
            this.label2.TabIndex = 13;
            this.label2.Text = "Общий баланс";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(1220, 534);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 39);
            this.textBox2.TabIndex = 16;
            // 
            // Transactions
            // 
            this.Transactions.BackColor = System.Drawing.Color.White;
            this.Transactions.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Transactions.Image = ((System.Drawing.Image)(resources.GetObject("Transactions.Image")));
            this.Transactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Transactions.Location = new System.Drawing.Point(16, 346);
            this.Transactions.Name = "Transactions";
            this.Transactions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Transactions.Size = new System.Drawing.Size(254, 65);
            this.Transactions.TabIndex = 19;
            this.Transactions.Text = "Транзакции";
            this.Transactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Transactions.UseVisualStyleBackColor = false;
            this.Transactions.Click += new System.EventHandler(this.Transactions_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(1076, 688);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(242, 50);
            this.button3.TabIndex = 22;
            this.button3.Text = "Закрыть приложение";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(1076, 641);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(242, 50);
            this.button2.TabIndex = 21;
            this.button2.Text = "Выйти в главное меню";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(1076, 594);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(242, 50);
            this.button4.TabIndex = 20;
            this.button4.Text = "Сохранить данные";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(304, 688);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(743, 50);
            this.button1.TabIndex = 23;
            this.button1.Text = "Обновить данные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(890, 18);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(61, 40);
            this.button6.TabIndex = 26;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(495, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 40);
            this.label3.TabIndex = 27;
            this.label3.Text = "Месяц №";
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(437, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 40);
            this.button5.TabIndex = 28;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBox3.Font = new System.Drawing.Font("Lucida Calligraphy", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(635, 24);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(125, 31);
            this.textBox3.TabIndex = 29;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBox4.Font = new System.Drawing.Font("Lucida Calligraphy", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(759, 24);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(125, 31);
            this.textBox4.TabIndex = 30;
            this.textBox4.Text = "2020 г.";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FamilyBudget
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1332, 750);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Transactions);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.MonthCalendar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reports);
            this.Controls.Add(this.Accounts);
            this.Controls.Add(this.Categories);
            this.Controls.Add(this.Users);
            this.Controls.Add(this.Planning);
            this.Controls.Add(this.PictureBudget);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FamilyBudget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FamilyBudget";
            this.Load += new System.EventHandler(this.FamilyBudget_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBudget;
        private System.Windows.Forms.Button Planning;
        private System.Windows.Forms.Button Users;
        private System.Windows.Forms.Button Categories;
        private System.Windows.Forms.Button Accounts;
        private System.Windows.Forms.Button Reports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar MonthCalendar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Transactions;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}

