import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {SplitStringPipe} from "./pipes/split-string.pipe";
import {SafePipe} from "./pipes/safe.pipe";


@NgModule({
  declarations: [SplitStringPipe, SafePipe],
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
