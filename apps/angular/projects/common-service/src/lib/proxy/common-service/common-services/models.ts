import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CityCreateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
}

export interface CityDto extends FullAuditedEntityDto<number> {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
  concurrencyStamp?: string;
}

export interface CityExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
  descriptor?: string;
}

export interface CityUpdateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
  concurrencyStamp?: string;
}

export interface CountryCreateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
}

export interface CountryDto extends FullAuditedEntityDto<number> {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
  concurrencyStamp?: string;
}

export interface CountryExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
  descriptor?: string;
}

export interface CountryUpdateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
  concurrencyStamp?: string;
}

export interface GetCitiesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
  descriptor?: string;
}

export interface GetCountriesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
  descriptor?: string;
}

export interface GetPromoCodeMastersInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  promoCode?: string;
  serviceType?: string;
  discountType?: string;
  discountValueMin?: number;
  discountValueMax?: number;
  dateEffectiveFromMin?: string;
  dateEffectiveFromMax?: string;
  dateEffectiveToMin?: string;
  dateEffectiveToMax?: string;
  maxUsageLimitMin?: number;
  maxUsageLimitMax?: number;
  maxUsagePerUserMin?: number;
  maxUsagePerUserMax?: number;
  customerType?: string;
  minBookingAmountMin?: number;
  minBookingAmountMax?: number;
  paymentMethod?: string;
  userGroup?: string;
  minNoOfNightsMin?: number;
  minNoOfNightsMax?: number;
  minNoOfPaxMin?: number;
  minNoOfPaxMax?: number;
  earlyBirdDaysMin?: number;
  earlyBirdDaysMax?: number;
  validTimeFromMin?: string;
  validTimeFromMax?: string;
  validTimeToMin?: string;
  validTimeToMax?: string;
  stackable?: boolean;
  countryId?: string;
  cityId?: string;
}

export interface GetPromoCodeUsageTrackingsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  userIDMin?: number;
  userIDMax?: number;
  bookingIDMin?: number;
  bookingIDMax?: number;
  usageDateMin?: string;
  usageDateMax?: string;
  promoCodeMasterId?: number;
}

export interface GetProvincesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
  descriptor?: string;
}

export interface GetRegionsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
  descriptor?: string;
}

export interface GetWeekDaysInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  dayAbbreviation?: string;
  isWeekend?: boolean;
  displayOrderMin?: number;
  displayOrderMax?: number;
}

export interface PromoCodeMasterCreateDto {
  name: string;
  promoCode?: string;
  serviceType?: string;
  discountType?: string;
  discountValue: number;
  dateEffectiveFrom?: string;
  dateEffectiveTo?: string;
  maxUsageLimit?: number;
  maxUsagePerUser?: number;
  customerType?: string;
  minBookingAmount: number;
  paymentMethod?: string;
  userGroup?: string;
  minNoOfNights: number;
  minNoOfPax: number;
  earlyBirdDays: number;
  validTimeFrom?: string;
  validTimeTo?: string;
  stackable: boolean;
  countryIds: string[];
  cityIds: string[];
}

export interface PromoCodeMasterDto extends FullAuditedEntityDto<number> {
  name: string;
  promoCode?: string;
  serviceType?: string;
  discountType?: string;
  discountValue: number;
  dateEffectiveFrom?: string;
  dateEffectiveTo?: string;
  maxUsageLimit?: number;
  maxUsagePerUser?: number;
  customerType?: string;
  minBookingAmount: number;
  paymentMethod?: string;
  userGroup?: string;
  minNoOfNights: number;
  minNoOfPax: number;
  earlyBirdDays: number;
  validTimeFrom?: string;
  validTimeTo?: string;
  stackable: boolean;
  concurrencyStamp?: string;
}

export interface PromoCodeMasterExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  promoCode?: string;
  serviceType?: string;
  discountType?: string;
  discountValueMin?: number;
  discountValueMax?: number;
  dateEffectiveFromMin?: string;
  dateEffectiveFromMax?: string;
  dateEffectiveToMin?: string;
  dateEffectiveToMax?: string;
  maxUsageLimitMin?: number;
  maxUsageLimitMax?: number;
  maxUsagePerUserMin?: number;
  maxUsagePerUserMax?: number;
  customerType?: string;
  minBookingAmountMin?: number;
  minBookingAmountMax?: number;
  paymentMethod?: string;
  userGroup?: string;
  minNoOfNightsMin?: number;
  minNoOfNightsMax?: number;
  minNoOfPaxMin?: number;
  minNoOfPaxMax?: number;
  earlyBirdDaysMin?: number;
  earlyBirdDaysMax?: number;
  validTimeFromMin?: string;
  validTimeFromMax?: string;
  validTimeToMin?: string;
  validTimeToMax?: string;
  stackable?: boolean;
  countryId?: string;
  cityId?: string;
}

export interface PromoCodeMasterUpdateDto {
  name: string;
  promoCode?: string;
  serviceType?: string;
  discountType?: string;
  discountValue: number;
  dateEffectiveFrom?: string;
  dateEffectiveTo?: string;
  maxUsageLimit?: number;
  maxUsagePerUser?: number;
  customerType?: string;
  minBookingAmount: number;
  paymentMethod?: string;
  userGroup?: string;
  minNoOfNights: number;
  minNoOfPax: number;
  earlyBirdDays: number;
  validTimeFrom?: string;
  validTimeTo?: string;
  stackable: boolean;
  countryIds: string[];
  cityIds: string[];
  concurrencyStamp?: string;
}

export interface PromoCodeMasterWithNavigationPropertiesDto {
  promoCodeMaster: PromoCodeMasterDto;
  countries: CountryDto[];
  cities: CityDto[];
}

export interface PromoCodeUsageTrackingCreateDto {
  userID: number;
  bookingID: number;
  usageDate?: string;
  promoCodeMasterId?: number;
}

export interface PromoCodeUsageTrackingDto extends FullAuditedEntityDto<number> {
  userID: number;
  bookingID: number;
  usageDate?: string;
  promoCodeMasterId?: number;
  concurrencyStamp?: string;
}

export interface PromoCodeUsageTrackingExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  userIDMin?: number;
  userIDMax?: number;
  bookingIDMin?: number;
  bookingIDMax?: number;
  usageDateMin?: string;
  usageDateMax?: string;
  promoCodeMasterId?: number;
}

export interface PromoCodeUsageTrackingUpdateDto {
  userID: number;
  bookingID: number;
  usageDate?: string;
  promoCodeMasterId?: number;
  concurrencyStamp?: string;
}

export interface PromoCodeUsageTrackingWithNavigationPropertiesDto {
  promoCodeUsageTracking: PromoCodeUsageTrackingDto;
  promoCodeMaster: PromoCodeMasterDto;
}

export interface ProvinceCreateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
}

export interface ProvinceDto extends FullAuditedEntityDto<number> {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
  concurrencyStamp?: string;
}

export interface ProvinceExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
  descriptor?: string;
}

export interface ProvinceUpdateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
  concurrencyStamp?: string;
}

export interface RegionCreateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
}

export interface RegionDto extends FullAuditedEntityDto<number> {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
  concurrencyStamp?: string;
}

export interface RegionExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
  descriptor?: string;
}

export interface RegionUpdateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  latitude?: string;
  longitude?: string;
  countryCode?: string;
  countrySubdivisionCode?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  polygonType?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  descriptor?: string;
  concurrencyStamp?: string;
}

export interface WeekDayCreateDto {
  name: string;
  dayAbbreviation: string;
  isWeekend: boolean;
  displayOrder: number;
}

export interface WeekDayDto extends FullAuditedEntityDto<number> {
  name: string;
  dayAbbreviation: string;
  isWeekend: boolean;
  displayOrder: number;
  concurrencyStamp?: string;
}

export interface WeekDayExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  dayAbbreviation?: string;
  isWeekend?: boolean;
  displayOrderMin?: number;
  displayOrderMax?: number;
}

export interface WeekDayUpdateDto {
  name: string;
  dayAbbreviation: string;
  isWeekend: boolean;
  displayOrder: number;
  concurrencyStamp?: string;
}
