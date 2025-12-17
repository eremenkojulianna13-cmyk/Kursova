namespace NotaryOfficeApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Підпис з назвою нотаріальної контори
        private System.Windows.Forms.Label lblOfficeName; 
        // Основна панель розташування елементів
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel; 
        // Панель для розташування кнопок
        private System.Windows.Forms.TableLayoutPanel tablePanel;
        // Заголовок панелі адміністратора
        private System.Windows.Forms.Label lblTitle;
        // Кнопки навігації між формами
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnNotaries;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnCases;
        private System.Windows.Forms.Button btnAgreements;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Ініціалізація елементів
            this.lblOfficeName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel(); 

            this.btnClients = new System.Windows.Forms.Button();
            this.btnNotaries = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnCases = new System.Windows.Forms.Button();
            this.btnAgreements = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            // Форматування основної форми
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FADADD");
            this.Text = "Нотаріальна контора — Панель адміністратора";
            this.ClientSize = new System.Drawing.Size(1000, 750); 
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // lblOfficeName – відображення назви контори
            this.lblOfficeName.Text = "Нотаріальна контора";
            this.lblOfficeName.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblOfficeName.AutoSize = true;
            this.lblOfficeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOfficeName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5); 

            // lblTitle – заголовок панелі адміністратора
            this.lblTitle.Text = "Панель адміністратора";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Left = 20;
            this.lblTitle.Top = 20;
            this.lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.lblTitle.Margin = new System.Windows.Forms.Padding(20, 20, 0, 30);

            // tablePanel – панель для вертикального розташування кнопок
            this.tablePanel.ColumnCount = 1;
            this.tablePanel.RowCount = 7;
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // Встановлення висоти кожного рядка для кнопок
            for (int i = 0; i < 7; i++)
            {
                this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            }

            // Метод для стилізації кнопок
            void StyleButton(System.Windows.Forms.Button b, string text)
            {
                b.Text = text;
                b.BackColor = System.Drawing.Color.White;
                b.Font = new System.Drawing.Font("Segoe UI", 14F);
                b.Width = 300;
                b.Height = 55;
                b.Anchor = System.Windows.Forms.AnchorStyles.None;
                b.Click += new System.EventHandler(this.Button_Click); 
            }

            // Стилізація та ініціалізація кнопок
            StyleButton(btnClients, "Клієнти");
            StyleButton(btnNotaries, "Нотаріуси");
            StyleButton(btnServices, "Послуги");
            StyleButton(btnCases, "Справи");
            StyleButton(btnAgreements, "Угоди");
            StyleButton(btnArchive, "Архів");
            StyleButton(btnExit, "Вихід");

            // Додавання кнопок до tablePanel
            this.tablePanel.Controls.Add(btnClients, 0, 0);
            this.tablePanel.Controls.Add(btnNotaries, 0, 1);
            this.tablePanel.Controls.Add(btnServices, 0, 2);
            this.tablePanel.Controls.Add(btnCases, 0, 3);
            this.tablePanel.Controls.Add(btnAgreements, 0, 4);
            this.tablePanel.Controls.Add(btnArchive, 0, 5);
            this.tablePanel.Controls.Add(btnExit, 0, 6);

            // mainLayoutPanel – вертикальна панель, що містить заголовки та кнопки
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.RowCount = 4; 
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // Рядки mainLayoutPanel
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F)); 
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); 
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); 
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F)); 

            // Додавання елементів до mainLayoutPanel
            this.mainLayoutPanel.Controls.Add(this.lblOfficeName, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.lblTitle, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.tablePanel, 0, 3);

            // Додавання головної панелі на форму
            this.Controls.Clear(); 
            this.Controls.Add(this.mainLayoutPanel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
