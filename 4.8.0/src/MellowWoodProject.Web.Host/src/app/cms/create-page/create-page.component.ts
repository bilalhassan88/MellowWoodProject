import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
  PageServiceProxy,
  PageDto,
  CreatePageDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-page.component.html',
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
export class CreatePageComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  page: PageDto = new PageDto();
 
  constructor(
    injector: Injector,
    private _pageService: PageServiceProxy,
    private _dialogRef: MatDialogRef<CreatePageComponent>
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._pageService
  }


  save(): void {
    this.saving = true;


    const page_ = new CreatePageDto();
    page_.init(this.page);

    this._pageService
      .create(page_)
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
