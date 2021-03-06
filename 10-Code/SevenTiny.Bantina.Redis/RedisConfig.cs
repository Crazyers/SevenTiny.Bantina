﻿/*********************************************************
 * CopyRight: 7TINY CODE BUILDER. 
 * Version: 5.0.0
 * Author: 7tiny
 * Address: Earth
 * Create: 2018-02-27 19:23:12
 * Modify: 2018-02-27 19:23:12
 * E-mail: dong@7tiny.com | sevenTiny@foxmail.com 
 * GitHub: https://github.com/sevenTiny 
 * Personal web site: http://www.7tiny.com 
 * Technical WebSit: http://www.cnblogs.com/7tiny/ 
 * Description: 
 * Thx , Best Regards ~
 *********************************************************/
using SevenTiny.Bantina.Configuration;
using SevenTiny.Bantina.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenTiny.Bantina.Redis
{
    [ConfigClass(Name = "Redis")]
    internal class RedisConfig : ConfigBase<RedisConfig>
    {
        public int ID { get; set; }
        public string InstanceName { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }

        private static Dictionary<int, RedisConfig> dictionary;

        private static void Initial()
        {
            dictionary = new Dictionary<int, RedisConfig>();
            foreach (var item in Configs)
            {
                dictionary.AddOrUpdate(item.ID, item);
            }
        }

        public static RedisConfig Get(int key)
        {
            if (dictionary != null && dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            Initial();
            return dictionary.SafeGet(key);
        }

        /// <summary>
        /// if redis config only 1 line,means the first config is default.
        /// </summary>
        public static RedisConfig Default => Configs.FirstOrDefault() ?? throw new NullReferenceException("Redis Config Empty!");
    }
}
