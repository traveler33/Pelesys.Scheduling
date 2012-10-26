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
    public partial class DateFormat
    {

         #region Mandatory
          public static ObjectContext GetContextByEntityNamespace(string entityNamespace)
          {
              return new Pelesys.Scheduling.SchedulingEntity();
          }
          #endregion

         #region Method
          public static List<DateFormat> GetDateFormat(int cultureID)
          {
              string eSQL = " Where T.CultureID =" + cultureID;
              return DateFormat.LoadListWhere<DateFormat>(eSQL);
             
          }
         #endregion


        

      #region Metadata
      internal sealed class Metadata
      {
      }
      #endregion
    }
}
