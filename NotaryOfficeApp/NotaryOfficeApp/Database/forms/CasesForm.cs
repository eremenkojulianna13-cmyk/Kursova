using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NotaryOfficeApp.Forms
{
    // Форма для роботи зі справами: додавання, перегляд, пошук та архівування
    public partial class CasesForm : Form
    {
        // Рядок підключення до бази даних MySQL
        private readonly string connectionString =
            "server=localhost;user=root;password=12345;database=notary_office;SslMode=none;";

        public CasesForm()
        {
            InitializeComponent();
            LoadClients();  // Завантажує список клієнтів 
            LoadNotaries(); // Завантажує список нотаріусів 
            LoadCases();    // Завантажує таблицю справ
        }

        // Метод завантаження всіх клієнтів для вибору у формі додавання справи
        private void LoadClients()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                var dt = new DataTable();
                new MySqlDataAdapter("SELECT client_id, full_name FROM clients WHERE is_archived = 0", conn).Fill(dt);

                cboClients.DataSource = dt;        // Прив'язка до ComboBox
                cboClients.DisplayMember = "full_name"; // Відображення ПІБ клієнта
                cboClients.ValueMember = "client_id";   // Значення для збереження у базі
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження клієнтів: " + ex.Message);
            }
        }

        // Метод завантаження всіх нотаріусів для вибору у формі додавання справи
        private void LoadNotaries()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                var dt = new DataTable();
                new MySqlDataAdapter("SELECT notary_id, full_name FROM notaries WHERE is_archived = 0", conn).Fill(dt);

                cboNotaries.DataSource = dt;       // Прив'язка до ComboBox
                cboNotaries.DisplayMember = "full_name"; // Відображення ПІБ нотаріуса
                cboNotaries.ValueMember = "notary_id";   // Значення для збереження у базі
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження нотаріусів: " + ex.Message);
            }
        }

        // Метод завантаження всіх справ 
        private void LoadCases()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = @"
                    SELECT c.case_id, cl.full_name AS client, n.full_name AS notary,
                           c.start_date, c.closing_date, c.status
                    FROM cases c
                    JOIN clients cl ON c.client_id = cl.client_id
                    JOIN notaries n ON c.notary_id = n.notary_id
                    WHERE c.is_archived = 0";

                using var adapter = new MySqlDataAdapter(query, conn);
                var table = new DataTable();
                adapter.Fill(table);

                dgvCases.DataSource = table;                     
                dgvCases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження справ: " + ex.Message);
            }
        }

        // Метод пошуку справ за ім'ям клієнта
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                LoadCases(); // Якщо пошук пустий, завантажуємо всі справи
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = @"
                    SELECT c.case_id, cl.full_name AS client, n.full_name AS notary,
                           c.start_date, c.closing_date, c.status
                    FROM cases c
                    JOIN clients cl ON c.client_id = cl.client_id
                    JOIN notaries n ON c.notary_id = n.notary_id
                    WHERE c.is_archived = 0 AND cl.full_name LIKE @q";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@q", "%" + search + "%");

                using var adapter = new MySqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);

                dgvCases.DataSource = table; // Вивід результатів
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка пошуку: " + ex.Message);
            }
        }

        // Метод додавання нової справи
        private void btnAddCase_Click(object sender, EventArgs e)
        {
            if (cboClients.SelectedValue == null || cboNotaries.SelectedValue == null)
            {
                MessageBox.Show("Виберіть клієнта та нотаріуса!");
                return;
            }

            try
            {
                int clientId = Convert.ToInt32(cboClients.SelectedValue);
                int notaryId = Convert.ToInt32(cboNotaries.SelectedValue);

                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = @"
                    INSERT INTO cases (client_id, notary_id, start_date, status, is_archived)
                    VALUES (@client, @notary, @start, 'Активна', 0)";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@client", clientId);
                cmd.Parameters.AddWithValue("@notary", notaryId);
                cmd.Parameters.AddWithValue("@start", DateTime.Now);

                cmd.ExecuteNonQuery(); // Виконання додавання
                LoadCases();           // Оновлення таблиці після додавання
                MessageBox.Show("Справа додана!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка додавання: " + ex.Message);
            }
        }

        // Метод архівування вибраної справи
        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (dgvCases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть справу!");
                return;
            }

            int id = Convert.ToInt32(dgvCases.SelectedRows[0].Cells["case_id"].Value);

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                string query = "UPDATE cases SET is_archived = 1 WHERE case_id = @id";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery(); // Виконання архівування

                LoadCases();           // Оновлення таблиці після архівування
                MessageBox.Show("Справа архівована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка архівації: " + ex.Message);
            }
        }

        // Кнопка для оновлення таблиці справ
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCases();
        }
    }
}
