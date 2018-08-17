import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Dish } from './dish.domain';
import { DishService } from './dish.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Restaurant } from '../restaurant/restaurant.domain';
import { RestaurantService } from '../restaurant/restaurant.service';

@Component({
    selector: 'dish-form',
    templateUrl: './dish.component.form.html'
})
export class DishComponentForm {
    dish: Dish = new Dish();
    dishForm: FormGroup;
    serviceDish: DishService;
    serviceRestaurant: RestaurantService;
    route: ActivatedRoute;
    router: Router;
    restautantOptions: Restaurant[]

    constructor(serviceDish: DishService, serviceRestaurant: RestaurantService, fb: FormBuilder, route: ActivatedRoute, router: Router) {
        this.serviceDish = serviceDish;
        this.route = route;
        this.router = router;
        serviceRestaurant.getAll().subscribe(restaurants => {
            this.restautantOptions = restaurants;
        }, error => console.log(error));
        this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.serviceDish.getById(id)
                    .subscribe(dish => this.dish = dish, erro => console.log(erro));
            }
        })
        this.dishForm = fb.group({
            name: ['', Validators.compose([Validators.required, Validators.minLength(4)])],
            restaurantId: ['', Validators.compose([Validators.required])],
            price: ['', Validators.compose([Validators.required])]
        });
    }

    add(event) {
        event.preventDefault();
        console.log(this.dish);
        this.serviceDish.add(this.dish)
            .subscribe(res => {
                this.dish = new Dish();
                this.router.navigate(['dishs'])
            }, error => console.log(error));
    }
}