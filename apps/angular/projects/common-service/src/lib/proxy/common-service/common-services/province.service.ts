import type {
  GetProvincesInput,
  ProvinceCreateDto,
  ProvinceDto,
  ProvinceExcelDownloadDto,
  ProvinceUpdateDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type {
  AppFileDescriptorDto,
  DownloadTokenResultDto,
  GetFileInput,
} from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ProvinceService {
  apiName = 'CommonService';

  create = (input: ProvinceCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProvinceDto>(
      {
        method: 'POST',
        url: '/api/common/provinces',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/common/provinces/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetProvincesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/provinces/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          locationId: input.locationId,
          name: input.name,
          fullName: input.fullName,
          descriptor: input.descriptor,
          iataAirportCode: input.iataAirportCode,
          iataAirportMetroCode: input.iataAirportMetroCode,
          countrySubdivisionCode: input.countrySubdivisionCode,
          latitude: input.latitude,
          longitude: input.longitude,
          polygonType: input.polygonType,
          countryCode: input.countryCode,
          categories: input.categories,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (provinceIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/provinces',
        params: { provinceIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProvinceDto>(
      {
        method: 'GET',
        url: `/api/common/provinces/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/common/provinces/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/provinces/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetProvincesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ProvinceDto>>(
      {
        method: 'GET',
        url: '/api/common/provinces',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          locationId: input.locationId,
          name: input.name,
          fullName: input.fullName,
          descriptor: input.descriptor,
          iataAirportCode: input.iataAirportCode,
          iataAirportMetroCode: input.iataAirportMetroCode,
          countrySubdivisionCode: input.countrySubdivisionCode,
          latitude: input.latitude,
          longitude: input.longitude,
          polygonType: input.polygonType,
          countryCode: input.countryCode,
          categories: input.categories,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: ProvinceExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/provinces/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          locationId: input.locationId,
          name: input.name,
          fullName: input.fullName,
          descriptor: input.descriptor,
          iataAirportCode: input.iataAirportCode,
          iataAirportMetroCode: input.iataAirportMetroCode,
          countrySubdivisionCode: input.countrySubdivisionCode,
          latitude: input.latitude,
          longitude: input.longitude,
          polygonType: input.polygonType,
          countryCode: input.countryCode,
          categories: input.categories,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: ProvinceUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProvinceDto>(
      {
        method: 'PUT',
        url: `/api/common/provinces/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/common/provinces/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
