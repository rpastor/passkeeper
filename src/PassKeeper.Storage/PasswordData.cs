using System.Collections.Generic;

namespace PassKeeper.Storage {
    public class PasswordData {
        public string serviceName { get; set; }
        public string password { get; set; }
        public string loginName { get; set; }
        public string passwordHint { get; set; }
        public List<string> securityQuestionAnswers { get; set; }
    }
}
