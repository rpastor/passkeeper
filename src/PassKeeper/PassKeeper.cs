using System;

namespace PassKeeper
{
    class PassKeeper
    {
        private IStorage storage;

        public PassKeeper(IStorage storage) {
            this.storage = storage;
        }
        
        public string[] GetPasswordList()
        {
            return storage.GetPasswordList();
        }

        public string GetPassword(string serviceName, string encryptedUnlockSecret)
        {
            return storage.GetPassword(serviceName, encryptedUnlockSecret);
        }

        public void AddPassword(string serviceName, string encryptedServicePassword)
        {
            storage.AddPassword(serviceName, encryptedServicePassword);
        }

        public void UpdatePassword(string serviceName, string encryptedServicePassword, string encryptedUnlockSecret)
        {

        }

        public void DeletePassword(string serviceName, string encryptedUnlockSecret)
        {

        }

    }
}