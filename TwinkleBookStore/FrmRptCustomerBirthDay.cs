using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using InterfaceBookStore;
using BLBookStore;
using DLBookStore;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
namespace TwinkleBookStore
{
    public partial class FrmRptCustomerBirthDay : Form
    {

        //IUnityContainer objcontainer = new UnityContainer();
        // BLLogin objBLLogin;
        dynamic objBLLogin;
        dynamic objBLUserItem;

       

     
        public FrmRptCustomerBirthDay()
        {
            InitializeComponent();
            Program.Bootstrap();
        
            objBLLogin = Program.container.Resolve<BLLogin>();
            objBLUserItem= Program.container.Resolve<BLUserItem>();



        }
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCustBday.usp_UpCmgBdayCust' table. You can move, or remove it, as needed.
            this.usp_UpCmgBdayCustTableAdapter.Fill(this.dsCustBday.usp_UpCmgBdayCust);
            // Reset();
            //LoadBirthdayCust();

            dataGridView1.Visible = false;
            btnExport.Visible = false;
            this.reportViewer1.RefreshReport();
        }


       

        private List<ModelBookStore.UserDetail> LoadData( string Name,string PhoneNo)
        {
            List<ModelBookStore.UserDetail> objCustomerList = objBLLogin.SearchCustomer(Name,PhoneNo);

            return objCustomerList;
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
        private void Reset()
        {
          
           

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaster objMaster = new FrmMaster();
                objMaster.ExportToPDF(dataGridView1,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
        private void LoadBirthdayCust()
        {

         
            List<ModelBookStore.UserDetail> objUserDetailList = LoadBirthdayList();
            DataTable dtCustomer = new DataTable();
            dtCustomer.Columns.Add("FirstName");
            dtCustomer.Columns.Add("LastName");
          
            dtCustomer.Columns.Add("DOB");
            dtCustomer.Columns.Add("PhoneNumber");
            dtCustomer.Columns.Add("EmailId");
            dtCustomer.Columns.Add("Address");
            dtCustomer.Columns.Add("City");
            dtCustomer.Columns.Add("State");



            foreach (var Cust in objUserDetailList)
            {
               
                    DataRow drcustomer = dtCustomer.NewRow();
                    drcustomer["FirstName"] = Cust.FirstName;
                    drcustomer["LastName"] = Cust.LastName;
                    drcustomer["PhoneNumber"] = Cust.PhoneNumber;
                    drcustomer["EmailId"] = Cust.EmailId;
                    drcustomer["DOB"] = Cust.DOB;
                    drcustomer["Address"] = Cust.Address;
                    drcustomer["City"] = Cust.city;
                    drcustomer["State"] = Cust.state;
                    dtCustomer.Rows.Add(drcustomer);
              
            }
            dataGridView1.DataSource = dtCustomer;
           
        }
       
        private List<ModelBookStore.UserDetail> LoadBirthdayList()
        {
            List<ModelBookStore.UserDetail> objUserDetailList = objBLLogin.LoadCustBDay();

            return objUserDetailList;
        }
    }
}