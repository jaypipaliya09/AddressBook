using AddressBook.BAL;
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

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Event

    #region Fill Grid View
    private void FillGridView()
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dtContact = new DataTable();

        dtContact = balContact.SelectAll();

        gvContact.DataSource = dtContact;
        gvContact.DataBind();
    }
    #endregion Fill Grid View

    #region gvContact : RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // Which command is clicked | e.CommandName
        // Which Row is clicked | Get the ID of that Row | e.CommandArgument
        if (e.CommandName == "DeleteRecord")
        {

            ContactBAL balContact = new ContactBAL();
            ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
            #region Delete ContactCategory
            if (balContactWiseContactCategory.DeleteByContactID(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
            {
                FillGridView();
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
            #endregion Delete ContactCategory

            #region Delete Contact
            if (balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
            {
                FillGridView();
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
            #endregion Delete Contact
        }


    }
    #endregion gvContact : RowCommand

}