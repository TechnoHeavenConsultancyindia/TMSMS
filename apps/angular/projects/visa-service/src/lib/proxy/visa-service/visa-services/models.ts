import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetVisaTermCategoriesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
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
