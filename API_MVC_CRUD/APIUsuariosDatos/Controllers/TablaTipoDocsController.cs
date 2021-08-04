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

        // GET: api/TablaTipoDocs
        public IQueryable<TablaTipoDoc> GetTablaTipoDoc()
        {
            return db.TablaTipoDoc;
        }

        // GET: api/TablaTipoDocs/5
        [ResponseType(typeof(TablaTipoDoc))]
        public IHttpActionResult GetTablaTipoDoc(int id)
        {
            TablaTipoDoc tablaTipoDoc = db.TablaTipoDoc.Find(id);
            if (tablaTipoDoc == null)
            {
                return NotFound();
            }

            return Ok(tablaTipoDoc);
        }

        // PUT: api/TablaTipoDocs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTablaTipoDoc(int id, TablaTipoDoc tablaTipoDoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tablaTipoDoc.IdTipoDoc)
            {
                return BadRequest();
            }

            db.Entry(tablaTipoDoc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablaTipoDocExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TablaTipoDocs
        [ResponseType(typeof(TablaTipoDoc))]
        public IHttpActionResult PostTablaTipoDoc(TablaTipoDoc tablaTipoDoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TablaTipoDoc.Add(tablaTipoDoc);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tablaTipoDoc.IdTipoDoc }, tablaTipoDoc);
        }

        // DELETE: api/TablaTipoDocs/5
        [ResponseType(typeof(TablaTipoDoc))]
        public IHttpActionResult DeleteTablaTipoDoc(int id)
        {
            TablaTipoDoc tablaTipoDoc = db.TablaTipoDoc.Find(id);
            if (tablaTipoDoc == null)
            {
                return NotFound();
            }

            db.TablaTipoDoc.Remove(tablaTipoDoc);
            db.SaveChanges();

            return Ok(tablaTipoDoc);
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