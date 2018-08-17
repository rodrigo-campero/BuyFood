import { Restaurant } from '../restaurant/restaurant.domain'
export class Dish {
    dishId: string;
    name: string;
    price: string;
    restaurant: Restaurant
    restaurantId: string
}