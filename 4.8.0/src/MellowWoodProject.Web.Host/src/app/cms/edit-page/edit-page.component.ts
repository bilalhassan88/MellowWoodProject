import { Component, Injector, Inject, OnInit, Optional } from '@angular/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
  PageServiceProxy,
  GetPageForEditOutput,
  PageDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-page.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class EditPageComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  page: PageDto = new PageDto();

  constructor(
    injector: Injector,
    private _pageService: PageServiceProxy,
    private _dialogRef: MatDialogRef<EditPageComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._pageService
      .getPageForEdit(this._id)
      .subscribe((result: GetPageForEditOutput) => {

        this.page.init(result.page);
        });

  }

 
  save(): void {
    this.saving = true;


    this._pageService
      .update(this.page)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
        window.location.reload();
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }
}
