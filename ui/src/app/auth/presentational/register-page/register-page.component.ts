import {Component, Input, OnInit} from '@angular/core';
import {ApiErrorModel} from "../../../../models/error.models";

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {

  @Input()
  public loading: boolean = false;

  @Input()
  public error: ApiErrorModel | null;

  constructor() { }

  ngOnInit(): void {
  }

}
