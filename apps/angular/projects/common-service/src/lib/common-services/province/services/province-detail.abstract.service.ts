import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { ProvinceDto } from '../../../proxy/common-service/common-services/models';
import { ProvinceService } from '../../../proxy/common-service/common-services/province.service';

export abstract class AbstractProvinceDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(ProvinceService);
  public readonly list = inject(ListService);

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.id, {
        ...formValues,
        concurrencyStamp: this.selected.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const {
      locationId,
      name,
      fullName,
      latitude,
      longitude,
      countryCode,
      countrySubdivisionCode,
      iataAirportCode,
      iataAirportMetroCode,
      polygonType,
      categories,
      tags,
      statusFlag,
      descriptor,
    } = this.selected || {};

    this.form = this.fb.group({
      locationId: [locationId ?? null, []],
      name: [name ?? null, [Validators.required]],
      fullName: [fullName ?? null, []],
      latitude: [latitude ?? null, []],
      longitude: [longitude ?? null, []],
      countryCode: [countryCode ?? null, []],
      countrySubdivisionCode: [countrySubdivisionCode ?? null, []],
      iataAirportCode: [iataAirportCode ?? null, []],
      iataAirportMetroCode: [iataAirportMetroCode ?? null, []],
      polygonType: [polygonType ?? null, []],
      categories: [categories ?? null, []],
      tags: [tags ?? null, []],
      statusFlag: [statusFlag ?? null, [Validators.required]],
      descriptor: [descriptor ?? null, []],
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

  update(record: ProvinceDto) {
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
