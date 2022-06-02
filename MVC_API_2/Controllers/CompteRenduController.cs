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
using System.Net.Http;

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

        [HttpPost]
        public IHttpActionResult InsertCompteRendu()
        {
            try
            {
                HttpContent content = Request.Content;
                System.Threading.Tasks.Task<string> tacheAsync = content.ReadAsStringAsync();
                string objetJson = tacheAsync.Result;

                CcompteRendu oCompteRendu = Newtonsoft.Json.JsonConvert.DeserializeObject<CcompteRendu>(objetJson);
                CcompteRendus oCompteRendus = CcompteRendus.getInstance();
                int nbEnregAffecte = 0;

                nbEnregAffecte = oCompteRendus.ajouterCompteRendu(oCompteRendu); ;

                if (nbEnregAffecte > 0)
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