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
        public Form1()
        {   
            InitializeComponent();//Fonction appelée en 1ère

            client_initialize();//initialisation du listing des clients
        }


        private void client_initialize()
        {//dataGrid_Listing_Client
            dataGrid_Listing_Client.Rows.Add(); //This inserts first row, index is "0"
            dataGrid_Listing_Client.Rows[0].Cells[0].Value = "case 1";
            dataGrid_Listing_Client.Rows[0].Cells[1].Value = "case 2";

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
    }
}
