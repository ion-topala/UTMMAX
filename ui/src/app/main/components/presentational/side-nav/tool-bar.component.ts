import {Component, Input, OnInit} from "@angular/core";
import {UserModel} from "../../../../../models/user.models";


@Component({
  selector: 'app-tool-bar',
  templateUrl: './tool-bar.component.html',
  styleUrls: ['./tool-bar.component.scss']
})
export class ToolBarComponent implements OnInit {
  routes = ['Categories', 'Movies', 'TvSerials' ];

  @Input()
  public user: UserModel = null;

  constructor() { }

  ngOnInit() {
  }

}
