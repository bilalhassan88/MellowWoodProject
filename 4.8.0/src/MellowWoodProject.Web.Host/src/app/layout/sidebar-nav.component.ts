import { Component, Injector, ViewEncapsulation, Inject, Injectable } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { pipe } from 'rxjs';
import { AppConsts } from '@shared/AppConsts';

@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})

@Injectable({
    providedIn: 'root'
})

export class SideBarNavComponent extends AppComponentBase {

    data: object;



    menuItems: MenuItem[] = [
        new MenuItem(this.l('HomePage'), '', 'home', '/app/home'),

        new MenuItem(this.l('Tenants'), 'Pages.Tenants', 'business', '/app/tenants'),
        new MenuItem(this.l('Users'), 'Pages.Users', 'people', '/app/users'),
        new MenuItem(this.l('Roles'), 'Pages.Roles', 'local_offer', '/app/roles'),
        new MenuItem(this.l('About'), '', 'info', '/app/about'),
        new MenuItem(this.l('CMS'), '', '', './cms'),
 
        




    ];




    baseurl = AppConsts.remoteServiceBaseUrl;

    
    // Http Headers
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    constructor(private http: HttpClient, injector: Injector) {
        super(injector);
    }

    ngOnInit() {
        this.loadPages().subscribe((d) => {

            for (var val of d['result']) {
                let url_ =  "./cms/"+ val['id'];
                this.menuItems.push(new MenuItem(this.l(val['pageName']), '', 'home', url_))
                
                
            }
        })
    }




    loadPages() {

        return this.http.get(this.baseurl + '/api/services/app/CMS/GetAll');

    }


    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }
}




