using System;
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

namespace APIUsuariosDatos.Controllers
{
    public class TablaTipoDocsController : ApiController
    {
        private AdmUsuariosEntities1 db = new AdmUsuariosEntities1();

        [HttpGet]
        public IEnumerable<TablaTipoDoc> Get()
        {
            var listado = db.TablaTipoDoc.ToList();
            return listado;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TablaTipoDocExists(int id)
        {
            return db.TablaTipoDoc.Count(e => e.IdTipoDoc == id) > 0;
        }
    }
}