import type {
  GetPromoCodeMastersInput,
  PromoCodeMasterCreateDto,
  PromoCodeMasterDto,
  PromoCodeMasterExcelDownloadDto,
  PromoCodeMasterUpdateDto,
  PromoCodeMasterWithNavigationPropertiesDto,
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
export class PromoCodeMasterService {
  apiName = 'CommonService';

  create = (input: PromoCodeMasterCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PromoCodeMasterDto>(
      {
        method: 'POST',
        url: '/api/common/promo-code-masters',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/common/promo-code-masters/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetPromoCodeMastersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/promo-code-masters/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          promoCode: input.promoCode,
          serviceType: input.serviceType,
          discountType: input.discountType,
          discountValueMin: input.discountValueMin,
          discountValueMax: input.discountValueMax,
          dateEffectiveFromMin: input.dateEffectiveFromMin,
          dateEffectiveFromMax: input.dateEffectiveFromMax,
          dateEffectiveToMin: input.dateEffectiveToMin,
          dateEffectiveToMax: input.dateEffectiveToMax,
          maxUsageLimitMin: input.maxUsageLimitMin,
          maxUsageLimitMax: input.maxUsageLimitMax,
          maxUsagePerUserMin: input.maxUsagePerUserMin,
          maxUsagePerUserMax: input.maxUsagePerUserMax,
          customerType: input.customerType,
          minBookingAmountMin: input.minBookingAmountMin,
          minBookingAmountMax: input.minBookingAmountMax,
          paymentMethod: input.paymentMethod,
          userGroup: input.userGroup,
          minNoOfNightsMin: input.minNoOfNightsMin,
          minNoOfNightsMax: input.minNoOfNightsMax,
          minNoOfPaxMin: input.minNoOfPaxMin,
          minNoOfPaxMax: input.minNoOfPaxMax,
          earlyBirdDaysMin: input.earlyBirdDaysMin,
          earlyBirdDaysMax: input.earlyBirdDaysMax,
          validTimeFromMin: input.validTimeFromMin,
          validTimeFromMax: input.validTimeFromMax,
          validTimeToMin: input.validTimeToMin,
          validTimeToMax: input.validTimeToMax,
          stackable: input.stackable,
          countryId: input.countryId,
          cityId: input.cityId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (promoCodeMasterIds: number[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/common/promo-code-masters',
        params: { promoCodeMasterIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PromoCodeMasterDto>(
      {
        method: 'GET',
        url: `/api/common/promo-code-masters/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getCityLookup = (input: LookupRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/common/promo-code-masters/city-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getCountryLookup = (input: LookupRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/common/promo-code-masters/country-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/common/promo-code-masters/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/promo-code-masters/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetPromoCodeMastersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<
      any,
      PagedResultDto<PromoCodeMasterWithNavigationPropertiesDto>
    >(
      {
        method: 'GET',
        url: '/api/common/promo-code-masters',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          promoCode: input.promoCode,
          serviceType: input.serviceType,
          discountType: input.discountType,
          discountValueMin: input.discountValueMin,
          discountValueMax: input.discountValueMax,
          dateEffectiveFromMin: input.dateEffectiveFromMin,
          dateEffectiveFromMax: input.dateEffectiveFromMax,
          dateEffectiveToMin: input.dateEffectiveToMin,
          dateEffectiveToMax: input.dateEffectiveToMax,
          maxUsageLimitMin: input.maxUsageLimitMin,
          maxUsageLimitMax: input.maxUsageLimitMax,
          maxUsagePerUserMin: input.maxUsagePerUserMin,
          maxUsagePerUserMax: input.maxUsagePerUserMax,
          customerType: input.customerType,
          minBookingAmountMin: input.minBookingAmountMin,
          minBookingAmountMax: input.minBookingAmountMax,
          paymentMethod: input.paymentMethod,
          userGroup: input.userGroup,
          minNoOfNightsMin: input.minNoOfNightsMin,
          minNoOfNightsMax: input.minNoOfNightsMax,
          minNoOfPaxMin: input.minNoOfPaxMin,
          minNoOfPaxMax: input.minNoOfPaxMax,
          earlyBirdDaysMin: input.earlyBirdDaysMin,
          earlyBirdDaysMax: input.earlyBirdDaysMax,
          validTimeFromMin: input.validTimeFromMin,
          validTimeFromMax: input.validTimeFromMax,
          validTimeToMin: input.validTimeToMin,
          validTimeToMax: input.validTimeToMax,
          stackable: input.stackable,
          countryId: input.countryId,
          cityId: input.cityId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (
    input: PromoCodeMasterExcelDownloadDto,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/common/promo-code-masters/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          promoCode: input.promoCode,
          serviceType: input.serviceType,
          discountType: input.discountType,
          discountValueMin: input.discountValueMin,
          discountValueMax: input.discountValueMax,
          dateEffectiveFromMin: input.dateEffectiveFromMin,
          dateEffectiveFromMax: input.dateEffectiveFromMax,
          dateEffectiveToMin: input.dateEffectiveToMin,
          dateEffectiveToMax: input.dateEffectiveToMax,
          maxUsageLimitMin: input.maxUsageLimitMin,
          maxUsageLimitMax: input.maxUsageLimitMax,
          maxUsagePerUserMin: input.maxUsagePerUserMin,
          maxUsagePerUserMax: input.maxUsagePerUserMax,
          customerType: input.customerType,
          minBookingAmountMin: input.minBookingAmountMin,
          minBookingAmountMax: input.minBookingAmountMax,
          paymentMethod: input.paymentMethod,
          userGroup: input.userGroup,
          minNoOfNightsMin: input.minNoOfNightsMin,
          minNoOfNightsMax: input.minNoOfNightsMax,
          minNoOfPaxMin: input.minNoOfPaxMin,
          minNoOfPaxMax: input.minNoOfPaxMax,
          earlyBirdDaysMin: input.earlyBirdDaysMin,
          earlyBirdDaysMax: input.earlyBirdDaysMax,
          validTimeFromMin: input.validTimeFromMin,
          validTimeFromMax: input.validTimeFromMax,
          validTimeToMin: input.validTimeToMin,
          validTimeToMax: input.validTimeToMax,
          stackable: input.stackable,
          countryId: input.countryId,
          cityId: input.cityId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getWithNavigationProperties = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PromoCodeMasterWithNavigationPropertiesDto>(
      {
        method: 'GET',
        url: `/api/common/promo-code-masters/with-navigation-properties/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: number, input: PromoCodeMasterUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PromoCodeMasterDto>(
      {
        method: 'PUT',
        url: `/api/common/promo-code-masters/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/common/promo-code-masters/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
