import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { PromoCodeMasterWithNavigationPropertiesDto } from '../../../proxy/common-service/common-services/models';
import { PromoCodeMasterService } from '../../../proxy/common-service/common-services/promo-code-master.service';

export abstract class AbstractPromoCodeMasterDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(PromoCodeMasterService);
  public readonly list = inject(ListService);

  public readonly getCountryLookup = this.proxyService.getCountryLookup;

  public readonly getCityLookup = this.proxyService.getCityLookup;

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
      countryIds: this.form.value.countryIds.map(({ id }) => id),
      cityIds: this.form.value.cityIds.map(({ id }) => id),
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.promoCodeMaster.id, {
        ...formValues,
        concurrencyStamp: this.selected.promoCodeMaster.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const {
      name,
      promoCode,
      serviceType,
      discountType,
      discountValue,
      dateEffectiveFrom,
      dateEffectiveTo,
      maxUsageLimit,
      maxUsagePerUser,
      customerType,
      minBookingAmount,
      paymentMethod,
      userGroup,
      minNoOfNights,
      minNoOfPax,
      earlyBirdDays,
      validTimeFrom,
      validTimeTo,
      stackable,
    } = this.selected?.promoCodeMaster || {};

    const { countries = [], cities = [] } = this.selected || {};

    this.form = this.fb.group({
      name: [name ?? null, [Validators.required, Validators.maxLength(255)]],
      promoCode: [promoCode ?? null, [Validators.maxLength(50)]],
      serviceType: [serviceType ?? null, [Validators.maxLength(100)]],
      discountType: [discountType ?? null, [Validators.maxLength(50)]],
      discountValue: [discountValue ?? null, [Validators.required]],
      dateEffectiveFrom: [dateEffectiveFrom ?? null, [Validators.required]],
      dateEffectiveTo: [dateEffectiveTo ?? null, [Validators.required]],
      maxUsageLimit: [maxUsageLimit ?? null, []],
      maxUsagePerUser: [maxUsagePerUser ?? null, []],
      customerType: [customerType ?? null, [Validators.maxLength(50)]],
      minBookingAmount: [minBookingAmount ?? null, [Validators.required]],
      paymentMethod: [paymentMethod ?? null, [Validators.maxLength(100)]],
      userGroup: [userGroup ?? null, [Validators.maxLength(100)]],
      minNoOfNights: [minNoOfNights ?? null, [Validators.required]],
      minNoOfPax: [minNoOfPax ?? null, [Validators.required]],
      earlyBirdDays: [earlyBirdDays ?? null, [Validators.required]],
      validTimeFrom: [validTimeFrom ?? null, [Validators.required]],
      validTimeTo: [validTimeTo ?? null, [Validators.required]],
      stackable: [stackable ?? false, []],
      countryIds: [countries, []],
      cityIds: [cities, []],
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

  update(record: PromoCodeMasterWithNavigationPropertiesDto) {
    this.proxyService
      .getWithNavigationProperties(record.promoCodeMaster.id)
      .subscribe(data => {
        this.selected = data;
        this.showForm();
      });
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
