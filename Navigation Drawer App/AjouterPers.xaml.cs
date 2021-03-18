using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Navigation_Drawer_App
{
    /// <summary>
    /// Interaction logic for AjouterPers.xaml
    /// </summary>
    public partial class AjouterPers : Window
    {
        public AjouterPers()
        {
            InitializeComponent();
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {

                sqlCon.Open();
                String query = "INSERT INTO personnels (matricule, nom, prenom, profession, idService) VALUES (@Matricule, @NomP, @PrenomP, @Profession, @Service)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Matricule", txtM.Text);
                sqlCmd.Parameters.AddWithValue("@NomP", txtNomP.Text);
                sqlCmd.Parameters.AddWithValue("@PrenomP", txtPrenomP.Text);
                sqlCmd.Parameters.AddWithValue("@Profession", txtProfession.Text);
                sqlCmd.Parameters.AddWithValue("@Service", txtService.Text);

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Employé Enregistré avec succès !!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnQuitt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear(object sender, RoutedEventArgs e)
        {

        }
    }
}
