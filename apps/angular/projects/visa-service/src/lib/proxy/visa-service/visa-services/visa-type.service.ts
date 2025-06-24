import type {
  GetVisaTypesInput,
  VisaTypeCreateDto,
  VisaTypeDto,
  VisaTypeExcelDownloadDto,
  VisaTypeUpdateDto,
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
export class VisaTypeService {
  apiName = 'VisaService';

  create = (input: VisaTypeCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VisaTypeDto>(
      {
        method: 'POST',
        url: '/api/visa/visa-types',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/visa/visa-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetVisaTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/visa/visa-types/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          subCategory: input.subCategory,
          visaPurpose: input.visaPurpose,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (visaTypeIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/visa/visa-types',
        params: { visaTypeIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VisaTypeDto>(
      {
        method: 'GET',
        url: `/api/visa/visa-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/visa/visa-types/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/visa/visa-types/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetVisaTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<VisaTypeDto>>(
      {
        method: 'GET',
        url: '/api/visa/visa-types',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          subCategory: input.subCategory,
          visaPurpose: input.visaPurpose,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: VisaTypeExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/visa/visa-types/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          subCategory: input.subCategory,
          visaPurpose: input.visaPurpose,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: VisaTypeUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VisaTypeDto>(
      {
        method: 'PUT',
        url: `/api/visa/visa-types/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/visa/visa-types/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
