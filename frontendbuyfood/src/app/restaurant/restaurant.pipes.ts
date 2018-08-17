import { Pipe, PipeTransform } from '@angular/core';
import { RestaurantService } from './restaurant.service';

@Pipe({
    name: 'filterByName'
})
export class RestaurantFilterByName implements PipeTransform {
    service: RestaurantService;
    constructor(service: RestaurantService) {
        this.service = service;
    }
    transform(restaurants, digited: string) {
        this.service.getAll(digited).subscribe(res => restaurants = res);
        return restaurants.filter(dish => dish.name.toLowerCase().includes(digited.toLowerCase()));
    }
}