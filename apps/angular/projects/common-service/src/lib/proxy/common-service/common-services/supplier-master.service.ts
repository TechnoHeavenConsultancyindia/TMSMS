import type {
  GetSupplierMastersInput,
  SupplierMasterCreateDto,
  SupplierMasterDto,
  SupplierMasterExcelDownloadDto,
  SupplierMasterUpdateDto,
  SupplierMasterWithNavigationPropertiesDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type {
  AppFileDescriptorDto,
  DownloadTokenResultDto,
  GetFileInput,
  LookupDto,
  LookupRequestDto,
} from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class SupplierMasterService {
  apiName = 'CommonService';

  create = (input: SupplierMasterCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierMasterDto>(
      {
        method: 'POST',
        url: '/api/common/supplier-masters',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/common/supplier-masters/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetSupplierMastersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/supplier-masters/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          type: input.type,
          contactName: input.contactName,
          contactEmail: input.contactEmail,
          dialCode: input.dialCode,
          contactPhone: input.contactPhone,
          supplierStatusMin: input.supplierStatusMin,
          supplierStatusMax: input.supplierStatusMax,
          preffered: input.preffered,
          countryId: input.countryId,
          supplierServiceTypeId: input.supplierServiceTypeId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (supplierMasterIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/supplier-masters',
        params: { supplierMasterIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierMasterDto>(
      {
        method: 'GET',
        url: `/api/common/supplier-masters/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getCountryLookup = (input: LookupRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/common/supplier-masters/country-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/common/supplier-masters/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/supplier-masters/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetSupplierMastersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<
      any,
      PagedResultDto<SupplierMasterWithNavigationPropertiesDto>
    >(
      {
        method: 'GET',
        url: '/api/common/supplier-masters',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          type: input.type,
          contactName: input.contactName,
          contactEmail: input.contactEmail,
          dialCode: input.dialCode,
          contactPhone: input.contactPhone,
          supplierStatusMin: input.supplierStatusMin,
          supplierStatusMax: input.supplierStatusMax,
          preffered: input.preffered,
          countryId: input.countryId,
          supplierServiceTypeId: input.supplierServiceTypeId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (
    input: SupplierMasterExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/supplier-masters/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          type: input.type,
          contactName: input.contactName,
          contactEmail: input.contactEmail,
          dialCode: input.dialCode,
          contactPhone: input.contactPhone,
          supplierStatusMin: input.supplierStatusMin,
          supplierStatusMax: input.supplierStatusMax,
          preffered: input.preffered,
          countryId: input.countryId,
          supplierServiceTypeId: input.supplierServiceTypeId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getSupplierServiceTypeLookup = (
    input: LookupRequestDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/common/supplier-masters/supplier-service-type-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getWithNavigationProperties = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierMasterWithNavigationPropertiesDto>(
      {
        method: 'GET',
        url: `/api/common/supplier-masters/with-navigation-properties/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: SupplierMasterUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SupplierMasterDto>(
      {
        method: 'PUT',
        url: `/api/common/supplier-masters/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/common/supplier-masters/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
