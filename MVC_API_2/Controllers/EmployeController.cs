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
    public class EmployeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllVisiteurs()
        {
            try
            {
                Cvisiteurs ovisiteurs = Cvisiteurs.getInstance();
                if(ovisiteurs.oListVisiteurs != null)
                {
                    return Json(ovisiteurs.oListVisiteurs);
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllChefs()
        {
            try
            {
                CchefRegions ochefs = CchefRegions.getInstance();
                if (ochefs.oListChefs != null)
                {
                    return Json(ochefs.oListChefs);
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
