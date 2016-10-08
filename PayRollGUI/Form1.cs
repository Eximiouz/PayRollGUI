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
            int HrsWork, OverTimehrs, NumAbs, LoanYrs;
            char LoanCode;
            int errcode = 0;
            /*ERROR CODES
             * 1 = Invalid Input
             * 2 = Invalid Loan Combo
             * 3 = Hrs Works Less Than 40
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

                Loan = LoanCheck(LoanCode, LoanYrs);
                
                if (Loan > 0)
                {
                    if (HrsWork >= 40)
                    {
                        BasicPay = HrsWork * DailyRate;
                        OverTimehrs = HrsWork - 40;
                        OvertimePay = OverTimehrs * DailyRate;
                        GrossPay = BasicPay + OvertimePay;
                        Tax = GrossPay * 0.08;
                        AbsDed = NumAbs * DailyRate;
                        TotalDed = SSS + Pagibig + PhilHealth + Loan + Tax + AbsDed;
                        NetPay = GrossPay - TotalDed;

                        txtBasicPay.Text = BasicPay.ToString();
                        txtOverTimePay.Text = OvertimePay.ToString();
                        txtGrossPay.Text = GrossPay.ToString();
                        txtLoan.Text = Loan.ToString();
                        txtTax.Text = Tax.ToString();
                        txtAbsDed.Text = AbsDed.ToString();
                        txtTotalDed.Text = TotalDed.ToString();
                        txtNetPay.Text = NetPay.ToString();

                    }
                    else
                    {
                        errcode = 3;
                    }
                }
                else
                {
                    errcode = 2;
                }

            }
            else
            {
                errcode = 1;
            }

            if (errcode == 1)
            {
                MessageBox.Show("Invalid Inputs.");
            }
            else if (errcode == 1)
            {
                MessageBox.Show("Invalid Loan Combination.");
            }
            if (errcode == 3)
            {
                MessageBox.Show("Hours Worked must be equal or more than 40");
            }

        }

        int LoanCheck(char LoanCode, int LoanYrs)
        {
            if (LoanCode == 'C' && LoanYrs == 5)
            {
                return 10000;
            }
            else if (LoanCode == 'P' && LoanYrs == 10)
            {
                return 20000;
            }
            else if (LoanCode == 'R' && LoanYrs == 20)
            {
                return 40000;
            }
            else
            {
                return 0;
            }
        }

        void clear(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    clear(c);
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            Compute();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear(this);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
