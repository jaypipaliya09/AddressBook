using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityBAL
/// </summary>
namespace AddressBook.BAL
{
    public class CityBAL
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
        public CityBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.Insert(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.Update(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Delete(CityID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Delete Operation

        #region Select Operation
        #region SelectAll
        public DataTable SelectAll()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectByPK(CityID);
        }
        #endregion SelectByPK
        #endregion Select Operation
    }
}