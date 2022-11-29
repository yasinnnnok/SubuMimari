﻿using MongoDB.Bson;

namespace SUBU.Core.Extensions
{
    public static class StringExtensions
    {
        public static ObjectId ToObjectId(this string s)
        {
            return ObjectId.Parse(s);
        }
    }
}
