using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Pelesys.Data;

namespace Pelesys.Scheduling
{
  
    public partial class DesignFormTab
    {
        #region Mandatory
        public static ObjectContext GetContextByEntityNamespace(string entityNamespace)
        {
            return new Pelesys.Scheduling.SchedulingEntity();
        }
        #endregion



        #region Method


        public static DesignFormTab GetDataBySysIdentity(int eFormID, string SysIdentity)
        {
            string eSQL = "Where T.FormID=" + eFormID + " and T.SysIdentity='" + SysIdentity + "'";
            List<DesignFormTab> otab = DesignFormTab.LoadListWhere<DesignFormTab>(eSQL);

            return otab.FirstOrDefault();
        }



        public static bool IsTabNameExist(int eFormID, string eTabID, string TabName)
        {
            string eSQL = string.Empty;
            if (eTabID =="")
            {
                 eSQL = " Where T.FormID=" + eFormID + " and T.name ='" +  TabName + "'";
            }
            else
            {
                eSQL = " Where T.FormID=" + eFormID + " and T.name ='" + TabName + "' and T.SysIdentity<>'" + eTabID + "'";
            }
           List<DesignFormTab> oList =  DesignFormTab.LoadListWhere<DesignFormTab>(eSQL);
           if (oList.Count > 0)
           {
               return true;
           }


            return false;

        }
        

        public static List<DesignFormTab> GetDataBy(int eFormID)
        {
            string eSQL = " Where T.FormID=" + eFormID + " order by T.Sequence";
            return DesignFormTab.LoadListWhere<DesignFormTab>(eSQL);

        }

        public static DesignFormTab GetDataBy(int eFormID, int eDesignFormTabID)
        {
            string eSQL = " Where T.FormID=" + eFormID + " and T.eDesignFormTabID=" + eDesignFormTabID;
            var List = DesignFormTab.LoadListWhere<DesignFormTab>(eSQL);
            if ( List.Count >0 )
            {
                return List.First();
            }

            return null;
        }


        public static List<DesignFormTab> GetNewTabNameBy(int eFormID, string NewTabName)
        {
            string eSQL = " Where T.FormID=" + eFormID + " and T.SysIndetity ='" + NewTabName + "'";
            var List = DesignFormTab.LoadListWhere<DesignFormTab>(eSQL);
            return List;
        }
        #endregion

    }
}
