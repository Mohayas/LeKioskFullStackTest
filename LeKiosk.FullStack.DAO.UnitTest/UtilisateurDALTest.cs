using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeKioskDAO;
using System.Collections.Generic;

namespace LeKiosk.FullStack.DAO.UnitTest
{
    [TestClass]
    public class UtilisateurDALTest
    {
        UtilisateurDAL utilisateurDAL;

        private void initialize()
        {
            utilisateurDAL = new UtilisateurDAL();
        }

        [TestMethod]
        public void getListUtilisateursSuccess()
        {
            initialize();
            List<Utilisateur> listUsers = utilisateurDAL.getListUtilisateurs();
            Assert.AreNotEqual(listUsers.Count, 0);
        }
        /// <summary>
        /// Test Methode getListUtilisateurs when Failed
        /// </summary>
        [TestMethod]
        public void getListUtilisateursFailed()
        {
            initialize();
            List<Utilisateur> listUsers = utilisateurDAL.getListUtilisateurs();
            Assert.AreEqual(listUsers.Count, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailSuccess()
        {
            initialize();
            Utilisateur user = utilisateurDAL.getUtilisateurByEmail("asas.mohamed@gmail.com");
            Assert.IsNotNull(user);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailFailed()
        {
            initialize();
            Utilisateur user = utilisateurDAL.getUtilisateurByEmail("something@gmail.com");
            Assert.IsNull(user);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailandPasswordSuccess()
        {
            initialize();
            Utilisateur user = utilisateurDAL.getUtilisateurByEmailAndPasswword("asas.mohamed@gmail.com", "p@ssW0rd");
            Assert.IsNotNull(user);
        }
        /// <summary>
        /// 
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
