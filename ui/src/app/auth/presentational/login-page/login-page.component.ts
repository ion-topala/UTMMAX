import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {ApiErrorModel} from "../../../../models/error.models";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnChanges {

  @Input()
  public loading: boolean = false;

  @Input()
  public error: ApiErrorModel | null = null;

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
  }

}
