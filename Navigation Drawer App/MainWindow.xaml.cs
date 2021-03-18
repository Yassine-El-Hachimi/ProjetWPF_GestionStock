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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Navigation_Drawer_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void Materiel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Materiel.Visibility = Visibility.Visible;
            Perssonel.Visibility = Visibility.Collapsed;
            Servive.Visibility = Visibility.Collapsed;
            Commande.Visibility = Visibility.Collapsed;
            Statistics.Visibility = Visibility.Collapsed;
        }


        private void datagridMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True;");

                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    String query = "SELECT * FROM materiel";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.ExecuteNonQuery();

                    SqlDataAdapter data = new SqlDataAdapter(sqlCmd);
                    DataTable dt = new DataTable("materiel");
                    data.Fill(dt);
                    datagridMateriel.ItemsSource = dt.DefaultView;
                    data.Update(dt);
                    sqlCon.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            AjouterMat ajouterM = new AjouterMat();
            ajouterM.Show();
            Close();
            
        }
        private void BtnMoifier_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (datagridMateriel.SelectedItem == null)
                    return;
                DataRowView rowView = (DataRowView)datagridMateriel.SelectedItem;

                int selectedIndex = datagridMateriel.SelectedIndex;
                var index = datagridMateriel.SelectedIndex;
                ModefierMateriel modefier = new ModefierMateriel();
                var row = (DataRowView)datagridMateriel.SelectedItem;
                modefier.txtMat.Text = row.Row[0].ToString();
                modefier.txtNomMat.Text = row.Row[1].ToString();
                modefier.txtNumInv.Text = row.Row[2].ToString();
                // ajouter.dateTime.SelectedDate = row.Row[3].ToString();

                
                modefier.Show();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "DELETE FROM materiel WHERE id=@Id";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter data = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("materiel");

                
                int selectedIndex = datagridMateriel.SelectedIndex;
                var row = (DataRowView)datagridMateriel.SelectedItem;
                row.Delete();
                sqlCmd.Parameters.AddWithValue("@Id", row["id"]);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();

                data.Update(dt);
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }









        //PERSSONE__________________________________________________________________________________________________________________________________________//
        //__________________________________________________________________________________________________________________________________________________//



        public void Personnel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Materiel.Visibility = Visibility.Collapsed;
            Perssonel.Visibility = Visibility.Visible;
            Servive.Visibility = Visibility.Collapsed;
            Commande.Visibility = Visibility.Collapsed;
            Statistics.Visibility = Visibility.Collapsed;


        }

        private void BtnLoadPers_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            string CmdString = string.Empty;
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT * FROM personnels";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();

                SqlDataAdapter data = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("personnels");
                data.Fill(dt);
                dataGridPersonnel.ItemsSource = dt.DefaultView;
                data.Update(dt);
                sqlCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnAjouterPers_Click(object sender, RoutedEventArgs e)
        {
            AjouterPers ajouterPers = new AjouterPers();
            ajouterPers.Show();
            Close();
        }

        private void BtnModifierPers_Click(object sender, RoutedEventArgs e)
        {
            ModefierPers modefierPers = new ModefierPers();
            modefierPers.Show();
            Close();
        }

        private void BtnSupprimerPers_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "DELETE FROM personnels WHERE matricule=@Matricule";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter data = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("personnels");

                int selectedIndex = dataGridPersonnel.SelectedIndex;
                var row = (DataRowView)dataGridPersonnel.SelectedItem;
                row.Delete();
                sqlCmd.Parameters.AddWithValue("@Matricule", row["matricule"]);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();
                data.Update(dt);
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPc_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                if (dataGridPersonnel.SelectedItem == null)
                    return;
                DataRowView rowView = (DataRowView)dataGridPersonnel.SelectedItem;

                int selectedIndex = dataGridPersonnel.SelectedIndex;
                var index = dataGridPersonnel.SelectedIndex;
                PasserCommande pass = new PasserCommande();
                var row = (DataRowView)dataGridPersonnel.SelectedItem;
                pass.txtPers.Text = row.Row[0].ToString();
                pass.txtNom.Text = row.Row[1] + " " + row.Row[2].ToString();
                pass.Show();

                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //PERSSONE__________________________________________________________________________________________________________________________________________//
        //__________________________________________________________________________________________________________________________________________________//


        //Service
        public void Service_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Materiel.Visibility = Visibility.Collapsed;
            Perssonel.Visibility = Visibility.Collapsed;
            Servive.Visibility = Visibility.Visible;
            Commande.Visibility = Visibility.Collapsed;
            Statistics.Visibility = Visibility.Collapsed;
        }






















        private void Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            Close();
        }











        //SERVICE__________________________________________________________________________________________________________________________________________//
        //__________________________________________________________________________________________________________________________________________________//
        private void BtnLoadS_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT * FROM service";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();

                SqlDataAdapter data = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("service");
                data.Fill(dt);
                DataGridS.ItemsSource = dt.DefaultView;
                data.Update(dt);
                sqlCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSupprimerS_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "DELETE FROM service WHERE id_service=@IdService";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter data = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("service");

                
                


                int selectedIndex = DataGridS.SelectedIndex;
                var row = (DataRowView)DataGridS.SelectedItem;
                row.Delete();
                sqlCmd.Parameters.AddWithValue("@IdService", row["id_service"]);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();
                data.Update(dt);
                sqlCon.Close();

                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAjouterS_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {

                sqlCon.Open();
                String query = "INSERT INTO service (id_service, nom_service) VALUES (@IdService, @NomService)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@IdService", txtIdS.Text);
                sqlCmd.Parameters.AddWithValue("@NomService", txtNomS.Text);


                sqlCmd.ExecuteNonQuery();
                MessageBox.Show(" Service Enregistré !!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        //SERVICE__________________________________________________________________________________________________________________________________________//
        
            
        
        //Commande___________________________________________________________________________________________________________________________________//

        public void Commande_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Materiel.Visibility = Visibility.Collapsed;
            Perssonel.Visibility = Visibility.Collapsed;
            Servive.Visibility = Visibility.Collapsed;
            Commande.Visibility = Visibility.Visible;
            Statistics.Visibility = Visibility.Collapsed;
        }
   
        private void btnLoadCmd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT * FROM commande";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();

                SqlDataAdapter data = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("commande");
                data.Fill(dt);
                DataGridCom.ItemsSource = dt.DefaultView;
                data.Update(dt);
                sqlCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void supprimerCmd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-I409R4P\SQLEXPRESS; Initial Catalog=stock; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "DELETE FROM commande WHERE id=@Id";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
               
                SqlDataAdapter data = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("commande");

                

                int selectedIndex = DataGridCom.SelectedIndex;
                var row = (DataRowView)DataGridCom.SelectedItem;
                row.Delete();
                sqlCmd.Parameters.AddWithValue("@Id", row["id"]);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();

                data.Update(dt);
                sqlCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }











        //STATISTICS__________________________________________________________________________________________________________________________________________//
        //__________________________________________________________________________________________________________________________________________________//

        public void Statistics_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Materiel.Visibility = Visibility.Collapsed;
            Perssonel.Visibility = Visibility.Collapsed;
            Servive.Visibility = Visibility.Collapsed;
            Commande.Visibility = Visibility.Collapsed;
            Statistics.Visibility = Visibility.Visible;
        }


    }
}
