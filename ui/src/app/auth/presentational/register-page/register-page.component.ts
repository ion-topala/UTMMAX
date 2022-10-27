import {Component, Input, OnInit} from '@angular/core';
import {ApiErrorModel} from "../../../../models/error.models";
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {
  profileForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    age: new FormControl(''),
  })
  createProfile() {
    this.profileForm.patchValue({
    });
  }

  ;
  onSubmit() {
    console.warn(this.profileForm.value);
  }
  @Input()
  public loading: boolean = false;

  @Input()
  public error: ApiErrorModel | null;

  constructor() { }

  ngOnInit(): void {
  }

}
