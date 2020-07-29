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
using Microsoft.Reporting.WinForms;
namespace TwinkleBookStore
{
    public partial class FrmRptQualifiedCust : Form
    {

        //IUnityContainer objcontainer = new UnityContainer();
        // BLLogin objBLLogin;
        dynamic objBLLogin;
        dynamic objBLUserItem;

       

     
        public FrmRptQualifiedCust()
        {
            InitializeComponent();
            Program.Bootstrap();
        
            objBLLogin = Program.container.Resolve<BLLogin>();
            objBLUserItem= Program.container.Resolve<BLUserItem>();



        }
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            Reset();
            DataTable dt = new DataTable();
                dt=LoadQualifiedCust();
            dataGridView1.DataSource = dt;

            //ReportDataSource datasource = new ReportDataSource("Qualified", dt);
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.RefreshReport();

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

      
        private DataTable LoadQualifiedCust()
        {
            List<ModelBookStore.UserDetail> objUserDetailList = LoadCustomAllData();
            DataTable dtCustomer = new DataTable();
            dtCustomer.Columns.Add("FirstName");
            dtCustomer.Columns.Add("LastName");
            dtCustomer.Columns.Add("PhoneNumber");
            dtCustomer.Columns.Add("EmailId");
            dtCustomer.Columns.Add("DOB");
            dtCustomer.Columns.Add("Address");
            dtCustomer.Columns.Add("City");
            dtCustomer.Columns.Add("State");



            foreach (var Cust in objUserDetailList)
            {
                bool exists = objBLUserItem.Eligible20Discount(Cust.id);
                if (exists)
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

            }
            foreach (DataRow row in dtCustomer.Rows)
            {
                bool IsEmpty = false;
                foreach (object obj in row.ItemArray)
                {
                    if (String.IsNullOrEmpty(obj.ToString()))
                    {
                        IsEmpty = true;
                    }
                    else
                    {
                        IsEmpty = false;
                    }
                }
                if (IsEmpty)
                {
                    dtCustomer.Rows.Remove(row);
                }
            }
            return dtCustomer;
           
          
        }
        private List<ModelBookStore.UserDetail> LoadCustomAllData()
        {
            List<ModelBookStore.UserDetail> objUserDetailList = objBLLogin.Load();

            return objUserDetailList;
        }
    }
}