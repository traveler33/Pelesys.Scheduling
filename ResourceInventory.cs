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
    public partial class ResourceInventory
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
        #endregion


    }
}
