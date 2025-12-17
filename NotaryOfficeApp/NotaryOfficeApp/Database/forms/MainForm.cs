using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotaryOfficeApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            BuildUI(); // Виклик методу для побудови головного інтерфейсу
        }

        private void BuildUI()
        {
            this.Controls.Clear(); // Очистка всіх контролів на формі перед побудовою нового UI

            // Основні властивості форми
            this.Text = "Нотаріальна контора — Панель адміністратора";
            this.BackColor = ColorTranslator.FromHtml("#FADADD"); 
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.WindowState = FormWindowState.Maximized; 

            // Створення панелі для вертикального розташування елементів
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.TopDown; 
            panel.AutoSize = true; 
            panel.WrapContents = false; 
            panel.Padding = new Padding(0, 150, 0, 0); 

            // Назва контори
            Label lbl1 = new Label();
            lbl1.Text = "Нотаріальна контора";
            lbl1.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            lbl1.AutoSize = true;
            lbl1.Margin = new Padding(0, 0, 0, 5);
            lbl1.TextAlign = ContentAlignment.MiddleCenter;

            // Підзаголовок - панель адміністратора
            Label lbl2 = new Label();
            lbl2.Text = "Панель адміністратора";
            lbl2.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lbl2.AutoSize = true;
            lbl2.Margin = new Padding(0, 0, 0, 30);
            lbl2.TextAlign = ContentAlignment.MiddleCenter;

            panel.Controls.Add(lbl1); 
            panel.Controls.Add(lbl2); 

            // Массив назв кнопок для навігації
            string[] names = { "Клієнти", "Нотаріуси", "Послуги", "Справи", "Угоди", "Архів", "Вихід" };

            // Динамічне створення кнопок
            foreach (string name in names)
            {
                Button btn = new Button();
                btn.Text = name; 
                btn.Width = 300;
                btn.Height = 60;
                btn.BackColor = Color.White;
                btn.Font = new Font("Segoe UI", 14);
                btn.Margin = new Padding(0, 5, 0, 5);
                btn.Click += Button_Click; 

                panel.Controls.Add(btn); // Додаємо кнопку на панель
            }

            int x = 750; 
            panel.Location = new Point(x, 0);

            // Динамічне позиціонування панелі при зміні розміру форми
            this.Resize += (s, e) =>
            {
                panel.Location = new Point(x, 0);
            };

            this.Controls.Add(panel); // Додаємо панель на форму
        }

        // Обробник натискання кнопок навігації
        private void Button_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;

            switch (btn.Text)
            {
                case "Клієнти":
                    new NotaryOfficeApp.Forms.ClientsForm().ShowDialog(); // Відкриття форми клієнтів
                    break;

                case "Нотаріуси":
                    new NotaryOfficeApp.Forms.NotariesForm().ShowDialog(); // Відкриття форми нотаріусів
                    break;

                case "Послуги":
                    new NotaryOfficeApp.Forms.ServicesForm().ShowDialog(); // Відкриття форми послуг
                    break;

                case "Справи":
                    new NotaryOfficeApp.Forms.CasesForm().ShowDialog(); // Відкриття форми справ
                    break;

                case "Угоди":
                    new NotaryOfficeApp.Forms.AgreementsForm().ShowDialog(); // Відкриття форми угод
                    break;

                case "Архів":
                    new NotaryOfficeApp.Forms.ArchiveForm().ShowDialog(); // Відкриття форми архіву
                    break;

                case "Вихід":
                    Application.Exit(); // Вихід з програми
                    break;
            }
        }
    }
}
