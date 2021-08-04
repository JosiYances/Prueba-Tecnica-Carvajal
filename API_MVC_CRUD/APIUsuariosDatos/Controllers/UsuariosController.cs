﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCUsuariosData.Modelo;
using ServiciosWeb;

namespace APIUsuariosDatos.Controllers
{
    public class UsuariosController : ApiController
    {
        private AdmUsuariosEntities db = new AdmUsuariosEntities();

        // GET: api/Usuarios
        public IQueryable<Usuarios> GetUsuarios()
        {
            return db.Usuarios;
           
        }

        // GET: api/Usuarios/5        
        public Usuarios Get(int id)
        {
            var SelesctUser = db.Usuarios.FirstOrDefault(x => x.Id == id);
            return SelesctUser;
        }

        // GET:
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult GetU(int Documento)
        {
            var oUser = (from d in db.Usuarios
                         where d.Identificación == Documento
                         select d).FirstOrDefault();

            if (oUser == null)
            {
                return NotFound();
            }

            return Ok(oUser);
        }

        // PUT: api/Usuarios/5
        [HttpPut]
        public bool Put(Usuarios usuarios)
        {           
            var ActUser = db.Usuarios.FirstOrDefault(x => x.Id == usuarios.Id);
            ActUser.Nombre = usuarios.Nombre;
            ActUser.Apellido = usuarios.Apellido;
            ActUser.TipoID = usuarios.TipoID;
            ActUser.Identificación = usuarios.Identificación;
            ActUser.Contrasena = usuarios.Contrasena;
            ActUser.Correo = usuarios.Correo;
            return db.SaveChanges() > 0;
        }

        // POST: api/Usuarios
        [HttpPost]
        public bool Post(Usuarios usuarios)
        {
            var Compro = (from d in db.Usuarios
                         where d.Identificación == usuarios.Identificación
                         select d).FirstOrDefault();

            if (Compro == null)
            {

                db.Usuarios.Add(usuarios);
                return db.SaveChanges() > 0;
            }

            return false;

        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public bool Delete(int id)
        {
            var DelUser = db.Usuarios.FirstOrDefault(x => x.Id == id);
            db.Usuarios.Remove(DelUser);
            return db.SaveChanges() > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}