import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BaseComponent} from "./base.component";
import {SuggestionComponent} from './suggestion/suggestion.component';
import {SearchBarComponent} from "./search-bar/search-bar.component";


@NgModule({
  declarations: [
    BaseComponent,
    SuggestionComponent,
    SearchBarComponent,
  ],
  exports: [
    BaseComponent,
    SuggestionComponent,
    SearchBarComponent,
  ],
  imports: [
    CommonModule
  ]
})
export class UiCoreModule {
}
