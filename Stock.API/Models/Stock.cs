﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stock.API.Models
{
	public class Stock
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
		[BsonElement(Order = 0)]
		public string Id { get; set; }

		[BsonRepresentation(BsonType.Int64)]
		[BsonElement(Order = 1)]
		public int ProductId { get; set; }

        [BsonRepresentation(BsonType.Int64)]
        [BsonElement(Order = 2)]
        public int Count { get; set; }
	}
}

