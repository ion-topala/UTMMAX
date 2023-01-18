import {Component, Input, OnInit} from '@angular/core';
import {MovieDetailsModel} from "../../../../models/movie-models";
import {data} from "autoprefixer";

enum ProfessionType {
  Actor = "actor",
  MovieDirector = "director",
  Designer = "designer"
}

@Component({
  selector: 'app-movie-details-page',
  templateUrl: './movie-details-page.component.html',
  styleUrls: ['./movie-details-page.component.scss']
})
export class MovieDetailsPageComponent implements OnInit {

  @Input()
  public data: MovieDetailsModel;

  constructor() {
  }

  ngOnInit() {
  }

  public getGenres(): string {
    if (!this.data) {
      return null;
    }

    return this.data.genres.map(value => value.name).join(", ");

  }

  public getMovieDirectors(): string {
    if (!this.data) {
      return null;
    }

    return this.data.persons
      .filter(value => value.enProfession === ProfessionType.MovieDirector)
      .map(value => value.name)
      .slice(0, 5)
      .join(", ");
  }

  public getActors(): string {
    if (!this.data) {
      return null;
    }

    return this.data.persons
      .filter(value => value.enProfession === ProfessionType.Actor)
      .map(value => value.name)
      .slice(0, 5)
      .join(", ");
  }

  public getBudged(): string {
    if (!this.data) {
      return null;
    }

    return this.formatNumbers(this.data.budget.value.toString()) + " "+ this.data.budget.currency;
  }

  public formatNumbers(value: string): string {
    return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " ");
  }

  public getTrailer(): string{
    if (!this.data){
      return null;
    }

    return this.data.videos.trailers
      .filter(value => value.type === "TRAILER" && value.url.includes("embed"))[0].url;
  }
}
