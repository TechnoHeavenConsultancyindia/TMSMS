import type {
  GetVisaDiscountCategoriesInput,
  VisaDiscountCategoryCreateDto,
  VisaDiscountCategoryDto,
  VisaDiscountCategoryExcelDownloadDto,
  VisaDiscountCategoryUpdateDto,
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
export class VisaDiscountCategoryService {
  apiName = 'VisaService';

  create = (input: VisaDiscountCategoryCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VisaDiscountCategoryDto>(
      {
        method: 'POST',
        url: '/api/visa/visa-discount-categories',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/visa/visa-discount-categories/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetVisaDiscountCategoriesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/visa/visa-discount-categories/all',
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

  deleteByIds = (visaDiscountCategoryIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/visa/visa-discount-categories',
        params: { visaDiscountCategoryIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VisaDiscountCategoryDto>(
      {
        method: 'GET',
        url: `/api/visa/visa-discount-categories/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/visa/visa-discount-categories/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/visa/visa-discount-categories/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetVisaDiscountCategoriesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<VisaDiscountCategoryDto>>(
      {
        method: 'GET',
        url: '/api/visa/visa-discount-categories',
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
    input: VisaDiscountCategoryExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/visa/visa-discount-categories/as-excel-file',
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
    input: VisaDiscountCategoryUpdateDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, VisaDiscountCategoryDto>(
      {
        method: 'PUT',
        url: `/api/visa/visa-discount-categories/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/visa/visa-discount-categories/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
