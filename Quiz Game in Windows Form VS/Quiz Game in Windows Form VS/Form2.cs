using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_Game_in_Windows_Form_VS
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usertextbox = tbUsername.Text;
            string passtextbox = tbPassword.Text;
            string connString = ConfigurationManager.ConnectionStrings["Quiz_Game_in_Windows_Form_VS.Properties.Settings.LoginAppDBConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            // deschiderea conexiunii
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from usertb where username = @username and password = @password", conn);
            cmd.Parameters.AddWithValue("@username", usertextbox);
            cmd.Parameters.AddWithValue("@password", passtextbox);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // datele sunt corecte, deschide form2
                Form1 quizForm = new Form1();
                quizForm.Show();
            }
            else
            {
                // datele sunt incorecte, afiseaza un mesaj de eroare
                MessageBox.Show("Numele de utilizator sau parola sunt incorecte!");
            }
            // inchiderea conexiunii
            conn.Close();


        }

       
    }
}
