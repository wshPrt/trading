﻿using System;

namespace JY
{
    public class OrderItem
    {
        public OrderItem(string data)
        {
            string[] items = data.Split(',');
            if (items.Length == 11)
            {
                code = items[0];
                name = items[1];
                type = items[2];
                price = items[3];
                count = items[4];
                deal_count = items[5];
                cancel_count = "0";
                status = items[6];
                date = items[7];
                time = items[8];
                order_no = items[9];
                request_id = items[10];
            }
        }

        public string code { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string price { get; set; }
        public string count { get; set; }
        public string deal_count { get; set; }
        public string cancel_count
        {
            get
            {
                return status.Contains("撤") ? (decimal.Parse(count) - decimal.Parse(deal_count)).ToString() : "0";
            }
            set { }
        }
        public string status { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string order_no { get; set; }
        public string request_id { get; set; }
    }
}