using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pelesys.Data;


namespace Pelesys.Scheduling
{
     public  partial class Setting
    {

        #region Method
        static public List<Setting> GetAllDataListNames()
        {
            return GetDicByCategory("DataList");

        }

        public static List<Setting> GetDicByCategory(string Category)
        {
            return Setting.LoadList<Setting>("Select Value T From Settings as T Where T.Category ='" + Category + "' Order by T.Name ");
        }
        #endregion

    }
}
