using StackExchange.Redis;
using System.Collections.Generic;

namespace Core.CrossCuttingConcerns.Caching.Redis
{

    public class RedisServer
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisServer(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect(($"{_host}:{_port}"));
        public IDatabase GetDb() => _connectionMultiplexer.GetDatabase();
        public IEnumerable<RedisKey> GetKeys() => _connectionMultiplexer.GetServer($"{_host}:{_port}").Keys();


    }
}
