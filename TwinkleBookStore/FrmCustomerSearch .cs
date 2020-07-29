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
    public partial class FrmCustomerSearch : Form
    {

        //IUnityContainer objcontainer = new UnityContainer();
        // BLLogin objBLLogin;
        dynamic objBLLogin;

      
       

        int SelectedId = 0;
        public FrmCustomerSearch()
        {
            InitializeComponent();
            Program.Bootstrap();
        
            objBLLogin = Program.container.Resolve<BLLogin>();
           

        }
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            Reset();
           // dataGridView1.ReadOnly = true;
            //dataGridView1.Columns["id"].Visible = false;
            //dataGridView1.Columns["UserId"].Visible = false;
            //dataGridView1.Columns["Login"].Visible = false;



        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {



                List<ModelBookStore.UserDetail> objUserDetailList = LoadData(txtFirstName.Text,txtPhoneNo.Text);
                dataGridView1.DataSource = objUserDetailList;

                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["UserId"].Visible = false;
                dataGridView1.Columns["Login"].Visible = false;


            }
            catch (Exception ex)
            {
               // throw new Exception(ex.Message);
                MessageBox.Show(ex.Message);
            }
            
        }

        private List<ModelBookStore.UserDetail> LoadData( string Name,string PhoneNo)
        {
            List<ModelBookStore.UserDetail> objCustomerList = objBLLogin.SearchCustomer();

            if (!string.IsNullOrEmpty(Name))
            {
                objCustomerList = (from objItems in objCustomerList
                                where objItems.FirstName.Contains(Name) || objItems.LastName.Contains(Name)
                                
                                select objItems
                     //select new Role { id = objItems.id, UserId = objItems.Name }
                     ).ToList();
            }
            if (!string.IsNullOrEmpty(PhoneNo))
            {
                objCustomerList = (from objItems in objCustomerList
                                   where objItems.PhoneNumber.Contains(PhoneNo) 

                                   select objItems
                     //select new Role { id = objItems.id, UserId = objItems.Name }
                     ).ToList();
            }
          

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
            txtFirstName.Text = "";
           
           
            txtPhoneNo.Text = "";

            dataGridView1.DataSource = null;
          
            txtFirstName.Focus();
           

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaster objMaster = new FrmMaster();
                objMaster.ExportToPDF(dataGridView1,false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}