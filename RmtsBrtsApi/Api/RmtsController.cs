using RmtsBrtsApi.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace RmtsBrtsApi.Api
{
    public class RmtsController : ApiController
    {
        #region GetAllPickupPointsRmts
        [HttpGet]
        public HttpResponseMessage GetAllPickupPointsRmts()
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RmtsConnectionString"].ToString().Trim());
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = @"[dbo].[PR_RMTS_PICKUP_POINT_SELECTALL]";
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

        #region GetAllRmtsRoutes
        [HttpGet]
        public HttpResponseMessage GetAllRmtsRoutes()
        {
            try
            {
                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RmtsConnectionString"].ToString().Trim());
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = @"[dbo].[PR_RMTS_ROUTE_SELECTALL]";
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

        #region GetRmtsRouteFromTo
        [HttpPost]
        public HttpResponseMessage GetRmtsRouteFromTo([FromBody] FormDataCollection formBody)
        {
            try
            {
                String ErrorMessage = "";
                SqlString frompickpoint = SqlString.Null;
                SqlString topickpoint = SqlString.Null;

                if(formBody.GetValues("frompickpoint") == null)
                {
                    ErrorMessage += "frompickpoint required.";
                }
                else
                {
                    frompickpoint = formBody.Get("frompickpoint").ToString().Trim();
                }

                if (formBody.GetValues("topickpoint") == null)
                {
                    ErrorMessage += "frompickpoint required.";
                }
                else
                {
                    topickpoint = formBody.Get("topickpoint").ToString().Trim();
                }

                SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["RmtsConnectionString"].ToString().Trim());
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = @"[dbo].[PR_RMTS_GET_ROUTE]";
                objCmd.Parameters.AddWithValue("@frompickpoint", frompickpoint);
                objCmd.Parameters.AddWithValue("@topickpoint", topickpoint);
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