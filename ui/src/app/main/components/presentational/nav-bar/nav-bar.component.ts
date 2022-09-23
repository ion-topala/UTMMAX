import {Component, Input, OnInit} from '@angular/core';
import {UserModel} from "../../../../../models/user.models";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  @Input()
  public user: UserModel = null;

  constructor() {
  }

  ngOnInit(): void {
    this.user = {
      id: 1,
      firstName: "Topala",
      lastName: "Ion",
      email: "string",
      phone: "string",
      avatarKey: "string",
      timeZone: "string",
    };
  }

}
