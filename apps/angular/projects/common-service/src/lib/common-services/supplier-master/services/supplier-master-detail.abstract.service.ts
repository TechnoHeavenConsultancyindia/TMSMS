import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import { supplierTypeOptions } from '../../../proxy/common-service/supplier-type.enum';
import { supplierStatusOptions } from '../../../proxy/common-service/supplier-status.enum';
import type { SupplierMasterWithNavigationPropertiesDto } from '../../../proxy/common-service/common-services/models';
import { SupplierMasterService } from '../../../proxy/common-service/common-services/supplier-master.service';

export abstract class AbstractSupplierMasterDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(SupplierMasterService);
  public readonly list = inject(ListService);

  public readonly getCountryLookup = this.proxyService.getCountryLookup;

  public readonly getSupplierServiceTypeLookup =
    this.proxyService.getSupplierServiceTypeLookup;

  supplierTypeOptions = supplierTypeOptions;
  supplierStatusOptions = supplierStatusOptions;

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.supplierMaster.id, {
        ...formValues,
        concurrencyStamp: this.selected.supplierMaster.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const {
      name,
      type,
      contactName,
      contactEmail,
      dialCode,
      contactPhone,
      supplierStatus,
      preffered,
      countryId,
      supplierServiceTypeId,
    } = this.selected?.supplierMaster || {};

    this.form = this.fb.group({
      name: [name ?? null, [Validators.required, Validators.maxLength(150)]],
      type: [type ?? null, [Validators.required]],
      contactName: [
        contactName ?? null,
        [Validators.required, Validators.maxLength(150)],
      ],
      contactEmail: [contactEmail ?? null, [Validators.maxLength(150), Validators.email]],
      dialCode: [dialCode ?? null, [Validators.maxLength(10)]],
      contactPhone: [contactPhone ?? null, [Validators.maxLength(50)]],
      supplierStatus: [supplierStatus ?? null, [Validators.required]],
      preffered: [preffered ?? false, []],
      countryId: [countryId ?? null, [Validators.required]],
      supplierServiceTypeId: [supplierServiceTypeId ?? null, [Validators.required]],
    });
  }

  showForm() {
    this.buildForm();
    this.isVisible = true;
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: SupplierMasterWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  hideForm() {
    this.isVisible = false;
  }

  submitForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = this.createRequest().pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm()),
    );

    request.subscribe(this.list.get);
  }

  changeVisible($event: boolean) {
    this.isVisible = $event;
  }
}
