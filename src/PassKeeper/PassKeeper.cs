using System;

namespace PassKeeper
{
    public class PassKeeper
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
            return AesProvider.Decrypt(storage.GetPassword(serviceName, encryptedUnlockSecret));
        }

        public void AddPassword(string serviceName, string encryptedServicePassword)
        {
            storage.AddPassword(serviceName, AesProvider.Encrypt(encryptedServicePassword));
        }

        public void UpdatePassword(string serviceName, string encryptedServicePassword, string encryptedUnlockSecret)
        {
            storage.UpdatePassword(serviceName, AesProvider.Encrypt(encryptedServicePassword), encryptedUnlockSecret);
        }

        public void DeletePassword(string serviceName, string encryptedUnlockSecret)
        {
            storage.DeletePassword(serviceName, encryptedUnlockSecret);
        }
    }
}