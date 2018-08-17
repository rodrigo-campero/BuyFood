import { Pipe, PipeTransform } from '@angular/core';
import { DishService } from './dish.service';

@Pipe({
    name: 'filterByName'
})
export class DishFilterByName implements PipeTransform {
    service: DishService;
    constructor(service: DishService) {
        this.service = service;
    }
    transform(dishs, digited: string) {
      this.service.getAll(digited).subscribe(res => dishs = res);
        return dishs.filter(dish => dish.name.toLowerCase().includes(digited.toLowerCase()));
    }
}