import type {
  GetRestaurantDietaryTypesInput,
  RestaurantDietaryTypeCreateDto,
  RestaurantDietaryTypeDto,
  RestaurantDietaryTypeExcelDownloadDto,
  RestaurantDietaryTypeUpdateDto,
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
export class RestaurantDietaryTypeService {
  apiName = 'RestaurantService';

  create = (input: RestaurantDietaryTypeCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantDietaryTypeDto>(
      {
        method: 'POST',
        url: '/api/restaurant/restaurant-dietary-types',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/restaurant/restaurant-dietary-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetRestaurantDietaryTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/restaurant/restaurant-dietary-types/all',
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

  deleteByIds = (restaurantDietaryTypeIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/restaurant/restaurant-dietary-types',
        params: { restaurantDietaryTypeIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantDietaryTypeDto>(
      {
        method: 'GET',
        url: `/api/restaurant/restaurant-dietary-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/restaurant/restaurant-dietary-types/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/restaurant/restaurant-dietary-types/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetRestaurantDietaryTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<RestaurantDietaryTypeDto>>(
      {
        method: 'GET',
        url: '/api/restaurant/restaurant-dietary-types',
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
    input: RestaurantDietaryTypeExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/restaurant/restaurant-dietary-types/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (
    id: number,
    input: RestaurantDietaryTypeUpdateDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, RestaurantDietaryTypeDto>(
      {
        method: 'PUT',
        url: `/api/restaurant/restaurant-dietary-types/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/restaurant/restaurant-dietary-types/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
