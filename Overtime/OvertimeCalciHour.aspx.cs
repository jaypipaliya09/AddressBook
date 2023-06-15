using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Overtime_OvertimeCalciHour : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SelectDurationMode();
            
        }

    }
    #endregion Load Event

    #region Button : Calculate

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        OvertimePay();
       
    }

    #endregion Button : Calculate

    #region Clear Controls
    protected void ClearControls()
    {
        ddlCurrency.SelectedIndex = -1;
        txtRegularPay.Text = "";
        txtRegularWorktime.Text = "";
        txtTotalWorktime.Text = "";
        txtMultiplier.Text = "";
    }
    #endregion Clear Controls

    #region OvertimePay
    protected void OvertimePay()
    {
        #region Local Variable
        Double overtimeHours = 0;
        Double regularPay = 0;
        Double overtimePay = 0;
        String strUnit = "";
        String strPayUnit = "";
        Double totalPay = 0;
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlCurrency.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Currency <br/>";
        }

        if (txtRegularWorktime.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Regular Work Time <br/>";
        }
        if (txtTotalWorktime.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Total Work Time <br/>";
        }
        if (txtRegularPay.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Regular Pay <br/>";
        }
        if (txtMultiplier.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Multiplier for overtime <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Calculation
        if (Convert.ToDouble(txtRegularWorktime.Text.Trim()) > 0 && Convert.ToDouble(txtRegularPay.Text.Trim()) > 0 && Convert.ToDouble(txtTotalWorktime.Text.Trim()) > 0 && Convert.ToDouble(txtMultiplier.Text.Trim()) > 0)
        {
            if (Convert.ToDouble(txtTotalWorktime.Text.Trim()) >= Convert.ToDouble(txtRegularWorktime.Text.Trim()))
            {
                overtimeHours = Convert.ToDouble(txtTotalWorktime.Text.Trim()) - Convert.ToDouble(txtRegularWorktime.Text.Trim());
            }

            if (ddlCalculationType.SelectedValue.ToString().Trim() == "hour")
            {
                strUnit = "hours";
                strPayUnit = "day";
            }
            if (ddlCalculationType.SelectedValue.ToString().Trim() == "week")
            {
                strUnit = "weeks";
                strPayUnit = "month";
            }
            if (ddlCalculationType.SelectedValue.ToString().Trim() == "day")
            {
                strUnit = "days";
                strPayUnit = "week";
            }
            divAnswer.Visible = true;
            lblMessage.Visible = false;
            regularPay = Convert.ToDouble(txtRegularWorktime.Text.Trim()) * Convert.ToDouble(txtRegularPay.Text.Trim());
            lblRegularPay.Text = "Regular Pay: " + regularPay.ToString().Trim() + " " + ddlCurrency.SelectedValue.ToString().Trim()+"/"+strPayUnit;

            lblOvertimeHours.Text = "Overtime " + char.ToUpperInvariant(strUnit[0]).ToString().Trim()+strUnit.Substring(1)+": " + overtimeHours.ToString().Trim() +" "+strUnit;
            lblRegularHours.Text = "Regular " + char.ToUpperInvariant(strUnit[0]).ToString().Trim()+strUnit.Substring(1)+ ":  " + txtRegularWorktime.Text.Trim() +" "+strUnit;
            
            overtimePay = Convert.ToDouble(overtimeHours) * Convert.ToDouble(txtMultiplier.Text.Trim()) * Convert.ToDouble(txtRegularPay.Text.Trim());
            lblOvertimePay.Text = "Overtime Pay: " + overtimePay.ToString().Trim() + " " + ddlCurrency.SelectedValue.ToString().Trim()+"/"+strPayUnit;
            totalPay = overtimePay + regularPay;
            lblTotalPay.Text = "Total Pay: " + totalPay + " " + ddlCurrency.SelectedValue.ToString().Trim() + "/" + strPayUnit;
            DisplayCalculation(strUnit, overtimeHours, overtimePay, regularPay, strPayUnit, totalPay);
            divMathCalculation.Visible = true;
            ClearControls();
        }
        else
        {
            lblMessage.Visible = true;
            divAnswer.Visible = false;
            lblMessage.Text = "<br/>Please Enter a Valid Number";
        }
        #endregion Calculation
    }
    #endregion OvertimePay

    #region Select Duration Mode
    protected void SelectDurationMode()
    {
        String strUnit = "";
        if (ddlCalculationType.SelectedValue.ToString().Trim() == "hour")
        {
            strUnit = "hours";
        }
        if (ddlCalculationType.SelectedValue.ToString().Trim() == "week")
        {
            strUnit = "weeks";
        }
        if (ddlCalculationType.SelectedValue.ToString().Trim() == "day")
        {
            strUnit = "days";
        }
        lblRegularWorktime.Text = "Regular WorkTime in "+strUnit+": ";
        lblTotalWorktime.Text = "Total WorkTime in "+strUnit+": ";
        lblRegularPayPer.Text = "Regular Pay Per "+strUnit+": ";
        rfvRegularPay.Text = "Enter a Pay Per "+strUnit+": ";
        lblRegularWorktimeType.Text = strUnit;
        lblTotalWorktimeType.Text = strUnit;
    }
    #endregion Select Duaration Mode

    #region Clear Answer
    protected void ClearAnswer()
    {
        lblRegularPay.Text = "";
        lblOvertimePay.Text = "";
        lblTotalPay.Text = "";
        lblRegularHours.Text = "";
        lblOvertimeHours.Text = "";
        lblMessage.Text = "";
    }
    #endregion Clear Answer

    #region ddlCalculationType_SelectedIndexChanged
    protected void ddlCalculationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectDurationMode();
        ClearAnswer();
    }
    #endregion ddlCalculationType_SelectedIndexChanged

    #region Display Calculation

    private void DisplayCalculation(String strUnit, Double overtimeHours, Double overtimePay, Double regularPay, String strPayUnit, Double totalPay)
    {
        miCalTotalWorktime.InnerHtml = txtTotalWorktime.Text.Trim();
        miCalRegularWorktime.InnerHtml = txtRegularWorktime.Text.Trim();
        miCalOvertime.InnerHtml = overtimeHours.ToString().Trim()+" "+char.ToUpperInvariant(strUnit[0]).ToString().Trim()+strUnit.Substring(1);
        milblMode.InnerHtml = char.ToUpperInvariant(strPayUnit[0]).ToString().Trim() + strPayUnit.Substring(1);
        miCalOvertimeMultiplier.InnerHtml = txtMultiplier.Text.Trim();
        miCalRegularPay.InnerHtml = regularPay.ToString().Trim();
        miCalOvertimePay.InnerHtml = overtimePay.ToString().Trim();
        milblCurrency.InnerHtml = ddlCurrency.SelectedValue.ToString().Trim();
        milblMode1.InnerHtml = strPayUnit;
        milblRegularPay.InnerHtml = regularPay.ToString().Trim();
        milblOvertimePay.InnerHtml = overtimePay.ToString().Trim();
        miCalTotal.InnerHtml = totalPay.ToString().Trim();
        milblCurrency1.InnerHtml = ddlCurrency.SelectedValue.ToString().Trim();
        milblMode2.InnerHtml = strPayUnit;
        milblMode3.InnerHtml = char.ToUpperInvariant(strUnit[0]).ToString().Trim() + strUnit.Substring(1);
        milblRegularPayModeWise.InnerHtml = txtRegularPay.Text.Trim();
        milblRegularWorktime.InnerHtml = txtRegularWorktime.Text.Trim();
        miCalRegularPay1.InnerHtml = regularPay.ToString().Trim();
        milblCurrency2.InnerHtml = ddlCurrency.SelectedValue.ToString().Trim();
        milblMode4.InnerHtml = strPayUnit;
    }
    #endregion Display Calculation
}