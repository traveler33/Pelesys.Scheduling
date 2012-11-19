using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pelesys.Data;
using System.Data;
using System.Data.Objects;

namespace Pelesys.Scheduling
{
     public  partial class Setting
    {

         #region Mandatory
         public static ObjectContext GetContextByEntityNamespace(string entityNamespace)
         {
             return new Pelesys.Scheduling.SchedulingEntity();
         }
         #endregion

         #region Property


         #endregion

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
