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

                return View(Toedit);
            }

            return View();
        }

        // POST: Editar/Edit/5
        [HttpPost]
        public ActionResult Editar(UsuarioT usuario)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44359/");

            var request = clienteHttp.PutAsync("api/Usuarios/Put", usuario, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Actualizado = JsonConvert.DeserializeObject<bool>(resultString);

                if (Actualizado)
                {
                    ViewBag.Error = "Usuario actualizado";
                    return RedirectToAction("Index", "Home");
                }
            }

             return View();
        }
    }
}
