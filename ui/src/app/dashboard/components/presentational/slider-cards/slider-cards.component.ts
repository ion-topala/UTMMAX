import {Component, Input, OnInit} from '@angular/core';
import {MovieResultModel} from "../../../../models/movie-models";

@Component({
  selector: 'app-slider-cards',
  templateUrl: './slider-cards.component.html',
  styleUrls: ['./slider-cards.component.scss']
})
export class SliderCardsComponent implements OnInit {

  @Input()
  public movies: MovieResultModel[]

  public ngOnInit(): void {
  }

}
