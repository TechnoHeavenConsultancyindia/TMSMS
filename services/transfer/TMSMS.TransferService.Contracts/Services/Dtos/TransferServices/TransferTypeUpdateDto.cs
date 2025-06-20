using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace TMSMS.TransferService.TransferServices
{
    public abstract class TransferTypeUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(TransferTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}