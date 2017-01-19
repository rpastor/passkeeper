using System;
using Xunit;
using PassKeeper.Storage;

namespace PassKeeper.Tests
{
    public class FileStorageTests
    {
        private string unlockSecret = "my-encrypted-unlock-secret";

        [Fact]
        public void should_get_the_list_of_stored_passwords()
        {
            var storage = new FileStorage();
            var list = storage.GetPasswordList();

            Assert.NotNull(list);
            Assert.Equal(3, list.Length);
            Assert.Equal("amazon", list[0]);
        }

        [Fact]
        public void should_get_password_for_service_if_unlock_password_matches()
        {
            var storage = new FileStorage();
            var serviceName = "amazon";

            var password = storage.GetPassword(serviceName, this.unlockSecret);

            Assert.Equal("my-encrypted-amazon-password", password);
        }

        [Fact]
        public void should_add_new_password_to_list()
        {
            var storage = new FileStorage();
            storage.AddPassword("new-service", "new-password");

            Assert.Equal("new-password", storage.GetPassword("new-service", this.unlockSecret));
        }

        [Fact]
        public void should_add_loginName_to_list()
        {
            var storage = new FileStorage();
            storage.AddLoginName("amazon", "amazon-loginName", this.unlockSecret);

            Assert.Equal("amazon-loginName", storage.GetLoginName("amazon", this.unlockSecret));         
        }

        [Fact]
        public void should_add_passwordHint_to_list()
        {
            var storage = new FileStorage();
            storage.AddPasswordHint("amazon", "amazon-password-hint", this.unlockSecret);

            Assert.Equal("amazon-password-hint", storage.GetPasswordHint("amazon",this.unlockSecret));
        }
        [Fact]
        public void should_add_security_question_answer_to_list()
        {
            var storage = new FileStorage();
            storage.AddSecurityQuestionAnswer("amazon", "What\'s the name of the farm next to the Hill House?  \'I don\'t know.\'", this.unlockSecret);

            var list = storage.GetSecurityQuestionAnswer("amazon",this.unlockSecret);
            
            Assert.NotNull(list);
            Assert.Equal(1,list.Length);
            Assert.Equal("What\'s the name of the farm next to the Hill House?  \'I don\'t know.\'", list[0]);
        }
    }
}
