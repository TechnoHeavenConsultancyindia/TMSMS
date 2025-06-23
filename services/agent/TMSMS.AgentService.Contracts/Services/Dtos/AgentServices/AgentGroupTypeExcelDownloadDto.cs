using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.AgentService.AgentServices
{
    public abstract class AgentGroupTypeExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public AgentGroupTypeExcelDownloadDtoBase()
        {

        }
    }
}