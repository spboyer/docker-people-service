using System;
using Microsoft.Framework.Caching.Memory;

namespace docker_people_service.Core
{
    public interface IPeopleCacheService
    {
        PersonMajor[] GetPeople();
        void SavePeople(object people);
        string GetServiceGUID();

    }
    public class PeopleCacheService : IPeopleCacheService
    {
        private const string _key = "people";
        private IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        public PeopleCacheService()
        {

        }

        public PersonMajor[] GetPeople()
        {
            object result;
            result = cache.Get(_key);
            if (result != null)
            {
                return (PersonMajor[])result;
            }
            return null;
        }

        public void SavePeople(object people)
        {
            object result;
            result = cache.Set(
                            _key,
                            people,
                            new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                            .SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddMinutes(10)));
        }

        public string GetServiceGUID()
        {
            var service_key = "service_guid";
            object guid = cache.Get(service_key);
            if (guid == null)
            {
                guid = Guid.NewGuid();
                cache.Set(
                            service_key,
                            guid,
                            new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                            .SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddMinutes(10)));
            }

            return guid.ToString();
        }
    }
}
