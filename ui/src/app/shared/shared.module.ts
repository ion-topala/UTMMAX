import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {SplitStringPipe} from "./pipes/split-string.pipe";
import {SafePipe} from "./pipes/safe.pipe";
import { SearchContainerComponent } from './components/containers/search-container/search-container.component';


@NgModule({
  declarations: [SplitStringPipe, SafePipe, SearchContainerComponent],
  exports: [
    SplitStringPipe,
    SafePipe
  ],
  imports: [
    CommonModule,
  ]
})
export class SharedModule {
}
