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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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

    #region Fill Gried View
    private void FillGridView()
    {
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();

        dtState = balState.SelectAll();

        if(dtState!=null &&dtState.Rows.Count>0)
        {
            gvState.DataSource = dtState;
            gvState.DataBind();
        }

    }
    #endregion Fill Gried View

    #region gvState : RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        // Which command is clicked | e.CommandName
        // Which Row is clicked | Get the ID of that Row | e.CommandArgument
        if (e.CommandName == "DeleteRecord")
        {

            if (e.CommandArgument.ToString() != "")
            {
                StateBAL balState = new StateBAL();
                if (balState.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                }
                else
                {
                    lblMessage.Text = balState.Message;
                }
            }
        }


    }
    #endregion gvState : RowCommand

    
}