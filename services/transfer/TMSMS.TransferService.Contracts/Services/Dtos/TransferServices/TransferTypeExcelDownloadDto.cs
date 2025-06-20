using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.TransferService.TransferServices
{
    public abstract class TransferTypeExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public TransferTypeExcelDownloadDtoBase()
        {

        }
    }
}