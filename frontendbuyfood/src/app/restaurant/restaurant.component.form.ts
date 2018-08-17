import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Restaurant } from './restaurant.domain';
import { RestaurantService } from './restaurant.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'restaurant-form',
    templateUrl: './restaurant.component.form.html'
})
export class RestaurantComponentForm {
    restaurant: Restaurant = new Restaurant();
    restaurantForm: FormGroup;
    service: RestaurantService;
    route: ActivatedRoute;
    router: Router;

    constructor(service: RestaurantService, fb: FormBuilder, route: ActivatedRoute, router: Router) {
        this.service = service;
        this.route = route;
        this.router = router;
        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.service.getById(id)
                    .subscribe(restaurant => this.restaurant = restaurant, erro => console.log(erro));
            }
        })
        this.restaurantForm = fb.group({
            name: ['', Validators.compose([Validators.required, Validators.minLength(4)])]
        });
    }

    add(event) {
        event.preventDefault();
        this.service.add(this.restaurant)
            .subscribe(res => {
                this.restaurant = new Restaurant();
                this.router.navigate(['restaurants'])
            }, error => console.log(error));
    }
}