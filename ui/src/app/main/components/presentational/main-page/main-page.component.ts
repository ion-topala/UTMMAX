import {Component, Input, OnInit} from '@angular/core';
import {UserModel} from "../../../../models/user.models";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  @Input()
  public user: UserModel | null;

  constructor() {
  }

  ngOnInit(): void {
  }

}
