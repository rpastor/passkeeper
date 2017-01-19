using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PassKeeper.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace PassKeeper.MongoDb
{
    public class MongoStorage: IStorage
    {
        private string conString = @"mongodb://pkdb:cJe6VTwOKhv2AQQywWvbb7Ts1SUrgtDKtKdtlCeNQZ9e0ReZnf1DfgJDTcHeiOLj1D7UpMs5PUpQpjwJX1JDsQ==@pkdb.documents.azure.com:10250/?ssl=true&sslverifycertificate=false";
        //private string conString = @"mongodb://localhost:27017";
        private string dbName = "pkdb";
        private MongoClient client;
        private IMongoDatabase db;

        public MongoStorage()
        {
            client = new MongoClient(conString);
            db = client.GetDatabase(dbName);
        }

        private ProfileData GetProfile()
        {
            FilterDefinition<ProfileData> filter = "{ profileName: 'default' }";
            
            var collection = db.GetCollection<ProfileData>("profiles");
            return collection.Find(filter).First();
        }

        private void SaveProfile(ProfileData profile)
        {
            FilterDefinition<ProfileData> filter = "{ profileName: 'default' }";

            var collection = db.GetCollection<ProfileData>("profiles");
            collection.ReplaceOne(filter, profile);
        }

        public string[] GetPasswordList()
        {
            var profile = GetProfile();
            return profile.Passwords.Select(p => p.serviceName).ToArray();
        }

        public string GetPassword(string serviceName, string encryptedUnlockSecret)
        {
            var profile = GetProfile();
            VerifyUnlockSecret(profile, encryptedUnlockSecret);

            return GetPasswordFromProfileWithException(profile, serviceName).password;

        }

        public void AddPassword(string serviceName, string encryptedServicePassword)
        {
            var profile = GetProfile();
            var existingService = GetPasswordFromProfile(profile, serviceName);

            if (existingService != null)
            {
                throw new Exception("Service: " + serviceName + " already exists");
            }

            profile.Passwords.Add(new PasswordData {
                serviceName = serviceName,
                password = encryptedServicePassword
            });
            SaveProfile(profile);
        }

        public void UpdatePassword(string serviceName, string encryptedServicePassword, string encryptedUnlockSecret)
        {
            var profile = GetProfile();
            VerifyUnlockSecret(profile, encryptedUnlockSecret);

            var existingService = GetPasswordFromProfileWithException(profile, serviceName);

            existingService.password = encryptedServicePassword;
            SaveProfile(profile);
        }
        
        public void DeletePassword(string serviceName, string encryptedUnlockSecret)
        {
            var profile = GetProfile();
            VerifyUnlockSecret(profile, encryptedUnlockSecret);

            var existingService = GetPasswordFromProfileWithException(profile, serviceName);
            profile.Passwords.Remove(existingService);
            SaveProfile(profile);
        }        

        private PasswordData GetPasswordFromProfile(ProfileData profile, string serviceName)
        {
            return profile.Passwords.FirstOrDefault(x => x.serviceName == serviceName);
        }

        private PasswordData GetPasswordFromProfileWithException(ProfileData profile, string serviceName)
        {
            var service = GetPasswordFromProfile(profile, serviceName);
            if (service == null) {
                throw new Exception("Service: " + serviceName + " not found");
            }

            return service;
        }

        private void VerifyUnlockSecret(ProfileData profile, string unlockSecret)
        {
            if (profile.UnlockSecret != unlockSecret)
            {
                throw new Exception("Unlock secret does not match");
            }
            
        }
        public void AddLoginName(string serviceName, string loginName, string encryptedUnlockSecret)
        {
            var profile = GetProfile();
            VerifyUnlockSecret(profile, encryptedUnlockSecret);

            var existingService = GetPasswordFromProfileWithException(profile, serviceName);
            existingService.loginName = loginName;
        }
        public void AddPasswordHint(string serviceName, string passwordHint, string encryptedUnlockSecret)
        {
            var profile = GetProfile();
            VerifyUnlockSecret(profile, encryptedUnlockSecret);

            var existingService = GetPasswordFromProfileWithException(profile, serviceName);
            existingService.passwordHint = passwordHint;
        }

        public void AddSecurityQuestionAnswer(string serviceName, string securityQuestionAnswer, string encryptedUnlockSecret)
        {
            var profile = GetProfile();
            VerifyUnlockSecret(profile, encryptedUnlockSecret);

            var existingService = GetPasswordFromProfileWithException(profile, serviceName);
            existingService.securityQuestionAnswers.Add(securityQuestionAnswer); 
        }
    }
}
