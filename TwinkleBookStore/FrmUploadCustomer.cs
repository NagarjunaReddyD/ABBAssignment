using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
namespace TwinkleBookStore
{
    public partial class FrmUploadCustomer : Form
    {
        string filePath = string.Empty;
        string fileExt = string.Empty;

        System.Data.DataTable dtCustomerExcel;
        System.Data.DataTable dtItemExcel;
        System.Data.DataSet dsExccel;

        string cnstring = string.Empty;
        public FrmUploadCustomer()
        {
            cnstring = ConfigurationManager.ConnectionStrings["TwinkleStoreEntitiesAdo"].ToString();
            InitializeComponent();
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file 
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                txtPath.Text = filePath;
                fileExt = Path.GetExtension(filePath); //get the file extension  
            }


        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
            {
                try
                {
                     dtCustomerExcel = new System.Data.DataTable();
                    dsExccel = ReadCustomerExcel(filePath, fileExt); //read excel file  

                    dtCustomerExcel = dsExccel.Tables[0];
                    dtItemExcel = dsExccel.Tables[1];
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dtCustomerExcel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
            }
        }
        public System.Data.DataSet ReadCustomerExcel(string fileName, string fileExt)
        {
            
            string conn = string.Empty;
            System.Data.DataTable dtCustomerExcel = new System.Data.DataTable();
            DataSet ds = new DataSet();
            
        

            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=YES';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [CustomerHistory$]", con); //here we read data from Customer  
                    oleAdpt.Fill(dtCustomerExcel); //fill excel data into dataTable
                    ds.Tables.Add(dtCustomerExcel);

                    dtCustomerExcel = new System.Data.DataTable();
                    oleAdpt = new OleDbDataAdapter("select * from [ItemsDetails$]", con); //here we read data from Items  
                    oleAdpt.Fill(dtCustomerExcel); //fill excel data into dataTable 
                    ds.Tables.Add(dtCustomerExcel);
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);

                }
            }
            return ds;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ItemsBulkInsert();
                System.Data.DataTable dtCustomer = new System.Data.DataTable();
                dtCustomer.Columns.Add("FirstName");
                dtCustomer.Columns.Add("LastName");
                dtCustomer.Columns.Add("Address");
                dtCustomer.Columns.Add("City");
                dtCustomer.Columns.Add("State");
                dtCustomer.Columns.Add("PhoneNumber");
                dtCustomer.Columns.Add("DOB");
                dtCustomer.Columns.Add("IsMembership");

                System.Data.DataTable dtItems = new System.Data.DataTable();
                dtItems.Columns.Add("UserId");
                dtItems.Columns.Add("ItemId");
                dtItems.Columns.Add("DateOfPurchase");
                dtItems.Columns.Add("NoOfItems");

                DataRow drCustomer;
                DataRow drItem;
                int CustId = 0;
                int CustExistCount = 0;
                for (int i = 0; i < dtCustomerExcel.Rows.Count; i++)
                {


                    drCustomer = dtCustomer.NewRow();
                    drCustomer["FirstName"] = dtCustomerExcel.Rows[i]["FirstName"];
                    drCustomer["LastName"] = dtCustomerExcel.Rows[i]["LastName"];
                    drCustomer["Address"] = dtCustomerExcel.Rows[i]["Address"];
                    drCustomer["City"] = dtCustomerExcel.Rows[i]["City"];
                    drCustomer["State"] = dtCustomerExcel.Rows[i]["State"];
                    drCustomer["PhoneNumber"] = dtCustomerExcel.Rows[i]["PhoneNumber"];
                    drCustomer["DOB"] = dtCustomerExcel.Rows[i]["DOB"];
                    drCustomer["IsMembership"] = dtCustomerExcel.Rows[i]["IsMembership"];


                    CustExistCount = SearchCustomer(dtCustomerExcel.Rows[i]["FirstName"].ToString(), dtCustomerExcel.Rows[i]["LastName"].ToString(), dtCustomerExcel.Rows[i]["PhoneNumber"].ToString());


                    if (CustExistCount == 0)
                    {
                        CustId = InsertIntoCustomer(drCustomer);
                    }

                    System.Data.DataTable dtItem = new System.Data.DataTable();
                    dtItem = RetrieveItemDetails(dtCustomerExcel.Rows[i]["ItemName"].ToString());

                    int ItemId =  Convert.ToInt32( dtItem.Rows[0]["id"].ToString());
                    Decimal ItemPrice = Convert.ToDecimal( dtItem.Rows[0]["Price"].ToString());
                    dtCustomer.Rows.Add(drCustomer);


                    drItem = dtItems.NewRow();
                    drItem["UserId"] = CustId;
                    drItem["ItemId"] = ItemId;
                    drItem["DateOfPurchase"] = dtCustomerExcel.Rows[i]["DateOfPurchase"];
                    drItem["NoOfItems"] = dtCustomerExcel.Rows[i]["NoOfItems"];
                    drItem["NetAmount"] = ItemPrice * Convert.ToDecimal( dtCustomerExcel.Rows[i]["NetAmount"]);
                    InsertIntoCustomerItems(drItem);

                    dtItems.Rows.Add(drItem);

                }

                MessageBox.Show("Imported Successfuly");

                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int InsertIntoCustomer(DataRow dr)
        {
            SqlConnection cn = new SqlConnection(cnstring);
            cn.Open();
            string cmdstr = "insert into UserDetails(FirstName,LastName,Address,City,State,PhoneNumber,DOB,IsMembership)" +
                   " output INSERTED.ID " +
                "Values('" + dr["FirstName"] + "','" + dr["LastName"] + "','" + dr["Address"] + "','" + dr["City"] + "','" + dr["State"] + "','" + dr["PhoneNumber"] + "','" + dr["DOB"] + "','" + dr["IsMembership"] + "')";
            SqlCommand cmd = new SqlCommand(cmdstr, cn);
            int modified = (int)cmd.ExecuteScalar();
            //cmd.ExecuteNonQuery();
            cn.Close();
            return modified;
        }
        private void  InsertIntoCustomerItems(DataRow dr)
        {
            SqlConnection cn = new SqlConnection(cnstring);
            cn.Open();
            string cmdstr = "insert into UserItems(UserId,ItemId,DateOfPurchase,NoOfItems)" +
               
                "Values(" + dr["UserId"] + "," + dr["ItemId"] + ",'" + dr["DateOfPurchase"] + "'," + dr["NoOfItems"] + ")";

            SqlCommand cmd = new SqlCommand(cmdstr, cn);
            int modified = (int)cmd.ExecuteNonQuery();
            cn.Close();
            // cmd.ExecuteNonQuery();
            
        }

        private System.Data.DataTable RetrieveItemDetails(string Name)
        {
            SqlConnection cn = new SqlConnection(cnstring);
            cn.Open();
            string cmdstr = "select id,Price from Items where Name= '"+Name+"'";

            SqlCommand cmd = new SqlCommand(cmdstr, cn);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            System.Data.DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);

           // int modified = (int)cmd.ExecuteScalar();
            //cmd.ExecuteNonQuery();
            cn.Close();
            return dt;
        }
        private int SearchCustomer(string FName,string LName,string Mobile)
        {
            SqlConnection cn = new SqlConnection(cnstring);
            cn.Open();
            string cmdstr = "select count(*) from UserDetails where FirstName= '" + FName + "' and LastName= '" + LName + "' and PhoneNumber= '" + Mobile + "' ";

            SqlCommand cmd = new SqlCommand(cmdstr, cn);
            int modified = (int)cmd.ExecuteScalar();
            //cmd.ExecuteNonQuery();
            cn.Close();
            return modified;
        }

        private void ItemsBulkInsert()
        {
            SqlConnection cn = new SqlConnection(cnstring);
            cn.Open();
            SqlBulkCopy sqlbc = new SqlBulkCopy(cnstring);
            sqlbc.DestinationTableName = "Items";
            sqlbc.ColumnMappings.Add("Name", "Name");
            sqlbc.ColumnMappings.Add("Price", "Price");
          
            sqlbc.WriteToServer(dtItemExcel);
            cn.Close();
        }
    }
}
