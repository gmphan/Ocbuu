using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;

namespace Ocbuu.Services
{
    public class ResumerServices : IResumeServices
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMemoryCache _memoryCache;
        public ResumerServices(ILogger<ResumerServices> logger
                            , IUnityOfWork unityOfWork
                            , IMemoryCache memoryCache)
        {
            _logger = logger;
            _unityOfWork = unityOfWork;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<ResumeExperience>> GetAllResumeExperienceAsync()
        {
            return await GetTAsync("resumeExperience", () => _unityOfWork.ResumeExperience.GetAll());
            
        }

        public async Task<ResumeHeader> GetLatestResumeHeaderAsync()
        {
            
            return await GetTAsync("resumeHeaders", () => _unityOfWork.ResumeHeader.GetLatestRecord(x => x.Id));
        }

        public async Task<ResumeSummary> GetLatestResumeSummaryAsync()
        {
            return await GetTAsync("resumeSummary", () => _unityOfWork.ResumeSummary.GetLatestRecord(x => x.Id));
        }

        public async Task<T> GetTAsync<T>(string cacheKey, Func<T> getRecordFromDb) where T : class
        {
            if(!_memoryCache.TryGetValue(cacheKey, out T record))
            {
                _logger.LogInformation("Querying data from PgDb.");

                // Data not found in cache, retrieve data from db then
                record = getRecordFromDb();

                // Set the data to memory cache
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                                        .SetSlidingExpiration(TimeSpan.FromMinutes(15)) // Cache will expire if not accessed for 15 minute
                                        .SetAbsoluteExpiration(TimeSpan.FromHours(6));  // Cache will expire after 6 hours

                // Set data to cache
                _memoryCache.Set(cacheKey, record, cacheEntryOptions);
            }
            else
            {
                _logger.LogInformation($"Data was pulled from Memory Cache: {cacheKey}");
            }
            return record;
        }
    }
}