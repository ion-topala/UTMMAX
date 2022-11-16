import {Component, Input, OnInit} from "@angular/core";
import {UserModel} from "../../../../models/user.models";


@Component({
  selector: 'app-tool-bar',
  templateUrl: './tool-bar.component.html',
  styleUrls: ['./tool-bar.component.scss']
})
export class ToolBarComponent implements OnInit {
  routes = ['Movies', 'Tv-Series', 'Cartoons', 'Anime', 'Animated Series', 'Tv-Shows' ];

  @Input()
  public user: UserModel = null;

  constructor() { }

  ngOnInit() {
  }

}
