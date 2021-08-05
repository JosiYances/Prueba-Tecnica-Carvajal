using Newtonsoft.Json;
using ServiciosWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UsuariosWeb.Controllers
{
    public class EliminarController : Controller
    {  

        // GET: Eliminar/Edit/5
        public ActionResult Eliminar(int id)
        {
            try 
            { 

                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("https://localhost:44359/");

                var request = clienteHttp.DeleteAsync("api/Usuarios/Delete?id=" + id).Result;
                if (request.IsSuccessStatusCode)
                {
                    var resultstring = request.Content.ReadAsStringAsync().Result;
                    var Toedit = JsonConvert.DeserializeObject<bool>(resultstring);
                    
                    if(Toedit)
                    {
                        return RedirectToAction("Index", "Home", new { mensaje = "B" });
                    }
                    
                }

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home", new { mensaje = "F" });
            }
        }
            
    }
}
