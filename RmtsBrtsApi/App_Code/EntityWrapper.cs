using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RmtsBrtsApi.App_Code
{
    public class EntityWrapper
    {
        #region Properties
        protected int _IsResult;
        public int IsResult
        {
            get { return _IsResult; }
            set { _IsResult = value; }
        }
        protected String _Message;
        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        protected DataTable _ResultList;
        public DataTable ResultList
        {
            get { return _ResultList; }
            set { _ResultList = value; }
        }
        #endregion Properties
    }
}