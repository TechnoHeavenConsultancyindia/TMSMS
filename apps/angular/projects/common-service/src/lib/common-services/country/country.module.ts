import { NgModule } from '@angular/core';
import { CountryComponent } from './components/country.component';
import { CountryRoutingModule } from './country-routing.module';

@NgModule({
  declarations: [],
  imports: [CountryComponent, CountryRoutingModule],
})
export class CountryModule {}

export function loadCountryModuleAsChild() {
  return Promise.resolve(CountryModule);
}
