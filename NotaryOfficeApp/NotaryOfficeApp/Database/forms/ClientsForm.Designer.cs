namespace NotaryOfficeApp.Forms
{
    partial class ClientsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Таблиця для відображення клієнтів
        private System.Windows.Forms.DataGridView dgvClients;

        // Поля введення для даних клієнта
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;

        // Кнопки для додавання, видалення, архівування, оновлення та пошуку
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;

        // Підписи до полів введення
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Ініціалізація елементів форми
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPassport = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();

            // Основні властивості форми
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клієнти";

            // DataGridView для відображення всіх клієнтів
            this.dgvClients.Location = new System.Drawing.Point(20, 20);
            this.dgvClients.Size = new System.Drawing.Size(550, 550);
            this.dgvClients.ReadOnly = true; 
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Підписи для полів введення
            this.lblFullName.Text = "ПІБ:"; 
            this.lblFullName.Location = new System.Drawing.Point(600, 20);

            this.lblPassport.Text = "Паспорт:"; 
            this.lblPassport.Location = new System.Drawing.Point(600, 80);

            this.lblPhone.Text = "Телефон:"; 
            this.lblPhone.Location = new System.Drawing.Point(600, 140);

            this.lblEmail.Text = "Email:"; 
            this.lblEmail.Location = new System.Drawing.Point(600, 200);

            this.lblAddress.Text = "Адреса:"; 
            this.lblAddress.Location = new System.Drawing.Point(600, 260);

            // Поля введення даних
            this.txtFullName.Location = new System.Drawing.Point(600, 40);
            this.txtFullName.Width = 250;

            this.txtPassport.Location = new System.Drawing.Point(600, 100);
            this.txtPassport.Width = 250;

            this.txtPhone.Location = new System.Drawing.Point(600, 160);
            this.txtPhone.Width = 250;

            this.txtEmail.Location = new System.Drawing.Point(600, 220);
            this.txtEmail.Width = 250;

            this.txtAddress.Location = new System.Drawing.Point(600, 280);
            this.txtAddress.Width = 250;

            // Кнопки дій
            this.btnAdd.Text = "Додати"; // Додавання нового клієнта
            this.btnAdd.Location = new System.Drawing.Point(600, 330);
            this.btnAdd.Size = new System.Drawing.Size(120, 45);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Text = "Видалити"; // Видалення клієнта
            this.btnDelete.Location = new System.Drawing.Point(730, 330);
            this.btnDelete.Size = new System.Drawing.Size(120, 45);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnArchive.Text = "Архівувати"; // Архівування клієнта
            this.btnArchive.Location = new System.Drawing.Point(600, 380);
            this.btnArchive.Size = new System.Drawing.Size(120, 45);
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);

            this.btnRefresh.Text = "Оновити"; // Оновлення таблиці клієнтів
            this.btnRefresh.Location = new System.Drawing.Point(600, 440);
            this.btnRefresh.Size = new System.Drawing.Size(120, 45);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Поле та кнопка пошуку
            this.txtSearch.Location = new System.Drawing.Point(600, 500);
            this.txtSearch.Width = 180;

            this.btnSearch.Text = "Пошук"; // Пошук клієнтів
            this.btnSearch.Location = new System.Drawing.Point(790, 498);
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Додавання елементів на форму
            this.Controls.Add(this.dgvClients);

            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblPassport);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAddress);

            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtPassport);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAddress);

            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
