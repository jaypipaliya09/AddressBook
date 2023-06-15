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

public partial class AdminPanel_City_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region Edit Mode
            if (Request.QueryString["CountryID"] != null)
            {
                lblHeading.Text = "<h2>Edit Mode</h2>";
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
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
        //Validate the Data
        String strErrorMessage = "";

        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Country Name <br/>";
        }


        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        CountryENT entCountry = new CountryENT();
        //Save the Country Data
        if (txtCountryName.Text.Trim() != "")
        {
            entCountry.CountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            entCountry.CountryCode = txtCountryCode.Text.Trim();
        }

        #endregion Gather Information

        CountryBAL balCountry = new CountryBAL();
        if(Request.QueryString["CountryID"]==null)
        {
            if (balCountry.Insert(entCountry))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);

            if (balCountry.Update(entCountry))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
        }

    }
    #endregion Button : Save

    #region Clear Controls
    private void ClearControls()
    {
        txtCountryName.Text = "";
        txtCountryCode.Text = "";
        txtCountryName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();

        entCountry = balCountry.SelectByPK(CountryID);

        if (!entCountry.CountryName.IsNull)
        {
            txtCountryName.Text = entCountry.CountryName.Value.ToString();
        }
        if (!entCountry.CountryCode.IsNull)
        {
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();
        }
    }
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/AdminPanel/Country/CountryList.aspx", true);
    }
    #endregion Button : Cancel
}