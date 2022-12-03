import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BaseComponent} from "./base.component";
import { SuggestionComponent } from './suggestion/suggestion.component';



@NgModule({
  declarations: [
    BaseComponent,
    SuggestionComponent
  ],
    exports: [
        BaseComponent,
        SuggestionComponent
    ],
  imports: [
    CommonModule
  ]
})
export class UiCoreModule { }
