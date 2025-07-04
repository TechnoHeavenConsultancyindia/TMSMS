import { mapEnumToOptions } from '@abp/ng.core';

export enum SupplierType {
  OTA = 0,
  DMC = 1,
  Wholesaler = 2,
}

export const supplierTypeOptions = mapEnumToOptions(SupplierType);
