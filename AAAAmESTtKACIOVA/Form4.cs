using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAAAmESTtKACIOVA
{
    public partial class Form4 : Form
    {
        private int goodsId; 
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mEST;";

        public Form4(int id, string name, decimal price)
        {
            InitializeComponent();
            goodsId = id;
            textBox1.Text = name;  
            textBox2.Text = price.ToString();
        }

        
        private void goodsEditButton_Click_1(object sender, EventArgs e)
        {
            string newName = textBox1.Text;
            if (!decimal.TryParse(textBox2.Text, out decimal newPrice))
            {
                MessageBox.Show("Пожалуйста, введите корректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "UPDATE goodss SET name = @name, price = @price WHERE id = @id";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", goodsId);
                        sqlCommand.Parameters.AddWithValue("@name", newName);
                        sqlCommand.Parameters.AddWithValue("@price", newPrice);
                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Товар успешно обновлён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить товар.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка обновления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
