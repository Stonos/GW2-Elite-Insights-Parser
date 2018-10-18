﻿using System.Runtime.Serialization;

namespace LuckParser.Models.HtmlModels
{
    [DataContract]
    public class FoodDto
    {
        [DataMember] public double time;
        [DataMember] public double duration;
        [DataMember] public long id;
        [DataMember(EmitDefaultValue = false)] public bool dimished;
    }
}
