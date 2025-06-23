using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentVoucherTypeExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public AgentVoucherTypeExcelDownloadDtoBase()
        {

        }
    }
}