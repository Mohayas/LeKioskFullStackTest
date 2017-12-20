using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeKioskDAO
{
    /// <summary>
    /// A class that handels all the 'Utilisateur' methods related to database
    /// </summary>
    public class UtilisateurDAL
    {
        KioskEntities DB = new KioskEntities();
        /// <summary>
        /// a method that returns list of  all users selected from databse
        /// </summary>
        /// <returns></returns>
        public List<Utilisateur> getListUtilisateurs()
        {
            return DB.Utilisateurs.ToList();
        }
        /// <summary>
        /// select user from user by its email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Utilisateur</returns>
        public Utilisateur getUtilisateurByEmail(string email)
        {
            return DB.Utilisateurs.Where(u => u.email == email).First();
        }
        /// <summary>
        /// returns a user selected by its email and password from database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns>Utilisateur</returns>
        public Utilisateur getUtilisateurByEmailAndPasswword(string email,string pass)
        {
            return DB.Utilisateurs.Where(u => u.email == email && u.password == pass).First();
        }
        /// <summary>
        /// add new user to database and returns the new user created 
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <returns>Utilisateur</returns>
        public Utilisateur addUtilisateur(Utilisateur utilisateur)
        {
            DB.Utilisateurs.Add(utilisateur);
            DB.SaveChanges();
            return utilisateur;
        }
    }
}
