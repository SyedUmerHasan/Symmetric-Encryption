//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Crypto
{
    public static class DynamicStoredProcedure
    {
        //public  static IEnumerable<dynamic> DynamicListFromSql(this DbContext db, string Sql, Dictionary<string, object> Params)
        //{
        //    using (var state = db.Database.GetDbConnection())
        //    {
        //        DbCommand cmd = state.CreateCommand();
        //        cmd.CommandText = Sql;
        //        if (cmd.Connection.State != null) { cmd.Connection.Open(); }

        //        foreach (KeyValuePair<string, object> p in Params)
        //        {
        //            DbParameter dbParameter = cmd.CreateParameter();
        //            dbParameter.ParameterName = p.Key;
        //            dbParameter.Value = p.Value;
        //            cmd.Parameters.Add(dbParameter);
        //        }

        //        using (var dataReader = cmd.ExecuteReader())
        //        {
        //            while (dataReader.Read())
        //            {
        //                var row = new ExpandoObject() as IDictionary<string, object>;
        //                for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
        //                {
        //                    row.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
        //                }
        //                yield return row;
        //            }
        //        }
        //    }
        //}
    }
}
