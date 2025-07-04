import type {
  GetPromoCodeUsageTrackingsInput,
  PromoCodeUsageTrackingCreateDto,
  PromoCodeUsageTrackingDto,
  PromoCodeUsageTrackingExcelDownloadDto,
  PromoCodeUsageTrackingUpdateDto,
  PromoCodeUsageTrackingWithNavigationPropertiesDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type {
  AppFileDescriptorDto,
  DownloadTokenResultDto,
  GetFileInput,
  LookupDto,
  LookupRequestDto,
} from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class PromoCodeUsageTrackingService {
  apiName = 'CommonService';

  create = (input: PromoCodeUsageTrackingCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PromoCodeUsageTrackingDto>(
      {
        method: 'POST',
        url: '/api/common/promo-code-usage-trackings',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/common/promo-code-usage-trackings/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetPromoCodeUsageTrackingsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/promo-code-usage-trackings/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          userIDMin: input.userIDMin,
          userIDMax: input.userIDMax,
          bookingIDMin: input.bookingIDMin,
          bookingIDMax: input.bookingIDMax,
          usageDateMin: input.usageDateMin,
          usageDateMax: input.usageDateMax,
          promoCodeMasterId: input.promoCodeMasterId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (promoCodeUsageTrackingIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/promo-code-usage-trackings',
        params: { promoCodeUsageTrackingIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PromoCodeUsageTrackingDto>(
      {
        method: 'GET',
        url: `/api/common/promo-code-usage-trackings/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/common/promo-code-usage-trackings/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/promo-code-usage-trackings/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetPromoCodeUsageTrackingsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<
      any,
      PagedResultDto<PromoCodeUsageTrackingWithNavigationPropertiesDto>
    >(
      {
        method: 'GET',
        url: '/api/common/promo-code-usage-trackings',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          userIDMin: input.userIDMin,
          userIDMax: input.userIDMax,
          bookingIDMin: input.bookingIDMin,
          bookingIDMax: input.bookingIDMax,
          usageDateMin: input.usageDateMin,
          usageDateMax: input.usageDateMax,
          promoCodeMasterId: input.promoCodeMasterId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (
    input: PromoCodeUsageTrackingExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/promo-code-usage-trackings/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          userIDMin: input.userIDMin,
          userIDMax: input.userIDMax,
          bookingIDMin: input.bookingIDMin,
          bookingIDMax: input.bookingIDMax,
          usageDateMin: input.usageDateMin,
          usageDateMax: input.usageDateMax,
          promoCodeMasterId: input.promoCodeMasterId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getPromoCodeMasterLookup = (input: LookupRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/common/promo-code-usage-trackings/promo-code-master-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getWithNavigationProperties = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PromoCodeUsageTrackingWithNavigationPropertiesDto>(
      {
        method: 'GET',
        url: `/api/common/promo-code-usage-trackings/with-navigation-properties/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  update = (
    id: number,
    input: PromoCodeUsageTrackingUpdateDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, PromoCodeUsageTrackingDto>(
      {
        method: 'PUT',
        url: `/api/common/promo-code-usage-trackings/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/common/promo-code-usage-trackings/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
