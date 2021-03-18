using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for AjouterMat.xaml
    /// </summary>
    public partial class AjouterMat : Window
    {
        public AjouterMat()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {

                sqlCon.Open();
                String query = "INSERT INTO materiel (id, nom_materiel, num_inventaire, date_entree, fournisseur, qte_entree, stock, id_cat) VALUES (@ID, @NomMat, @NumInv, @DateEntree, @Fournisseur, @QteEntree, @Stock, @IdCat)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Id", txtMat.Text);
                sqlCmd.Parameters.AddWithValue("@NomMat", txtNomMat.Text);
                sqlCmd.Parameters.AddWithValue("@NumInv", txtNumInv.Text);
                sqlCmd.Parameters.AddWithValue("@DateEntree", dateTime.SelectedDate);
                sqlCmd.Parameters.AddWithValue("@Fournisseur", txtFournisseur.Text);
                sqlCmd.Parameters.AddWithValue("@QteEntree", txtQteEntree.Text);
                sqlCmd.Parameters.AddWithValue("@Stock", txtStock.Text);
                sqlCmd.Parameters.AddWithValue("@IdCat", txtIdCat.Text);



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

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {

        }
    }
}
