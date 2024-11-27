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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 
        }

        private void getUser() // получить всех пользователей
        {
            try
            {


                if
                    (textBox1.Text != null && textBox2.Text != null)
                {

                    string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mEST; ";
                    SqlConnection sqlConnection = new SqlConnection(connString);
                    //"Data Source = 310D - 15\SQLEXPRESS; Initial Catalog = Admin; Persist Security Info = True; User ID = sa; Password = 1");
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("select * from [users] where login = '" + textBox1.Text + "' and pass = '" + textBox2.Text + "'", sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                       
                        Form2 form2 = new Form2();
                        form2.UserId = true;
                        form2.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Данные не верны!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            getUser();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {

            List<string> setlogin = new List<string>();
            string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mEST;";
            SqlConnection sqlConnection = new SqlConnection(connString);

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select login from [users]", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                setlogin.Add(sqlDataReader.GetString(0));
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.UserId = false;
            form2.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        
    }
}
