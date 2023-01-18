import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges
} from "@angular/core";
import {UserModel} from "../../../../models/user.models";
import {StorageService} from "../../../../shared/storage.service";
import {filter, Observable, pluck} from "rxjs";


@Component({
  selector: 'app-tool-bar',
  templateUrl: './tool-bar.component.html',
  styleUrls: ['./tool-bar.component.scss']
})
export class ToolBarComponent implements OnChanges {
  routes = ['Movies', 'Tv-Series', 'Cartoons', 'Anime', 'Animated Series', 'Tv-Shows'];

  @Input()
  public user: UserModel | null;

  constructor(private cdRef: ChangeDetectorRef) {
  }

  @Input()
  public searchTerm: string;

  @Output()
  public onSearchBarClick = new EventEmitter();

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['user']?.currentValue) {
      this.cdRef.markForCheck();
    }
  }

}
