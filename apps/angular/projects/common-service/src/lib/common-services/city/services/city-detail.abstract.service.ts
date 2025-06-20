import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { CityDto } from '../../../proxy/common-service/common-services/models';
import { CityService } from '../../../proxy/common-service/common-services/city.service';

export abstract class AbstractCityDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(CityService);
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
      descriptor,
      iataAirportCode,
      iataAirportMetroCode,
      countrySubdivisionCode,
      latitude,
      longitude,
      polygonType,
      countryCode,
      categories,
      tags,
      statusFlag,
    } = this.selected || {};

    this.form = this.fb.group({
      locationId: [locationId ?? null, []],
      name: [name ?? null, [Validators.required]],
      fullName: [fullName ?? null, []],
      descriptor: [descriptor ?? null, []],
      iataAirportCode: [iataAirportCode ?? null, []],
      iataAirportMetroCode: [iataAirportMetroCode ?? null, []],
      countrySubdivisionCode: [countrySubdivisionCode ?? null, []],
      latitude: [latitude ?? null, []],
      longitude: [longitude ?? null, []],
      polygonType: [polygonType ?? null, []],
      countryCode: [countryCode ?? null, []],
      categories: [categories ?? null, []],
      tags: [tags ?? null, []],
      statusFlag: [statusFlag ?? null, [Validators.required]],
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

  update(record: CityDto) {
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
