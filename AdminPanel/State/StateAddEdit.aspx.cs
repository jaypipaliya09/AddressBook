using AddressBook;
using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            #region Edit Mode
            if (Request.QueryString["StateID"] != null)
            {
                lblHeading.Text = "<h2>Edit Mode</h2>";
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            #endregion Edit Mode
            #region Add Mode
            else
            {
                lblHeading.Text = "<h2>Add Mode</h2>";
            }
            #endregion Add Mode

        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country <br/>";
        }

        if (txtStateName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter State Name <br/>";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        StateENT entState = new StateENT();
        //Gather the Information
        if (ddlCountryID.SelectedIndex > 0)
        {
            entState.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

        }

        if (txtStateName.Text.Trim() != "")
        {
            entState.StateName = txtStateName.Text.Trim();
        }
        if (txtStateCode.Text.Trim() != "")
        {
            entState.StateCode = txtStateCode.Text.Trim();
        }
        #endregion Gather Information

        StateBAL balState = new StateBAL();
        if(Request.QueryString["StateID"]==null)
        {
            if (balState.Insert(entState))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balState.Message;
            }
        }
        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);

            if (balState.Update(entState))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
            }
            else
            {
                lblMessage.Text = balState.Message;
            }
        }
    }
    #endregion Button : Save

    #region Clear Controls
    private void ClearControls()
    {
        ddlCountryID.SelectedIndex = 0;
        txtStateName.Text = "";
        txtStateCode.Text = "";
        ddlCountryID.Focus();
    }
    #endregion Clear Controls

    #region Fill DropDown List
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountryID);
    }
    #endregion Fill DropDown List

    #region Fill Controls
    private void FillControls(SqlInt32 StateID)
    {
        StateENT entState = new StateENT();
        StateBAL balState = new StateBAL();

        entState = balState.SelectByPK(StateID);
        if (!entState.StateID.IsNull)
        {
            ddlCountryID.SelectedValue = entState.CountryID.Value.ToString();
        }

        if (!entState.StateName.IsNull)
        {
            txtStateName.Text = entState.StateName.Value.ToString();
        }
        if (!entState.StateCode.IsNull)
        {
            txtStateCode.Text = entState.StateCode.Value.ToString();
        }
        
    }
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx", true);
    }
    #endregion Button : Cancel
}