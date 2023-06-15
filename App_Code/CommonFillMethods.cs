using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace AddressBook
{
    public class CommonFillMethods
    {
        #region Constructor
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Fill Country
        public static void FillDropDownListCountry(DropDownList ddlCountryID)
        {
            CountryBAL balCountry = new CountryBAL();
            ddlCountryID.DataSource = balCountry.SelectForDropDownList();
            ddlCountryID.DataValueField = "CountryID";
            ddlCountryID.DataTextField = "CountryName";
            ddlCountryID.DataBind();
            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
        }
        #endregion Fill Country

        #region Fill State
        public static void FillDropDownListState(DropDownList ddlStateID)
        {
            StateBAL balState = new StateBAL();
            ddlStateID.DataSource = balState.SelectForDropDownList();
            ddlStateID.DataValueField = "StateID";
            ddlStateID.DataTextField = "StateName";
            ddlStateID.DataBind();
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        #endregion Fill State

        #region Fill City
        public static void FillDropDownListCity(DropDownList ddlCityID)
        {
            CityBAL balCity = new CityBAL();
            ddlCityID.DataSource = balCity.SelectForDropDownList();
            ddlCityID.DataValueField = "CityID";
            ddlCityID.DataTextField = "CityName";
            ddlCityID.DataBind();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        #endregion Fill City

        #region Fill ContactCategory by CheckboxList
        public static void FillCBLContactCategoryID(CheckBoxList cbl)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            DataTable dt = balContactCategory.SelectForDropDownList();

            cbl.DataSource = dt;
            cbl.DataValueField = "ContactCategoryID";
            cbl.DataTextField = "ContactCategoryName";
            cbl.DataBind();
        }
        #endregion Fill ContactCategory by CheckboxList
    }
}