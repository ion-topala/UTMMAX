import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {UserModel} from "../../../../models/user.models";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  @Input()
  public user: UserModel | null;

  @Output()
  public onSearchBarClick = new EventEmitter();

  constructor() {
  }

  ngOnInit(): void {
  }

}
