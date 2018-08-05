using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Well.Schools.Common
{
    public static class EFCoreSqlQueryExtensions
    {
        public static IEnumerable<T> SqlQuery<T>(this DatabaseFacade db, string sql, IDbDataParameter[] parameters = null) where T : class
        {

            var conn = db.GetDbConnection();
            List<T> list = new List<T>();
            try

            {

                conn.Open();
                using (var command = conn.CreateCommand())

                {

                    command.CommandText = sql;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    DbDataReader reader = command.ExecuteReader();

                    // 下面处理得到的 reader，略
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            object Obj = System.Activator.CreateInstance(typeof(T));
                            Type ObjType = Obj.GetType();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                PropertyInfo PI = ObjType.GetProperty(reader.GetName(i));
                                if (PI != null)
                                {
                                    string PTName = PI.PropertyType.Name.ToString();
                                    string FullName = PI.PropertyType.FullName;
                                    string Name = PI.Name;

                                    object Value = PI.GetValue(Obj, null);

                                    switch (PI.PropertyType.ToString())
                                    {
                                        case "System.Int64":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToInt64(reader[Name]), null);
                                            break;
                                        case "System.Byte[]":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : (byte[])reader[Name], null);
                                            break;
                                        case "System.Boolean":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToBoolean(reader[Name]), null);
                                            break;
                                        case "System.String":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToString(reader[Name]), null);
                                            break;
                                        case "System.DateTime":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToDateTime(reader[Name]), null);
                                            break;
                                        case "System.Decimal":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToDecimal(reader[Name]), null);
                                            break;
                                        case "System.Double":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToDouble(reader[Name]), null);
                                            break;
                                        case "System.Int32":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToInt32(reader[Name]), null);
                                            break;
                                        case "System.Single":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToSingle(reader[Name]), null);
                                            break;
                                        case "System.Byte":
                                            PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToByte(reader[Name]), null);
                                            break;
                                        default:
                                            int Chindex = PTName.IndexOf("Nullable");
                                            if (FullName.IndexOf("System.Int64") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToInt64(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.Boolean") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToBoolean(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.String") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToString(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.DateTime") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToDateTime(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.Decimal") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToDecimal(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.Double") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToDouble(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.Int32") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToInt32(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.Single") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToSingle(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.Byte") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToByte(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.Int16") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToInt16(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.UInt16") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToUInt16(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.UInt32") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToUInt32(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.UInt64") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToUInt64(reader[Name]), null);
                                            }

                                            if (FullName.IndexOf("System.SByte") >= 0)
                                            {
                                                PI.SetValue(Obj, reader.IsDBNull(reader.GetOrdinal(Name)) ? Value : Convert.ToSByte(reader[Name]), null);
                                            }
                                            break;
                                    }

                                }
                            }
                            list.Add(Obj as T);
                        }

                    }
                    reader.Close();


                }

            }

            catch (Exception ex)

            {
                throw ex;
            }

            finally

            {

                conn.Close();

            }
            return list;
        }
    }
}
