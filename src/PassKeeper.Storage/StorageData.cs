using System.Collections.Generic;

namespace PassKeeper.Storage {
    public class StorageData {
        public string unlockSecret { get; set; }

        public List<PasswordData> passwords { get; set; }
    }
}
