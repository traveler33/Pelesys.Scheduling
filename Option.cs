using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Pelesys.Data;
namespace Pelesys.Scheduling
{
    
    public partial class Option
    {
        #region Mandatory
        public static ObjectContext GetContextByEntityNamespace(string entityNamespace)
        {
            return new Pelesys.Scheduling.SchedulingEntity();
        }
        #endregion

        #region Mothed

        public static string GetOptionByKey(string Key)
        {
            List< Option>  opList = Option.LoadListWhere<Option>( " Where T.optionKey='" + Key + "'" );
            Option op = opList.FirstOrDefault();
            if (op == null)
            {
                return string.Empty;
            }
            return op._OptionValue;
        
        }

        #endregion

    }
}
