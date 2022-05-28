﻿using System.Collections.Generic;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FicheFraisController : ApiController
    {
        #region FicheFrais
        #endregion

        #region FraisForfaits
        [HttpGet]
        public IHttpActionResult GetAllFraisForfaits()
        {
            try
            {
                CfraisForfaits oFraisForfaits = CfraisForfaits.getInstance();
                if (oFraisForfaits.oListFraisForfaits != null)
                {
                    return Json(oFraisForfaits.oListFraisForfaits);
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region LigneFF
        [HttpGet]
        public IHttpActionResult GetAllLigneFF()
        {
            try
            {
                CligneFFs oLigneFFs = CligneFFs.getInstance();
                if (oLigneFFs.oListLigneFFs != null)
                {
                    return Json(oLigneFFs.oListLigneFFs);
                }
                return BadRequest("ERREUR");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult InsertLigneFF()
        {
            try
            {
                HttpContent content = Request.Content;
                System.Threading.Tasks.Task<string> tacheAsync = content.ReadAsStringAsync();
                string objetJson = tacheAsync.Result;

                CligneFF oLigneFF = Newtonsoft.Json.JsonConvert.DeserializeObject<CligneFF>(objetJson);
                CligneFFs oLigneFFs = CligneFFs.getInstance();
                int nbEnregAffecte = 0;

                nbEnregAffecte = oLigneFFs.ajouterLigneFF(oLigneFF); ;

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

        #region LigneFHF
        [HttpGet]
        public IHttpActionResult GetAllLigneFHF()
        {
            try
            {
                CligneFHFs oLigneFHs = CligneFHFs.getInstance();
                if (oLigneFHs.oListLigneFHFs != null)
                {
                    return Json(oLigneFHs.oListLigneFHFs);
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
