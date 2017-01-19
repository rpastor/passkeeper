using System;
using Microsoft.AspNetCore.Mvc;
using PassKeeper;
using PassKeeper.Storage;
using PassKeeper.MongoDb;

namespace PassKeeper
{
    [Route("api/passwords")]
    public class PKController : Controller
    {
        [Route("")]
        [HttpGet]
        public string[] GetPasswords()
        {
            var passKeeper = GetPassKeeper();
            return passKeeper.GetPasswordList();
        }

        [Route("{serviceName}")]
        [HttpGet]
        public string GetPassword(string serviceName, string uk)
        {
            var passKeeper = GetPassKeeper();
            return passKeeper.GetPassword(serviceName, uk);
        }

        [Route("")]
        [HttpPost]
        public void PostPassword([FromBody]PasswordData pwData)
        {
            var passKeeper = GetPassKeeper();
            passKeeper.AddPassword(pwData.serviceName, pwData.password);
        }

        [Route("{serviceName}")]
        [HttpPut]
        public void PutPassword(string serviceName, [FromBody]PasswordData pwData, string uk)
        {
            var passKeeper = GetPassKeeper();
            passKeeper.UpdatePassword(pwData.serviceName, pwData.password, uk);
        }

        [Route("{serviceName}")]
        [HttpDelete]
        public void DeletePassword(string serviceName, string uk)
        {
            var passKeeper = GetPassKeeper();
            passKeeper.DeletePassword(serviceName, uk);
        }

        [Route("loginName/{serviceName}")]
        [HttpGet]
        public string GetLoginName(string serviceName, string uk)
        {
            var passKeeper = GetPassKeeper();
            return passKeeper.GetLoginName(serviceName, uk);
        }

        [Route("sqa/{serviceName}")]
        [HttpGet]
        public string[] GetSecurityQuestionAnswers(string serviceName, string uk)
        {
            var passKeeper = GetPassKeeper();
            return passKeeper.GetSecurityQuestionAnswers(serviceName, uk);
        }

        private PassKeeper GetPassKeeper()
        {
//            var storage = new FileStorage();
            var storage = new MongoStorage();
            return new PassKeeper(storage);
        }
    }
}