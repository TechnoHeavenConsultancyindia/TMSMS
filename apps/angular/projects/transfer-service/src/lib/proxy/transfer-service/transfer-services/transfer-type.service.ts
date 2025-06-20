import type {
  GetTransferTypesInput,
  TransferTypeCreateDto,
  TransferTypeDto,
  TransferTypeExcelDownloadDto,
  TransferTypeUpdateDto,
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
export class TransferTypeService {
  apiName = 'TransferService';

  create = (input: TransferTypeCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TransferTypeDto>(
      {
        method: 'POST',
        url: '/api/transfer/transfer-types',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/transfer/transfer-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetTransferTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/transfer/transfer-types/all',
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

  deleteByIds = (transferTypeIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/transfer/transfer-types',
        params: { transferTypeIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TransferTypeDto>(
      {
        method: 'GET',
        url: `/api/transfer/transfer-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/transfer/transfer-types/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/transfer/transfer-types/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetTransferTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<TransferTypeDto>>(
      {
        method: 'GET',
        url: '/api/transfer/transfer-types',
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
    input: TransferTypeExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/transfer/transfer-types/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: TransferTypeUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TransferTypeDto>(
      {
        method: 'PUT',
        url: `/api/transfer/transfer-types/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/transfer/transfer-types/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
