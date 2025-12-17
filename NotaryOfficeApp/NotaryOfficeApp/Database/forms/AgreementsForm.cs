using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NotaryOfficeApp.Forms
{
    // Форма для роботи з угодами нотаріальної контори
    public partial class AgreementsForm : Form
    {
        // Рядок підключення до бази даних MySQL
        private readonly string connectionString =
            "server=localhost;user=root;password=12345;database=notary_office;SslMode=none;";

        // Конструктор форми
        public AgreementsForm()
        {
            InitializeComponent();

            // Початкове завантаження даних при відкритті форми
            LoadAgreements(); 
            LoadCases();      
            LoadNotaries();   
            LoadServices();   
        }

        // Метод для завантаження всіх активних угод у таблицю DataGridView
        private void LoadAgreements()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                // SQL-запит для отримання повної інформації про угоди
                string sql = @"
                    SELECT 
                        a.agreement_id AS 'ID',
                        cl.full_name AS 'Клієнт',
                        n.full_name AS 'Нотаріус',
                        s.service_name AS 'Послуга',
                        a.amount AS 'Сума',
                        a.agreement_date AS 'Дата'
                    FROM agreements a
                    JOIN cases c ON a.case_id = c.case_id
                    JOIN clients cl ON c.client_id = cl.client_id
                    JOIN notaries n ON c.notary_id = n.notary_id
                    JOIN services s ON a.service_id = s.service_id
                    WHERE a.is_archived = 0
                    ORDER BY a.agreement_id";

                // Заповнення DataTable 
                using var adapter = new MySqlDataAdapter(sql, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Відображення даних у таблиці
                dgvAgreements.DataSource = table;
            }
            catch (Exception ex)
            {
                // Повідомлення користувачу у випадку помилки
                MessageBox.Show("Помилка завантаження: " + ex.Message);
            }
        }

        // Метод для завантаження справ
        private void LoadCases()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                // Формування списку справ з відображенням клієнта та дати початку
                string query = @"
                    SELECT c.case_id, CONCAT(cl.full_name, ' | ', c.start_date) AS case_info
                    FROM cases c
                    JOIN clients cl ON c.client_id = cl.client_id
                    WHERE c.is_archived = 0";

                using var cmd = new MySqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                DataTable t = new DataTable();
                t.Load(reader);

                // Прив’язка даних 
                cbCases.DataSource = t;
                cbCases.DisplayMember = "case_info"; // що бачить користувач
                cbCases.ValueMember = "case_id";     // фактичне значення
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження справ: " + ex.Message);
            }
        }

        // Метод для завантаження списку нотаріусів 
        private void LoadNotaries()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                // Отримання активних нотаріусів
                string query = "SELECT notary_id, full_name FROM notaries WHERE is_archived = 0";
                using var cmd = new MySqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                DataTable t = new DataTable();
                t.Load(reader);

                // Прив’язка нотаріусів 
                cbNotaries.DataSource = t;
                cbNotaries.DisplayMember = "full_name";
                cbNotaries.ValueMember = "notary_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження нотаріусів: " + ex.Message);
            }
        }

        // Метод для завантаження послуг 
        private void LoadServices()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                // Отримання списку послуг та їх вартості
                string query = "SELECT service_id, service_name, price FROM services";
                using var cmd = new MySqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                DataTable t = new DataTable();
                t.Load(reader);

                cbServices.DataSource = t;
                cbServices.DisplayMember = "service_name";
                cbServices.ValueMember = "service_id";

                // Автоматичне встановлення ціни при виборі послуги
                cbServices.SelectedIndexChanged += (s, e) =>
                {
                    if (cbServices.SelectedValue != null)
                    {
                        var row = ((DataRowView)cbServices.SelectedItem).Row;
                        nudAmount.Value = Convert.ToDecimal(row["price"]);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження послуг: " + ex.Message);
            }
        }

        // Кнопка оновлення списку угод
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAgreements();
        }

        // Обробник додавання нової угоди
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Перевірка, чи всі необхідні дані вибрані
            if (cbCases.SelectedValue == null || cbServices.SelectedValue == null || cbNotaries.SelectedValue == null)
            {
                MessageBox.Show("Виберіть справу, нотаріуса та послугу!");
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                // SQL запит для додавання угоди
                string sql = @"INSERT INTO agreements (case_id, service_id, amount, agreement_date)
                               VALUES (@case, @service, @amount, @date)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@case", cbCases.SelectedValue);
                cmd.Parameters.AddWithValue("@service", cbServices.SelectedValue);
                cmd.Parameters.AddWithValue("@amount", nudAmount.Value);
                cmd.Parameters.AddWithValue("@date", dtAgreement.Value.Date);

                cmd.ExecuteNonQuery();

                // Оновлення таблиці після додавання
                LoadAgreements();
                MessageBox.Show("Угоду додано!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка додавання: " + ex.Message);
            }
        }

        // Пошук угод за клієнтом, нотаріусом або послугою
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAgreements();
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                // SQL запит з використанням LIKE для пошуку
                string sql = @"
                    SELECT 
                        a.agreement_id AS 'ID',
                        cl.full_name AS 'Клієнт',
                        n.full_name AS 'Нотаріус',
                        s.service_name AS 'Послуга',
                        a.amount AS 'Сума',
                        a.agreement_date AS 'Дата'
                    FROM agreements a
                    JOIN cases c ON a.case_id = c.case_id
                    JOIN clients cl ON c.client_id = cl.client_id
                    JOIN notaries n ON c.notary_id = n.notary_id
                    JOIN services s ON a.service_id = s.service_id
                    WHERE cl.full_name LIKE @q 
                       OR n.full_name LIKE @q 
                       OR s.service_name LIKE @q";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@q", "%" + txtSearch.Text.Trim() + "%");

                using var adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvAgreements.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка пошуку: " + ex.Message);
            }
        }
    }
}
