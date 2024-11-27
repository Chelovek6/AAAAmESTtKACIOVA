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
            }
            else
            {
                toForm3Button.Visible = false;
            }

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM goodss ORDER BY Name", sqlConnection);
            
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string name = sqlDataReader.GetString(1); 
                decimal price = sqlDataReader.GetDecimal(2); 

                listgoodss.Add($"{name} - {price:C}"); 
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
                string name = sqlDataReader.GetString(1);
                decimal price = sqlDataReader.GetDecimal(2);

                listgoodss.Add($"{name} - {price:C}");
            }
            listBox1.DataSource = listgoodss;
        }

        private void toForm3Button_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
