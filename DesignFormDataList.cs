using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Data;
using Pelesys.Data;

namespace Pelesys.Scheduling
{
     [MetadataTypeAttribute(typeof(Metadata))]
    public partial class DesignFormDataList
    {


         #region Mandatory
         public static ObjectContext GetContextByEntityNamespace(string entityNamespace)
         {
             return new Pelesys.Scheduling.SchedulingEntity();
         }
         #endregion

         #region Method
         static public List<DesignFormDataList> GetAllDataList()
         {
             return DesignFormDataList.LoadList<DesignFormDataList>("select [type], Category from SCH.DesignformDatalist group by [type], category order by Category ");
                
         }


         static public DataTable   GetAllDataListCategory()
         {
             String SQL = "select Category, Category from Sch.DesignformDatalist group by category";
             DBManager db = new DBManager();
             return  db.GetDataTableFromSQL(SQL);
             
         }

         

         public static List<DesignFormDataList> GetDataListByType(int Type)
         {
             return DesignFormDataList.LoadListWhere<DesignFormDataList>("Where T.Type =" + Type );
         }

         #endregion
    }
}
