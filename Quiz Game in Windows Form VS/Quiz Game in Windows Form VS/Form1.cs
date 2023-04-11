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
    
    public partial class Form1 : Form
    {
        // quiz game variables

        int correctAnswer;
        int questionNumber = 1;
        int score;
        int prcentage;
        int totalQuestions;

        public Form1()
        {
            InitializeComponent();

            askQuestion(questionNumber);

            totalQuestions = 11;
        }

        private void checAnswerEvent(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if(buttonTag == correctAnswer)
            {
                score++;

            }

            if(questionNumber==totalQuestions)
            {
                // work out the procentage
                prcentage = (int)Math.Round((double)(score * 100) / totalQuestions);

                MessageBox.Show(
                    "Quiz Ended" + Environment.NewLine + 
                    "You have answered " + score + " questions correctly." + Environment.NewLine +
                    "Your total procentage is " + prcentage + "%" + Environment.NewLine +
                    "Click OK to play again"
                    );

                

                score = 0;
                questionNumber = 0;
                askQuestion(questionNumber);
            }

            questionNumber++;
            askQuestion(questionNumber);

             
            
        }

        private void askQuestion(int qnum)
        {

            switch(qnum)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.casaalba;
                    lblQuestion.Text = "In ce oras se afla Casa Alba a Statelor Unite?";
                    button1.Text = "California";
                    button2.Text = "New-York";
                    button3.Text = "Washington DC";
                    button4.Text = "Las Vegas";

                    correctAnswer = 3;

                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.colosseum;
                    lblQuestion.Text = "In ce capitala europeana poti vizita Colosseum-ul?";
                    button1.Text = "Roma";
                    button2.Text = "Berlin";
                    button3.Text = "Vatican";
                    button4.Text = "Atena";

                    correctAnswer = 1;

                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources.dunarea;
                    lblQuestion.Text = "Din ce tara izvoraste Dunarea?";
                    button1.Text = "Romania";
                    button2.Text = "Austria";
                    button3.Text = "Franta";
                    button4.Text = "Germania";

                    correctAnswer = 4;

                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources.hitler;
                    lblQuestion.Text = "Care a fost generalul nazistilor in cel de-al doilea Razboi Mondial?";
                    button1.Text = "Adolf Hitler";
                    button2.Text = "Hermann Wilhelm Goring";
                    button3.Text = "Josef Kramer";
                    button4.Text = "Otto Adolf Eichmann";

                    correctAnswer = 1;

                    break;

                case 5:
                    pictureBox1.Image = Properties.Resources.luna;
                    lblQuestion.Text = "Care a fost primul on care a mers pe Luna?";
                    button1.Text = "Theodore Rosevelt";
                    button2.Text = "Karl Marx";
                    button3.Text = "Neil Arsmstrong";
                    button4.Text = "James Madison";

                    correctAnswer = 3;
                    break;

                case 6:
                    pictureBox1.Image = Properties.Resources.napoleon;
                    lblQuestion.Text = "Pe ce insula a murit Napoleon?";
                    button1.Text = "Insula Sfanta Ana";
                    button2.Text = "Insula Sfanta Elena";
                    button3.Text = "Insula Serpilor";
                    button4.Text = "Insula lui Napoleon";

                    correctAnswer = 1;

                    break;

                case 7:
                    pictureBox1.Image = Properties.Resources.razboi;
                    lblQuestion.Text = "Cati ani a durat razboiul de 100 de ani?";
                    button1.Text = "100";
                    button2.Text = "99";
                    button3.Text = "116";
                    button4.Text = "114";

                    correctAnswer = 3;

                    break;

                case 8:
                    pictureBox1.Image = Properties.Resources.vatican;
                    lblQuestion.Text = "Care este cea mai mica tara din lume?";
                    button1.Text = "Monaco";
                    button2.Text = "San Marino";
                    button3.Text = "Tuvalu";
                    button4.Text = "Vatican";

                    correctAnswer = 4;

                    break;

                case 9:
                    pictureBox1.Image = Properties.Resources.tabel;
                    lblQuestion.Text = "Care este cea mai dura subtanta naturala?";
                    button1.Text = "Titanul";
                    button2.Text = "Diamantul";
                    button3.Text = "Wolfram";
                    button4.Text = "Aur";

                    correctAnswer = 2;

                    break;

                case 10:
                    pictureBox1.Image = Properties.Resources.cina;
                    lblQuestion.Text = "Cine a pictat celebrul tablou <<Cina cea de taina>>?";
                    button1.Text = "Vincent van Gogh";
                    button2.Text = "Leonardo da Vinci";
                    button3.Text = "Michelangelo";
                    button4.Text = "Johannes Vermeer";

                    correctAnswer = 2;

                    break;

                case 11:
                    pictureBox1.Image = Properties.Resources.noapte;
                    lblQuestion.Text = "Cine a pictat <<Noaptea instelata>>?";
                    button1.Text = "Vincent van Gogh";
                    button2.Text = "Picasso";
                    button3.Text = "Leonardo da Vinci";
                    button4.Text = "Stefan Luchian";

                    correctAnswer = 1;

                    break;



            }

        }

        private void InsertScore(string username, string password, int score)
        {
            // Stringul de conexiune cu baza de date.
            string connectionString = "Data Source=<DESKTOP - VHICJFT>;Initial Catalog=<usertb>;User ID=<username>;Password=<password>";

            // Cream conexiunea cu baza de date.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Deschidem conexiunea.
                connection.Open();

                // Cream comanda SQL de inserare a datelor.
                string commandText = "INSERT INTO Scores (username, password, score) VALUES (@username, @password, @score)";
                SqlCommand command = new SqlCommand(commandText, connection);

                // Adaugam parametrii in comanda SQL.
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@score", score);

                // Executam comanda SQL.
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Score inserted successfully.");
                }
            }
        }

    }
}
