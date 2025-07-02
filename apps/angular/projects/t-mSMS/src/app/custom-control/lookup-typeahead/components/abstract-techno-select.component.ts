import {
  AbstractNgModelComponent,
  PagedAndSortedResultRequestDto,
  PagedResultDto,
} from '@abp/ng.core';
import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';

@Component({ selector: 'techno-typeahead:not(p)',template: '' })
export class AbstractTechnoSelectComponent<T = any, U = string>
  extends AbstractNgModelComponent<U>
  implements PagedAndSortedResultRequestDto
{
  @Input() getFn: (params: PagedAndSortedResultRequestDto) => Observable<PagedResultDto<T>>;
  @Input() lookupNameProp = 'displayName';
  @Input() lookupIdProp = 'id';
  @Input() maxResultCount = 10;
  @Input() skipCount = 0;
  @Input() sorting?: string;
  @Input() disabled = false;
  @Input() cid?: string;

  get pageQuery(): PagedAndSortedResultRequestDto {
    return this.createRequestDto(this);
  }

  set pageQuery(value: PagedAndSortedResultRequestDto) {
    Object.assign(this, this.createRequestDto(value));
  }

  protected createRequestDto(value: PagedAndSortedResultRequestDto) {
    return new PagedAndSortedResultRequestDto({
      maxResultCount: value.maxResultCount,
      skipCount: value.skipCount,
      sorting: value.sorting,
    });
  }
}
