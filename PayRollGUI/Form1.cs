using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayRollGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Compute()
        {
            string EmpName, EmpCode;
            double DailyRate, BasicPay, OvertimePay, SSS, Pagibig, PhilHealth, Loan, Tax, AbsDed, GrossPay, TotalDed, NetPay;
            int HrsWork, NumAbs, LoanYrs;
            char LoanCode;
            int errcode = 0;
            /*ERROR CODES
             * 1 = Invalid Input
             */

            if(double.TryParse(txtDailyRate.Text, out DailyRate) && 
               int.TryParse(txtHrsWork.Text, out HrsWork) &&
               int.TryParse(txtNumAbs.Text, out NumAbs) &&
               char.TryParse(cmbLoanCode.Text, out LoanCode) &&
               int.TryParse(cmbLoanYrs.Text, out LoanYrs) &&
               double.TryParse(txtSSS.Text, out SSS) &&
               double.TryParse(txtPagibig.Text, out Pagibig) &&
               double.TryParse(txtPhilHealth.Text, out PhilHealth) &&
               txtEmpName.Text.Length > 0 &&
               txtEmpCode.Text.Length > 0)
            {
                EmpName = txtEmpName.Text;
                EmpCode = txtEmpCode.Text;
                DailyRate = double.Parse(txtDailyRate.Text);
                HrsWork = int.Parse(txtHrsWork.Text);
                NumAbs= int.Parse(txtNumAbs.Text);
                LoanCode = char.Parse(cmbLoanCode.Text);
                LoanYrs = int.Parse(cmbLoanYrs.Text);
                SSS = double.Parse(txtSSS.Text);
                Pagibig = double.Parse(txtPagibig.Text);
                PhilHealth = double.Parse(txtPhilHealth.Text);
            }
            else
            {
                errcode = 1;
            }

        }
    }
}
