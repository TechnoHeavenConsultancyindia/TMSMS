using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TMSMS.TransferService.TransferServices
{
    public abstract class TransferTypeCreateDtoBase
    {
        [Required]
        [StringLength(TransferTypeConsts.NameMaxLength)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}