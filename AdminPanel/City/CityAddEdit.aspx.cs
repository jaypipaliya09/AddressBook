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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            #region Edit Mode
            if (Request.QueryString["CityID"] != null)
            {
                lblHeading.Text = "<h2>Edit Mode</h2>";
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
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

        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country <br/>";
        }

        if (txtCityName.Text.Trim() == "")
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
        CityENT entCity = new CityENT();

        //Gather the Information
        if (ddlStateID.SelectedIndex > 0)
        {
            entCity.StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }

        if (txtCityName.Text.Trim() != "")
        {
            entCity.CityName = txtCityName.Text.Trim();
        }

        if (txtSTDCode.Text.Trim() != "")
        {
            entCity.STDCode = txtSTDCode.Text.Trim();
        }
        if (txtPinCode.Text.Trim() != "")
        {
            entCity.PinCode = txtPinCode.Text.Trim();
        }
        #endregion Gather Information

        CityBAL balCity = new CityBAL();

        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balCity.Message;
            }
        }

        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
            
                if(balCity.Update(entCity))
                {
                    ClearControls();
                    Response.Redirect("~/AdminPanel/City/CityList.aspx");
                }
                else
                {
                    lblMessage.Text = balCity.Message;
                }
            
        }
        
    }
    #endregion Button : Save

    #region  Fill DropDown List
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListState(ddlStateID);
    }
    #endregion  Fill DropDown List

    #region Clear Controls
    private void ClearControls()
    {
        ddlStateID.SelectedIndex = 0;
        txtCityName.Text = "";
        txtSTDCode.Text = "";
        txtPinCode.Text = "";
        ddlStateID.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByPK(CityID);

        if (!entCity.StateID.IsNull)
        {
            ddlStateID.SelectedValue = entCity.StateID.Value.ToString();
        }

        if(!entCity.CityName.IsNull)
        {
            txtCityName.Text = entCity.CityName.Value.ToString();
        }
        if (!entCity.STDCode.IsNull)
        {
            txtSTDCode.Text = entCity.STDCode.Value.ToString();
        }
        if (!entCity.PinCode.IsNull)
        {
            txtPinCode.Text = entCity.PinCode.Value.ToString();
        }
    }
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Button : Cancel
}