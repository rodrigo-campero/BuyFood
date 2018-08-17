import { Dish } from "../dish/dish.domain";

export class Restaurant {
    restaurantId: string;
    name: string;
    dishes: Dish[];
}