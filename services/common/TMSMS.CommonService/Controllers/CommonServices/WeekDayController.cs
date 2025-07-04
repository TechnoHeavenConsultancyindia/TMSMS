using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.CommonService.CommonServices;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("WeekDay")]
    [Route("api/common/week-days")]

    public abstract class WeekDayControllerBase : AbpController
    {
        protected IWeekDaysAppService _weekDaysAppService;

        public WeekDayControllerBase(IWeekDaysAppService weekDaysAppService)
        {
            _weekDaysAppService = weekDaysAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<WeekDayDto>> GetListAsync(GetWeekDaysInput input)
        {
            return _weekDaysAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<WeekDayDto> GetAsync(int id)
        {
            return _weekDaysAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<WeekDayDto> CreateAsync(WeekDayCreateDto input)
        {
            return _weekDaysAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<WeekDayDto> UpdateAsync(int id, WeekDayUpdateDto input)
        {
            return _weekDaysAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _weekDaysAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(WeekDayExcelDownloadDto input)
        {
            return _weekDaysAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _weekDaysAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<int> weekdayIds)
        {
            return _weekDaysAppService.DeleteByIdsAsync(weekdayIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetWeekDaysInput input)
        {
            return _weekDaysAppService.DeleteAllAsync(input);
        }
    }
}