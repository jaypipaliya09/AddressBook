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

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
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
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dtContactCategory = new DataTable();

        dtContactCategory = balContactCategory.SelectAll();

        if (dtContactCategory != null && dtContactCategory.Rows.Count > 0)
        {
            gvContactCategory.DataSource = dtContactCategory;
            gvContactCategory.DataBind();
        }
    }
    #endregion Fill Grid View

    #region gvContactCategory : RowCommand
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // Which command is clicked | e.CommandName
        // Which Row is clicked | Get the ID of that Row | e.CommandArgument
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

                if(balContactCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balContactCategory.Message;
                }
            }
        }


    }
    #endregion gvContactCategory : RowCommand

    
}
