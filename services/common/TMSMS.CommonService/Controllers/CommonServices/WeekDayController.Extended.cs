using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TMSMS.CommonService.CommonServices;

namespace TMSMS.CommonService.CommonServices
{
    [RemoteService]
    [Area("app")]
    [ControllerName("WeekDay")]
    [Route("api/common/week-days")]

    public class WeekDayController : WeekDayControllerBase, IWeekDaysAppService
    {
        public WeekDayController(IWeekDaysAppService weekDaysAppService) : base(weekDaysAppService)
        {
        }
    }
}