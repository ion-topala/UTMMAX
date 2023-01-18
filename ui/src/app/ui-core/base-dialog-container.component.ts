import { OnInit } from "@angular/core";
import { BaseComponent } from "./base.component";
import {MatDialogRef} from "@angular/material/dialog";
import {ResponsiveService, ScreenSize} from "./services/responsive.service";
import {takeUntil} from "rxjs";

export interface Size {
  width?: string;
  height?: string;
}

// @ts-ignore
@Component({
  template: '',
})
export class BaseDialogContainerComponent<T> extends BaseComponent implements OnInit {
  public smallScreenSize: Size | null = null;
  public mediumScreenSize: Size | null = null;
  public largeScreenSize: Size | null = null;

  constructor(protected dialogRef: MatDialogRef<T>, protected responsiveService: ResponsiveService) {
    super();
  }

  public ngOnInit(): void {
    this.responsiveService
      .getScreenSize()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe((size: ScreenSize) => {
        let newSize = null;
        switch (size) {
          case 'small':
            newSize = this.smallScreenSize;
            break;
          case 'medium':
            newSize = this.mediumScreenSize;
            break;
          case 'large':
            newSize = this.largeScreenSize;
            break;
          default:
            return;
        }

        if (newSize) {
          this.dialogRef.updateSize(newSize.width, newSize.height);
        }
      });
  }
}
