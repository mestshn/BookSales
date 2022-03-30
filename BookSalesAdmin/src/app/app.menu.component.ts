import {Component, OnInit} from '@angular/core';
import {AppComponent} from './app.component';

@Component({
    selector: 'app-menu',
    template: `
        <ul class="layout-menu">
            <li app-menuitem *ngFor="let item of model; let i = index;" [item]="item" [index]="i" [root]="true"></li>
        </ul>
    `
})
export class AppMenuComponent implements OnInit {

    model: any[];

    constructor(public app: AppComponent) {}

    ngOnInit() {
        this.model = [
            {
                label: 'Favoriler', icon: 'pi pi-fw pi-home',
                items: [
                    {label: 'Satış Paneli', icon: 'pi pi-fw pi-home', routerLink: ['/']},
                ]
            },
            {
                label: 'Mağaza Yönetim', icon: 'pi pi-fw pi-star', routerLink: ['/uikit'],
                items: [
                    {label: 'Ürün Listesi', icon: 'pi pi-fw pi-check-square', routerLink: ['/uikit/input']},
                    {label: 'Ürün Tanımla', icon: 'pi pi-fw pi-bookmark', routerLink: ['/uikit/floatlabel']},
                    {label: 'Sipariş Listesi', icon: 'pi pi-fw pi-exclamation-circle', routerLink: ['/uikit/invalidstate']},
                    {label: 'Stok Listesi', icon: 'pi pi-fw pi-mobile', routerLink: ['/uikit/button'], class: 'rotated-icon'},
                    {label: 'Stok Ekle', icon: 'pi pi-fw pi-circle-off', routerLink: ['/uikit/misc']}
                ]
            },
        ];
    }
}
