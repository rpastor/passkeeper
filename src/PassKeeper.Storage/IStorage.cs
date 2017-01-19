namespace PassKeeper.Storage {
    public interface IStorage {
        string[] GetPasswordList();

        string GetPassword(string serviceName, string encryptedUnlockSecret);

        void AddPassword(string serviceName, string encryptedServicePassword);

        void UpdatePassword(string serviceName, string encryptedServicePassword, string encryptedUnlockSecret);

        void DeletePassword(string serviceName, string encryptedUnlockSecret);
        
        void AddLoginName(string serviceName, string loginName, string encryptedUnlockSecret);

        void AddPasswordHint(string serviceName, string passwordHint, string encryptedUnlockSecret);
        
        void AddSecurityQuestionAnswer(string serviceName, string securityQuestionAnswer, string encryptedUnlockSecret);
    }
}