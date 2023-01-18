import { Component, OnInit } from '@angular/core';
import {BaseDialogContainerComponent} from "../../../../ui-core/base-dialog-container.component";
import {ResponsiveService} from "../../../../ui-core/services/responsive.service";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-search-container',
  templateUrl: './search-container.component.html',
  styleUrls: ['./search-container.component.scss']
})
export class SearchContainerComponent extends BaseDialogContainerComponent<SearchContainerComponent> implements OnInit {

  constructor(
    dialogRef: MatDialogRef<SearchContainerComponent>,
    responsiveService: ResponsiveService,
  ) {
    super(dialogRef, responsiveService)
  }

  public override ngOnInit() {
    super.ngOnInit();
  }

}
