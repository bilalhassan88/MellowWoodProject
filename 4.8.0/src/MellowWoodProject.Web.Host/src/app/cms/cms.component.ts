import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
    PageServiceProxy,
    PageDto,
    PagedResultDtoOfPageDto
} from '@shared/service-proxies/service-proxies';
import { CreatePageComponent } from './create-page/create-page.component';
import { EditPageComponent } from './edit-page/edit-page.component';
import { ActivatedRoute, Router } from '@angular/router';

class PagedPageRequestDto extends PagedRequestDto {
    keyword: string;
}


@Component({
    templateUrl: './cms.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class CmsComponent extends PagedListingComponentBase<PageDto> {
    protected delete(entity: PageDto): void {
        throw new Error("Method not implemented.");
    }

    pages: PageDto[] = [];
    page: PageDto;
    id:string;
    htmlContent:string;
    keyword = '';
    isShow = false;
 

    constructor(
        injector: Injector,
        private _pagesService: PageServiceProxy,
        private _dialog: MatDialog,
        private route: ActivatedRoute,
        private router: Router,

    ) {
        super(injector);
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    }


    list(
        request: PagedPageRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        this.id = this.route.snapshot.paramMap.get('id');
        

        if(this.id !=null)
        {



            this._pagesService
            .get(+this.id)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )

            .subscribe((result: PageDto) => {
                this.pages.push(result);
                this.isShow = false;  
                
            });
        }
        else{     

    

        request.keyword = this.keyword;

        this._pagesService
            .getAll()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )

            .subscribe((result: PagedResultDtoOfPageDto) => {
                this.pages = result.items;
                this.isShow = true;  
            });
        }
    }



    createPage(): void {
        this.showCreateOrEditPageDialog();
    }

    editPage(page: PageDto): void {
        this.showCreateOrEditPageDialog(page.id);
    }



    showCreateOrEditPageDialog(id?: number): void {
        let createOrEditPageDialog;
        console.log(id);
        if (id === undefined || id <= 0) {
            createOrEditPageDialog = this._dialog.open(CreatePageComponent);
        } else {
            createOrEditPageDialog = this._dialog.open(EditPageComponent, {
                data: id
            });
        }

        createOrEditPageDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }
}
