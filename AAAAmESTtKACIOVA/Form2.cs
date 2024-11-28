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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AAAAmESTtKACIOVA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        public bool UserId {  get; set; }   
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> listgoodss = new List<string>();
            string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mEST;";
            SqlConnection sqlConnection = new SqlConnection(connString);

            if (UserId == true)
            {
                toForm3Button.Visible = true;
                deleteButton.Visible = true;
                ChangeButton.Visible = true;
            }
            else
            {
                toForm3Button.Visible = false;
                deleteButton.Visible = false;
                ChangeButton.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM goodss ORDER BY Name", sqlConnection);
            
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int id = sqlDataReader.GetInt32(0);
                string name = sqlDataReader.GetString(1); 
                decimal price = sqlDataReader.GetDecimal(2);

                listgoodss.Add($"{id}: {name} - {price:C}");
            }
            listBox1.DataSource = listgoodss;
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> listgoodss = new List<string>();
            string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mEST;";
            SqlConnection sqlConnection = new SqlConnection(connString);

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM goodss ORDER BY price", sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                int id = sqlDataReader.GetInt32(0);
                string name = sqlDataReader.GetString(1);
                decimal price = sqlDataReader.GetDecimal(2);

                listgoodss.Add($"{id}: {name} - {price:C}");
            }
            listBox1.DataSource = listgoodss;
        }

        private void toForm3Button_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Извлечение ID товара из выделенного элемента
            string selectedItem = listBox1.SelectedItem.ToString();
            int id = int.Parse(selectedItem.Split(':')[0]); // Парсим ID из строки

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mEST;";
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "DELETE FROM goodss WHERE id = @id";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Товар успешно удалён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button2_Click(null, null); // Обновляем список товаров
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить товар.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string selectedItem = listBox1.SelectedItem.ToString();
            int id = int.Parse(selectedItem.Split(':')[0]);
            string name = selectedItem.Split(':')[1].Split('-')[0].Trim(); 
            string pricePart = selectedItem.Split('-')[1].Trim();
            decimal price = decimal.Parse(pricePart, System.Globalization.NumberStyles.Currency); 

            
            Form4 form4 = new Form4(id, name, price);
            form4.ShowDialog();

            
            button2_Click(null, null);
        }
    }
}
