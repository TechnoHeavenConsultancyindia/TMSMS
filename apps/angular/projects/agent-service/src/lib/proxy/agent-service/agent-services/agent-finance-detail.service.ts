import type {
  AgentFinanceDetailCreateDto,
  AgentFinanceDetailDto,
  AgentFinanceDetailExcelDownloadDto,
  AgentFinanceDetailUpdateDto,
  GetAgentFinanceDetailsInput,
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
export class AgentFinanceDetailService {
  apiName = 'AgentService';

  create = (input: AgentFinanceDetailCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AgentFinanceDetailDto>(
      {
        method: 'POST',
        url: '/api/agent/agent-finance-details',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/agent/agent-finance-details/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetAgentFinanceDetailsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/agent/agent-finance-details/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          creditLimitMin: input.creditLimitMin,
          creditLimitMax: input.creditLimitMax,
          creditLimitCurrency: input.creditLimitCurrency,
          displayCurrency: input.displayCurrency,
          outstandingBalanceMin: input.outstandingBalanceMin,
          outstandingBalanceMax: input.outstandingBalanceMax,
          convertedBalanceMin: input.convertedBalanceMin,
          convertedBalanceMax: input.convertedBalanceMax,
          lastConversionRateMin: input.lastConversionRateMin,
          lastConversionRateMax: input.lastConversionRateMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (agentFinanceDetailIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/agent/agent-finance-details',
        params: { agentFinanceDetailIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AgentFinanceDetailDto>(
      {
        method: 'GET',
        url: `/api/agent/agent-finance-details/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/agent/agent-finance-details/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/agent/agent-finance-details/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetAgentFinanceDetailsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<AgentFinanceDetailDto>>(
      {
        method: 'GET',
        url: '/api/agent/agent-finance-details',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          creditLimitMin: input.creditLimitMin,
          creditLimitMax: input.creditLimitMax,
          creditLimitCurrency: input.creditLimitCurrency,
          displayCurrency: input.displayCurrency,
          outstandingBalanceMin: input.outstandingBalanceMin,
          outstandingBalanceMax: input.outstandingBalanceMax,
          convertedBalanceMin: input.convertedBalanceMin,
          convertedBalanceMax: input.convertedBalanceMax,
          lastConversionRateMin: input.lastConversionRateMin,
          lastConversionRateMax: input.lastConversionRateMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (
    input: AgentFinanceDetailExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/agent/agent-finance-details/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          creditLimitMin: input.creditLimitMin,
          creditLimitMax: input.creditLimitMax,
          creditLimitCurrency: input.creditLimitCurrency,
          displayCurrency: input.displayCurrency,
          outstandingBalanceMin: input.outstandingBalanceMin,
          outstandingBalanceMax: input.outstandingBalanceMax,
          convertedBalanceMin: input.convertedBalanceMin,
          convertedBalanceMax: input.convertedBalanceMax,
          lastConversionRateMin: input.lastConversionRateMin,
          lastConversionRateMax: input.lastConversionRateMax,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (
    id: number,
    input: AgentFinanceDetailUpdateDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, AgentFinanceDetailDto>(
      {
        method: 'PUT',
        url: `/api/agent/agent-finance-details/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/agent/agent-finance-details/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
