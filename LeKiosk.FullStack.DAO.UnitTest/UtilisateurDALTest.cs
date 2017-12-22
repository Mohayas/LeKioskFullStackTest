using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeKioskDAO;
using System.Collections.Generic;

namespace LeKiosk.FullStack.DAO.UnitTest
{
    [TestClass]
    public class UtilisateurDALTest
    {
        //un objet de la classs UtilisateurDAL qu'on va tester
        UtilisateurDAL utilisateurDAL;
        /// <summary>
        /// //l'initialistation de l'objet utilisateurDAL
        /// </summary>
        private void initialize()
        {
            utilisateurDAL = new UtilisateurDAL();
        }
        /// <summary>
        /// tester la methode qui renvois tous les utilisateurs
        /// success
        /// </summary>
        [TestMethod]
        public void getListUtilisateursSuccess()
        {
            initialize();
            List<Utilisateur> listUsers = utilisateurDAL.getListUtilisateurs();
            Assert.AreNotEqual(listUsers.Count, 0);
        }
        /// <summary>
        /// tester la methode qui renvois tous les utilisateurs
        /// faild
        /// </summary>
        [TestMethod]
        public void getListUtilisateursFailed()
        {
            initialize();
            List<Utilisateur> listUsers = utilisateurDAL.getListUtilisateurs();
            Assert.AreEqual(listUsers.Count, 0);
        }
        /// <summary>
        /// tester la methode qui renvois un utilisateur par son email
        /// success
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailSuccess()
        {
            initialize();
            Utilisateur user = utilisateurDAL.getUtilisateurByEmail("asas.mohamed@gmail.com");
            Assert.IsNotNull(user);
        }
        /// <summary>
        /// tester la methode qui renvois un utilisateur par son email
        /// faild
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailFailed()
        {
            initialize();
            Utilisateur user = utilisateurDAL.getUtilisateurByEmail("something@gmail.com");
            Assert.IsNull(user);
        }
        /// <summary>
        /// tester la methode qui renvois un utilisateur par son email et password
        /// success
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailandPasswordSuccess()
        {
            initialize();
            Utilisateur user = utilisateurDAL.getUtilisateurByEmailAndPasswword("mo@yas.com", "aaa");
            Assert.IsNotNull(user);
        }
        /// <summary>
        /// tester la methode qui renvois un utilisateur par son email et password
        /// faild
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailandPasswordFailed()
        {
            initialize();
            Utilisateur user = utilisateurDAL.getUtilisateurByEmailAndPasswword("something@gmail.com", "BadPassword");
            Assert.IsNull(user);
        }

    }
}