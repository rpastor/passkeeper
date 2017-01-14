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
    }
}
