using System;
using PassKeeper.Storage;

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

        public void AddLoginName(string serviceName, string loginName, string encryptedUnlockSecret)
        {
            storage.AddLoginName(serviceName, loginName, encryptedUnlockSecret);
        }

        public string GetLoginName(string serviceName, string encryptedUnlockSecret)
        {
            return storage.GetLoginName(serviceName, encryptedUnlockSecret);
        }

        public void AddPasswordHint(string serviceName, string passwordHint, string encryptedUnlockSecret)
        {
            storage.AddPasswordHint(serviceName, passwordHint, encryptedUnlockSecret);
        }

        public string GetPasswordHint(string serviceName, string encryptedUnlockSecret)
        {
            return storage.GetPasswordHint(serviceName, encryptedUnlockSecret);
        }

        public void AddSecurityQuestionAnswer(string serviceName, string securityQuestionAnswer, string encryptedUnlockSecret)
        {
            storage.AddSecurityQuestionAnswer(serviceName, securityQuestionAnswer, encryptedUnlockSecret);
        }

        public string[] GetSecurityQuestionAnswers(string serviceName, string encryptedUnlockSecret)
        {
            return storage.GetSecurityQuestionAnswers(serviceName, encryptedUnlockSecret);
        }
    }
}