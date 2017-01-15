using PassKeeper.Storage;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace PassKeeper.MongoDb {
    public class ProfileData {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("profileName")]
        public string ProfileName { get; set; }
        [BsonElement("unlockSecret")]
        public string UnlockSecret { get; set; }
        [BsonElement("passwords")]
        public List<PasswordData> Passwords { get; set; }
    }
}
