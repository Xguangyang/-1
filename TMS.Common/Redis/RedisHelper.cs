﻿using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.Redis
{
    public class RedisHelper : IDisposable
    {
        //连接字符串
        public string _connectionString = ConfigHelperRedis._conn;
        //实例名称
        public string _instanceName = ConfigHelperRedis._name;
        //默认数据库
        public int _defaultDB = ConfigHelperRedis._db;

        private ConcurrentDictionary<string, ConnectionMultiplexer> _connections;

        /// <summary>
        /// Redis
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="instanceName">实例名称</param>
        /// <param name="defaultDB">默认数据库</param>
        public RedisHelper(/*string connectionString, string instanceName, int defaultDB = 0*/)
        {
            //_connectionString = connectionString;
            //_instanceName = instanceName;
            //_defaultDB = defaultDB;
            _connections = new ConcurrentDictionary<string, ConnectionMultiplexer>();
        }

        /// <summary>
        /// 获取ConnectionMultiplexer  表示与 redis 服务器的关联关联组
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer GetConnect()
        {
            return _connections.GetOrAdd(_instanceName, p => ConnectionMultiplexer.Connect(_connectionString));
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <param name="configName"></param>
        /// <param name="db">默认为0：优先代码的db配置，其次config中的配置</param>
        /// <returns></returns>
        public IDatabase GetDatabase()
        {
            return GetConnect().GetDatabase(_defaultDB);
        }

        public IServer GetServer(string configName = null, int endPointsIndex = 0)
        {
            var confOption = ConfigurationOptions.Parse(_connectionString);
            return GetConnect().GetServer(confOption.EndPoints[endPointsIndex]);
        }

        public ISubscriber GetSubscriber(string configName = null)
        {
            return GetConnect().GetSubscriber();
        }

        public void Dispose()
        {
            if (_connections != null && _connections.Count > 0)
            {
                foreach (var item in _connections.Values)
                {
                    item.Close();
                }
            }
        }



    }
}