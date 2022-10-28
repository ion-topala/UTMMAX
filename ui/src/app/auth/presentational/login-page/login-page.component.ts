import {Component, Input, OnChanges, SimpleChanges} from '@angular/core';
import {ApiErrorModel} from "../../../../models/error.models";
import {FormControl, FormGroup} from "@angular/forms";


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnChanges {
  name = new FormControl('');
  profileForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  })

  @Input()
  public loading: boolean = false;

  @Input()
  public error: ApiErrorModel | null = null;

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
  }

}
