using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace WindowsFormsApplication3
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();           
            cryRpt.Load(@"C:\Users\HOME\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\CrystalReport3.rpt");
            cryRpt.SetDatabaseLogon("root", "");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
            
        }
    }
}
