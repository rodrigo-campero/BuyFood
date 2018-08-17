import { Component, OnInit } from '@angular/core';
import { Restaurant } from './restaurant.domain';
import { RestaurantService } from './restaurant.service';

@Component({
    selector: 'index',
    templateUrl: './restaurant.component.index.html'
})
export class RestaurantComponentIndex implements OnInit {
    title: string = 'app';
    restaurants: Restaurant[] = [];
    service: RestaurantService;

    constructor(service: RestaurantService) {
        this.service = service;
        this.service
            .getAll()
            .subscribe(restaurants => {
                this.restaurants = restaurants;
            }, error => console.log(error));
    }

    remove(restaurant: Restaurant) {
        this.service.remove(restaurant)
        .subscribe(res => {
            let newRestaurants = this.restaurants.splice(0);
            let index = newRestaurants.indexOf(restaurant);
            newRestaurants.splice(index, 1);
            this.restaurants = newRestaurants;
            console.log(res);
        }, erro => console.log(erro));
    }

    ngOnInit() {
        console.log('init')
    }
}