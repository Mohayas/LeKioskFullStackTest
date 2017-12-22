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
using LeKiosk.FullStack.Business;
using LeKioskDAO;

namespace LeKioskFullStack.Controllers
{
    public class UtilisateursController : ApiController
    {
        private UtilisateurServices _utilisateurServices;

        private void initialize()
        {
            _utilisateurServices = new UtilisateurServices();
        }

        /// <summary>
        /// returns a list of all users.
        ///  GET: api/Utilisateurs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetUtilisateurs()
        {
            initialize();
            return Ok(_utilisateurServices.getListUtilisateurs());
        }


        /// <summary>
        /// La méthode Signin qui prends deux paramètres (email et password) renvois un objet 'Utilisateur'
        /// si les information d'authentification sont correct ou un produit une erreur sinon.
        ///  GET: api/Utilisateurs
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Utilisateur</returns>
        [HttpGet]
        public IHttpActionResult Signin(string email, string password)
        {
            initialize();
            Utilisateur user = _utilisateurServices.getUtilisateur(email, password);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        /// <summary>
        ///La méthode Signup permet d'enregistrer un Utilisateur 
        ///l'objet utilisateur est recupéré depuis la requête.
        /// POST: api/Utilisateurs
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(Utilisateur))]
        public HttpResponseMessage Signup(Utilisateur utilisateur)
        {
            initialize();
            try
            {
                _utilisateurServices.addUtilisateur(utilisateur);
                var message = Request.CreateResponse(HttpStatusCode.Created, utilisateur);
                //Ajouter le chemin de l'utilisateur créé dans l'entête de requête.
                message.Headers.Location = new Uri(Request.RequestUri + "/" + utilisateur.Id);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// verifier si l'existance d'un email et renvois l'utilisateur correspondant et l'email perdu par mail
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult forgotPassword(string email)
        {
            initialize();
            Utilisateur user = _utilisateurServices.getUtilisateur(email);
            if (user == null)
                return NotFound();
            return Ok(true);
        }

    }
}