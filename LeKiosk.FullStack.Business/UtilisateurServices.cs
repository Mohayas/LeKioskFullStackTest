using LeKioskDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeKiosk.FullStack.Business
{
    public class UtilisateurServices
    {
        UtilisateurDAL _utilisateurService = new UtilisateurDAL();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Utilisateur> getListUtilisateurs()
        {
            return _utilisateurService.getListUtilisateurs();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Utilisateur getUtilisateur(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            return _utilisateurService.getUtilisateurByEmail(email);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Utilisateur getUtilisateur(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;
            return _utilisateurService.getUtilisateurByEmailAndPasswword(email, password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="utilisateur">a user object to add</param>
        /// <returns></returns>
        public Utilisateur addUtilisateur(Utilisateur utilisateur)
        {
            if (utilisateur == null
                || string.IsNullOrEmpty(utilisateur.email)
                || string.IsNullOrEmpty(utilisateur.password)
                ) return null;
            return _utilisateurService.addUtilisateur(utilisateur);
        }
    }
}
