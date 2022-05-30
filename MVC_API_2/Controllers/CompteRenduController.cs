using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using classes_metier;
using classes_outils;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using System.Web.Http.Cors;

namespace Test_1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tous les domaines

    public class CompteRenduController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllCompteRendu()
        {
            try
            {
                CcompteRendus oCompteRendus = CcompteRendus.getInstance();
                if (oCompteRendus.oListCompteRendus != null)
                {
                    return Json(oCompteRendus.oListCompteRendus);
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