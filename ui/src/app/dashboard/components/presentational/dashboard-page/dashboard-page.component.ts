import {Component, Input, OnInit} from '@angular/core';
import {MovieResultModel} from "../../../../models/movie-models";

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent implements OnInit {

  @Input()
  public movies:MovieResultModel[]

  constructor() { }

  ngOnInit() {
  }

}
