import type {
  GetRestaurantTagsInput,
  RestaurantTagCreateDto,
  RestaurantTagDto,
  RestaurantTagExcelDownloadDto,
  RestaurantTagUpdateDto,
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
export class RestaurantTagService {
  apiName = 'RestaurantService';

  create = (input: RestaurantTagCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantTagDto>(
      {
        method: 'POST',
        url: '/api/restaurant/restaurant-tags',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/restaurant/restaurant-tags/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetRestaurantTagsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/restaurant/restaurant-tags/all',
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

  deleteByIds = (restaurantTagIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/restaurant/restaurant-tags',
        params: { restaurantTagIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantTagDto>(
      {
        method: 'GET',
        url: `/api/restaurant/restaurant-tags/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/restaurant/restaurant-tags/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/restaurant/restaurant-tags/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetRestaurantTagsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<RestaurantTagDto>>(
      {
        method: 'GET',
        url: '/api/restaurant/restaurant-tags',
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
    input: RestaurantTagExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/restaurant/restaurant-tags/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: RestaurantTagUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RestaurantTagDto>(
      {
        method: 'PUT',
        url: `/api/restaurant/restaurant-tags/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/restaurant/restaurant-tags/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
