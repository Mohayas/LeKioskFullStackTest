using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeKioskDAO
{
    /// <summary>
    /// 
    /// </summary>
    public class UtilisateurDAL
    {
        KioskEntities DB = new KioskEntities();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Utilisateur> getListUtilisateurs()
        {
            return DB.Utilisateurs.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Utilisateur getUtilisateurByEmail(string email)
        {
            return DB.Utilisateurs.Where(u => u.email == email).First();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Utilisateur getUtilisateurByEmailAndPasswword(string email,string pass)
        {
            return DB.Utilisateurs.Where(u => u.email == email && u.password == pass).First();
        }    
        public Utilisateur addUtilisateur(Utilisateur utilisateur)
        {
            DB.Utilisateurs.Add(utilisateur);
            DB.SaveChanges();
            return utilisateur;
        }
    }
}
