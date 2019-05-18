using System;
using Blog.Repository;
using Blog.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Repository.Tests {

    [TestClass]
    public class UserRepositoryTest {

        BlogUnitOfWork unit = new BlogUnitOfWork();

        #region GetById()

        [TestMethod]
        public void GetById_IdExistsInDatabaseAndUserIsNotDeleted_NotNull() {
            Assert.IsNotNull(unit.Users.GetById(1));
        }

        [TestMethod]
        public void GetById_IdExistsInDatabaseAndUserIsDeleted_Null() {
            Assert.IsNull(unit.Users.GetById(5));
        }

        [TestMethod]
        public void GetById_IdNotExistsInDatabase_Null() {
            Assert.IsNull(unit.Users.GetById(6));
        }

        [TestMethod]
        public void GetById_IdValueIsNull_Null() {
            Assert.IsNull(unit.Users.GetById(null));
        }

        #endregion

    }
}
