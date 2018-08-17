import { NgModule } from "@angular/core";
import { RestaurantComponentForm } from "./restaurant.component.form";
import { RestaurantComponentIndex } from "./restaurant.component.index";
import { RestaurantFilterByName } from "./restaurant.pipes";
import { RestaurantService } from "./restaurant.service";
import { CommonModule } from "@angular/common";

@NgModule({
    imports: [CommonModule],
    declarations: [RestaurantComponentForm, RestaurantComponentIndex, RestaurantFilterByName],
    exports: [RestaurantComponentForm, RestaurantComponentIndex, RestaurantFilterByName],
    providers: [RestaurantService]
})
export class RestaurantModule { }