using FreeCourse.Services.Basket.Settings;
using StackExchange.Redis;

namespace FreeCourse.Services.Basket.Services
{
    public class RedisService
    {
        private readonly RedisSetting _redisSetting;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(RedisSetting redisSetting)
        {
            _redisSetting = redisSetting;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_redisSetting.Host}:{_redisSetting.Port}");

        public IDatabase GetDb(int db=1)=> _connectionMultiplexer.GetDatabase(db);
    }
}
