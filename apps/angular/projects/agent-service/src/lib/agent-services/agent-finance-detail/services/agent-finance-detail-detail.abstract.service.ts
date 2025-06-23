import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { AgentFinanceDetailDto } from '../../../proxy/agent-service/agent-services/models';
import { AgentFinanceDetailService } from '../../../proxy/agent-service/agent-services/agent-finance-detail.service';

export abstract class AbstractAgentFinanceDetailDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(AgentFinanceDetailService);
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
      creditLimit,
      creditLimitCurrency,
      displayCurrency,
      outstandingBalance,
      convertedBalance,
      lastConversionRate,
    } = this.selected || {};

    this.form = this.fb.group({
      creditLimit: [creditLimit ?? null, [Validators.required]],
      creditLimitCurrency: [creditLimitCurrency ?? null, [Validators.maxLength(10)]],
      displayCurrency: [displayCurrency ?? null, [Validators.maxLength(10)]],
      outstandingBalance: [outstandingBalance ?? null, [Validators.required]],
      convertedBalance: [convertedBalance ?? null, [Validators.required]],
      lastConversionRate: [lastConversionRate ?? null, [Validators.required]],
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

  update(record: AgentFinanceDetailDto) {
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
