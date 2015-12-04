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

        static string MyConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=gestion_materiel;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(MyConnectionString);
        static SqlCommand cmd = connection.CreateCommand();
        string loginValid = "admin";
        string mdpValid = "azerty";
        bool isModif = false;
        public Form1()
        {
            InitializeComponent();//Fonction appelée en 1ère
            mdpUserInsert.PasswordChar = '*';

        }

        private void initinialisationApp()
        {
            FillCombo();
            FillDataViewGrid();

            ToggleForm();
            FillFormCombo();
            client_initialize();//initialisation du listing des clients
            materiel_initialize();
            intervention_initialize();
            accueil_initialize();
            FillComboIntervention();
            FillDataViewGridIntervention();
        }


        private void materiel_initialize()
        {
            editButtonMateriel.Enabled = false;
            deleteButtonMateriel.Enabled = false;
        }


        private void FillDataViewGrid()
        {

            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT materiel.id_materiel AS 'ID', materiel.name AS 'Nom Materiel', materiel.description AS 'Description',type.nom AS 'Type Materiel',client.name AS 'Nom Client',  salle.nom_salle AS 'Salle' , etage.nom_etage AS 'Etage', batiment.nom_batiment AS 'Batiment', site.nom AS 'Site' FROM materiel " +
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
                listitem.Add(new ListItem("Indifferent", 0));
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


                ListItem item = (ListItem)comboBox1.SelectedItem;

                if (item.ID == 0) {
                    cmd.CommandText = "SELECT materiel.id_materiel AS 'ID', materiel.name AS 'Nom Materiel', type.nom AS 'Type Materiel',client.name AS 'Nom Client',  salle.nom_salle AS 'Salle' , etage.nom_etage AS 'Etage', batiment.nom_batiment AS 'Batiment', site.nom AS 'Site' FROM materiel " +
                       "INNER JOIN type ON materiel.id_type = type.id_type " +
                       "INNER JOIN client ON materiel.id_client = client.id_client " +
                       "INNER JOIN intervention ON materiel.id_materiel = intervention.id_materiel " +
                       "INNER JOIN salle ON intervention.id_salle = salle.id_salle " +
                       "INNER JOIN etage ON salle.id_salle = etage.id_etage " +
                       "INNER JOIN dbo.batiment ON batiment.id_batiment = etage.id_batiment " +
                       "INNER JOIN dbo.site ON site.id_site = batiment.id_site ";
                }
                else
                {
                    cmd.CommandText = "SELECT materiel.id_materiel AS 'ID', materiel.name AS 'Nom Materiel', type.nom AS 'Type Materiel',client.name AS 'Nom Client',  salle.nom_salle AS 'Salle' , etage.nom_etage AS 'Etage', batiment.nom_batiment AS 'Batiment', site.nom AS 'Site' FROM materiel " +
                    "INNER JOIN type ON materiel.id_type = type.id_type " +
                    "INNER JOIN client ON materiel.id_client = client.id_client " +
                    "INNER JOIN intervention ON materiel.id_materiel = intervention.id_materiel " +
                    "INNER JOIN salle ON intervention.id_salle = salle.id_salle " +
                    "INNER JOIN etage ON salle.id_salle = etage.id_etage " +
                    "INNER JOIN dbo.batiment ON batiment.id_batiment = etage.id_batiment " +
                    "INNER JOIN dbo.site ON site.id_site = batiment.id_site WHERE materiel.id_type = " + item.ID;
                }

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGrid_Listing_Materiel.ReadOnly = true;
                dataGrid_Listing_Materiel.DataSource = ds.Tables[0].DefaultView;


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
            addButtonMateriel.Enabled = true;
            editButtonMateriel.Enabled = true;
            deleteButtonMateriel.Enabled = true;
            buttonModifier.Visible = false;
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
            FillDataViewGridIntervention();
            formFieldNomMateriel.Text = "";

        }

        private void addButtonMateriel_Click(object sender, EventArgs e)
        {
            buttonModifier.Visible = false;
            buttonValider.Visible = true;
            editButtonMateriel.Enabled = false;
            deleteButtonMateriel.Enabled = false;
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

                if (formFieldBatiment.SelectedItem == "") return;

                ListItem item = (ListItem)formFieldBatiment.SelectedItem;
                DataSet1TableAdapters.etageTableAdapter batimentAdaptater = new DataSet1TableAdapters.etageTableAdapter();
                DataSet1.etageDataTable tab1 = new DataSet1.etageDataTable();
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
            this.formFieldNomMateriel.Text = "";

            ToggleForm();
            editButtonMateriel.Enabled = true;
            deleteButtonMateriel.Enabled = true;
        }

        private void deleteButtonMateriel_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce matériel ? ", "Confirmation suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int selectedrowindex = dataGrid_Listing_Materiel.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGrid_Listing_Materiel.Rows[selectedrowindex];
                String idMat = Convert.ToString(selectedRow.Cells[0].Value);

                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "delete from intervention where id_materiel = " + idMat;
                SqlDataAdapter adap = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                cmd.CommandText = "delete from materiel where id_materiel = " + idMat;
                SqlDataAdapter adap2 = new SqlDataAdapter(cmd);
                DataSet ds2 = new DataSet();
                adap2.Fill(ds2);

                FillDataViewGrid();
                MessageBox.Show("materiel supprimée avec succès");
            }
        }

        private void editButtonMateriel_Click_1(object sender, EventArgs e)
        {
            buttonModifier.Visible = true;
            buttonValider.Visible = false;

            addButtonMateriel.Enabled = true;
            editButtonMateriel.Enabled = true;
            deleteButtonMateriel.Enabled = true;
            ToggleForm();
            int selectedrowindex = dataGrid_Listing_Materiel.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGrid_Listing_Materiel.Rows[selectedrowindex];
            String nomMat = Convert.ToString(selectedRow.Cells[1].Value);
            formFieldNomMateriel.Text = nomMat;

        }

        private void editButtonForm_Click(object sender, EventArgs e)
        {
            buttonModifier.Visible = false;
            ToggleForm();
            int selectedrowindex = dataGrid_Listing_Materiel.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGrid_Listing_Materiel.Rows[selectedrowindex];
            String idMat = Convert.ToString(selectedRow.Cells[0].Value);

            {
                ListItem client = (ListItem)formFieldClient.SelectedItem;
                string name = formFieldNomMateriel.Text;
                string description = "";
                ListItem type = (ListItem)formFieldTypeMateriel.SelectedItem;

                cmd.CommandText = "UPDATE materiel SET id_client =" + client.ID + ", name = @name, description = @description, id_type = " + type.ID
                + " WHERE id_materiel = " + idMat;
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("description", description);
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
            }

            MessageBox.Show("Matériel Modifié avec succès");

            FillDataViewGrid();

        }



        //INTERVETION///////////////////////////////////////////////////////////////////////////////////////////////

        private void FillDataViewGridIntervention()
        {

            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT intervention.id_intervention AS 'ID', materiel.name AS 'Materiel', client.name AS 'Client', intervention.date_plannifiee AS 'Date Plannifiée', intervention.date_realisee AS 'Date Realisée', intervention.commentaires AS 'Commentaires'"
                    + "FROM intervention "
                    + "INNER JOIN materiel ON materiel.id_materiel = intervention.id_materiel "
                    + "INNER JOIN client ON client.id_client = materiel.id_client ";


                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGrid_Listing_Intervention.ReadOnly = true;
                dataGrid_Listing_Intervention.DataSource = ds.Tables[0].DefaultView;
            }

        }

        private void ToggleFormIntervention()
        {
            if (formFieldCommentaireIntervention.Enabled == false) { formFieldCommentaireIntervention.Enabled = true; } else { formFieldCommentaireIntervention.Enabled = false; }
            if (dateTimePickerIntervention.Enabled == false) { dateTimePickerIntervention.Enabled = true; } else { dateTimePickerIntervention.Enabled = false; }
            if (buttonValiderIntervention.Enabled == false) { buttonValiderIntervention.Enabled = true; } else { buttonValiderIntervention.Enabled = false; }

        }

        private void dataGrid_Listing_Intervention_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            editButtonIntervention.Enabled = true;

        }


        private void intervention_initialize()
        {
            editButtonIntervention.Enabled = false;
            formFieldCommentaireIntervention.Enabled = false;
            dateTimePickerIntervention.Enabled = false;
            buttonValiderIntervention.Enabled = false;
        }

        private void editButtonIntervention_Click(object sender, EventArgs e)
        {
            ToggleFormIntervention();
        }

        private void buttonValiderIntervention_Click(object sender, EventArgs e)
        {

            DataSet1TableAdapters.interventionTableAdapter materielAdaptater = new DataSet1TableAdapters.interventionTableAdapter();
            DataSet1TableAdapters.interventionTableAdapter intervetionAdaptater = new DataSet1TableAdapters.interventionTableAdapter();
            DataSet1.interventionDataTable tab1 = new DataSet1.interventionDataTable();

            int selectedrowindex = dataGrid_Listing_Intervention.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGrid_Listing_Intervention.Rows[selectedrowindex];
            int idInter = (int)selectedRow.Cells[0].Value;
            var theDate = dateTimePickerIntervention.Value;
            string commentaires = formFieldCommentaireIntervention.Text;
            materielAdaptater.UpdateIntervention(tab1, idInter, theDate, commentaires);

            MessageBox.Show("L'intervention a été modifiée avec succès");
            formFieldCommentaireIntervention.Text = "";
            FillDataViewGridIntervention();
        }


        ////ACCUEIL//////////////////////////////////////////////////////////////



        private void accueil_initialize()
        {
            FillDataViewGridAccueil();

        }

        private void FillDataViewGridAccueil()
        {

            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT TOP 5 materiel.name, convert(varchar(50),intervention.date_realisee,103) AS DateRealisee FROM intervention "
                    +"INNER JOIN materiel ON materiel.id_materiel = intervention.id_materiel  ORDER BY date_realisee";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                DataTable myDataTable = ds.Tables[0];

                foreach (DataRow dataRow in myDataTable.Rows)
                {
                    listLastIntervention.Items.Add(dataRow["name"] + "  : " + dataRow["DateRealisee"]);
                }
            }

            using (SqlCommand cmd2 = connection.CreateCommand())
            {
                cmd2.CommandText = "SELECT TOP 5 materiel.name, convert(varchar(50),intervention.date_plannifiee,103) AS DatePlannifiee FROM intervention "
                    +"INNER JOIN materiel ON materiel.id_materiel = intervention.id_materiel ORDER BY date_plannifiee";
                SqlDataAdapter adap = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                DataTable myDataTable = ds.Tables[0];

                foreach (DataRow dataRow in myDataTable.Rows)
                {
                    listNextIntervention.Items.Add(dataRow["name"] + "  : " + dataRow["DatePlannifiee"]);
                }
            }

        }



        // CLIENT//
        private void client_initialize()
        {
            denominationClient.Enabled = false;
            buttonValiderClient.Enabled = false;
            groupBoxClient.Enabled = false;
            try
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT id_client AS 'ID' , name AS 'Nom Client' FROM Client";
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    dataGrid_Listing_Client.ReadOnly = true;
                    dataGrid_Listing_Client.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxClient.Enabled = true;
            denominationClient.Enabled = true;
            buttonValiderClient.Enabled = true;
            //ToggleFormClient();
        }




        private void ToggleFormClient()
        {
            if (denominationClient.Enabled == false) { denominationClient.Enabled = true; } else { denominationClient.Enabled = false; }
            if (buttonValiderClient.Enabled == false) { buttonValiderClient.Enabled = true; } else { buttonValiderClient.Enabled = false; }
        }

        private void buttonValiderClient_Click(object sender, EventArgs e)
        {
            if (isModif == false)
            {
                DataSet1TableAdapters.clientTableAdapter clientAdaptater = new DataSet1TableAdapters.clientTableAdapter();
                DataSet1TableAdapters.clientTableAdapter intervetionAdaptater = new DataSet1TableAdapters.clientTableAdapter();
                DataSet1.clientDataTable tab1 = new DataSet1.clientDataTable();
                clientAdaptater.Insert(denominationClient.Text);
                MessageBox.Show("Client crée avec succès");
                client_initialize();
                denominationClient.Text = "";
                //ToggleFormClient();

                groupBoxClient.Enabled = false;
            }
            else
            {

                int selectedrowindex = dataGrid_Listing_Client.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGrid_Listing_Client.Rows[selectedrowindex];
                int idClient = Convert.ToInt32(selectedRow.Cells[0].Value);

                SqlCommand cmd = connection.CreateCommand();
                string name = denominationClient.Text;
                //cmd.CommandText = "UPDATE client SET name = "+ name +" WHERE id_client = "+idClient;
                cmd.CommandText = "UPDATE client SET name = @name WHERE id_client= " + idClient;
                cmd.Parameters.AddWithValue("name", name);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                client_initialize();
                MessageBox.Show("Client modifié avec avec succès");
                isModif = false;
               // ToggleFormClient();

                denominationClient.Text = "";
                groupBoxClient.Enabled = false;
            }
        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce client ? ", "Confirmation suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           if (result == DialogResult.Yes)
              {
                  int selectedrowindex = dataGrid_Listing_Client.SelectedCells[0].RowIndex;
                  DataGridViewRow selectedRow = dataGrid_Listing_Client.Rows[selectedrowindex];
                  int idClient = Convert.ToInt32(selectedRow.Cells[0].Value);
                  SqlCommand cmd = connection.CreateCommand();
                  cmd.CommandText = "delete from client where id_client = " + idClient;
                  SqlDataAdapter adap = new SqlDataAdapter(cmd);
                  DataSet ds = new DataSet();
                  adap.Fill(ds);
                  client_initialize();
                  //ToggleFormClient();
                  MessageBox.Show("Client supprimé avec succès");
              }
  
        }

        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            isModif = true;
            int selectedrowindex = dataGrid_Listing_Client.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGrid_Listing_Client.Rows[selectedrowindex];
            string nomClient = Convert.ToString(selectedRow.Cells[1].Value);
            denominationClient.Text = nomClient;

            groupBoxClient.Enabled = true;
            denominationClient.Enabled = true;
            buttonValiderClient.Enabled = true;
        }

        private void searchClient_Click(object sender, EventArgs e)
        {
            string name = formFieldRecherche.Text;
            if (name == "" || name == "tous")
            {

                cmd.CommandText = "SELECT id_client AS ID, name as 'Nom Client' FROM client";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                dataGrid_Listing_Client.ReadOnly = true;
                dataGrid_Listing_Client.DataSource = ds.Tables[0].DefaultView;
                cmd.Parameters.Clear();
            }
            else
            {

                cmd.CommandText = "SELECT id_client AS ID, name as 'Nom Client' FROM client where name like '%'+ @name + '%'";
                cmd.Parameters.AddWithValue("name", name);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                dataGrid_Listing_Client.ReadOnly = true;
                dataGrid_Listing_Client.DataSource = ds.Tables[0].DefaultView;
                cmd.Parameters.Clear();
            }

        }

        private void FillComboIntervention()
        {

            try
            {
                DataSet1TableAdapters.clientTableAdapter clientAdaptater = new DataSet1TableAdapters.clientTableAdapter();
                DataSet1.clientDataTable tab1 = new DataSet1.clientDataTable();
                clientAdaptater.Fill(tab1);
                List<ListItem> listitem = new List<ListItem>();
                listitem.Add(new ListItem("Indifferent", 0));
                foreach (DataSet1.clientRow Row in tab1.Rows)
                {
                    
                    listitem.Add(new ListItem(Row.name, Row.id_client));
                }
                comboIntervention.DataSource = listitem;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                using (SqlCommand cmd = connection.CreateCommand())
                {

                    ListItem client = (ListItem)comboIntervention.SelectedItem;

                    if (client.ID == 0) {
                        cmd.CommandText = "SELECT intervention.id_intervention AS 'ID', materiel.name AS 'Materiel', client.name AS 'Client', intervention.date_plannifiee AS 'Date Plannifiée', intervention.date_realisee AS 'Date Realisée', intervention.commentaires AS 'Commentaires'"
                               + "FROM intervention "
                               + "INNER JOIN materiel ON materiel.id_materiel = intervention.id_materiel "
                               + "INNER JOIN client ON client.id_client = materiel.id_client";
               
                    }
                    else
                    {
                        cmd.CommandText = "SELECT intervention.id_intervention AS 'ID', materiel.name AS 'Materiel', client.name AS 'Client', intervention.date_plannifiee AS 'Date Plannifiée', intervention.date_realisee AS 'Date Realisée', intervention.commentaires AS 'Commentaires'"
                            + "FROM intervention "
                            + "INNER JOIN materiel ON materiel.id_materiel = intervention.id_materiel "
                            + "INNER JOIN client ON client.id_client = materiel.id_client "
                            + "WHERE client.id_client = " + client.ID;
                    }

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    dataGrid_Listing_Intervention.ReadOnly = true;
                    dataGrid_Listing_Intervention.DataSource = ds.Tables[0].DefaultView;
                }
            }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string loginUser = loginTxt.Text;
            string mdpUser = mdpUserInsert.Text;

            if (loginUser == loginValid && mdpUser == mdpValid)
            {
                MessageBox.Show("Bienvenue dans GestionMatos !");
                initinialisationApp();
                panelLogin.Visible = false;
            }
            else
            {
                MessageBox.Show("Votre authentification est invalide");
            }
        }

      
         }
}
