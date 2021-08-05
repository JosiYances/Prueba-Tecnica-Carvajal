using Newtonsoft.Json;
using ServiciosWeb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace UsuariosWeb.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(string mensaje)
        {
            if (mensaje == "A")
            {
                ViewBag.Error = "Usuario actualizado";
                return View();
            }

            if (mensaje == "B")
            {
                ViewBag.Error = "Usuario eliminado";
                return View();
            }

            if (mensaje == "C")
            {
                ViewBag.Error = "Usuario creado";
                return View();
            }

            if (mensaje == "D")
            {
                ViewBag.Error = "Usuario ya existe";
                return View();
            }

            if (mensaje == "E")
            {
                ViewBag.Error = "Error de formato";
                return View();
            }
            if (mensaje == "F")
            {
                ViewBag.Error = "Verifica la conexión con la base de datos";
                return View();
            }
            return View();

        }

        [HttpPost]
        public ActionResult Index(int Documento, string Contrasena)
        {
            try 
            { 
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("https://localhost:44359/");

                var request = clienteHttp.GetAsync("api/Usuarios/GetU?Documento=" + Documento).Result;

        
                
                if (request.IsSuccessStatusCode)
                {
                    var resultstring = request.Content.ReadAsStringAsync().Result;
                    var apee = JsonConvert.DeserializeObject<UsuarioT>(resultstring);
                    if (apee.Contrasena == Contrasena)
                    {
                        return RedirectToAction("Usuario","Usuario", apee);
                    }
                    ViewBag.Error = "Usuario o contrasena inválido";
                    return View();                

                }

                ViewBag.Error = "Usuario o contrasena invalido";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Verifique los datos y vuelva a intentar";
                return View();
            }
        }
    
    }
}