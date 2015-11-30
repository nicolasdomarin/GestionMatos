using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string myConnectionString = @"Server=GUETTA-PC\SQLEXPRESS;DataBase=gestion_materiel;Integrated Security=SSPI;Connect Timeout=5";



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gestion_materielDataSet4.type' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'gestion_materielDataSet4.type' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'gestion_materielDataSet3.type' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'gestion_materielDataSet1.materiel' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'gestion_materielDataSet1.type' table. You can move, or remove it, as needed.
          
            FillCombo();

        }
        private void FillCombo()
        {
            SqlConnection dbConnection = new SqlConnection(myConnectionString);
            SqlCommand sqlCmd = new SqlCommand();
            try
            {

                sqlCmd.Connection = dbConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT * FROM type";
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                DataTable dtRecord = new DataTable();
                sqlDataAdap.Fill(dtRecord);
                WindowsFormsApplication4.DataSet1TableAdapters.typeTableAdapter typeAdaptater = new WindowsFormsApplication4.DataSet1TableAdapters.typeTableAdapter();
                DataSet1.typeDataTable tab1 = new DataSet1.typeDataTable();
                typeAdaptater.Fill(tab1);
                List<ListItem> listitem = new List<ListItem>();
                foreach (DataSet1.typeRow Row in tab1.Rows) 
                {
                    listitem.Add(new ListItem(Row.nom,Row.id_type));
                } 
                comboBox1.DataSource = listitem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dbConnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader drSQL = null;
            SqlCommand sqlCmd = null;
            ListItem objListItem;
                     
            try
            {
                ListItem item = (ListItem)comboBox1.SelectedItem;
                SqlConnection dbConnection = new SqlConnection(myConnectionString);
                sqlCmd = new SqlCommand();
                sqlCmd.Connection = dbConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT * FROM materiel where id_type = " + item.ID;
               
                dbConnection.Open();
                drSQL = sqlCmd.ExecuteReader();
                listBox1.Items.Clear();
                
                while (drSQL.Read()) {
                    objListItem = new ListItem(drSQL["name"].ToString(), Convert.ToInt32(drSQL["id_type"]));
                    listBox1.Items.Add(objListItem);
                }
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
