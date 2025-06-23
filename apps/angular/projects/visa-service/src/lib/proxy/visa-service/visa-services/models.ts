import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetVisaDiscountCategoriesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface GetVisaTermCategoriesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface GetVisaTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  subCategory?: string;
  visaPurpose?: string;
  description?: string;
}

export interface VisaDiscountCategoryCreateDto {
  name: string;
  description?: string;
}

export interface VisaDiscountCategoryDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface VisaDiscountCategoryExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface VisaDiscountCategoryUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface VisaTermCategoryCreateDto {
  name?: string;
  description?: string;
}

export interface VisaTermCategoryDto extends FullAuditedEntityDto<number> {
  name?: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface VisaTermCategoryExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface VisaTermCategoryUpdateDto {
  name?: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface VisaTypeCreateDto {
  name: string;
  subCategory?: string;
  visaPurpose?: string;
  description?: string;
}

export interface VisaTypeDto extends FullAuditedEntityDto<number> {
  name: string;
  subCategory?: string;
  visaPurpose?: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface VisaTypeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  subCategory?: string;
  visaPurpose?: string;
  description?: string;
}

export interface VisaTypeUpdateDto {
  name: string;
  subCategory?: string;
  visaPurpose?: string;
  description?: string;
  concurrencyStamp?: string;
}
