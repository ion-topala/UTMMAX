import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BaseComponent} from "./base.component";
import {SuggestionComponent} from './suggestion/suggestion.component';
import { FooterComponent } from './footer/footer.component';


@NgModule({
  declarations: [
    BaseComponent,
    SuggestionComponent,
    FooterComponent,
  ],
    exports: [
        BaseComponent,
        SuggestionComponent,
        FooterComponent,
    ],
  imports: [
    CommonModule
  ]
})
export class UiCoreModule {
}
