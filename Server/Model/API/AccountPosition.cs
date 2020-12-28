﻿using System;
using System.Runtime.Serialization;

namespace Model.API
{
    [DataContract]
    public class AccountPosition
    {
        public int account_id { get; set; }

        [DataMember]
        public string account_name { get; set; }

        [DataMember]
        public string code { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int count_in { get; set; }

        [DataMember]
        public int count { get; set; }
    }
}