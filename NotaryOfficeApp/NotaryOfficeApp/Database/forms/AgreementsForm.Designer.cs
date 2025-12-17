namespace NotaryOfficeApp.Forms
{
    // Частина класу AgreementsForm, що відповідає за інтерфейс користувача
    partial class AgreementsForm
    {
        // Контейнер для компонентів форми
        private System.ComponentModel.IContainer components = null;

        // Основна таблиця для відображення списку угод
        private System.Windows.Forms.DataGridView dgvAgreements;

        // Випадаючий список для вибору справи
        private System.Windows.Forms.ComboBox cbCases;

        // Випадаючий список для ручного вибору нотаріуса
        private System.Windows.Forms.ComboBox cbNotaries;

        // Випадаючий список для вибору послуги
        private System.Windows.Forms.ComboBox cbServices;

        // Поле для відображення та редагування суми угоди
        private System.Windows.Forms.NumericUpDown nudAmount;

        // Поле для вибору дати укладення угоди
        private System.Windows.Forms.DateTimePicker dtAgreement;

        // Кнопка додавання нової угоди
        private System.Windows.Forms.Button btnAdd;

        // Кнопка оновлення списку угод
        private System.Windows.Forms.Button btnRefresh;

        // Поле для введення пошукового запиту
        private System.Windows.Forms.TextBox txtSearch;

        // Кнопка виконання пошуку
        private System.Windows.Forms.Button btnSearch;

        // Очищення ресурсів форми
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // Метод ініціалізації всіх елементів інтерфейсу
        private void InitializeComponent()
        {
            this.dgvAgreements = new System.Windows.Forms.DataGridView();
            this.cbCases = new System.Windows.Forms.ComboBox();
            this.cbNotaries = new System.Windows.Forms.ComboBox();
            this.cbServices = new System.Windows.Forms.ComboBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.dtAgreement = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAgreements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();

            // Таблиця для відображення всіх угод
            this.dgvAgreements.Location = new System.Drawing.Point(20, 20);
            this.dgvAgreements.Size = new System.Drawing.Size(700, 550);
            this.dgvAgreements.ReadOnly = true;
            this.dgvAgreements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgreements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Вибір справи, до якої належить угода
            this.cbCases.Location = new System.Drawing.Point(750, 40);
            this.cbCases.Size = new System.Drawing.Size(220, 32);
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Вибір нотаріуса вручну 
            this.cbNotaries.Location = new System.Drawing.Point(750, 90);
            this.cbNotaries.Size = new System.Drawing.Size(220, 32);
            this.cbNotaries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Вибір нотаріальної послуги
            this.cbServices.Location = new System.Drawing.Point(750, 140);
            this.cbServices.Size = new System.Drawing.Size(220, 32);
            this.cbServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Поле для відображення вартості послуги
            this.nudAmount.Location = new System.Drawing.Point(750, 190);
            this.nudAmount.Size = new System.Drawing.Size(220, 30);
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Maximum = 1000000;

            // Вибір дати укладення угоди
            this.dtAgreement.Location = new System.Drawing.Point(750, 240);
            this.dtAgreement.Size = new System.Drawing.Size(220, 30);
            this.dtAgreement.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Кнопка додавання нової угоди до бази даних
            this.btnAdd.Text = "Додати угоду";
            this.btnAdd.Location = new System.Drawing.Point(750, 290);
            this.btnAdd.Size = new System.Drawing.Size(220, 45);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // Кнопка оновлення списку угод
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.Location = new System.Drawing.Point(750, 350);
            this.btnRefresh.Size = new System.Drawing.Size(220, 45);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Поле введення тексту для пошуку угод
            this.txtSearch.Location = new System.Drawing.Point(750, 410);
            this.txtSearch.Size = new System.Drawing.Size(150, 30);

            // Кнопка запуску пошуку
            this.btnSearch.Text = "Пошук";
            this.btnSearch.Location = new System.Drawing.Point(910, 410);
            this.btnSearch.Size = new System.Drawing.Size(60, 30);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Налаштування основних параметрів форми
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угоди";

            // Додавання елементів на форму
            this.Controls.Add(this.dgvAgreements);
            this.Controls.Add(this.cbCases);
            this.Controls.Add(this.cbNotaries);
            this.Controls.Add(this.cbServices);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.dtAgreement);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAgreements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
