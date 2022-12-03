import {Component, EventEmitter, Input, Output} from '@angular/core';
import {ApiErrorModel} from "../../../models/error.models";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Constants} from "../../../constants";
import {Gender, RegisterUserModel} from "../../../models/user.models";
import {formatDate} from "@angular/common";

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent {
  profileForm = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.pattern(Constants.Regex.Email)]),
    password: new FormControl('', [Validators.required]),
    birthday: new FormControl('', [Validators.required]),
    gender: new FormControl('', [Validators.required]),
  })

  genders = Gender;
  hide = true;

  @Input()
  public loading: boolean = false;

  @Input()
  public error: ApiErrorModel | null;

  @Output()
  public onSubmit = new EventEmitter<RegisterUserModel>();

  createProfile() {
    let date = this.profileForm.get('birthday').value;
    const formatedDate = formatDate(date, 'yyyy-MM-dd', 'en');

    const model = {
      firstName: this.profileForm.get('firstName').value,
      lastName: this.profileForm.get('lastName').value,
      email: this.profileForm.get('email').value,
      password: this.profileForm.get('password').value,
      birthday: formatedDate,
      gender: this.profileForm.get('gender').value as unknown as Gender,
    } as RegisterUserModel;

    this.onSubmit.emit(model)
  }
}
