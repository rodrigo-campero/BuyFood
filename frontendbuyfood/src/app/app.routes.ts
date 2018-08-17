import { Routes, RouterModule } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { RestaurantComponentForm } from './restaurant/restaurant.component.form';
import { RestaurantComponentIndex } from './restaurant/restaurant.component.index';
import { DishComponentIndex } from './dish/dish.component.index';
import { DishComponentForm } from './dish/dish.component.form';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: 'restaurants',
        children: [
            { path: '', component: RestaurantComponentIndex },
            { path: 'add', component: RestaurantComponentForm },
            { path: 'edit/:id', component: RestaurantComponentForm }
        ]
    },
    {
        path: 'dishs',
        children: [
            { path: '', component: DishComponentIndex },
            { path: 'add', component: DishComponentForm },
            { path: 'edit/:id', component: DishComponentForm }
        ]
    },
    { path: '**', component: HomeComponent }
];

export const routing = RouterModule.forRoot(appRoutes);