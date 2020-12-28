﻿using Model.Common;
using Model.Enum;
using System;
using System.Runtime.Serialization;

namespace Model.DB
{
    [DataContract]
    public class Position : Base
    {
        [DataMember]
        public int count { get; set; }

        [DataMember]
        public decimal price_cost { get; set; }

        public decimal price_latest { get; set; }

        [DataMember]
        public int unit_id { get; set; }

        [DataMember]
        public int account_id { get; set; }

        public int block { get; set; }

        [DataMember]
        public string account_name { get; set; }

        [DataMember]
        public string unit_name { get; set; }

        [DataMember]
        [UnValue]
        public int count_sellable { get; set; }

        [DataMember]
        [UnValue]
        public int count_today_buy { get; set; }

        [DataMember]
        [UnValue]
        public int count_today_sell { get; set; }

        [DataMember]
        [UnValue]
        public decimal price_cost_today_buy { get; set; }

        [DataMember]
        [UnValue]
        public decimal price_cost_today_sell { get; set; }

        [UnValue]
        public BlockEnum block_enum
        {
            get { return (BlockEnum)block; }
            set { block = (int)value; }
        }
    }
}