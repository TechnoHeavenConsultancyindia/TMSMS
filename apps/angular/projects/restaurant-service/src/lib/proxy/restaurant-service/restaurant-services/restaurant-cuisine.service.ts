import type {
  GetRestaurantCuisinesInput,
  RestaurantCuisineCreateDto,
  RestaurantCuisineDto,
  RestaurantCuisineExcelDownloadDto,
  RestaurantCuisineUpdateDto,
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
export class RestaurantCuisineService {
  apiName = 'RestaurantService';

  create = (input: RestaurantCuisineCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantCuisineDto>(
      {
        method: 'POST',
        url: '/api/restaurant/restaurant-cuisines',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/restaurant/restaurant-cuisines/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetRestaurantCuisinesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/restaurant/restaurant-cuisines/all',
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

  deleteByIds = (restaurantCuisineIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/restaurant/restaurant-cuisines',
        params: { restaurantCuisineIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantCuisineDto>(
      {
        method: 'GET',
        url: `/api/restaurant/restaurant-cuisines/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/restaurant/restaurant-cuisines/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/restaurant/restaurant-cuisines/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetRestaurantCuisinesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<RestaurantCuisineDto>>(
      {
        method: 'GET',
        url: '/api/restaurant/restaurant-cuisines',
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
    input: RestaurantCuisineExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/restaurant/restaurant-cuisines/as-excel-file',
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
    input: RestaurantCuisineUpdateDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, RestaurantCuisineDto>(
      {
        method: 'PUT',
        url: `/api/restaurant/restaurant-cuisines/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/restaurant/restaurant-cuisines/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
