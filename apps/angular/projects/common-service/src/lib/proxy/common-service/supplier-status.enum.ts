import { mapEnumToOptions } from '@abp/ng.core';

export enum SupplierStatus {
  Active = 0,
  InActive = 1,
}

export const supplierStatusOptions = mapEnumToOptions(SupplierStatus);
