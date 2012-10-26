using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Pelesys.Data;
using System.Data;
using System.Web;



namespace Pelesys.Scheduling
{
   
    public partial class     DesignFormField
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


        //IsMandatory
        public static List<DesignFormField> GetMandatoryDataBy(int eFormID)
        {

            string eSQL = "Where  ( T.ControlType=5 or T.ControlType =3 or T.controlType= 9 or  T.controlType= 10)  and  T.FormID=" + eFormID;
            return DesignFormField.LoadListWhere<DesignFormField>(eSQL);
        
        }

        public static List<DesignFormField> GetDataBy(String  TabIdentifier, int eFormID)
        {
            DesignFormTab oTab = DesignFormTab.GetDataBySysIdentity(eFormID, TabIdentifier);
            if (oTab != null)
            {
                string eSQL = "Where T.TabID =" + oTab.FormTabID + " and T.FormID=" + eFormID;
                return DesignFormField.LoadListWhere<DesignFormField>(eSQL);
            }

            return null;
        }


        public static List<DesignFormField> GetDataBy(int eDesignFormTabID, int eFormID, int FieldID)
        {
            string eSQL = "Where T.TabID =" + eDesignFormTabID  + " and T.FormID=" + eFormID  + " and T.FieldID=" + FieldID;
            return DesignFormField.LoadListWhere<DesignFormField>(eSQL);
        }

        public static List<DesignFormField> GetDataByeFormID(int eFormID)
        {
            string eSQL = "Where T.FormID =" + eFormID  ;
            return DesignFormField.LoadListWhere<DesignFormField>(eSQL);
        }

        public static List<DesignFormField> GetDataByeFormID(int eFormID, int FieldID)
        {
            string eSQL = "Where T.FormID =" + eFormID + " and T.FieldID=" + FieldID; ;
            return DesignFormField.LoadListWhere<DesignFormField>(eSQL);
        }



        public static bool IsValidControlName(string TableName, string ControlName, int eFormID, int eFieldID)
        {

            string tSQL = "FormDesign @Type  = 'VerifyColumnName', @eFormID=" +  eFormID +", @fieldID=" +  eFieldID +", @Table='" + TableName + "', @NewColumnName = '" + ControlName + "'";
            
            
            DataTable oTb = DesignFormField.LoadDataTableBySQL(tSQL);
            FieldConstrol oField = new FieldConstrol();
            if (oTb.Rows.Count > 0)
            {
                if (oTb.Rows[0][0].ToString() == "1")
                {
                    return false;
                }
               
            }


            return true ;
        }

        public static FieldConstrol GetLabelName(string TableName)
        {
            string tSQL = "FormDesign @Type  = 'GetNewField',@Table='" + TableName + "'";
            DataTable oTb = DesignFormField.LoadDataTableBySQL(tSQL);
            FieldConstrol oField = new FieldConstrol();
            if (oTb.Rows.Count > 0)
            { 
               oField.ControlName = oTb.Rows[0]["NewControl"].ToString();
               oField.LableName = oTb.Rows[0]["NewLabel"].ToString();
            }


            return oField;
        }

        #endregion


        #region T-SQL Method




        //Modify a table column
        public static void UpdateFormDesignPosition(String SQL)
        {
            DBManager db = new DBManager();
            db.ExecuteNonQuery(SQL);

        }



        public static DataTable GetDataTableStructure(string TableName, string IDName, Int64 IDValue)
        {
            String SQL = @" Select * from " + TableName + " where " + IDName + " = " + IDValue;
            DBManager db = new DBManager();
            DataTable oDS = db.GetDataTableFromSQL(SQL);
            return oDS;
        
        }

        public static DataTable GetAllFieldsByTableName(String TableName)
        {
            String SQL = @" GetDBSchema  @Type ='GetAllFiledsByTableName' , 
                               @TableName='" + TableName + "'";
            DBManager db = new DBManager();
            DataTable oDS = db.GetDataTableFromSQL(SQL);
            return oDS;

        }



        public static void ModifyDBTableColumn(String TableName, string ColumnName, string DataType, string oldColumnName)
        {


            string SQL = string.Empty;
           

                SQL = @"sp_RENAME '" + TableName + "." + oldColumnName + "','" + ColumnName + "', 'COLUMN'";

                DBManager db = new DBManager();
                db.ExecuteNonQuery(SQL);
                //DeleteColumn

            
          




        }


        public static void ModifyColumnSize(String TableName, string ColumnName, int Size)
        {


            string SQL = string.Empty;
          

                SQL = @"ALTER TABLE " + TableName + " ALTER COLUMN " + ColumnName + " NVARCHAR (" + Size.ToString() + ")  NULL ";

                DBManager db = new DBManager();
                db.ExecuteNonQuery(SQL);
               

           
          



        }


        public static void ModifyDBTable(String TableName, string ColumnName, string DataType, Boolean IsAddNewColumn, int fieldID)
        {
            string SQL = string.Empty;

            if (IsAddNewColumn)
            {
                SQL = @"ALTER TABLE  " + TableName + "  " +
                              " ADD  " + ColumnName + " " + DataType + " NULL  ";
                DBManager db = new DBManager();
                db.ExecuteNonQuery(SQL);

            }
            else


            {

                //Change column name
                SQL = @"ALTER TABLE  " + TableName + "  " +
                            " ALTER COLUMN " + ColumnName + " " + DataType + " NULL  ";
                DBManager db = new DBManager();
               // db.ExecuteNonQuery(SQL);
                DesignFormField ofield = DesignFormField.Load<DesignFormField>(fieldID);

                //Change data type
                if (ColumnName != ofield.Name)
                {
                    SQL = @"sp_RENAME '" + TableName + ".[" + ofield.Name  + "]' , '" + ColumnName + "', 'COLUMN'";


                    db.ExecuteNonQuery(SQL);
                }
               
            
            }

            
           
           

        }

        //Delete a table column
        public static void DeleteColumnFromDBTable(String TableName, string ColumnName)
        {
           
                // first it drops this column then it delete a record in design table for this deleted column
                string SQL = @"ALTER TABLE  " + TableName +
                               " Drop Column " + ColumnName;
                DBManager db = new DBManager();
                db.ExecuteNonQuery(SQL);
          
        }

        #endregion
    }

    
}
