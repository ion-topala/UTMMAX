import {Component, Input, OnInit} from '@angular/core';
import {MovieResultModel} from "../../../../models/movie-models";

@Component({
  selector: 'app-movie-details-page',
  templateUrl: './movie-details-page.component.html',
  styleUrls: ['./movie-details-page.component.scss']
})
export class MovieDetailsPageComponent implements OnInit {

  @Input()
  public data: MovieResultModel;

  constructor() { }

  ngOnInit() {
  }

}
