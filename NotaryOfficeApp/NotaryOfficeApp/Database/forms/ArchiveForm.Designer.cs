namespace NotaryOfficeApp.Forms
{
    partial class ArchiveForm
    {
        private System.ComponentModel.IContainer components = null;

        // Таблиця для відображення всіх архівованих записів
        private System.Windows.Forms.DataGridView dgvArchive;

        // Кнопка для відновлення вибраного запису з архіву
        private System.Windows.Forms.Button btnRestore;

        // Кнопка для оновлення таблиці архівованих записів
        private System.Windows.Forms.Button btnRefresh;

        // Кнопка для показу всіх записів незалежно від фільтра
        private System.Windows.Forms.Button btnShowAll;

        // Комбо-бокс для вибору типу запису для фільтрації (клієнти, нотаріуси, справи, угоди)
        private System.Windows.Forms.ComboBox cmbFilter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvArchive = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchive)).BeginInit();
            this.SuspendLayout();

            // Форма ArchiveForm
            this.ClientSize = new System.Drawing.Size(1000, 600); 
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; 
            this.Text = "Архів"; 

            // Вид
            this.dgvArchive.Location = new System.Drawing.Point(20, 20); 
            this.dgvArchive.Size = new System.Drawing.Size(700, 550); 
            this.dgvArchive.Anchor = (System.Windows.Forms.AnchorStyles.Top |
            System.Windows.Forms.AnchorStyles.Bottom |
            System.Windows.Forms.AnchorStyles.Left |
            System.Windows.Forms.AnchorStyles.Right); 
            this.dgvArchive.ReadOnly = true; 
            this.dgvArchive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; 
            this.dgvArchive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; 

            // Кнопка Оновити
            this.btnRefresh.Text = "Оновити"; 
            this.btnRefresh.Location = new System.Drawing.Point(750, 40); 
            this.btnRefresh.Size = new System.Drawing.Size(220, 45); 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Кнопка Відновити
            this.btnRestore.Text = "Відновити"; 
            this.btnRestore.Location = new System.Drawing.Point(750, 100); 
            this.btnRestore.Size = new System.Drawing.Size(220, 45); 
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click); 

            // Кнопка Показати все
            this.btnShowAll.Text = "Показати все"; 
            this.btnShowAll.Location = new System.Drawing.Point(750, 160); 
            this.btnShowAll.Size = new System.Drawing.Size(220, 45); 
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click); 

            // ComboBox 
            this.cmbFilter.Location = new System.Drawing.Point(750, 230); 
            this.cmbFilter.Size = new System.Drawing.Size(220, 32); 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; 
            this.cmbFilter.Items.AddRange(new object[]
            {
                "Усі",       
                "Клієнти",  
                "Нотаріуси", 
                "Справи",   
                "Угоди"    
            });
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged); 

            // Додавання елементів на форму
            this.Controls.Add(this.dgvArchive); 
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRestore); 
            this.Controls.Add(this.btnShowAll); 
            this.Controls.Add(this.cmbFilter);

            ((System.ComponentModel.ISupportInitialize)(this.dgvArchive)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
