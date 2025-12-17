namespace NotaryOfficeApp.Forms
{
    partial class NotariesForm
    {
        private System.ComponentModel.IContainer components = null;

        // DataGridView для відображення нотаріусів
        private System.Windows.Forms.DataGridView dgvNotaries;

        // Поля введення даних нотаріуса
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.NumericUpDown numericExp; // Стаж
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;

        // Кнопки для взаємодії користувача: додати, видалити, архівувати
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnArchive;

        // Поле пошуку та кнопки
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        // Підписи для полів введення
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvNotaries = new System.Windows.Forms.DataGridView();

            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.numericExp = new System.Windows.Forms.NumericUpDown();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvNotaries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExp)).BeginInit();
            this.SuspendLayout();

            // Форма
            this.Text = "Нотаріуси"; // Заголовок форми
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // DataGridView
            this.dgvNotaries.Location = new System.Drawing.Point(20, 20);
            this.dgvNotaries.Size = new System.Drawing.Size(550, 550);
            this.dgvNotaries.ReadOnly = true; // Заборонина редагування в таблиці
            this.dgvNotaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotaries.MultiSelect = false;

            // Підписи для полів введення
            this.lblFullName.Text = "ПІБ:";
            this.lblFullName.Location = new System.Drawing.Point(600, 20);

            this.lblPosition.Text = "Посада:";
            this.lblPosition.Location = new System.Drawing.Point(600, 80);

            this.lblExperience.Text = "Стаж (роки):";
            this.lblExperience.Location = new System.Drawing.Point(600, 140);

            this.lblPhone.Text = "Телефон:";
            this.lblPhone.Location = new System.Drawing.Point(600, 200);

            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(600, 260);

            // TextBoxes / NumericUpDown для введення даних
            this.txtFullName.Location = new System.Drawing.Point(600, 40);
            this.txtFullName.Width = 250;

            this.txtPosition.Location = new System.Drawing.Point(600, 100);
            this.txtPosition.Width = 250;

            this.numericExp.Location = new System.Drawing.Point(600, 160);
            this.numericExp.Width = 120;
            this.numericExp.Minimum = 0;
            this.numericExp.Maximum = 60;

            this.txtPhone.Location = new System.Drawing.Point(600, 220);
            this.txtPhone.Width = 250;

            this.txtEmail.Location = new System.Drawing.Point(600, 280);
            this.txtEmail.Width = 250;

            // Кнопки
            this.btnAdd.Text = "Додати"; // Додавання нотаріуса
            this.btnAdd.Location = new System.Drawing.Point(600, 330);
            this.btnAdd.Size = new System.Drawing.Size(120, 45);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Text = "Видалити"; // Видалення обраного нотаріуса
            this.btnDelete.Location = new System.Drawing.Point(730, 330);
            this.btnDelete.Size = new System.Drawing.Size(120, 45);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnArchive.Text = "Архівувати"; // Архівування обраного нотаріуса
            this.btnArchive.Location = new System.Drawing.Point(600, 380);
            this.btnArchive.Size = new System.Drawing.Size(120, 45);
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);

            // Пошук та оновлення
            this.txtSearch.Location = new System.Drawing.Point(600, 440);
            this.txtSearch.Width = 180;

            this.btnSearch.Text = "Пошук"; // Пошук за ключовим словом
            this.btnSearch.Location = new System.Drawing.Point(790, 438);
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnRefresh.Text = "Оновити"; // Оновлення таблиці
            this.btnRefresh.Location = new System.Drawing.Point(600, 490);
            this.btnRefresh.Size = new System.Drawing.Size(120, 45);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Додавання всіх контролів на форму
            this.Controls.Add(this.dgvNotaries);

            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);

            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.numericExp);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnArchive);

            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);

            ((System.ComponentModel.ISupportInitialize)(this.dgvNotaries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExp)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
