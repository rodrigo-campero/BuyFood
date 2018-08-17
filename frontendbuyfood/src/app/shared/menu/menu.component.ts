import { Component, Input } from '@angular/core'

@Component({
    selector: 'menu',
    templateUrl: './menu.component.html',
    styleUrls: [ './menu.component.css' ]
})
export class MenuComponent {
    @Input() titulo;
}