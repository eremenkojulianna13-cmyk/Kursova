using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace NotaryOfficeApp.Database
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Рядок підключення не може бути порожнім.");

            _connectionString = connectionString;
        }

        // Створення команди з параметрами
        private MySqlCommand CreateCommand(string sql, Dictionary<string, object>? parameters = null)
        {
            var command = new MySqlCommand(sql);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            return command;
        }

        // Отримання даних (SELECT)
        public DataTable GetDataTable(string sqlQuery, Dictionary<string, object>? parameters = null)
        {
            var table = new DataTable();

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = CreateCommand(sqlQuery, parameters))
            {
                command.Connection = connection;

                try
                {
                    connection.Open();
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Помилка виконання SELECT запиту до БД.", ex);
                }
            }

            return table;
        }

        // Виконання команд INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string sqlQuery, Dictionary<string, object>? parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = CreateCommand(sqlQuery, parameters))
            {
                command.Connection = connection;

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Помилка виконання команди в БД.", ex);
                }
            }
        }
    }
}