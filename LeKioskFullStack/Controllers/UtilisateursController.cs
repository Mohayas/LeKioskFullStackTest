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
using LeKioskDAO;

namespace LeKioskFullStack.Controllers
{
    public class UtilisateursController : ApiController
    {
        private KioskEntities db = new KioskEntities();


        // GET: api/Utilisateurs
        
        public IHttpActionResult GetUtilisateurs()
        {                      
            return Ok(db.Utilisateurs.ToList());
        }


        //La méthode Signin qui prends deux paramètres (email et password) renvois un objet 'Utilisateur'
        //si les information d'authentification sont correct ou un produit une erreur sinon.

        // GET: api/Utilisateurs

        [HttpGet]
        [ResponseType(typeof(Utilisateur))]        
        public IHttpActionResult Signin(string email, string password)
        {
            Utilisateur user = db.Utilisateurs.Where(u => u.email == email).Where(u => u.password == password).First();

            if (user == null)
            {                
                return NotFound();
            }

            return Ok(user);

        }



        //La méthode Signup permet d'enregistrer un Utilisateur dans la base de données.
        //l'objet utilisateur est recupéré depuis la requête.

        // POST: api/Utilisateurs
        [HttpPost]
        [ResponseType(typeof(Utilisateur))]        
        public HttpResponseMessage Signup(Utilisateur utilisateur)
        {
                       
            try
            {
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, utilisateur);
                
                message.Headers.Location = new Uri(Request.RequestUri +"/"+ utilisateur.Id);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest , ex);
            }

            
        }

       
    }
}