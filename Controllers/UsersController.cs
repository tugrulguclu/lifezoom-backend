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
using System.Text;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WEB_API.Controllers
{

    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]

    public class UsersController : ApiController
    {
        private testdbEntities6 db = new testdbEntities6();

        // GET: api/Users
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.ID)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.ID }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }

        private bool UsersExists(string username)
        {
            return db.Users.Count(e => e.username == username) > 0;
        }



        [Route("api/SignUp")]
        [HttpPost]
        public HttpResponseMessage SignUp([FromBody]Users u)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            bool isSuccess = false;
            if (UsersExists(u.username))
            {
               

            }
            else
            {
                //for the new users default credit is 5 
                u.credit = 5;
                db.Users.Add(u);
                db.SaveChanges();
                isSuccess = true;
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            if (isSuccess)
            {
                var obj = new
                {
                    status = "success",
                    user = u
                };
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            }
            else
            {
                var obj = new
                {
                    status = "error",
                    message = "User exists"
                };
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            }

            return response;           
        }

        [Route("api/CheckUser")]
        [HttpPost]
        public HttpResponseMessage CheckUser([FromBody]Users u)
        {

            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {

                using (testdbEntities6 dc = new testdbEntities6())
                {
                    var v = dc.Users.Where(a => a.username.Equals(u.username) && a.password.Equals(u.password)).FirstOrDefault();
                    if (v != null)
                    {
                        //Session["LogedUserID"] = v.ID.ToString();
                        //Session["LogedUserFullname"] = v.username.ToString();
                        //return RedirectToAction("AfterLogin");
                        var response = Request.CreateResponse(HttpStatusCode.OK);
                             
                        var obj = new
                        {
                            status = "success",
                            user = v
                        };

                        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                        response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                        return response;

                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);

        }

    }
}