using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using TMSMS.CommonService.Permissions;
using TMSMS.CommonService.CommonServices;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    [RemoteService(IsEnabled = false)]
    [Authorize(CommonServicePermissions.WeekDays.Default)]
    public abstract class WeekDaysAppServiceBase : ApplicationService
    {
        protected IDistributedCache<WeekDayDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IWeekDayRepository _weekDayRepository;
        protected WeekDayManager _weekDayManager;

        public WeekDaysAppServiceBase(IWeekDayRepository weekDayRepository, WeekDayManager weekDayManager, IDistributedCache<WeekDayDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _weekDayRepository = weekDayRepository;
            _weekDayManager = weekDayManager;

        }

        public virtual async Task<PagedResultDto<WeekDayDto>> GetListAsync(GetWeekDaysInput input)
        {
            var totalCount = await _weekDayRepository.GetCountAsync(input.FilterText, input.Name, input.DayAbbreviation, input.IsWeekend, input.DisplayOrderMin, input.DisplayOrderMax);
            var items = await _weekDayRepository.GetListAsync(input.FilterText, input.Name, input.DayAbbreviation, input.IsWeekend, input.DisplayOrderMin, input.DisplayOrderMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<WeekDayDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<WeekDay>, List<WeekDayDto>>(items)
            };
        }

        public virtual async Task<WeekDayDto> GetAsync(int id)
        {
            return ObjectMapper.Map<WeekDay, WeekDayDto>(await _weekDayRepository.GetAsync(id));
        }

        [Authorize(CommonServicePermissions.WeekDays.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _weekDayRepository.DeleteAsync(id);
        }

        [Authorize(CommonServicePermissions.WeekDays.Create)]
        public virtual async Task<WeekDayDto> CreateAsync(WeekDayCreateDto input)
        {

            var weekDay = await _weekDayManager.CreateAsync(
            input.Name, input.DayAbbreviation, input.IsWeekend, input.DisplayOrder
            );

            return ObjectMapper.Map<WeekDay, WeekDayDto>(weekDay);
        }

        [Authorize(CommonServicePermissions.WeekDays.Edit)]
        public virtual async Task<WeekDayDto> UpdateAsync(int id, WeekDayUpdateDto input)
        {

            var weekDay = await _weekDayManager.UpdateAsync(
            id,
            input.Name, input.DayAbbreviation, input.IsWeekend, input.DisplayOrder, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<WeekDay, WeekDayDto>(weekDay);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(WeekDayExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _weekDayRepository.GetListAsync(input.FilterText, input.Name, input.DayAbbreviation, input.IsWeekend, input.DisplayOrderMin, input.DisplayOrderMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<WeekDay>, List<WeekDayExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "WeekDays.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(CommonServicePermissions.WeekDays.Delete)]
        public virtual async Task DeleteByIdsAsync(List<int> weekdayIds)
        {
            await _weekDayRepository.DeleteManyAsync(weekdayIds);
        }

        [Authorize(CommonServicePermissions.WeekDays.Delete)]
        public virtual async Task DeleteAllAsync(GetWeekDaysInput input)
        {
            await _weekDayRepository.DeleteAllAsync(input.FilterText, input.Name, input.DayAbbreviation, input.IsWeekend, input.DisplayOrderMin, input.DisplayOrderMax);
        }
        public virtual async Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new WeekDayDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new TMSMS.CommonService.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}