using System.Collections.Generic;
using System.Web.Http;
using classes_metier;
using System.Web.Http.Cors;
using System.Linq;
using classes_outils;
using System;
using System.Net.Http;
using System.Net;

namespace Test_1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tous les domaines
    public class AuthentificationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult verification_objVisiteur(string slogin, string smdp)
        {
            try
            {
                Cvisiteurs ovisiteurs = Cvisiteurs.getInstance();
                Cvisiteur ovisiteur = ovisiteurs.GetVisiteur(slogin);
                if (ovisiteur != null && ovisiteur.Mdp == smdp)
                {
                    return Ok(ovisiteur);
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult verification_objChef(string slogin, string smdp)
        {
            try
            {
                CchefRegions ochefRegions = CchefRegions.getInstance();
                CchefRegion ochefRegion = ochefRegions.GetChef(slogin);
                if (ochefRegion != null && ochefRegion.Mdp == smdp)
                {
                    return Json(ochefRegion);
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}



#region Old ValueController
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using classes_outils;
using MySql.Data.MySqlClient;

namespace Test_1.Controllers
{
    // [EnableCors(origins: "http://applitestapi.local:8080", headers: "*", methods: "*")]

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            string chaine = null;
            Cdao odao = new Cdao();
            string query = "select * from lignefraishorsforfait where id = " + Convert.ToString(id);
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                chaine = Convert.ToString(ord["libelle"]);

            }

            return chaine;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}*/
#endregion