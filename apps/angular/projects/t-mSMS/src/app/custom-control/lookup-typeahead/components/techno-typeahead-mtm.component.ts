import { CoreModule, PagedAndSortedResultRequestDto, PagedResultDto, SubscriptionService } from '@abp/ng.core';
import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
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
import { AbstractTechnoSelectComponent } from './abstract-techno-select.component';
import { NgbTypeahead, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

export type InferredItemOf<T> = T extends Array<infer U> ? U : never;

type LookupOption = Record<string, string>;

export function selfTypeaheadMtmFactory(dependency?: any) {
  return dependency;
}

@Component({
  selector: 'techno-typeahead-mtm',
  standalone:true,
  templateUrl: './techno-typeahead-mtm.component.html',
  providers: [SubscriptionService],
  imports: [
    NgbTypeaheadModule,
    CoreModule,
    CommercialUiModule,
  ]
})
export class TechnoTypeaheadMtmComponent<T extends any[] = any[]>
  extends AbstractTechnoSelectComponent<T, any[]>
  implements OnChanges, OnInit {
  protected readonly cdr = inject(ChangeDetectorRef);
  protected readonly ngControl = inject(NgControl);

  private _model?: LookupOption[] = [];

  get model(): LookupOption[] {
    return this._model;
  }

  set model(selectedOption: LookupOption[]) {
    this._model = selectedOption;
    this.value = selectedOption;
  }

  get isInvalid() {
    return this.ngControl.dirty && this.ngControl.invalid;
  }

  get isDisabled() {
    return !this.typeaheadModel || typeof this.typeaheadModel === 'string';
  }

  focus$ = new Subject<string>();
  click$ = new Subject<string>();

  @Input() displayNameProp = 'name';
  @Input() lookupFilterProp = 'filter';
  @Input() filter = '';
  @Input() editingData: T;
  @Input() maxResultCount = 10;

  typeaheadModel;

  @ViewChild('typeaheadInstance', { static: true }) typeaheadInstance!: NgbTypeahead;

  private mapDataToOption = (item: InferredItemOf<T>) => {
    return this.createItemToOptionMapper(this.displayNameProp)(item);
  };

  private createItemToOptionMapper = (nameProp: string) => (item: InferredItemOf<T>) => ({
    [this.displayNameProp]: item[nameProp],
    [this.lookupIdProp]: item[this.lookupIdProp],
  });

  private mapResponseToOptions = ({ items }: PagedResultDto<T>) => {
    if (!items?.length) {
      return null;
    }
    return items.map<LookupOption>(this.createTypeaheadItemToOptionMapper(this.lookupNameProp));
  };

  private createTypeaheadItemToOptionMapper = (nameProp: string) => (item: InferredItemOf<T>) => ({
    [this.lookupNameProp]: item[nameProp],
    [this.lookupIdProp]: item[this.lookupIdProp],
  });

  private filterResponse = (data: PagedResultDto<T>) => ({
    ...data,
    items: data.items?.filter(item => {
      const _item = item[this.lookupIdProp];
      return !this.model.some(selected => selected[this.lookupIdProp] === _item);
    }),
  });

  protected createRequestDto(value: TechnoTypeaheadMtmComponent) {
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

  ngOnInit(): void {
    this.model = this.ngControl.control?.value ?? [];
  }

  ngOnChanges({ editingData }: SimpleChanges) {
    if (!editingData || !editingData.currentValue) {
      return;
    }

    const data: T = editingData.currentValue;
    if (
      this.value &&
      this.value.length === editingData.currentValue.length &&
      this.value.every(i => data.some(d => d[this.lookupIdProp] === i))
    ) {
      this.model = data ? data.map(this.mapDataToOption) : [];
    }
  }

  writeValue(value: Array<any>) {
    if (!value) this._model = [];
    if (
      Array.isArray(value) &&
      !value.some(item => typeof item === 'string' || typeof item === 'number')
    )
      this.model = value;
    super.writeValue(value);
  }

  search = (text$: Observable<string>) => {
    const debouncedText$ = text$ || text$.pipe(debounceTime(300), distinctUntilChanged());
    const clicksWithClosedPopup$ = this.click$.pipe(
      filter<string>(() => !this.typeaheadInstance.isPopupOpen()),
      distinctUntilChanged(),
    );
    const inputFocus$ = this.focus$.pipe(distinctUntilChanged());
    let stream = of([]);

    if (text$) {
      stream = merge(debouncedText$, inputFocus$, clicksWithClosedPopup$).pipe(
        tap(text => (this.filter = text)),
        switchMap(_ => this.getFn(this.pageQuery)),
        map(this.filterResponse),
        map(this.mapResponseToOptions),
      );
    }

    return stream;
  };

  typeaheadFormatter = (option: LookupOption) => option[this.lookupNameProp];

  addToModel(opt: LookupOption) {
    this.typeaheadModel = null;
    this.model = [
      ...this.model,
      {
        [this.displayNameProp]: opt[this.lookupNameProp],
        [this.lookupIdProp]: opt[this.lookupIdProp],
      },
    ];
  }

  addAllToModel() {
    const tempMaxResultCount = this.maxResultCount;
    this.maxResultCount = null;
    this.getFn(this.pageQuery).subscribe(data => {
      this.model = [];
      data.items?.map((item) => {
        this.model.push({
          [this.displayNameProp]: item[this.lookupNameProp],
          [this.lookupIdProp]: item[this.lookupIdProp],
        });
      });
    });
    this.maxResultCount = tempMaxResultCount;
    this.typeaheadModel = null;
  }

  deleteItem(item) {
    this.model = this.model.filter(i => item !== i);
  }
}
