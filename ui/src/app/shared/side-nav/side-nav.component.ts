import {Component, Input, OnInit} from "@angular/core";
import {UserModel} from "../../../models/user.models";


@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
  routes = ['Categories', 'Movies', 'TvSerials' ];

  @Input()
  public user: UserModel = null;

  constructor() { }

  ngOnInit() {
  }

}
