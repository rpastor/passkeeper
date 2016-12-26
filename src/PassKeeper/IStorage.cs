namespace PassKeeper {
    interface IStorage {
        string[] GetPasswordList();

        string GetPassword(string serviceName, string encryptedUnlockSecret);

        void AddPassword(string serviceName, string encryptedServicePassword);

        void UpdatePassword(string serviceName, string encryptedServicePassword, string encryptedUnlockSecret);

        void DeletePassword(string serviceName, string encryptedUnlockSecret);        
    }
}