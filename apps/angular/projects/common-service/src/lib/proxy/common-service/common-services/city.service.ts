import type {
  CityCreateDto,
  CityDto,
  CityExcelDownloadDto,
  CityUpdateDto,
  GetCitiesInput,
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
export class CityService {
  apiName = 'CommonService';

  create = (input: CityCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CityDto>(
      {
        method: 'POST',
        url: '/api/common/cities',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/common/cities/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetCitiesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/cities/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          locationId: input.locationId,
          name: input.name,
          fullName: input.fullName,
          latitude: input.latitude,
          longitude: input.longitude,
          countryCode: input.countryCode,
          countrySubdivisionCode: input.countrySubdivisionCode,
          iataAirportCode: input.iataAirportCode,
          iataAirportMetroCode: input.iataAirportMetroCode,
          polygonType: input.polygonType,
          categories: input.categories,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
          descriptor: input.descriptor,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (cityIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/cities',
        params: { cityIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CityDto>(
      {
        method: 'GET',
        url: `/api/common/cities/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/common/cities/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/cities/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetCitiesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CityDto>>(
      {
        method: 'GET',
        url: '/api/common/cities',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          locationId: input.locationId,
          name: input.name,
          fullName: input.fullName,
          latitude: input.latitude,
          longitude: input.longitude,
          countryCode: input.countryCode,
          countrySubdivisionCode: input.countrySubdivisionCode,
          iataAirportCode: input.iataAirportCode,
          iataAirportMetroCode: input.iataAirportMetroCode,
          polygonType: input.polygonType,
          categories: input.categories,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
          descriptor: input.descriptor,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: CityExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/cities/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          locationId: input.locationId,
          name: input.name,
          fullName: input.fullName,
          latitude: input.latitude,
          longitude: input.longitude,
          countryCode: input.countryCode,
          countrySubdivisionCode: input.countrySubdivisionCode,
          iataAirportCode: input.iataAirportCode,
          iataAirportMetroCode: input.iataAirportMetroCode,
          polygonType: input.polygonType,
          categories: input.categories,
          tags: input.tags,
          statusFlagMin: input.statusFlagMin,
          statusFlagMax: input.statusFlagMax,
          descriptor: input.descriptor,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: CityUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CityDto>(
      {
        method: 'PUT',
        url: `/api/common/cities/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/common/cities/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
