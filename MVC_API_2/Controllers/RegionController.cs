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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegionController : ApiController
    {
        // je renvoie la collection de CfraisForfait - pas de contrôleur spécial
        /*[HttpGet]
        public IHttpActionResult GetCollFF()
        {
            List<Cfraisforfait> ocollFF = Cfraisforfaits.getInstance().getCollFF();
            return Ok(ocollFF);
        }

        [HttpGet]
        public IHttpActionResult GetLigneFF(string sidVisiteur) //par idVisiteur
        {
            CficheFraiss ofiches = CficheFraiss.getInstance();
            bool OK = ofiches.verifExistFicheFrais(sidVisiteur, CtraitementDate.getAnneeMoisEnCours());
            if (OK)
            {
                string anneeMois = CtraitementDate.getAnneeMoisEnCours();

                CligneFraisForfaits olignesFF = CligneFraisForfaits.getInstance();

                List<CligneFraisForfait> olistLigneFF = olignesFF.getCollLigneFraisForfait();

                List<classes_metier.CligneFraisForfait> olistRetour;
                olistRetour = olistLigneFF.FindAll(
                    delegate (classes_metier.CligneFraisForfait oligneFF)
                    {
                        return oligneFF.idVisiteur == sidVisiteur && oligneFF.mois == anneeMois;
                    });

                return Ok(olistRetour);
            }
            else
            {
                bool reponse = ofiches.ajouterFicheFrais(sidVisiteur); //ajout de la fiche de frais et des 4 lignes de FF

                string anneeMois = CtraitementDate.getAnneeMoisEnCours();

                CligneFraisForfaits olignesFF = CligneFraisForfaits.getInstance();

                List<CligneFraisForfait> olistLigneFF = olignesFF.getCollLigneFraisForfait();

                List<classes_metier.CligneFraisForfait> olistRetour;
                olistRetour = olistLigneFF.FindAll(
                    delegate (classes_metier.CligneFraisForfait oligneFF)
                    {
                        return oligneFF.idVisiteur == sidVisiteur && oligneFF.mois == anneeMois;
                    });

                return Ok(olistRetour); // retour des lignes FF à 0

            }

        }

        //automatiquement en POST car le nom de la méthode commence par Update
        public IHttpActionResult UpdateLigneFF(int squantite, string sidFraisForfait, string sidVisiteur) //pour un idVisiteur
        {
            try
            {
                CligneFraisForfaits olignes = CligneFraisForfaits.getInstance();
                olignes.UpdateLigneFraisForfait(squantite, sidFraisForfait, sidVisiteur);
                return Ok("mis a jour effectuee");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        */
    }
}
