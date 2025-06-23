import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetRestaurantTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface RestaurantTypeCreateDto {
  name: string;
  description?: string;
}

export interface RestaurantTypeDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface RestaurantTypeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface RestaurantTypeUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}
