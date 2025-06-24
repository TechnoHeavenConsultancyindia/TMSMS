import type {
  GetRestaurantTypesInput,
  RestaurantTypeCreateDto,
  RestaurantTypeDto,
  RestaurantTypeExcelDownloadDto,
  RestaurantTypeUpdateDto,
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
export class RestaurantTypeService {
  apiName = 'RestaurantService';

  create = (input: RestaurantTypeCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantTypeDto>(
      {
        method: 'POST',
        url: '/api/restaurant/restaurant-types',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/restaurant/restaurant-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetRestaurantTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/restaurant/restaurant-types/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (restaurantTypeIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/restaurant/restaurant-types',
        params: { restaurantTypeIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantTypeDto>(
      {
        method: 'GET',
        url: `/api/restaurant/restaurant-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/restaurant/restaurant-types/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/restaurant/restaurant-types/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetRestaurantTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<RestaurantTypeDto>>(
      {
        method: 'GET',
        url: '/api/restaurant/restaurant-types',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (
    input: RestaurantTypeExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/restaurant/restaurant-types/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: RestaurantTypeUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantTypeDto>(
      {
        method: 'PUT',
        url: `/api/restaurant/restaurant-types/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/restaurant/restaurant-types/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
