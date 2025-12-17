namespace NotaryOfficeApp.Forms
{
    partial class CasesForm
    {
        private System.ComponentModel.IContainer components = null;

        // Таблиця для відображення справ
        private System.Windows.Forms.DataGridView dgvCases;

        // Кнопки керування
        private System.Windows.Forms.Button btnRefresh;   // Оновити таблицю
        private System.Windows.Forms.Button btnAddCase;   // Додати нову справу
        private System.Windows.Forms.Button btnArchive;   // Архівувати вибрану справу
        private System.Windows.Forms.Button btnSearch;    // Пошук справ

        // Поля вибору
        private System.Windows.Forms.ComboBox cboClients;   // Вибір клієнта для справи
        private System.Windows.Forms.ComboBox cboNotaries;  // Вибір нотаріуса для справи

        // Поле для пошуку
        private System.Windows.Forms.TextBox txtSearch;

        // Підписи
        private System.Windows.Forms.Label lblClient;  // Підпис для клієнта
        private System.Windows.Forms.Label lblNotary;  // Підпис для нотаріуса

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCases = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddCase = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.cboClients = new System.Windows.Forms.ComboBox();
            this.cboNotaries = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblNotary = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).BeginInit();
            this.SuspendLayout();

            // Таблиця для відображення всіх справ
            this.dgvCases.Location = new System.Drawing.Point(20, 20);
            this.dgvCases.Size = new System.Drawing.Size(700, 550);
            this.dgvCases.ReadOnly = true;
            this.dgvCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Кнопка Оновити, для оновлення таблиці
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.Location = new System.Drawing.Point(750, 20);
            this.btnRefresh.Size = new System.Drawing.Size(220, 40);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Підпис і ComboBox для вибору клієнта
            this.lblClient.Text = "Клієнт:";
            this.lblClient.Location = new System.Drawing.Point(750, 80);
            this.cboClients.Location = new System.Drawing.Point(820, 75);
            this.cboClients.Size = new System.Drawing.Size(150, 30);
            this.cboClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Підпис і ComboBox для вибору нотаріуса
            this.lblNotary.Text = "Нотаріус:";
            this.lblNotary.Location = new System.Drawing.Point(750, 120);
            this.cboNotaries.Location = new System.Drawing.Point(820, 115);
            this.cboNotaries.Size = new System.Drawing.Size(150, 30);
            this.cboNotaries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Кнопка Додати справу
            this.btnAddCase.Text = "Додати справу";
            this.btnAddCase.Location = new System.Drawing.Point(750, 160);
            this.btnAddCase.Size = new System.Drawing.Size(220, 45);
            this.btnAddCase.Click += new System.EventHandler(this.btnAddCase_Click);

            // Кнопка Архівувати справу
            this.btnArchive.Text = "Архівувати";
            this.btnArchive.Location = new System.Drawing.Point(750, 220);
            this.btnArchive.Size = new System.Drawing.Size(220, 45);
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);

            // Поле для введення тексту пошуку
            this.txtSearch.Location = new System.Drawing.Point(750, 280);
            this.txtSearch.Size = new System.Drawing.Size(150, 30);

            // Кнопка пошуку
            this.btnSearch.Text = "Пошук";
            this.btnSearch.Location = new System.Drawing.Point(910, 280);
            this.btnSearch.Size = new System.Drawing.Size(60, 30);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Основні налаштування форми
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справи";

            // Додавання елементів на форму
            this.Controls.Add(this.dgvCases);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddCase);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.cboClients);
            this.Controls.Add(this.cboNotaries);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblNotary);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
