using RmtsBrtsApi.App_Code;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace RmtsBrtsApi.Api
{
    public class BrtsController : ApiController
    {
        #region GetAllBrtsPickupPoints
        [HttpGet]
        public HttpResponseMessage GetAllBrtsPickupPoints()
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RmtsConnectionString"].ToString().Trim());
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = @"[dbo].[PR_BRTS_PICKUP_POINT_SELECTALL]";
                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();
                return GetResponseResult(dt);
            }
            catch (Exception ex)
            {
                return GetResponseError(ex);
            }
        }

        #endregion

        #region GetBrtsRouteFromTo
        [HttpPost]
        public HttpResponseMessage GetBrtsRouteFromTo([FromBody] FormDataCollection formBody)
        {
            try
            {
                String ErrorMessage = "";
                SqlInt32 fromID = SqlInt32.Null;
                SqlInt32 toID = SqlInt32.Null;

                if (formBody.GetValues("fromID") == null)
                {
                    ErrorMessage += "fromID required.";
                }
                else
                {
                    fromID = SqlInt32.Parse(formBody.Get("fromID").ToString().Trim());
                }

                if (formBody.GetValues("toID") == null)
                {
                    ErrorMessage += "toID required.";
                }
                else
                {
                    toID = SqlInt32.Parse(formBody.Get("toID").ToString().Trim());
                }

                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RmtsConnectionString"].ToString().Trim());
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = @"[dbo].[PR_BRTS_GET_ROUTE]";
                objCmd.Parameters.AddWithValue("@fromID", fromID);
                objCmd.Parameters.AddWithValue("@toID", toID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();
                return GetResponseResult(dt);
            }
            catch (Exception ex)
            {
                return GetResponseError(ex);
            }
        }
        #endregion

        #region GetBrtsGetTimings
        [HttpPost]
        public HttpResponseMessage GetBrtsGetTimings([FromBody] FormDataCollection formBody)
        {
            try
            {
                String ErrorMessage = "";
                SqlInt32 fromID = SqlInt32.Null;
                SqlInt32 toID = SqlInt32.Null;

                if (formBody.GetValues("fromID") == null)
                {
                    ErrorMessage += "fromID required.";
                }
                else
                {
                    fromID = SqlInt32.Parse(formBody.Get("fromID").ToString().Trim());
                }

                if (formBody.GetValues("toID") == null)
                {
                    ErrorMessage += "toID required.";
                }
                else
                {
                    toID = SqlInt32.Parse(formBody.Get("toID").ToString().Trim());
                }

                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RmtsConnectionString"].ToString().Trim());
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = @"[dbo].[PR_BRTS_GET_TIMINGS]";
                objCmd.Parameters.AddWithValue("@fromID", fromID);
                objCmd.Parameters.AddWithValue("@toID", toID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();
                return GetResponseResult(dt);
            }
            catch (Exception ex)
            {
                return GetResponseError(ex);
            }
        }
        #endregion

        #region GetBrtsGetTimingsNow
        [HttpPost]
        public HttpResponseMessage GetBrtsGetTimingsNow([FromBody] FormDataCollection formBody)
        {
            try
            {
                String ErrorMessage = "";
                SqlInt32 fromID = SqlInt32.Null;
                SqlInt32 toID = SqlInt32.Null;
                SqlInt32 time = SqlInt32.Null;

                if (formBody.GetValues("fromID") == null)
                {
                    ErrorMessage += "fromID required.";
                }
                else
                {
                    fromID = SqlInt32.Parse(formBody.Get("fromID").ToString().Trim());
                }

                if (formBody.GetValues("toID") == null)
                {
                    ErrorMessage += "toID required.";
                }
                else
                {
                    toID = SqlInt32.Parse(formBody.Get("toID").ToString().Trim());
                }

                if (formBody.GetValues("time") == null)
                {
                    ErrorMessage += "time required.";
                }
                else
                {
                    time = SqlInt32.Parse(formBody.Get("time").ToString().Trim());
                }

                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RmtsConnectionString"].ToString().Trim());
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = @"[dbo].[PR_BRTS_GET_TIMINGS_NOW]";
                objCmd.Parameters.AddWithValue("@fromID", fromID);
                objCmd.Parameters.AddWithValue("@toID", toID);
                objCmd.Parameters.AddWithValue("@time", time);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();
                return GetResponseResult(dt);
            }
            catch (Exception ex)
            {
                return GetResponseError(ex);
            }
        }
        #endregion

        #region GetBrtsRouteDetails
        [HttpPost]
        public HttpResponseMessage GetBrtsRouteDetails([FromBody] FormDataCollection formBody)
        {
            try
            {
                String ErrorMessage = "";
                SqlInt32 fromID = SqlInt32.Null;
                SqlInt32 toID = SqlInt32.Null;

                if (formBody.GetValues("fromID") == null)
                {
                    ErrorMessage += "fromID required.";
                }
                else
                {
                    fromID = SqlInt32.Parse(formBody.Get("fromID").ToString().Trim());
                }

                if (formBody.GetValues("toID") == null)
                {
                    ErrorMessage += "toID required.";
                }
                else
                {
                    toID = SqlInt32.Parse(formBody.Get("toID").ToString().Trim());
                }

                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RmtsConnectionString"].ToString().Trim());
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = @"[dbo].[PR_BRTS_GET_ROUTE_DETAILS]";
                objCmd.Parameters.AddWithValue("@fromID", fromID);
                objCmd.Parameters.AddWithValue("@toID", toID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);
                objConn.Close();
                return GetResponseResult(dt);
            }
            catch (Exception ex)
            {
                return GetResponseError(ex);
            }
        }
        #endregion

        #region GetResponseResult
        public HttpResponseMessage GetResponseResult(DataTable dt)
        {
            EntityWrapper ent = new EntityWrapper();
            if (dt != null && dt.Rows.Count > 0)
            {
                ent.IsResult = 1;
                ent.Message = "Data Found";
                ent.ResultList = dt;
                return Request.CreateResponse(HttpStatusCode.OK, ent);
            }
            else
            {
                ent.IsResult = 0;
                ent.Message = "No Data Found";
                return Request.CreateResponse(HttpStatusCode.OK, ent);
            }

        }
        #endregion GetResponseResult

        #region GetResponseError
        public HttpResponseMessage GetResponseError(Exception ex)
        {
            EntityWrapper ent = new EntityWrapper();
            ent.IsResult = 0;
            ent.Message = ex.Message.ToString();
            return Request.CreateResponse(HttpStatusCode.OK, ent);
        }
        #endregion GetResponseError
    }
}