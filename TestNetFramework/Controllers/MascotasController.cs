using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestNetFramework.Clases.Modelos;
using TestNetFramework.Datos;
using TestNetFramework.Models;

namespace TestNetFramework.Controllers
{
    [RoutePrefix("Api/Mascotas")]
    public class MascotasController : ApiController
    {
        /*
         PRUEBAS POSTMAN COPIAR TODA LA URL
         CONSULTA-> https://localhost:44391/Api/Mascotas/Consulta
         REGISTRO-> https://localhost:44391/Api/Mascotas/Registro?userId=1&nombre=POSTMAN&edad=3&desc=POSTMAN5
         ACTUALIZAR-> https://localhost:44391/Api/Mascotas/Actualizar?Id=5&nombre=POSTMAN5&edad=3&desc=POSTMAN19
         ELIMINAR-> https://localhost:44391/Api/Mascotas/Eliminar?id=5
         */
        [HttpGet]
        [Route("Consulta")]
        public OperationResult<List<Mascotas>> consultaMascotas()
        {
            try
            {
                var result = MascotasDatos.consultaMascotas();
                if (result.Count > 0)
                    return OperationResult<List<Mascotas>>.CreateSuccessResult(result);
                else
                    return OperationResult<List<Mascotas>>.CreateFailure();
            }
            catch (System.Exception ex)
            {
                return OperationResult<List<Mascotas>>.CreateFailure(ex);
            }
        }

        [HttpPost]
        [Route("Registro")]
        public OperationResult<string> registroMascotas(int userId, string nombre, int edad, string desc)
        {
            try
            {
                var result = new MascotasDatos().registroMascotas(userId, nombre, edad, desc);
                if (result != null)
                    return OperationResult<string>.CreateSuccessResult(result);
                else
                    return OperationResult<string>.CreateFailure("Ocurrió un error");
            }
            catch (System.Exception ex)
            {
                return OperationResult<string>.CreateFailure(ex);
            }
        }

        [HttpPost]
        [Route("Actualizar")]
        public OperationResult<string> actualizarMascotas(int id, string nombre, int edad, string desc)
        {
            try
            {
                var result = new MascotasDatos().actualizaMascotas(id, nombre, edad, desc);
                if (result != null)
                {
                    return OperationResult<string>.CreateSuccessResult(result);
                }
                else
                {
                    return OperationResult<string>.CreateFailure("Ocurrió un error");
                }
            }
            catch (System.Exception ex)
            {
                return OperationResult<string>.CreateFailure(ex);
            }
        }

        [HttpPost]
        [Route("Eliminar")]
        public OperationResult<string> eliminarMascotas(int id)
        {
            try
            {
                var result = new MascotasDatos().eliminarMascotas(id);
                if (result != null)
                {
                    return OperationResult<string>.CreateSuccessResult(result);
                }
                else
                {
                    return OperationResult<string>.CreateFailure("Ocurrió un error");
                }
            }
            catch (System.Exception ex)
            {
                return OperationResult<string>.CreateFailure(ex);
            }
        }


    }
}
