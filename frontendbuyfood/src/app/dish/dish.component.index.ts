import { Component, OnInit } from '@angular/core';
import { Dish } from './dish.domain';
import { DishService } from './dish.service';

@Component({
    selector: 'index',
    templateUrl: './dish.component.index.html'
})
export class DishComponentIndex implements OnInit {
    title: string = 'app';
    dishs: Dish[] = [];
    service: DishService;

    constructor(service: DishService) {
        this.service = service;
        this.service
            .getAll()
            .subscribe(dishs => {
                this.dishs = dishs;
            }, error => console.log(error));
    }

    remove(dish: Dish) {
        this.service.remove(dish)
        .subscribe(res => {
            let newDishs = this.dishs.splice(0);
            let index = newDishs.indexOf(dish);
            newDishs.splice(index, 1);
            this.dishs = newDishs;
            console.log(res);
        }, erro => console.log(erro));
    }

    ngOnInit() {
        console.log('init')
    }
}