import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AgentGroupTypeCreateDto {
  name: string;
  description?: string;
}

export interface AgentGroupTypeDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface AgentGroupTypeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface AgentGroupTypeUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface AgentPermissionTypeCreateDto {
  name: string;
  description?: string;
}

export interface AgentPermissionTypeDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface AgentPermissionTypeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface AgentPermissionTypeUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface AgentVoucherTypeCreateDto {
  name: string;
  description?: string;
}

export interface AgentVoucherTypeDto extends FullAuditedEntityDto<number> {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface AgentVoucherTypeExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
}

export interface AgentVoucherTypeUpdateDto {
  name: string;
  description?: string;
  concurrencyStamp?: string;
}

export interface GetAgentGroupTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface GetAgentPermissionTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}

export interface GetAgentVoucherTypesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
}
