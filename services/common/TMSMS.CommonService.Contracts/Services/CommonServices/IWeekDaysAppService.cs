using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using TMSMS.CommonService.Shared;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface IWeekDaysAppService : IApplicationService
    {

        Task<PagedResultDto<WeekDayDto>> GetListAsync(GetWeekDaysInput input);

        Task<WeekDayDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<WeekDayDto> CreateAsync(WeekDayCreateDto input);

        Task<WeekDayDto> UpdateAsync(int id, WeekDayUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(WeekDayExcelDownloadDto input);
        Task DeleteByIdsAsync(List<int> weekdayIds);

        Task DeleteAllAsync(GetWeekDaysInput input);
        Task<TMSMS.CommonService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}