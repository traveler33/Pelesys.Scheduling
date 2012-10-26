using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Pelesys.Data;
using Pelesys.Scheduling;


namespace Pelesys.Scheduling
{
    [MetadataTypeAttribute(typeof(Metadata))]
    public partial class DesignForm
    {


        #region Mandatory
        public static ObjectContext GetContextByEntityNamespace(string entityNamespace)
        {
            return new Pelesys.Scheduling.SchedulingEntity();
        }
        #endregion

        #region Method
        public static DesignForm GetDateBy(int eFormID)
       {
            
            string eSQL = " Where T.eFormID =" + eFormID;
            var list = DesignForm.LoadListWhere<DesignForm>(eSQL);
            return list.First();

        }

        static public List<DesignForm> GetDataBy(Int32 TypeID)
        {
            return ResourceType.LoadList<DesignForm>("Select Value T From DesignForms as T Where T.Type =" + TypeID + "  Order by T.Name ");

        }


        #endregion


    }

    #region Metadata
    internal sealed class Metadata
    {
    }
    #endregion
}
