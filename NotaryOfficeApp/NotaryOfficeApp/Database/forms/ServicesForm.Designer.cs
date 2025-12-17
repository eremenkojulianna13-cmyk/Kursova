namespace NotaryOfficeApp.Forms
{
    partial class ServicesForm
    {
        private System.ComponentModel.IContainer components = null;

        // Таблиця для відображення послуг
        private System.Windows.Forms.DataGridView dgvServices;

        // Поля введення для назви, опису та ціни послуги
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.NumericUpDown nudPrice;

        // Кнопки для додавання, редагування, видалення, пошуку та оновлення
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;

        // Підписи до полів введення
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Ініціалізація елементів форми
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();

            // DataGridView для відображення всіх послуг
            this.dgvServices.Location = new System.Drawing.Point(20, 20);
            this.dgvServices.Size = new System.Drawing.Size(550, 550);
            this.dgvServices.ReadOnly = true; // Запобігає редагуванню безпосередньо у таблиці
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.MultiSelect = false;

            // Підписи для полів введення
            this.lblName.Text = "Назва:";
            this.lblName.Location = new System.Drawing.Point(600, 20);

            this.lblDescription.Text = "Пояснення:";
            this.lblDescription.Location = new System.Drawing.Point(600, 80);

            this.lblPrice.Text = "Ціна:";
            this.lblPrice.Location = new System.Drawing.Point(600, 200);

            // Поля введення даних послуги
            this.txtName.Location = new System.Drawing.Point(600, 40);
            this.txtName.Width = 250;

            this.txtDescription.Location = new System.Drawing.Point(600, 100);
            this.txtDescription.Width = 250;
            this.txtDescription.Height = 80;
            this.txtDescription.Multiline = true;

            this.nudPrice.Location = new System.Drawing.Point(600, 220);
            this.nudPrice.Width = 120;
            this.nudPrice.DecimalPlaces = 2; // Відображення копійок
            this.nudPrice.Maximum = 1000000; // Максимальна ціна

            // Кнопки для взаємодії користувача
            this.btnAdd.Text = "Додати"; // Додавання нової послуги
            this.btnAdd.Location = new System.Drawing.Point(600, 260);
            this.btnAdd.Size = new System.Drawing.Size(120, 40);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Редагувати"; // Редагування обраної послуги
            this.btnEdit.Location = new System.Drawing.Point(730, 260);
            this.btnEdit.Size = new System.Drawing.Size(120, 40);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Видалити"; // Видалення обраної послуги
            this.btnDelete.Location = new System.Drawing.Point(600, 310);
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Поле для введення пошукового запиту
            this.txtSearch.Location = new System.Drawing.Point(600, 360);
            this.txtSearch.Width = 180;

            this.btnSearch.Text = "Пошук"; // Пошук послуг
            this.btnSearch.Location = new System.Drawing.Point(790, 358);
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.btnRefresh.Text = "Оновити"; // Оновлення таблиці послуг
            this.btnRefresh.Location = new System.Drawing.Point(600, 410);
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Додавання всіх контролів на форму
            this.Controls.Add(this.dgvServices);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);

            // Основні властивості форми
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Послуги";

            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
