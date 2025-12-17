using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using NotaryOfficeApp.Database;

namespace NotaryOfficeApp.Forms
{
    public partial class NotariesForm : Form
    {
        // Менеджер роботи з базою даних
        private DatabaseManager db;

        public NotariesForm()
        {
            InitializeComponent();

            // Підключення до бази даних
            string conn = "server=localhost;user=root;password=12345;database=notary_office;";
            db = new DatabaseManager(conn);

            // Завантаження нотаріусів при старті форми
            LoadNotaries();
        }

        // Метод для завантаження всіх активних нотаріусів у DataGridView
        private void LoadNotaries()
        {
            string sql = "SELECT * FROM notaries WHERE is_archived = 0 ORDER BY notary_id";
            dgvNotaries.DataSource = db.GetDataTable(sql);
        }

        // Додавання нового нотаріуса
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() == "" || txtPosition.Text.Trim() == "")
            {
                MessageBox.Show("Заповніть ПІБ та посаду.");
                return;
            }

            string sql = @"INSERT INTO notaries (full_name, position, experience_years, phone, email)
                           VALUES (@fn, @pos, @exp, @ph, @em)";

            // Параметри запиту
            var p = new Dictionary<string, object>()
            {
                {"@fn", txtFullName.Text.Trim()},
                {"@pos", txtPosition.Text.Trim()},
                {"@exp", numericExp.Value},
                {"@ph", txtPhone.Text.Trim()},
                {"@em", txtEmail.Text.Trim()}
            };

            db.ExecuteNonQuery(sql, p);

            MessageBox.Show("Нотаріуса додано!");
            ClearFields(); // Очистка полів після додавання
            LoadNotaries(); // Оновлення таблиці
        }

        // Видалення обраного нотаріуса
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNotaries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть рядок.");
                return;
            }

            int id = Convert.ToInt32(dgvNotaries.SelectedRows[0].Cells["notary_id"].Value);
            string sql = "DELETE FROM notaries WHERE notary_id = @id";

            db.ExecuteNonQuery(sql, new Dictionary<string, object>() { { "@id", id } });

            MessageBox.Show("Нотаріуса видалено.");
            LoadNotaries(); // Оновлення таблиці
        }

        // Архівування обраного нотаріуса
        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (dgvNotaries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть рядок.");
                return;
            }

            int id = Convert.ToInt32(dgvNotaries.SelectedRows[0].Cells["notary_id"].Value);
            string sql = "UPDATE notaries SET is_archived = 1 WHERE notary_id = @id";

            db.ExecuteNonQuery(sql, new Dictionary<string, object>() { { "@id", id } });

            MessageBox.Show("Переміщено в архів.");
            LoadNotaries(); // Оновлення таблиці
        }

        // Пошук нотаріусів за текстовим запитом
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string k = txtSearch.Text.Trim();

            if (k == "")
            {
                LoadNotaries(); // Якщо поле порожнє, показати всіх
                return;
            }

            string sql = @"SELECT * FROM notaries
                           WHERE full_name LIKE @k
                              OR position LIKE @k
                              OR phone LIKE @k
                              OR email LIKE @k";

            dgvNotaries.DataSource = db.GetDataTable(sql,
                new Dictionary<string, object>() { { "@k", "%" + k + "%" } });
        }

        // Оновлення таблиці нотаріусів
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotaries();
        }

        // Метод для очищення полів форми після додавання/редагування
        private void ClearFields()
        {
            txtFullName.Text = "";
            txtPosition.Text = "";
            numericExp.Value = 0;
            txtPhone.Text = "";
            txtEmail.Text = "";
        }
    }
}
