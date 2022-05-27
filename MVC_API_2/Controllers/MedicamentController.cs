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

    public class MedicamentController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllMedicaments()
        {
            try
            {
                Cmedicaments omedicaments = Cmedicaments.getInstance();
                if (omedicaments.oListMedicaments != null)
                {
                    return Json(omedicaments.oListMedicaments);
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region Controllers Presenter
        [HttpGet]
        public IHttpActionResult GetAllPresenters()
        {
            try
            {
                Cpresenters opresenters = new Cpresenters();
                if (opresenters.oListPresenters != null)
                {
                    return Json(opresenters.oListPresenters);
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult CreatePresenter(string sId_med, string sId_visit, int sId_medecin, string sMonth)
        {
            try
            {
                Cpresenters opresenters = Cpresenters.getInstance();
                bool reponse = opresenters.ajouterPresenter(sId_med, sId_visit, sId_medecin, sMonth);

                if (reponse)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Controllers Noter
        [HttpGet]
        public IHttpActionResult GetAllNotes()
        {
            try
            {
                /* ici, on fait un nouvel objet pour déclancher une nouvelle fois le contructeur de sorte à bien récupérer 
                   les notes récemment modifiées par le visiteur
                 */
                Cnotes onotes = new Cnotes();
                if (onotes.oListNotes != null)
                {
                    return Json(onotes.oListNotes);
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateNote()
        {
            try
            {
                /*
                 * récupération de l'objet en POST
                 * de sorte à pouvoir passer un text comprenant des espaces 
                 * (car dans l'url impossible)
                */

                HttpContent content = Request.Content;
                System.Threading.Tasks.Task<string> tacheAsync = content.ReadAsStringAsync();
                string objetJson = tacheAsync.Result;

                Cnote onote = Newtonsoft.Json.JsonConvert.DeserializeObject<Cnote>(objetJson);
                Cnotes onotes = Cnotes.getInstance();
                int nbEnregAffecte = 0;

                if (onote.Id == 0) // 0 pour update la note et 1 pour insert la note
                {
                    nbEnregAffecte = onotes.UpdateNote(onote.Note, onote.Id_med, onote.Id_visit);
                }
                else
                {
                    nbEnregAffecte = onotes.InsertNote(onote.Note, onote.Id_med, onote.Id_visit);
                }

                if (nbEnregAffecte > 0)
                {
                    return Ok();
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
