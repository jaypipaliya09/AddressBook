using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategoryDAL
/// </summary>

namespace AddressBook.DAL
{
    public class ContactWiseContactCategoryDAL : DatabaseConfig
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

        //protected Int32 _ContactID;

        //public Int32 ContactID
        //{
        //    get
        //    {
        //        return _ContactID;
        //    }
        //    set
        //    {
        //        _ContactID = value;
        //    }
        //}

        #endregion Local Variables

        #region Constructor
        public ContactWiseContactCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert 
        public Boolean Insert(ContactWiseContactCategoryENT entContactWiseContactCategory)
        {

            #region Connection String
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Connection String

            #region try | Catch | finally
            try
            {
                #region ConnOpen | Command
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[dbo].[PR_ContactWiseContactCategory_Insert]";
                #endregion ConnOpen | Command

                #region Prepare Command
                objCmd.Parameters.AddWithValue("@ContactID", entContactWiseContactCategory.ContactID);
                objCmd.Parameters.AddWithValue("@ContactCategoryID", entContactWiseContactCategory.ContactCategoryID);
                objCmd.Parameters.AddWithValue("@CreationDate", SqlDbType.DateTime).Value = entContactWiseContactCategory.CreationDate;
                #endregion Prepare Command

                #region Execute | Close | return
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                return true;
                #endregion Execute | Close | return
            }
            catch (SqlException sqlex)
            {
                Message = sqlex.InnerException.Message;
                return false;
            }
            catch (Exception ex)
            {
                Message = ex.InnerException.Message;
                return false;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }
            #endregion try | Catch | finally
        }
        #endregion Insert 

        #region Delete Operation
        public Boolean DeleteByContactID(SqlInt32 ContactID)
        {
            #region Connection String
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Connection String

            #region try | Catch | finally
            try
            {
                #region ConnOpen | Command
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[dbo].[PR_ContactWiseContactCategory_DeleteByContactID]";
                #endregion ConnOpen | Command

                #region Create Command
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                #endregion Create Command

                #region Execute | Close |return
                objCmd.ExecuteNonQuery();
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
                return true;
                #endregion Execute | Close | return
            }
            catch (SqlException sqlex)
            {
                Message = sqlex.InnerException.Message;
                return false;
            }
            catch (Exception ex)
            {
                Message = ex.InnerException.Message;
                return false;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }

            #endregion try | Catch | finally
        }
        #endregion Delete Operation

        #region SelectCheckBoxListContactCategory
        public DataTable SelectCheckBoxListContactCategory(SqlInt32 ContactID)
        {
            #region Connection String
            SqlConnection ObjConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Connection String

            #region try | Catch | finally
            try
            {
                #region ConnOpen | Command
                if (ObjConn.State != ConnectionState.Open)
                    ObjConn.Open();
                SqlCommand ObjCmd = ObjConn.CreateCommand();
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.CommandText = "[dbo].[PR_ContactWiseContactCategory_CheckboxList]";
                #endregion ConnOpen | Command

                #region Create Command
                ObjCmd.Parameters.AddWithValue("@ContactID", ContactID);
                #endregion Create Commad

                #region Execute | Close | return
                SqlDataReader objSDR = ObjCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                if (ObjConn.State != ConnectionState.Closed)
                    ObjConn.Close();
                return dt;
                #endregion Execute | Close | return
            }
            catch (SqlException sqlex)
            {
                Message = sqlex.InnerException.Message;
                return null;
            }
            catch (Exception ex)
            {
                Message = ex.InnerException.Message;
                return null;
            }
            finally
            {
                if (ObjConn.State != ConnectionState.Closed)
                    ObjConn.Close();
            }
            #endregion try | Catch | finally
        }
        #endregion SelectCheckBoxListContactCategory

    }
}