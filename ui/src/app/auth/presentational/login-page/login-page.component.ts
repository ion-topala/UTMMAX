import {Component, EventEmitter, Input, Output} from '@angular/core';
import {ApiErrorModel} from "../../../models/error.models";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Constants} from 'src/app/constants';
import {LoginModel} from "../../../models/user.models";


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {

  @Input()
  public loading: boolean = false;

  @Input()
  public error: ApiErrorModel | null = null;

  @Output()
  public onLogin = new EventEmitter<LoginModel>();

  public form: FormGroup;


  constructor(private fb: FormBuilder) {
    this.form = this.fb.group(
      {
        password: ['', [Validators.required,]],
        email: ['', [Validators.required, Validators.pattern(Constants.Regex.Email)]],
      }
    );
  }

  public submit(): void {
    this.onLogin.emit(this.form.value);
  }
}
