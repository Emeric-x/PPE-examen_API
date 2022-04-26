using System.Collections.Generic;
using System.Web.Http;
using classes_metier;
using System.Web.Http.Cors;
using System.Linq;
using classes_outils;
using System;
using System.Net.Http;
using System.Net;
using Newtonsoft;

namespace Test_1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class MedecinController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllMedecins()
        {
            try
            {
                Cmedecins omedecins = Cmedecins.getInstance();
                if (omedecins.oListMedecins != null)
                {
                    return Json(omedecins.oListMedecins);
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
