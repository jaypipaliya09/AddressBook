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
        
        if (ddlFindAverage.SelectedItem.ToString().Trim() == "Yes")
        {

            divEmployeeBegin.Visible = true;
            divEmployeeEnd.Visible = true;
            divAverageNumber.Visible = false;
        }
        else
        {
            divAverageNumber.Visible = true;
            divEmployeeBegin.Visible = false;
            divEmployeeEnd.Visible = false;
        }
        
    }
    #endregion Select Duaration Mode

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
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";
  
        if(ddlFindAverage.SelectedItem.ToString().Trim()=="No")
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
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Calculation

        if(ddlFindAverage.SelectedItem.ToString().Trim() == "Yes")
        {
            AverageNumber = (Convert.ToInt32(txtEmployeeBegin.Text.Trim()) + Convert.ToInt32(txtEmployeeEnd.Text.Trim())) / 2;
        }

        else
        {
            AverageNumber = float.Parse(txtAverageNumber.Text.Trim());
        }

        lblTurnOverRate.Text = "TurnOver Rate : " + Convert.ToString((Convert.ToInt32(txtEmployeeLeft.Text.Trim()) / AverageNumber) * 100) + "%";
        ClearControls();
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
    }
    #endregion ddlFindAverage_SelectedIndexChanged
}