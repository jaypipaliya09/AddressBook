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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region Edit Mode
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                lblHeading.Text = "<h2>Edit Mode</h2>";
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
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

        if (txtContactCategoryName.Text.Trim() == "")
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
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        //Save the Country Data
        if (txtContactCategoryName.Text.Trim() != "")
        {
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim();
        }
        #endregion Gather Information

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        if(Request.QueryString["ContactCategoryID"]==null)
        {
            if (balContactCategory.Insert(entContactCategory))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
        }
        else
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);

            if (balContactCategory.Update(entContactCategory))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
        }
    }
    #endregion Button : Save

    #region Clear Controls
    private void ClearControls()
    {
        txtContactCategoryName.Text = "";
        txtContactCategoryName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID);

        if (!entContactCategory.ContactCategoryName.IsNull)
        {
            txtContactCategoryName.Text = entContactCategory.ContactCategoryName.Value.ToString();
        }
    }
    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion Button : Cancel
}