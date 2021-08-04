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
    public class EditarController : Controller
    {        
        // GET: Editar/Edit/5
        [HttpGet]
        public ActionResult Editar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44359/");

            var request = clienteHttp.GetAsync("api/Usuarios/Get?id=" + id).Result;
            if (request.IsSuccessStatusCode) 
            { 
                var resultstring = request.Content.ReadAsStringAsync().Result;
                var Toedit = JsonConvert.DeserializeObject<UsuarioT>(resultstring);


                var request1 = clienteHttp.GetAsync("api/TablaTipoDocs/Get").Result;

                if (request1.IsSuccessStatusCode)
                {
                    var resultstring1 = request1.Content.ReadAsStringAsync().Result;
                    var TipoD = JsonConvert.DeserializeObject<List<TipoDocu>>(resultstring1);

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
                    return View(Toedit);
                }
            }

            return View();
        }

        // POST: Editar/Edit/5
        [HttpPost]
        public ActionResult Editar(UsuarioT usuario)
        {
            HttpClient clienteHttp2 = new HttpClient();
            clienteHttp2.BaseAddress = new Uri("https://localhost:44359/");

            var request2 = clienteHttp2.PutAsync("api/Usuarios/Put", usuario, new JsonMediaTypeFormatter()).Result;
            if (request2.IsSuccessStatusCode)
            {
                var resultString = request2.Content.ReadAsStringAsync().Result;
                var Actualizado = JsonConvert.DeserializeObject<bool>(resultString);

                if (Actualizado)
                {                                    
                    return RedirectToAction("Index", "Home", new { mensaje = "A" });
                }
            }

             return View();
        }
    }
}
