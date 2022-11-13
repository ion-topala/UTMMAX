import {Component, Input, OnChanges, SimpleChanges} from '@angular/core';
import {ApiErrorModel} from "../../../../models/error.models";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Constants} from 'src/app/constants';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnChanges {
  public form: FormGroup;

  @Input()
  public loading: boolean = false;

  @Input()
  public error: ApiErrorModel | null = null;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group(
      {
        password: ['', [Validators.required,]],
        email: ['', [Validators.required, Validators.pattern(Constants.Regex.Email)]],
      }
    );
  }

  ngOnChanges(changes: SimpleChanges): void {
  }

  submit() {
    console.log(this.form.value)
  }
}
