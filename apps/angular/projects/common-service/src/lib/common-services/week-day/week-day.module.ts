import { NgModule } from '@angular/core';
import { WeekDayComponent } from './components/week-day.component';
import { WeekDayRoutingModule } from './week-day-routing.module';

@NgModule({
  declarations: [],
  imports: [WeekDayComponent, WeekDayRoutingModule],
})
export class WeekDayModule {}

export function loadWeekDayModuleAsChild() {
  return Promise.resolve(WeekDayModule);
}
