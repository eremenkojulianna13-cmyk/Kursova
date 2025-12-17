using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using NotaryOfficeApp.Database;

namespace NotaryOfficeApp.Forms
{
    public partial class ClientsForm : Form
    {
        // Об'єкт для роботи з базою даних через власний клас DatabaseManager
        private DatabaseManager db;

        public ClientsForm()
        {
            InitializeComponent();
            string conn = "server=localhost;user=root;password=12345;database=notary_office;";
            db = new DatabaseManager(conn);

            // Завантаження клієнтів при запуску форми
            LoadClients();
        }

        // Метод для завантаження всіх активних клієнтів
        private void LoadClients()
        {
            string sql = "SELECT * FROM clients WHERE is_archived = 0 ORDER BY client_id";
            dgvClients.DataSource = db.GetDataTable(sql);
        }

        // Додавання нового клієнта
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            // Перевірка, щоб ПІБ та паспорт були заповнені
            if (txtFullName.Text.Trim() == "" || txtPassport.Text.Trim() == "")
            {
                MessageBox.Show("Заповніть ПІБ та паспорт.");
                return;
            }

            // SQL запит на додавання клієнта
            string sql = @"INSERT INTO clients (full_name, passport_number, phone, email, address)
                           VALUES (@fn, @pass, @phone, @email, @addr)";

            var p = new Dictionary<string, object>()
            {
                {"@fn", txtFullName.Text.Trim()},
                {"@pass", txtPassport.Text.Trim()},
                {"@phone", txtPhone.Text.Trim()},
                {"@email", txtEmail.Text.Trim()},
                {"@addr", txtAddress.Text.Trim()}
            };

            db.ExecuteNonQuery(sql, p);

            MessageBox.Show("Клієнта додано!");
            ClearFields();   // Очистка полів після додавання
            LoadClients();   // Оновлення таблиці
        }

        // Видалення обраного клієнта
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть рядок.");
                return;
            }

            int id = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["client_id"].Value);
            string sql = "DELETE FROM clients WHERE client_id = @id";
            db.ExecuteNonQuery(sql, new Dictionary<string, object>() { { "@id", id } });

            MessageBox.Show("Клієнта видалено.");
            LoadClients(); // Оновлення таблиці після видалення
        }

        // Архівування обраного клієнта
        private void btnArchive_Click(object? sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть рядок.");
                return;
            }

            int id = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["client_id"].Value);
            string sql = "UPDATE clients SET is_archived = 1 WHERE client_id = @id";
            db.ExecuteNonQuery(sql, new Dictionary<string, object>() { { "@id", id } });

            MessageBox.Show("Клієнта переміщено в архів.");
            LoadClients(); // Оновлення таблиці після архівування
        }

        // Пошук клієнтів по ПІБ, паспорту, телефону, email або адресі
        private void btnSearch_Click(object? sender, EventArgs e)
        {
            string k = txtSearch.Text.Trim();
            if (k == "")
            {
                LoadClients();
                return;
            }

            string sql = @"SELECT * FROM clients
                           WHERE full_name LIKE @k
                              OR passport_number LIKE @k
                              OR phone LIKE @k
                              OR email LIKE @k
                              OR address LIKE @k";

            dgvClients.DataSource = db.GetDataTable(sql, new Dictionary<string, object>() { { "@k", "%" + k + "%" } });
        }

        // Оновлення таблиці клієнтів
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadClients();
        }

        // Метод для очищення всіх полів введення на формі
        private void ClearFields()
        {
            txtFullName.Text = "";
            txtPassport.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }
    }
}
