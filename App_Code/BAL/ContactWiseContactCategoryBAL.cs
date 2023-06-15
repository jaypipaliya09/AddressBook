using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategoryBAL
/// </summary>
public class ContactWiseContactCategoryBAL
{
    #region Local Variables
    protected string _Message;
    public string Message
    {
        get
        {
            return _Message;
        }
        set
        {
            _Message = value;
        }
    }
    #endregion Local Variables

    #region Constructor
    public ContactWiseContactCategoryBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region Insert ContactWiseContactCategory
    public Boolean Insert(ContactWiseContactCategoryENT entContactWiseContactCategory)
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
        if (dalContactWiseContactCategory.Insert(entContactWiseContactCategory))
        {
            return true;
        }
        else
        {
            Message = dalContactWiseContactCategory.Message;
            return false;
        }
    }
    #endregion Insert ContactWiseContactCategory

    #region Delete Operation
    public Boolean DeleteByContactID(SqlInt32 ContactID)
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();

        if (dalContactWiseContactCategory.DeleteByContactID(ContactID))
        {
            return true;
        }
        else
        {
            Message = dalContactWiseContactCategory.Message;
            return false;
        }
    }
    #endregion Delete Operation

    #region SelectCheckBoxListContactCategory
    public DataTable SelectCheckBoxListContactCategory(SqlInt32 ContactID)
    {
        ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
        return dalContactWiseContactCategory.SelectCheckBoxListContactCategory(ContactID);
    }
    #endregion SelectCheckBoxListContactCategory
}