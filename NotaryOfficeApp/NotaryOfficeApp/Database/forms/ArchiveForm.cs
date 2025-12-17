using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NotaryOfficeApp.Forms
{
    public partial class ArchiveForm : Form
    {
        // Строка підключення до бази даних MySQL
        private readonly string connectionString =
            "server=localhost;user=root;password=12345;database=notary_office;SslMode=none;";

        // Конструктор форми архіву
        public ArchiveForm()
        {
            InitializeComponent();
            LoadArchive(); 
        }

        // Метод для завантаження архіву із фільтрацією
        private void LoadArchive(string filter = "all")
        {
            try
            {
                // Створюємо таблицю для відображення в DataGridView
                DataTable table = new DataTable();
                table.Columns.Add("type", typeof(string)); 
                table.Columns.Add("id", typeof(int));     
                table.Columns.Add("name", typeof(string)); 

                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                // Архівовані клієнти
                if (filter == "all" || filter == "client")
                {
                    var t = new DataTable();
                    new MySqlDataAdapter("SELECT client_id, full_name FROM clients WHERE is_archived = 1", conn).Fill(t);
                    foreach (DataRow r in t.Rows)
                        table.Rows.Add("client", r["client_id"], r["full_name"]);
                }

                // Архівовані нотаріуси
                if (filter == "all" || filter == "notary")
                {
                    var t = new DataTable();
                    new MySqlDataAdapter("SELECT notary_id, full_name FROM notaries WHERE is_archived = 1", conn).Fill(t);
                    foreach (DataRow r in t.Rows)
                        table.Rows.Add("notary", r["notary_id"], r["full_name"]);
                }

                // Архівовані справи
                if (filter == "all" || filter == "case")
                {
                    var t = new DataTable();
                    new MySqlDataAdapter("SELECT case_id, status FROM cases WHERE is_archived = 1", conn).Fill(t);
                    foreach (DataRow r in t.Rows)
                        table.Rows.Add("case", r["case_id"], r["status"]);
                }

                // Архівовані угоди
                if (filter == "all" || filter == "agreement")
                {
                    var t = new DataTable();
                    new MySqlDataAdapter("SELECT agreement_id FROM agreements WHERE is_archived = 1", conn).Fill(t);
                    foreach (DataRow r in t.Rows)
                        table.Rows.Add("agreement", r["agreement_id"], $"Agreement #{r["agreement_id"]}");
                }

                // Прив'язуємо таблицю 
                dgvArchive.DataSource = table;
            }
            catch (Exception ex)
            {
                // Показ повідомлення при помилці завантаження
                MessageBox.Show("Помилка завантаження архіву: " + ex.Message);
            }
        }

        // Кнопка оновлення даних з фільтром
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex <= 0)
                LoadArchive();
            else
            {
                string[] map = { "all", "client", "notary", "case", "agreement" };
                LoadArchive(map[cmbFilter.SelectedIndex]);
            }
        }

        // Кнопка показати всі записи
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            LoadArchive();
        }

        // Зміна вибору фільтра
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex <= 0) return;
            string[] map = { "all", "client", "notary", "case", "agreement" };
            LoadArchive(map[cmbFilter.SelectedIndex]);
        }

        // Відновлення архівованого запису
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvArchive.SelectedRows.Count == 0)
            {
                MessageBox.Show("Виберіть запис.");
                return;
            }

            // Отримання типу та ID запису
            var cellType = dgvArchive.SelectedRows[0].Cells["type"].Value;
            var cellId = dgvArchive.SelectedRows[0].Cells["id"].Value;

            if (cellType == null || cellId == null)
            {
                MessageBox.Show("Невірний запис.");
                return;
            }

            string type = cellType.ToString();
            int id = Convert.ToInt32(cellId);

            string table, idColumn;

            // Визначення таблиці та колонки за типом запису
            switch (type)
            {
                case "client": table = "clients"; idColumn = "client_id"; break;
                case "notary": table = "notaries"; idColumn = "notary_id"; break;
                case "case": table = "cases"; idColumn = "case_id"; break;
                case "agreement": table = "agreements"; idColumn = "agreement_id"; break;
                default: return;
            }

            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();

                // SQL для відновлення запису з архіву
                string q = $"UPDATE {table} SET is_archived = 0 WHERE {idColumn} = @id";
                using var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                // Оновлюємо таблицю після відновлення
                LoadArchive();
                MessageBox.Show("Запис відновлено!");
            }
            catch (Exception ex)
            {
                // Повідомлення про помилку при відновленні
                MessageBox.Show("Помилка відновлення: " + ex.Message);
            }
        }
    }
}
