import {Component, ElementRef, HostListener, Input, OnInit, ViewChild} from '@angular/core';
import {MovieResultModel} from "../../../../models/movie-models";

@Component({
  selector: 'app-slider-cards',
  templateUrl: './slider-cards.component.html',
  styleUrls: ['./slider-cards.component.scss']
})
export class SliderCardsComponent implements OnInit {

  @Input()
  public movies:MovieResultModel[]

  public arr: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9];
  public totalCards: number = this.arr.length;
  public currentPage: number = 1;
  public pagePosition: string = "0%";
  public cardsPerPage: number;
  public totalPages: number;
  public overflowWidth: string;
  public cardWidth: string;
  public containerWidth: number;

  @ViewChild("container", {static: true, read: ElementRef})
  container: ElementRef;

  @HostListener("window:resize") windowResize() {
    let newCardsPerPage = this.getCardsPerPage();
    if (newCardsPerPage != this.cardsPerPage) {
      this.cardsPerPage = newCardsPerPage;
      this.initializeSlider();
      if (this.currentPage > this.totalPages) {
        this.currentPage = this.totalPages;
        this.populatePagePosition();
      }
    }
  }

  public ngOnInit(): void {
    this.cardsPerPage = this.getCardsPerPage();
    this.initializeSlider();
  }

  public initializeSlider(): void {
    this.totalPages = Math.ceil(this.totalCards / this.cardsPerPage);
    this.overflowWidth = `calc(${this.totalPages * 100}% + ${this.totalPages * 10}px)`;
    this.cardWidth = `calc((${100 / this.totalPages}% - ${this.cardsPerPage * 10}px) / ${this.cardsPerPage})`;
  }

  public getCardsPerPage(): number {
    return Math.floor(this.container.nativeElement.offsetWidth / 200);
  }

  public changePage(incrementor: number): void {
    this.currentPage += incrementor;
    this.populatePagePosition();
  }

  public populatePagePosition(): void {
    this.pagePosition = `calc(${-100 * (this.currentPage - 1)}% - ${10 *
    (this.currentPage - 1)}px)`;
  }
}
