using Newtonsoft.Json;
using ServiciosWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace UsuariosWeb.Controllers
{
    public class RegistroController : Controller
    {
        public ActionResult Registro()
        {
            try 
            { 
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("https://localhost:44359/");                
                var request = clienteHttp.GetAsync("api/TablaTipoDocs/Get").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultstring = request.Content.ReadAsStringAsync().Result;
                    var TipoD = JsonConvert.DeserializeObject<List<TipoDocu>>(resultstring);

                    List<SelectListItem> items = TipoD.ConvertAll(s =>
                    {
                        return new SelectListItem()
                        {
                            Text = s.TipoDocSelect.ToString(),
                            Value = s.TipoDocSelect.ToString(),
                            Selected = false
                        };
                    });
                    ViewBag.items = items;
                    return View();
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { mensaje = "F" });
            }
        }


        [HttpPost]
        public ActionResult Registro(UsuarioT usuario)
        {
            try 
            { 
                if(ModelState.IsValid)
                { 
                    HttpClient clienteHttp = new HttpClient();
                    clienteHttp.BaseAddress = new Uri("https://localhost:44359/");

                    var request = clienteHttp.PostAsync("api/Usuarios/Post", usuario, new JsonMediaTypeFormatter()).Result;
                    if (request.IsSuccessStatusCode)
                    {
                        var resultString = request.Content.ReadAsStringAsync().Result;
                        var Ingresado = JsonConvert.DeserializeObject<bool>(resultString);

                        if(Ingresado)
                        {
                            return RedirectToAction("Index", "Home", new {mensaje = "C" });
                        }                
                    }

                    return RedirectToAction("Index", "Home", new {mensaje ="D" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { mensaje = "E" });
                }
            }
            catch 
            {
                return RedirectToAction("Index", "Home", new { mensaje = "F" });
            }
        }
    }
}
