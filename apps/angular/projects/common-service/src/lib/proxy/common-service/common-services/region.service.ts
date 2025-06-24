import type {
  GetRegionsInput,
  RegionCreateDto,
  RegionDto,
  RegionExcelDownloadDto,
  RegionUpdateDto,
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
export class RegionService {
  apiName = 'CommonService';

  create = (input: RegionCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RegionDto>(
      {
        method: 'POST',
        url: '/api/common/regions',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/common/regions/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetRegionsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/regions/all',
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
          categories: input.categories,
          countryCode: input.countryCode,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (regionIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/regions',
        params: { regionIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RegionDto>(
      {
        method: 'GET',
        url: `/api/common/regions/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/common/regions/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/regions/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetRegionsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<RegionDto>>(
      {
        method: 'GET',
        url: '/api/common/regions',
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
          categories: input.categories,
          countryCode: input.countryCode,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: RegionExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/regions/as-excel-file',
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
          categories: input.categories,
          countryCode: input.countryCode,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: RegionUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RegionDto>(
      {
        method: 'PUT',
        url: `/api/common/regions/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/common/regions/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
