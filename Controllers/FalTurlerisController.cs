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
using WEB_API.Models;
using System.Text;
using System.Web.Http.Cors;
namespace WEB_API.Controllers
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]

    public class FalTurleriController : ApiController
    {
        private testdbEntities7 db = new testdbEntities7();

        // GET: api/FalTurleris
        public IQueryable<FalTurleri> Get()
        {
            return db.FalTurleri;
        }


        [Route("api/GetFalTurleri")]
        [HttpGet]
        public HttpResponseMessage GetFalTurleri()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var obj = new
            {
                status = "success",
                falTuru = db.FalTurleri
            };

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            return response;
        }


        // GET: api/FalTurleris/5
        [ResponseType(typeof(FalTurleri))]
        public IHttpActionResult GetFalTurleri(int id)
        {
            FalTurleri falTurleri = db.FalTurleri.Find(id);
            if (falTurleri == null)
            {
                return NotFound();
            }

            return Ok(falTurleri);
        }

        // PUT: api/FalTurleris/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFalTurleri(int id, FalTurleri falTurleri)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != falTurleri.Id_Fal)
            {
                return BadRequest();
            }

            db.Entry(falTurleri).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FalTurleriExists(id))
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

        // POST: api/FalTurleris
        [ResponseType(typeof(FalTurleri))]
        public IHttpActionResult PostFalTurleri(FalTurleri falTurleri)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FalTurleri.Add(falTurleri);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FalTurleriExists(falTurleri.Id_Fal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = falTurleri.Id_Fal }, falTurleri);
        }

        // DELETE: api/FalTurleris/5
        [ResponseType(typeof(FalTurleri))]
        public IHttpActionResult DeleteFalTurleri(int id)
        {
            FalTurleri falTurleri = db.FalTurleri.Find(id);
            if (falTurleri == null)
            {
                return NotFound();
            }

            db.FalTurleri.Remove(falTurleri);
            db.SaveChanges();

            return Ok(falTurleri);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FalTurleriExists(int id)
        {
            return db.FalTurleri.Count(e => e.Id_Fal == id) > 0;
        }
    }
}