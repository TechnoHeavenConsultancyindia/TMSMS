import type {
  AgentGroupTypeCreateDto,
  AgentGroupTypeDto,
  AgentGroupTypeExcelDownloadDto,
  AgentGroupTypeUpdateDto,
  GetAgentGroupTypesInput,
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
export class AgentGroupTypeService {
  apiName = 'AgentService';

  create = (input: AgentGroupTypeCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AgentGroupTypeDto>(
      {
        method: 'POST',
        url: '/api/agent/agent-group-types',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/agent/agent-group-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetAgentGroupTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/agent/agent-group-types/all',
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

  deleteByIds = (agentGroupTypeIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/agent/agent-group-types',
        params: { agentGroupTypeIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AgentGroupTypeDto>(
      {
        method: 'GET',
        url: `/api/agent/agent-group-types/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/agent/agent-group-types/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/agent/agent-group-types/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetAgentGroupTypesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<AgentGroupTypeDto>>(
      {
        method: 'GET',
        url: '/api/agent/agent-group-types',
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
    input: AgentGroupTypeExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/agent/agent-group-types/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          description: input.description,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: AgentGroupTypeUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AgentGroupTypeDto>(
      {
        method: 'PUT',
        url: `/api/agent/agent-group-types/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/agent/agent-group-types/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
