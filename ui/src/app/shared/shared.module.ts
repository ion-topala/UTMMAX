import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {SplitStringPipe} from "./pipes/split-string.pipe";


@NgModule({
  declarations: [SplitStringPipe],
  exports: [
    SplitStringPipe
  ],
  imports: [
    CommonModule,
  ]
})
export class SharedModule {
}
