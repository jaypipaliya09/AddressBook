using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityDAL
/// </summary>

namespace AddressBook.DAL
{
    public class CityDAL : DatabaseConfig
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
        public CityDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
         
        #region Insert Operation
        public Boolean Insert(CityENT entCity)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_Insert";
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int,4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entCity.StateID;
                        objCmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = entCity.CityName;
                        objCmd.Parameters.Add("@STDCode", SqlDbType.VarChar).Value = entCity.STDCode;
                        objCmd.Parameters.Add("@PinCode", SqlDbType.VarChar).Value = entCity.PinCode;
                        objCmd.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = entCity.CreationDate;
                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@CityID"] != null)
                        {
                            entCity.CityID = Convert.ToInt32(objCmd.Parameters["@CityID"].Value);
                        }
                        return true;
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
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
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CityENT entCity)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CityID", entCity.CityID);
                        objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                        objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("@PinCode", entCity.PinCode);
                        objCmd.Parameters.AddWithValue("@CreationDate", entCity.CreationDate);
                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
                        return true;
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                    catch(SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch(Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CityID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        #endregion Prepare Command
                        objCmd.ExecuteNonQuery();
                        return true;
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
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
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and set Controls

                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
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
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }

                }
            }
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_SelectForDropDownList";
                        #endregion Prepare Command

                        #region ReadData and set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and set Controls

                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
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
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }

                }
            }
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 CityID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        #endregion Prepare Command

                        #region ReadData and set Controls
                        CityENT entCity = new CityENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entCity.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entCity.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                {
                                    entCity.CityName = Convert.ToString(objSDR["CityName"]);
                                }

                                if (!objSDR["STDCode"].Equals(DBNull.Value))
                                {
                                    entCity.STDCode = Convert.ToString(objSDR["STDCode"]);
                                }

                                if (!objSDR["PinCode"].Equals(DBNull.Value))
                                {
                                    entCity.PinCode = Convert.ToString(objSDR["PinCode"]);
                                }

                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entCity.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                            }
                        }
                        return entCity;
                        #endregion ReadData and set Controls

                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
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
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }

                }
            }
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}