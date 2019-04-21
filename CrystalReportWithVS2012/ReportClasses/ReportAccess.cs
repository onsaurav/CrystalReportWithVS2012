using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.Windows.Forms;

namespace CrystalReportWithVS2012
{
    public class ReportAccess
    {
        static public Boolean ShowReport(CrystalDecisions.CrystalReports.Engine.ReportClass ReportName, string SelectionFormula)
        {
            try
            {
                frmReport ofrmReport = new frmReport();
                ofrmReport.crvReportViewer.ReportSource = ReportName;
                ReportName.RecordSelectionFormula = SelectionFormula;
                ofrmReport.Show();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Report .....", MessageBoxButtons.OK);
                return false;
            }
        }
    }
}
