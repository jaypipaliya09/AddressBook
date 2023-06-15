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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
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
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();


        dtCity = balCity.SelectAll();

        if (dtCity != null && dtCity.Rows.Count > 0)
        {
            gvCity.DataSource = dtCity;
            gvCity.DataBind();
        }
    }
    #endregion Fill Grid View Function

    #region gvCity : RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // Which command is clicked | e.CommandName
        // Which Row is clicked | Get the ID of that Row | e.CommandArgument
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                CityBAL balCity = new CityBAL();
                if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balCity.Message;
                }
            }
        }


    }
    #endregion gvCity : RowCommand
}