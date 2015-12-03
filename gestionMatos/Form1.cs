using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace gestionMatos
{
    public partial class Form1 : Form
    {

        string MyConnectionString = "Data Source=NICO-PC\\SQLEXPRESS;Initial Catalog=gestion_materiel;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();//Fonction appelée en 1ère
            FillCombo();
            FillDataViewGrid();
            ToggleForm();
            FillFormCombo();
            client_initialize();//initialisation du listing des clients
            materiel_initialize();

        }


        private void materiel_initialize()
        {
            editButtonMateriel.Enabled = false;
            deleteButtonMateriel.Enabled = false;
        }


        private void FillDataViewGrid()
        {
            string MyConnectionString = "Data Source=NICO-PC\\SQLEXPRESS;Initial Catalog=gestion_materiel;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(MyConnectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT materiel.id_materiel AS 'ID', materiel.name AS 'Nom Materiel', type.nom AS 'Type Materiel',client.name AS 'Nom Client',  salle.nom_salle AS 'Salle' , etage.nom_etage AS 'Etage', batiment.nom_batiment AS 'Batiment', site.nom AS 'Site' FROM materiel " +
                "INNER JOIN type ON materiel.id_type = type.id_type " +
                "INNER JOIN client ON materiel.id_client = client.id_client " +
                "INNER JOIN intervention ON materiel.id_materiel = intervention.id_materiel " +
                "INNER JOIN salle ON intervention.id_salle = salle.id_salle " +
                "INNER JOIN etage ON salle.id_salle = etage.id_etage " +
                "INNER JOIN dbo.batiment ON batiment.id_batiment = etage.id_batiment " +
                "INNER JOIN dbo.site ON site.id_site = batiment.id_site";


                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGrid_Listing_Materiel.ReadOnly = true;
                dataGrid_Listing_Materiel.DataSource = ds.Tables[0].DefaultView;
            }

        }

        private void client_initialize()
        {

            try
            {
                DataSet1TableAdapters.clientTableAdapter clientAdaptater = new DataSet1TableAdapters.clientTableAdapter();
                DataSet1.clientDataTable tab1 = new DataSet1.clientDataTable();
                clientAdaptater.Fill(tab1);
                //List<ListItem> listitem = new List<ListItem>();
                int numRow = 0;
                // int numCol = dataGrid_Listing_Client.ColumnCount; 
                foreach (DataSet1.clientRow Row in tab1.Rows)
                {
                    // listitem.Add(new ListItem(Row.nom, Row.id_type));
                    dataGrid_Listing_Client.Rows.Add(); //This inserts first row, index is "0"
                    dataGrid_Listing_Client.Rows[numRow].Cells[0].Value = Row.id_client;
                    dataGrid_Listing_Client.Rows[numRow].Cells[1].Value = Row.name;
                    numRow++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1Onglets.SelectTab(onglet_interventions);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1Onglets.SelectTab(onglet_interventions);
        }

        private void FillCombo()
        {
            try
            {
                DataSet1TableAdapters.typeTableAdapter typeAdaptater = new DataSet1TableAdapters.typeTableAdapter();
                DataSet1.typeDataTable tab1 = new DataSet1.typeDataTable();
                typeAdaptater.Fill(tab1);
                List<ListItem> listitem = new List<ListItem>();

                foreach (DataSet1.typeRow Row in tab1.Rows)
                {
                    listitem.Add(new ListItem(Row.nom, Row.id_type));
                }
                comboBox1.DataSource = listitem;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //   dbConnection.Close();
        }


        private void FillFormCombo()
        {
            // SqlConnection dbConnection = new SqlConnection(myConnectionString);
            //SqlCommand sqlCmd = new SqlCommand();
            try
            {
                //TYPE MATERIEL //
                DataSet1TableAdapters.typeTableAdapter typeAdaptater = new DataSet1TableAdapters.typeTableAdapter();
                DataSet1.typeDataTable tab1 = new DataSet1.typeDataTable();
                typeAdaptater.Fill(tab1);
                List<ListItem> listitem = new List<ListItem>();

                foreach (DataSet1.typeRow Row in tab1.Rows)
                {
                    listitem.Add(new ListItem(Row.nom, Row.id_type));
                }
                formFieldTypeMateriel.DataSource = listitem;

                //CLIENT //
                DataSet1TableAdapters.clientTableAdapter clientAdaptater = new DataSet1TableAdapters.clientTableAdapter();
                DataSet1.clientDataTable tab2 = new DataSet1.clientDataTable();
                clientAdaptater.Fill(tab2);
                List<ListItem> listitem2 = new List<ListItem>();

                foreach (DataSet1.clientRow Row in tab2.Rows)
                {
                    listitem2.Add(new ListItem(Row.name, Row.id_client));
                }
                formFieldClient.DataSource = listitem2;


                //SITE//
                DataSet1TableAdapters.siteTableAdapter siteAdaptater = new DataSet1TableAdapters.siteTableAdapter();
                DataSet1.siteDataTable tab3 = new DataSet1.siteDataTable();
                siteAdaptater.Fill(tab3);
                List<ListItem> listitem3 = new List<ListItem>();

                foreach (DataSet1.siteRow Row in tab3.Rows)
                {
                    listitem3.Add(new ListItem(Row.nom, Row.id_site));
                }
                formFieldSite.DataSource = listitem3;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //   dbConnection.Close();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string MyConnectionString = "Data Source=NICO-PC\\SQLEXPRESS;Initial Catalog=gestion_materiel;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(MyConnectionString))
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    ListItem item = (ListItem)comboBox1.SelectedItem;
                    cmd.CommandText = "SELECT materiel.id_materiel AS 'ID', materiel.name AS 'Nom Materiel', type.nom AS 'Type Materiel',client.name AS 'Nom Client',  salle.nom_salle AS 'Salle' , etage.nom_etage AS 'Etage', batiment.nom_batiment AS 'Batiment', site.nom AS 'Site' FROM materiel " +
                    "INNER JOIN type ON materiel.id_type = type.id_type " +
                    "INNER JOIN client ON materiel.id_client = client.id_client " +
                    "INNER JOIN intervention ON materiel.id_materiel = intervention.id_materiel " +
                    "INNER JOIN salle ON intervention.id_salle = salle.id_salle " +
                    "INNER JOIN etage ON salle.id_salle = etage.id_etage " +
                    "INNER JOIN dbo.batiment ON batiment.id_batiment = etage.id_batiment " +
                    "INNER JOIN dbo.site ON site.id_site = batiment.id_site WHERE materiel.id_type = " + item.ID;


                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    dataGrid_Listing_Materiel.ReadOnly = true;
                    dataGrid_Listing_Materiel.DataSource = ds.Tables[0].DefaultView;
                }



                //DataSet1TableAdapters.materielTableAdapter materielAdaptater = new DataSet1TableAdapters.materielTableAdapter();
                //DataSet1.materielDataTable tab1 = new DataSet1.materielDataTable();
                //// materielAdaptater.NicoProcedure(tab1, item.ID);
                //materielAdaptater.GetMaterielByType(tab1, item.ID);
                //List<ListItem> listitem = new List<ListItem>();
                //foreach (DataSet1.materielRow Row in tab1.Rows)
                //{
                //    listitem.Add(new ListItem(Row.name, Row.id_materiel));
                //}
                //dataGrid_Listing_Materiel.DataSource = listitem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void ToggleForm()
        {
            if (formFieldNomMateriel.Enabled == false) { formFieldNomMateriel.Enabled = true; } else { formFieldNomMateriel.Enabled = false; }
            if (formFieldClient.Enabled == false) { formFieldClient.Enabled = true; } else { formFieldClient.Enabled = false; }
            if (formFieldTypeMateriel.Enabled == false) { formFieldTypeMateriel.Enabled = true; } else { formFieldTypeMateriel.Enabled = false; }
            if (formFieldSite.Enabled == false) { formFieldSite.Enabled = true; } else { formFieldSite.Enabled = false; }
            if (formFieldBatiment.Enabled == false) { formFieldBatiment.Enabled = true; } else { formFieldBatiment.Enabled = false; }
            if (formFieldEtage.Enabled == false) { formFieldEtage.Enabled = true; } else { formFieldEtage.Enabled = false; }
            if (formFieldSalle.Enabled == false) { formFieldSalle.Enabled = true; } else { formFieldSalle.Enabled = false; }
            //  if (formFieldDescription.Enabled == false) { formFieldDescription.Enabled = true; } else { formFieldDescription.Enabled = false; }
            if (buttonValider.Enabled == false) { buttonValider.Enabled = true; } else { buttonValider.Enabled = false; }
            if (buttonAnnuler.Enabled == false) { buttonAnnuler.Enabled = true; } else { buttonAnnuler.Enabled = false; }

        }


        private void editButtonMateriel_Click(object sender, EventArgs e)
        {
            ToggleForm();

        }

        private void deleteButtonMateriel_Click(object sender, EventArgs e)
        {
            ToggleForm();

        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            ToggleForm();

            DataSet1TableAdapters.materielTableAdapter materielAdaptater = new DataSet1TableAdapters.materielTableAdapter();
            DataSet1TableAdapters.interventionTableAdapter intervetionAdaptater = new DataSet1TableAdapters.interventionTableAdapter();
            DataSet1.materielDataTable tab1 = new DataSet1.materielDataTable();
            ListItem client = (ListItem)formFieldClient.SelectedItem;
            ListItem batiment = (ListItem)formFieldClient.SelectedItem;
            ListItem materiel = (ListItem)formFieldClient.SelectedItem;
            ListItem type_materiel = (ListItem)formFieldTypeMateriel.SelectedItem;
            ListItem salle = (ListItem)formFieldSalle.SelectedItem;
            string name_materiel = formFieldNomMateriel.Text;
            string description = "";
            string commentaires = "";
            materielAdaptater.InsertMaterielAndIntervention(tab1, client.ID, name_materiel, description, type_materiel.ID, commentaires, salle.ID);

            MessageBox.Show("Materiel crée avec succès");
            FillDataViewGrid();
            formFieldNomMateriel.Text = "";
            //materielAdaptater.InsertMateriel(tab1,id_materiel,id_client,id_intervention,name_materiel,description , id_type);

        }

        private void addButtonMateriel_Click(object sender, EventArgs e)
        {
            buttonModifier.Visible = false;
            buttonValider.Visible = true;
            ToggleForm();

        }

        private void formFieldSite_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {

                if (formFieldSite.SelectedItem.ToString() == "") return;
                ListItem item = (ListItem)formFieldSite.SelectedItem;
                DataSet1TableAdapters.batimentTableAdapter batimentAdaptater = new DataSet1TableAdapters.batimentTableAdapter();
                DataSet1.batimentDataTable tab1 = new DataSet1.batimentDataTable();
                batimentAdaptater.GetBatimentBySite(tab1, item.ID);
                List<ListItem> listitem = new List<ListItem>();
                foreach (DataSet1.batimentRow Row in tab1.Rows)
                {
                    listitem.Add(new ListItem(Row.nom_batiment, Row.id_batiment));
                }


                formFieldBatiment.DataSource = listitem;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void formFieldBatiment_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
        
                if ( formFieldBatiment.SelectedItem == "") return;

                ListItem item = (ListItem)formFieldBatiment.SelectedItem;
                DataSet1TableAdapters.etageTableAdapter batimentAdaptater = new DataSet1TableAdapters.etageTableAdapter();
                DataSet1.etageDataTable tab1 = new DataSet1.etageDataTable();
                // materielAdaptater.NicoProcedure(tab1, item.ID);
                batimentAdaptater.GetEtageByBatiment(tab1, item.ID);
                List<ListItem> listitem = new List<ListItem>();
                foreach (DataSet1.etageRow Row in tab1.Rows)
                {
                    listitem.Add(new ListItem(Row.nom_etage, Row.id_etage));
                }


                formFieldEtage.DataSource = listitem;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formFieldEtage_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                if (formFieldEtage.SelectedItem == "") return;

                ListItem item = (ListItem)formFieldEtage.SelectedItem;
                DataSet1TableAdapters.salleTableAdapter salleAdaptater = new DataSet1TableAdapters.salleTableAdapter();
                DataSet1.salleDataTable tab1 = new DataSet1.salleDataTable();
                // materielAdaptater.NicoProcedure(tab1, item.ID);
                salleAdaptater.GetSalleByEtage(tab1, item.ID);
                List<ListItem> listitem = new List<ListItem>();
                foreach (DataSet1.salleRow Row in tab1.Rows)
                {
                    listitem.Add(new ListItem(Row.nom_salle, Row.id_salle));
                }


                formFieldSalle.DataSource = listitem;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGrid_Listing_Materiel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            editButtonMateriel.Enabled = true;
            deleteButtonMateriel.Enabled = true;
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            addButtonMateriel.Enabled = true;
            // this.formFieldNomMateriel.Refresh();
            this.formFieldNomMateriel.Text = "";
            //   this.formFieldDescription.Text = "";

            //formFieldNomMateriel.SetValue("");
            //  ToggleForm();
        }

        private void deleteButtonMateriel_Click_1(object sender, EventArgs e)
        {
            int selectedrowindex = dataGrid_Listing_Materiel.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGrid_Listing_Materiel.Rows[selectedrowindex];
            String idMat = Convert.ToString(selectedRow.Cells[0].Value);

            SqlConnection connection = new SqlConnection(MyConnectionString);
            using (SqlCommand cmd2 = connection.CreateCommand())
            {
                cmd2.CommandText = "delete from intervention where id_materiel = " + idMat;
                SqlDataAdapter adap = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                adap.Fill(ds);


            }

            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "delete from materiel where id_materiel = " + idMat;

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
            }


            FillDataViewGrid();
            MessageBox.Show("materiel supprimée avec succès");
        }

        private void editButtonMateriel_Click_1(object sender, EventArgs e)
        {
            buttonModifier.Visible = true;
            buttonValider.Visible = false;


            ToggleForm();
            int selectedrowindex = dataGrid_Listing_Materiel.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGrid_Listing_Materiel.Rows[selectedrowindex];
            String nomMat = Convert.ToString(selectedRow.Cells[1].Value);
          
            formFieldNomMateriel.Text = nomMat;

        }

        private void editButtonForm_Click(object sender, EventArgs e)
        {

            int selectedrowindex = dataGrid_Listing_Materiel.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGrid_Listing_Materiel.Rows[selectedrowindex];


            String idMat = Convert.ToString(selectedRow.Cells[0].Value);



            SqlConnection connection = new SqlConnection(MyConnectionString);

            using (SqlCommand cmd = connection.CreateCommand())
            {
                ListItem client = (ListItem)formFieldClient.SelectedItem;
                string name = formFieldNomMateriel.Text;
                string description = "";
                ListItem type = (ListItem)formFieldTypeMateriel.SelectedItem;

                cmd.CommandText = "UPDATE materiel SET id_client ="+ client.ID+", name = @name, description = @description, id_type = "+type.ID
                +" WHERE id_materiel = " + idMat;
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("description", description);
                    //, name =" + name + " , description = " + description + " , id_type = " + type.ID + " WHERE id_materiel =" + idMat;

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
            }

            using (SqlCommand cmd2 = connection.CreateCommand())
            {
                ListItem salle = (ListItem)formFieldSalle.SelectedItem;
                cmd2.CommandText = "UPDATE intervention SET id_salle =" + salle.ID
                    + " where id_materiel =" + idMat;
                SqlDataAdapter adap = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                //#TODO refresh la grid intervention
            }

            MessageBox.Show("Matériel Modifié avec succès");
            FillDataViewGrid();

        }

    }
}
