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
            return _utilisateurService.getUtilisateurByEmailAndPasswword(email, password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="utilisateur">a user object to add</param>
        /// <returns></returns>
        public Utilisateur addUtilisateur(Utilisateur utilisateur)
        {
            return _utilisateurService.addUtilisateur(utilisateur);
        }
    }
}
