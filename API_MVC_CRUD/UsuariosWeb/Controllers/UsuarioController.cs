﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosWeb;

namespace UsuariosWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Usuario(UsuarioT MiUser)
        {
          
            return View(MiUser);
        }

        
    }
}
