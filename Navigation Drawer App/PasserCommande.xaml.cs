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
    /// Interaction logic for PasserCommande.xaml
    /// </summary>
    public partial class PasserCommande : Window
    {
        public PasserCommande()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {

                sqlCon.Open();
                String query = "INSERT INTO commande (id, matricule, qte_commande, nom_personnel) VALUES (@Id, @Mat, @Qte, @Nom)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Id", txtId.Text);
                sqlCmd.Parameters.AddWithValue("@Mat", txtPers.Text);
                sqlCmd.Parameters.AddWithValue("@Qte", txtQte.Text);
                sqlCmd.Parameters.AddWithValue("@Nom", txtNom.Text);


                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Commande Enregistré avec succès !!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {

        }
    }
}
