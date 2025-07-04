import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CityCreateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
}

export interface CityDto extends FullAuditedEntityDto<number> {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
  concurrencyStamp?: string;
}

export interface CityExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
}

export interface CityUpdateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories?: string;
  tags?: string;
  statusFlag: number;
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
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
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

export interface GetProvincesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
}

export interface GetRegionsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  categories?: string;
  countryCode?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
}

export interface ProvinceCreateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories: string;
  tags?: string;
  statusFlag: number;
}

export interface ProvinceDto extends FullAuditedEntityDto<number> {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories: string;
  tags?: string;
  statusFlag: number;
  concurrencyStamp?: string;
}

export interface ProvinceExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
}

export interface ProvinceUpdateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  countryCode?: string;
  categories: string;
  tags?: string;
  statusFlag: number;
  concurrencyStamp?: string;
}

export interface RegionCreateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  categories: string;
  countryCode?: string;
  tags?: string;
  statusFlag: number;
}

export interface RegionDto extends FullAuditedEntityDto<number> {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  categories: string;
  countryCode?: string;
  tags?: string;
  statusFlag: number;
  concurrencyStamp?: string;
}

export interface RegionExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  locationId?: string;
  name?: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  categories?: string;
  countryCode?: string;
  tags?: string;
  statusFlagMin?: number;
  statusFlagMax?: number;
}

export interface RegionUpdateDto {
  locationId?: string;
  name: string;
  fullName?: string;
  descriptor?: string;
  iataAirportCode?: string;
  iataAirportMetroCode?: string;
  countrySubdivisionCode?: string;
  latitude?: string;
  longitude?: string;
  polygonType?: string;
  categories: string;
  countryCode?: string;
  tags?: string;
  statusFlag: number;
  concurrencyStamp?: string;
}
