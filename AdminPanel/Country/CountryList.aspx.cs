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

public partial class AdminPanel_City_CountryList : System.Web.UI.Page
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
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectAll();

        if (dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
        }
    }
    #endregion Fill Grid View

    #region gvCountry : RowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // Which command is clicked | e.CommandName
        // Which Row is clicked | Get the ID of that Row | e.CommandArgument
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                CountryBAL balCountry = new CountryBAL();
                if(balCountry.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balCountry.Message;
                }
            }
        }


    }
    #endregion gvCountry : RowCommand

    
}
