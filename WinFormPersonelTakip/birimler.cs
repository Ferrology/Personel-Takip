using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WinFormPersonelTakip
{
    class birimler
    {

        [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("birim")]
        public int birim { get; set; }


    }
}
