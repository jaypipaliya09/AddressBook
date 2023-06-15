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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillDropDownList();
            CommonFillMethods.FillCBLContactCategoryID(cblContactCategoryID);
            #region Edit Mode
            if (Request.QueryString["ContactID"] != null)
            {
                lblHeading.Text = "<h2>Edit Mode</h2>";
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
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

        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select State <br/>";
        }

        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select City <br/>";
        }

        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Name <br/>";
        }

        if (txtContactNo.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Number <br/>";
        }

        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Email I'D <br/>";
        }

        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Your Address <br/>";
        }


        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        ContactENT entContact = new ContactENT();
        //Gather the Information
        if (ddlCountryID.SelectedIndex > 0)
        {
            entContact.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

        }
        if (ddlStateID.SelectedIndex > 0)
        {
            entContact.StateID = Convert.ToInt32(ddlStateID.SelectedValue);

        }
        if (ddlCityID.SelectedIndex > 0)
        {
            entContact.CityID = Convert.ToInt32(ddlCityID.SelectedValue);
        }

        if (txtContactName.Text.Trim() != "")
        {
            entContact.ContactName = txtContactName.Text.Trim();
        }

        if (txtContactNo.Text.Trim() != "")
        {
            entContact.ContactNo = txtContactNo.Text.Trim();
        }

        if (txtEmail.Text.Trim() != "")
        {
            entContact.Email = txtEmail.Text.Trim();
        }

        if (txtAddress.Text.Trim() != "")
        {
            entContact.Address = txtAddress.Text.Trim();
        }
        if (txtWhatsAppNo.Text.Trim() != "")
        {
            entContact.WhatsAppNo = txtWhatsAppNo.Text.Trim();
        }
        if (txtBirthDate.Text.Trim() != "")
        {
            entContact.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
        }
        if (txtAge.Text.Trim() != "")
        {
            entContact.Age = Convert.ToInt32(txtAge.Text.Trim());
        }

        if (txtBloodGroup.Text.Trim() != "")
        {
            entContact.BloodGroup = txtBloodGroup.Text.Trim();
        }

        if (txtFacebookID.Text.Trim() != "")
        {
            entContact.FacebookID = txtFacebookID.Text.Trim();
        }
        if (txtLinkedINID.Text.Trim() != "")
        {
            entContact.LinkedINID = txtLinkedINID.Text.Trim();
        }
        #endregion Gather Information


        ContactBAL balContact = new ContactBAL();

        #region Insert
        if(Request.QueryString["ContactID"]==null)
        {
            if (balContact.Insert(entContact))
            {
                #region Insert Contact Category
                foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
                {

                    if (liContactCategoryID.Selected)
                    {
                        ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();
                        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
                        entContactWiseContactCategory.ContactID = balContact.ContactID;
                        entContactWiseContactCategory.ContactCategoryID = SqlInt32.Parse(liContactCategoryID.Value.ToString());
                        balContactWiseContactCategory.Insert(entContactWiseContactCategory);

                    }
                }
                #endregion Insert Contact Category
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
            }

            else
            {
                lblMessage.Text = balContact.Message;
            }
        }

       
        #endregion Insert

        #region Update
        else
        {
            entContact.ContactID = SqlInt32.Parse(Request.QueryString["ContactID"].ToString().Trim());
            if (balContact.Update(entContact))
            {

                #region Update Contact Category
                ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();
                ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
                if (!balContactWiseContactCategory.DeleteByContactID(entContact.ContactID))
                {
                    lblMessage.Text = balContactWiseContactCategory.Message;
                }

                foreach (ListItem liContactCategoryID in cblContactCategoryID.Items)
                {
                    if (liContactCategoryID.Selected)
                    {

                        entContactWiseContactCategory.ContactID = entContact.ContactID;
                        entContactWiseContactCategory.ContactCategoryID = SqlInt32.Parse(liContactCategoryID.Value.ToString());
                        balContactWiseContactCategory.Insert(entContactWiseContactCategory);
                    }
                }
                #endregion Update Contact Category
                Response.Redirect("/AdminPanel/Contact/ContactList.aspx");

            }

            else
            {
                lblMessage.Text = balContact.Message;
            }
        }
        #endregion Update
    }
    #endregion Button : Save

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountryID);
        CommonFillMethods.FillDropDownListState(ddlStateID);
        CommonFillMethods.FillDropDownListCity(ddlCityID);
    }
    #endregion Fill DropDownList

    #region Clear Controls
    private void ClearControls()
    {
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        txtContactName.Text = "";
        txtContactNo.Text = "";
        cblContactCategoryID.ClearSelection();
        txtWhatsAppNo.Text = "";
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        txtBloodGroup.Text = "";
        txtFacebookID.Text = "";
        txtLinkedINID.Text = "";
        ddlCountryID.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID)
    {
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(ContactID);

        if (!entContact.CountryID.IsNull)
        {
            ddlCountryID.SelectedValue = entContact.CountryID.Value.ToString();

        }
        if (!entContact.StateID.IsNull)
        {
            ddlStateID.SelectedValue = entContact.StateID.Value.ToString();

        }
        if (!entContact.CityID.IsNull)
        {
            ddlCityID.SelectedValue = entContact.CityID.Value.ToString();
        }

        if (!entContact.ContactName.IsNull)
        {
            txtContactName.Text = entContact.ContactName.Value.ToString();
        }

        if (!entContact.ContactNo.IsNull)
        {
            txtContactNo.Text = entContact.ContactNo.Value.ToString();
        }

        if (!entContact.Email.IsNull)
        {
            txtEmail.Text = entContact.Email.Value.ToString();
        }

        if (!entContact.Address.IsNull)
        {
            txtAddress.Text = entContact.Address.Value.ToString();
        }
        if (!entContact.WhatsAppNo.IsNull)
        {
            txtWhatsAppNo.Text = entContact.WhatsAppNo.Value.ToString();
        }
        if (!entContact.BirthDate.IsNull)
        {
            txtBirthDate.Text = entContact.BirthDate.Value.ToString();
        }
        if (!entContact.Age.IsNull)
        {
            txtAge.Text = entContact.Age.Value.ToString();
        }

        if (!entContact.BloodGroup.IsNull)
        {
            txtBloodGroup.Text = entContact.BloodGroup.Value.ToString();
        }

        if (!entContact.FacebookID.IsNull)
        {
            txtFacebookID.Text = entContact.FacebookID.Value.ToString();
        }
        if (!entContact.LinkedINID.IsNull)
        {
            txtLinkedINID.Text = entContact.LinkedINID.Value.ToString();
        }

        #region Fill CheckboxList
        ContactWiseContactCategoryBAL balContactWiseContactCategoury = new ContactWiseContactCategoryBAL();
        DataTable dt = balContactWiseContactCategoury.SelectCheckBoxListContactCategory(ContactID);

        if (dt.Rows.Count > 0)
        {
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (!dr["SelectedOrNot"].Equals(DBNull.Value))
                {
                    if (dr["SelectedOrNot"].ToString().Trim() == "SELECTED")
                    {
                        if (dr["ContactCategoryName"].ToString().Trim() == cblContactCategoryID.Items[i].Text && dr["ContactCategoryID"].ToString().Trim() == cblContactCategoryID.Items[i].Value)
                        {
                            cblContactCategoryID.Items[i].Selected = true;
                        }
                    }
                    i++;
                }
            }
        }
    }
        #endregion Fill CheckboxList

    #endregion Fill Controls

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
    }
    #endregion Button : Cancel






}