using System;

namespace PassKeeper
{
    class PassKeeper
    {
        private IStorage storage;

        PassKeeper(IStorage storage) {
            this.storage = storage;
        }
        
        string[] GetPasswordList()
        {
            throw new NotImplementedException();
        }

        string GetPassword(string serviceName, string encryptedUnlockSecret)
        {
            throw new NotImplementedException();
        }

        void AddPassword(string serviceName, string encryptedServicePassword)
        {

        }

        void UpdatePassword(string serviceName, string encryptedServicePassword, string encryptedUnlockSecret)
        {

        }

        void DeletePassword(string serviceName, string encryptedUnlockSecret)
        {

        }

    }
}