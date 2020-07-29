using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace TwinkleBookStore
{
    public partial class FrmMaster : Form
    {
        public FrmMaster()
        {
            InitializeComponent();
        }

      
        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmRegister_Click(object sender, EventArgs e)
        {
            FrmLoginRegistration obj = new FrmLoginRegistration();
                obj.Show();
        }

        private void tsmRoles_Click(object sender, EventArgs e)
        {
            FrmRoles objRole = new FrmRoles();
            objRole.Show();
        }

        private void tsmUserRoles_Click(object sender, EventArgs e)
        {
            FrmUserRoles objUserRole = new FrmUserRoles();
            objUserRole.Show();
        }

        private void tsmItems_Click(object sender, EventArgs e)
        {
            FrmItem objItem = new FrmItem();
            objItem.Show();
        }

        private void tsmUserItems_Click(object sender, EventArgs e)
        {
            FrmCustomerItem objUserItem = new FrmCustomerItem();
            objUserItem.Show();
        }

        private void tsmImport_Click(object sender, EventArgs e)
        {
            FrmUploadCustomer objImport = new FrmUploadCustomer();
            objImport.Show();
        }

        private void tsmCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomer objCustomer = new FrmCustomer();
            objCustomer.Show();
        }

        private void tsmCustomerSearch_Click(object sender, EventArgs e)
        {
            FrmCustomerSearch objCustSearch = new FrmCustomerSearch();
            objCustSearch.Show();
        }

        public void ExportToPDF(DataGridView dataGridView1, bool ExtraRow=false)
        {
          
                if (dataGridView1.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = ConfigurationSettings.AppSettings["PDF"].ToString();
                    bool fileError = false;
                    PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                    pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable.AddCell(cell);
                    }

                int GridRowCount = dataGridView1.Rows.Count;
                int rowIterator=0;

                if (ExtraRow == false)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        rowIterator++;
                        //if(GridRowCount>rowIterator)
                        //{ 

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value==null)
                            {
                                pdfTable.AddCell("");
                            }
                            else
                            {
                                pdfTable.AddCell(cell.Value.ToString());
                            }
                           
                        }
                        // }
                    }
                }
                else {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        rowIterator++;
                        if (GridRowCount > rowIterator)
                        {

                            foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                        }
                    }

                }

                    using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                    
                    
                }

                    MessageBox.Show("PDF has saved in "+ sfd.FileName + " path", "Info");

                //Process myProcess = new Process();
                //myProcess.StartInfo.FileName = "AcroRd32Info.exe";
                //myProcess.StartInfo.Arguments = "/A \"page=2\" \"D:\\Output.pdf\"";
                //myProcess.Start();
            }
           
        }

        private void tsmQualifiedCustomers_Click(object sender, EventArgs e)
        {
            FrmRptQualifiedCust objrpt = new FrmRptQualifiedCust();
            objrpt.Show();
        }

        private void tsmBirthday_Click(object sender, EventArgs e)
        {
            FrmRptCustomerBirthDay Bday = new FrmRptCustomerBirthDay();
            Bday.Show();
        }

        private void tsmAnnualBillig_Click(object sender, EventArgs e)
        {
            FrmRptCustomerAnnualBill Bill = new FrmRptCustomerAnnualBill();
            Bill.Show();
        }

        private void tsmLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin objLogin = new FrmLogin();
            objLogin.Show();
        }
    }
    }

