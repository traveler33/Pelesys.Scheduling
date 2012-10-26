using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Pelesys.Data;
using Pelesys.Scheduling;
using System.Data;

namespace Pelesys.Scheduling
{
    public partial class ResourceType
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
      
        static public List<ResourceType> GetDataBy()
        {

            return ResourceType.LoadList<ResourceType>("Select Value T From ResourceTypes as T Order by T.Name ");
        }


        static public ResourceType GetDataBy(Int32 ResourceTypeID)
        {

            return ResourceType.LoadByID<ResourceType>(ResourceTypeID);
        }


        static public Int32 GetMaxTabID()
        {
            DBManager oDB = new DBManager();
            DataTable oDS = oDB.GetDataTableFromSQL("Select Max(FormTabID)as MaxTabID From sch.DesignFormTab");
            if (oDS.Rows.Count > 0)
            {
                if (oDS.Rows[0]["MaxTabID"] != null && oDS.Rows[0]["MaxTabID"].ToString() != string.Empty )
                {
                    Int32 rCount = Convert.ToInt32(oDS.Rows[0]["MaxTabID"].ToString());
                    rCount = rCount + 1;
                    return rCount;
                }
               
            }

            return 0;
        }

        #endregion


    }
}
