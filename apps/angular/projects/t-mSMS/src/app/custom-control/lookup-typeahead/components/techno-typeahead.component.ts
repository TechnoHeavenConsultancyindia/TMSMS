import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
  inject,
} from '@angular/core';
import { NgControl } from '@angular/forms';
import { merge, Observable, of, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, filter, map, switchMap, tap } from 'rxjs/operators';
import { NgbTypeahead, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { CoreModule, PagedAndSortedResultRequestDto, PagedResultDto, SubscriptionService } from '@abp/ng.core';
import { AbstractTechnoSelectComponent } from './abstract-techno-select.component';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

@Component({
  selector: 'techno-typeahead',
  standalone:true,
  templateUrl: './techno-typeahead.component.html',
  providers: [SubscriptionService],
  imports: [
    NgbTypeaheadModule,
    CoreModule,
    CommercialUiModule,
  ]
})
export class TechnoTypeaheadComponent<T = any>
  extends AbstractTechnoSelectComponent<T>
  implements OnChanges, OnInit {
  protected readonly subscriptionService = inject(SubscriptionService);
  protected readonly ngControl = inject(NgControl);

  private _model?: LookupOption;
  @ViewChild('typeaheadInstance', { static: true }) typeaheadInstance!: NgbTypeahead;
  focus$ = new Subject<string>();
  click$ = new Subject<string>();

  @Input() displayNameProp = 'name';
  @Input() lookupFilterProp = 'filter';
  @Input() filter = '';
  @Input() editingData: T;

  private createItemToOptionMapper = (nameProp: string) => (item: T) => ({
    [this.lookupNameProp]: item[nameProp],
    [this.lookupIdProp]: item[this.lookupIdProp],
  });

  private mapDataToOption = (item: T) => this.createItemToOptionMapper(this.displayNameProp)(item);

  private mapResponseToOptions = ({ items }: PagedResultDto<T>) =>
    items.length
      ? items.map<LookupOption>(this.createItemToOptionMapper(this.lookupNameProp))
      : [null];

  search = (text$: Observable<string>) => {
    var filterLength: number = 0;
    text$.subscribe(data => {filterLength = data.length;})
    const clicksWithClosedPopup$ = this.click$.pipe(
      filter<string>(() => !this.typeaheadInstance.isPopupOpen()),
      distinctUntilChanged(),
    );
    const inputFocus$ = this.focus$.pipe(distinctUntilChanged());
    let stream = of([null]);
    if (text$) {
      stream = merge(text$, inputFocus$, clicksWithClosedPopup$).pipe(
        tap(text => (this.filter = text)),
        debounceTime(300),
        switchMap(() => filterLength>=3?this.getFn(this.pageQuery):[]),
        map(this.mapResponseToOptions),
      );
    }
    return stream;
  };

  typeaheadFormatter = (option: LookupOption) => option[this.lookupNameProp];

  get model(): LookupOption {
    return this._model;
  }

  set model(selectedOption: LookupOption) {
    this._model = selectedOption;

    const value = selectedOption ? selectedOption[this.lookupIdProp] : null;
    if (value !== this.value) this.value = value;
  }

  get isInvalid() {
    return this.ngControl.dirty && this.ngControl.invalid;
  }

  ngOnInit() {
    this.get();
  }

  protected get() {
    if (this.value) {
      this.subscriptionService.addOne(this.getFn(this.pageQuery), ({ items }) => {
        const value = items.find(item => this.value === item[this.lookupIdProp]);
        this.model = {
          [this.lookupNameProp]: value[this.lookupNameProp],
          [this.lookupIdProp]: value[this.lookupIdProp],
        };
      });
    }
  }

  protected createRequestDto(value: TechnoTypeaheadComponent) {
    return Object.assign(
      new PagedAndSortedResultRequestDto({
        maxResultCount: value.maxResultCount,
        skipCount: value.skipCount,
        sorting: value.sorting,
      }),
      { [this.lookupFilterProp]: value.filter },
    );
  }

  constructor() {
    super();
    this.ngControl.valueAccessor = this;
  }

  ngOnChanges({ editingData }: SimpleChanges) {
    if (!editingData || !editingData.currentValue) return;

    const data = editingData.currentValue;
    if (data[this.lookupIdProp] === this.value) {
      this.model = data ? this.mapDataToOption(data) : undefined;
    }
  }

  writeValue(value: string) {
    if (!value) this._model = undefined;
    super.writeValue(value);
  }
}

type LookupOption = Record<string, string>;

export function selfFactory(dependency?: any) {
  return dependency;
}