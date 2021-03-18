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
    /// Interaction logic for ModefierPers.xaml
    /// </summary>
    public partial class ModefierPers : Window
    {
        public ModefierPers()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSaveP_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {

                sqlCon.Open();
                String query = "UPDATE personnels set nom=@Nom, prenom=@Prenom, profession=@Profession, idService=@Service where matricule= @Matricule";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Matricule", txtMp.Text);
                sqlCmd.Parameters.AddWithValue("@Nom", txtNp.Text);
                sqlCmd.Parameters.AddWithValue("@Prenom", txtPp.Text);
                sqlCmd.Parameters.AddWithValue("@Profession", txtPrf.Text);
                sqlCmd.Parameters.AddWithValue("@Service", txtIds.Text);

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Employé Modifié avec succès !!");


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
