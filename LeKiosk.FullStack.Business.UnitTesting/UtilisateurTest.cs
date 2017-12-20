using System;
using System.Collections.Generic;
using LeKioskDAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeKiosk.FullStack.Business.UnitTesting
{
    [TestClass]
    public class UtilisateurTest
    {
        //Instance of Class UtilisateurServices for calling Business methodes
        UtilisateurServices _utilisateurServices;
        /// <summary>
        /// Initialize the needed Values,objects
        /// </summary>
        private void initialize()
        {
            _utilisateurServices = new UtilisateurServices();
        }
        /// <summary>
        /// Test Methode getListUtilisateurs when Success
        /// </summary>
        [TestMethod]
        public void getListUtilisateursSuccess()
        {
            initialize();
            List<Utilisateur> listUsers = _utilisateurServices.getListUtilisateurs();
            Assert.AreNotEqual(listUsers.Count,0);
        }
        /// <summary>
        /// Test Methode getListUtilisateurs when Failed
        /// </summary>
        [TestMethod]
        public void getListUtilisateursFailed()
        {
            initialize();
            List<Utilisateur> listUsers = _utilisateurServices.getListUtilisateurs();
            Assert.AreEqual(listUsers.Count, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailSuccess()
        {
            initialize();
            Utilisateur user = _utilisateurServices.getUtilisateur("asas.mohamed@gmail.com");
            Assert.IsNotNull(user);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailFailed()
        {
            initialize();
            Utilisateur user = _utilisateurServices.getUtilisateur("something@gmail.com");
            Assert.IsNull(user);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailandPasswordSuccess()
        {
            initialize();
            Utilisateur user = _utilisateurServices.getUtilisateur("asas.mohamed@gmail.com","p@ssW0rd");
            Assert.IsNotNull(user);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void getUtilisateurbyEmailandPasswordFailed()
        {
            initialize();
            Utilisateur user = _utilisateurServices.getUtilisateur("something@gmail.com","BadPassword");
            Assert.IsNull(user);
        }
    }
}
