using System.Collections.Generic;

namespace PassKeeper {
    public class StorageData {
        public string unlockSecret { get; set; }

        public List<PasswordData> passwords { get; set; }
    }

    public class PasswordData {
        public string serviceName { get; set; }
        public string password { get; set; }
    }
}
