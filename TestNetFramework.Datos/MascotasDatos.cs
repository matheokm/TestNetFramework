using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using TestNetFramework.Clases.Modelos;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace TestNetFramework.Datos
{
    public class MascotasDatos
    {
        public static string connectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString; }
        }
        public static List<Mascotas> consultaMascotas()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var result = db.Query<Mascotas>("[dbo].[Mascota_All]", commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("TestNetFrameworkAPI/Mascotas", $"Mascotas ==> ERROR: {ex.Message} " +
                    $"- STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}", 
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        public string registroMascotas(int userId, string nombre, int edad, string desc)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@userId", userId);
                    parameters.Add("@nombre", nombre);
                    parameters.Add("@edad", edad);
                    parameters.Add("@desc", desc);
                    var result = db.Query<string>("[dbo].[Mascota_Add]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("TestNetFrameworkAPI/Mascotas", $"Mascotas ==> ERROR: {ex.Message} " +
                   $"- STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}",
                   System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        public string actualizaMascotas(int id, string nombre, int edad, string desc)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id", id);
                    parameters.Add("@nombre", nombre);
                    parameters.Add("@edad", edad);
                    parameters.Add("@desc", desc);
                    var result = db.Query<string>("[dbo].[Mascota_Update]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("TestNetFrameworkAPI/Mascotas", $"Mascotas ==> ERROR: {ex.Message} " +
                   $"- STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}",
                   System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        public string eliminarMascotas(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id", id);
                    var result = db.Query<string>("[dbo].[Mascota_Delete]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("TestNetFrameworkAPI/Mascotas", $"Mascotas ==> ERROR: {ex.Message} " +
                   $"- STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}",
                   System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }
    }
}
