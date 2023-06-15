using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TurnoverRate_TurnoverRate : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            SelectMode();
            
        }
    }
    #endregion Load Event

    #region Clear Controls
    protected void ClearControls()
    {
        txtAverageNumber.Text = "";
        txtEmployeeBegin.Text = "";
        txtEmployeeEnd.Text = "";
        txtEmployeeLeft.Text = "";
    }
    #endregion Clear Controls

    #region Select Mode
    protected void SelectMode()
    {
        
        if (ddlFindAverage.SelectedValue.ToString().Trim() == "yes")
        {
            divEmployeeBegin.Visible = true;
            divEmployeeEnd.Visible = true;
            divAverageNumber.Visible = false;
            divMethod1.Visible = true;
            divMethod2.Visible = false;
        }
        else
        {
            divAverageNumber.Visible = true;
            divEmployeeBegin.Visible = false;
            divEmployeeEnd.Visible = false;
            divMethod1.Visible = false;
            divMethod2.Visible = true;
        }
        
    }
    #endregion Select Mode

    #region Button : Calculate
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        TurnoverRate();
    }
    #endregion Button : Calculate

    #region Turnover Rate
    
    protected void TurnoverRate()
    {
        #region Local Variable
        float AverageNumber=0;
        float TurnoverRatio = 0;
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";
  
        if(ddlFindAverage.SelectedValue.ToString().Trim()=="no")
        {
            if (txtAverageNumber.Text.Trim() == "")
            {
                strErrorMessage += "- Enter Average Number of Employee <br/>";
            }
        }
        else
        {
            if (txtEmployeeBegin.Text.Trim() == "")
            {
                strErrorMessage += "- Enter Number of Employee at the begining <br/>";
            }

            if (txtEmployeeEnd.Text.Trim() == "")
            {
                strErrorMessage += "- Enter Number of Employee at the ending <br/>";
            }
            
        }
        if (txtEmployeeLeft.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Number of Employee who left  <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Kindly solve following Error(s)" +  strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Calculation

        if(ddlFindAverage.SelectedValue.ToString().Trim() == "yes")
        {
            AverageNumber = (float.Parse(txtEmployeeBegin.Text.Trim()) + float.Parse(txtEmployeeEnd.Text.Trim())) / 2;
        }

        else
        {
            AverageNumber = float.Parse(txtAverageNumber.Text.Trim());
        }
        TurnoverRatio = (float.Parse(txtEmployeeLeft.Text.Trim()) / AverageNumber) * 100;
        divMathCalculation.Visible = true;
        DisplayCalculation(AverageNumber, TurnoverRatio);
        ClearControls();
        lblTurnOverRate.Text = "TurnOver Rate : " + TurnoverRatio.ToString("0.00").Trim() + "%";
        #endregion Calculation
    }

    #endregion Turnover Rate

    #region Clear Answer
    protected void ClearAnswer()
    {
        lblTurnOverRate.Text = "";
        lblMessage.Text = "";
    }
    #endregion Clear Answer

    #region ddlFindAverage_SelectedIndexChanged
    protected void ddlFindAverage_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectMode();
        ClearAnswer();
        divMathCalculation.Visible = false;
    }
    #endregion ddlFindAverage_SelectedIndexChanged

    #region Display Calculation
    protected void DisplayCalculation(float AverageNumber, float TurnoverRatio)
    {
        miCalEmployeebegin.InnerHtml = txtEmployeeBegin.Text.Trim();
        miCalEmployeeend.InnerHtml = txtEmployeeEnd.Text.Trim();
        miCalEmployeeLeft.InnerHtml = txtEmployeeLeft.Text.Trim();
        miCalEmployeeLeftMethod2.InnerHtml = txtEmployeeLeft.Text.Trim();
        miCalAverage.InnerHtml = AverageNumber.ToString("0.00").Trim();
        miDisAverage.InnerHtml = AverageNumber.ToString("0.00").Trim();
        miDisAverageMethod2.InnerHtml = AverageNumber.ToString("0.00").Trim();
        miCalTurnoverRatio.InnerHtml = TurnoverRatio.ToString("0.00").Trim();
        miCalTurnoverRatioMethod2.InnerHtml = TurnoverRatio.ToString("0.00").Trim();
    }

    #endregion Display Calculation
}