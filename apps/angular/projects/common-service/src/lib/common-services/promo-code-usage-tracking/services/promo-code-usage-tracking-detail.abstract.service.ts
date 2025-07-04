import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { PromoCodeUsageTrackingWithNavigationPropertiesDto } from '../../../proxy/common-service/common-services/models';
import { PromoCodeUsageTrackingService } from '../../../proxy/common-service/common-services/promo-code-usage-tracking.service';

export abstract class AbstractPromoCodeUsageTrackingDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(PromoCodeUsageTrackingService);
  public readonly list = inject(ListService);

  public readonly getPromoCodeMasterLookup = this.proxyService.getPromoCodeMasterLookup;

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.promoCodeUsageTracking.id, {
        ...formValues,
        concurrencyStamp: this.selected.promoCodeUsageTracking.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const { userID, bookingID, usageDate, promoCodeMasterId } =
      this.selected?.promoCodeUsageTracking || {};

    this.form = this.fb.group({
      userID: [userID ?? null, [Validators.required]],
      bookingID: [bookingID ?? null, [Validators.required]],
      usageDate: [usageDate ?? null, [Validators.required]],
      promoCodeMasterId: [promoCodeMasterId ?? null, []],
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

  update(record: PromoCodeUsageTrackingWithNavigationPropertiesDto) {
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
