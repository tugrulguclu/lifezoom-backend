using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using WEB_API.Models;
using System.Web.Http.Cors;
using System.Text;



namespace WEB_API.Controllers
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]

    public class LoginController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public HttpResponseMessage CheckUser([FromBody]Users u)
        {

            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {

                //using (testdbEntities4 dc = new testdbEntities4())
                //{
                //    var v = dc.Users.Where(a => a.username.Equals(u.username) && a.password.Equals(u.password)).FirstOrDefault();
                //    if (v != null)
                //    {
                //        //Session["LogedUserID"] = v.ID.ToString();
                //        //Session["LogedUserFullname"] = v.username.ToString();
                //        //return RedirectToAction("AfterLogin");
                //        var response = Request.CreateResponse(HttpStatusCode.OK);
                //        //var data = new
                //        //{
                //        //    status = new { status = "success" },
                //        //    user = new   { v.ID,v.username }
                //        //};

                //        var data = new
                //        {
                //            status = new { status = "success" },
                //            user = new { v.ID, v.username }
                //        };

                //        var obj = new 
                //        {
                //            status = "success",
                //            user = v
                //        };

                //        //string rawJsonFromDb = _session.Query<Player>().ToJsonArray();

                //        //var obj = new Lad
                //        //{
                //        //    firstName = "Markoff",
                //        //    lastName = "Chaney",
                //        //    dateOfBirth = new MyDate
                //        //    {
                //        //        year = 1901,
                //        //        month = 4,
                //        //        day = 30
                //        //    }
                //        //};

                //        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                //        response.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                //        return response;

                //    }
                // }
            }
            //return View(u);
            return Request.CreateResponse(HttpStatusCode.NotFound);

        }
    }
}