using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NotaryOfficeApp.Forms
{
    public partial class ServicesForm : Form
    {
        // Рядок підключення до бази даних
        private readonly string connectionString =
            "server=localhost;user=root;password=12345;database=notary_office;SslMode=none;";

        public ServicesForm()
        {
            InitializeComponent();
            LoadServices(); // Завантаження всіх послуг при ініціалізації форми
        }

        // Метод для завантаження всіх послуг з бази даних у DataGridView
        private void LoadServices()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "SELECT service_id, service_name AS 'Назва', description AS 'Пояснення', price AS 'Ціна', created_at AS 'Дата створення' FROM services ORDER BY service_id";
                using var adapter = new MySqlDataAdapter(sql, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvServices.DataSource = table; // Відображення у таблиці
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження послуг: " + ex.Message);
            }
        }

        // Додавання нової послуги до бази
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введіть назву послуги!");
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "INSERT INTO services (service_name, description, price, created_at) VALUES (@name, @desc, @price, @date)";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@price", nudPrice.Value);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                cmd.ExecuteNonQuery(); // Виконання вставки
                LoadServices(); // Оновлення таблиці
                MessageBox.Show("Послугу додано!");
                ClearFields(); // Очищення полів після додавання
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка додавання: " + ex.Message);
            }
        }

        // Редагування обраної послуги
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть послугу для редагування.");
                return;
            }

            int id = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["service_id"].Value);

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "UPDATE services SET service_name=@name, description=@desc, price=@price WHERE service_id=@id";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@price", nudPrice.Value);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery(); // Виконання оновлення
                LoadServices(); // Оновлення таблиці
                MessageBox.Show("Послугу змінено!");
                ClearFields(); // Очищення полів
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка редагування: " + ex.Message);
            }
        }

        // Видалення обраної послуги
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть послугу для видалення.");
                return;
            }

            int id = Convert.ToInt32(dgvServices.SelectedRows[0].Cells["service_id"].Value);

            if (MessageBox.Show("Ви впевнені, що хочете видалити цю послугу?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "DELETE FROM services WHERE service_id=@id";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery(); // Виконання видалення
                LoadServices(); // Оновлення таблиці
                MessageBox.Show("Послугу видалено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка видалення: " + ex.Message);
            }
        }

        // Пошук послуг за назвою або описом
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string sql = "SELECT service_id, service_name AS 'Назва', description AS 'Пояснення', price AS 'Ціна', created_at AS 'Дата створення' " +
                             "FROM services " +
                             "WHERE service_name LIKE @q OR description LIKE @q";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@q", "%" + txtSearch.Text.Trim() + "%");

                using var adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvServices.DataSource = table; // Відображення результатів пошуку
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка пошуку: " + ex.Message);
            }
        }

        // Оновлення таблиці послуг
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadServices();
        }

        // Метод для очищення полів введення
        private void ClearFields()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            nudPrice.Value = 0;
        }
    }
}
