using Volo.Abp.Application.Dtos;
using System;

namespace TMSMS.TransferService.TransferServices
{
    public abstract class GetTransferTypesInputBase : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public GetTransferTypesInputBase()
        {

        }
    }
}