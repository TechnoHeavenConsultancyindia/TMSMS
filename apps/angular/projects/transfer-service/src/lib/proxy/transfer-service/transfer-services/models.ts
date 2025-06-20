import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetTransferTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface TransferTypeCreateDto {
  name: string;
  description?: string;
}

export interface TransferTypeDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface TransferTypeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface TransferTypeUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}
