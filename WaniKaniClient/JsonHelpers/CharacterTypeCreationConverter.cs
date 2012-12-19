using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaniKaniClient.Models;
using Newtonsoft.Json.Linq;

namespace WaniKaniClient.JsonHelpers
{
    public class CharacterTypeCreationConverter : JsonCreationConverter<BaseCharacter>
    {
        protected override BaseCharacter Create(Type objectType, JObject jObject)
        {
            if (jObject["type"].ToString() == "kanji")
                return new Kanji();
            if (jObject["type"].ToString() == "vocabulary")
                return new Vocabulary();
            if (jObject["type"].ToString() == "radical")
                return new Radical();

            return new BaseCharacter();
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
}
