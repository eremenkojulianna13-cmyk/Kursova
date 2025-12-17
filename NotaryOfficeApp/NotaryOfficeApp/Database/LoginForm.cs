using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotaryOfficeApp
{
    public class LoginForm : Form
    {
        private TextBox passwordBox;
        private Label messageLabel;

        public LoginForm()
        {
            this.Text = "Авторизація адміністратора";
            this.BackColor = Color.FromArgb(0xFA, 0xDA, 0xDD); 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(500, 300);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Label title = new Label();
            title.Text = "Вхід до системи нотаріальної контори";
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.AutoSize = true;
            title.Location = new Point(20, 20);
            Controls.Add(title);

            Label passLabel = new Label();
            passLabel.Text = "Введіть пароль адміністратора:";
            passLabel.Font = new Font("Segoe UI", 11);
            passLabel.AutoSize = true;
            passLabel.Location = new Point((ClientSize.Width - 250) / 2, 100);
            Controls.Add(passLabel);

            passwordBox = new TextBox();
            passwordBox.PasswordChar = '*';
            passwordBox.Width = 200;
            passwordBox.Location = new Point((ClientSize.Width - 200) / 2, 130);
            Controls.Add(passwordBox);

            Button loginButton = new Button();
            loginButton.Text = "Увійти";
            loginButton.BackColor = Color.White;
            loginButton.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            loginButton.Width = 120;
            loginButton.Height = 40;
            loginButton.Location = new Point((ClientSize.Width - 120) / 2, 180);
            loginButton.Click += LoginButton_Click;
            Controls.Add(loginButton);

            messageLabel = new Label();
            messageLabel.ForeColor = Color.Red;
            messageLabel.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            messageLabel.AutoSize = true;
            messageLabel.Location = new Point((ClientSize.Width - 200) / 2, 240);
            Controls.Add(messageLabel);
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            string enteredPassword = passwordBox.Text.Trim();
            string correctPassword = "admin123"; 

            if (enteredPassword == correctPassword)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide(); 
            }
            else
            {
                messageLabel.Text = "Пароль невірний!";
                passwordBox.Clear();
                passwordBox.Focus();
            }
        }
    }
}

