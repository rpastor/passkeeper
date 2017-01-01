using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace PassKeeper {
    public class FileStorage : IStorage {
        private string fileName = "db.json";
        private string fileDirectory = "";
        private StorageData data;

        public FileStorage() {
            this.fileDirectory = Path.GetDirectoryName(this.GetType().GetTypeInfo().Assembly.Location);
            OpenFile();
        }

        public string[] GetPasswordList() {
            var serviceList = new List<string>();
            foreach (var service in this.data.passwords)
            {
                serviceList.Add(service.serviceName.ToString());
            }
            return serviceList.ToArray();
        }

        public string GetPassword(string serviceName, string encryptedUnlockSecret) {
            if (this.data.unlockSecret == encryptedUnlockSecret)
            {
                return GetPasswordFromDynamicWithException(serviceName).password;
            }      
            else
            {
                throw new Exception("Unlock secret does not match");
            }
        }

        public void AddPassword(string serviceName, string encryptedServicePassword) {
            var existingService = GetPasswordFromDynamic(serviceName);

            if (existingService != null)
            {
                throw new Exception("Service: " + serviceName + " already exists");
            }

            this.data.passwords.Add(new PasswordData {
                serviceName = serviceName,
                password = encryptedServicePassword
            });
            SaveFile();
        }

        public void UpdatePassword(string serviceName, string encryptedServicePassword, string encryptedUnlockSecret) {
            throw new NotImplementedException();            
        }

        public void DeletePassword(string serviceName, string encryptedUnlockSecret)  {
            throw new NotImplementedException();            
        }

        public dynamic GetPasswordFromDynamic(string serviceName)
        {
            foreach (var service in this.data.passwords)
            {
                if (service.serviceName == serviceName)
                {
                    return service;
                }
            }

            return null;
        }

        public dynamic GetPasswordFromDynamicWithException(string serviceName)
        {
            var service = GetPasswordFromDynamic(serviceName);
            if (service == null) {
                throw new Exception("Service: " + serviceName + " not found");
            }

            return service;
        }

        private string FullFilename
        {
            get 
            {
                return Path.Combine(this.fileDirectory, this.fileName);                
            }
        }

        private void OpenFile() 
        {
            var fileContent = System.IO.File.ReadAllText(this.FullFilename);
            this.data = JsonConvert.DeserializeObject<StorageData>(fileContent);
        }

        private void SaveFile() 
        {
            var jsonString = JsonConvert.SerializeObject(this.data);
            System.IO.File.WriteAllText(this.FullFilename, jsonString);
        }
    }
}
