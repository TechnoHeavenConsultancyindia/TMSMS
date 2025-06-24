import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetRestaurantCuisinesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface GetRestaurantDietaryTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface GetRestaurantTagsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface GetRestaurantTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface RestaurantCuisineCreateDto {
  name: string;
  description?: string;
}

export interface RestaurantCuisineDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface RestaurantCuisineExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface RestaurantCuisineUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface RestaurantDietaryTypeCreateDto {
  name: string;
  description?: string;
}

export interface RestaurantDietaryTypeDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface RestaurantDietaryTypeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface RestaurantDietaryTypeUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface RestaurantTagCreateDto {
  name: string;
  description?: string;
}

export interface RestaurantTagDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface RestaurantTagExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface RestaurantTagUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
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
