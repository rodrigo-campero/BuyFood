import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import 'rxjs/add/operator/map';
import { AppComponent } from './app.component';
import { routing } from './app.routes';
import { NgxCurrencyModule } from "ngx-currency";

import { MenuModule } from './shared/menu/menu.module';
import { HomeComponent } from './home/home.component';
import { RestaurantComponentForm } from './restaurant/restaurant.component.form';
import { RestaurantComponentIndex } from './restaurant/restaurant.component.index';
import { RestaurantFilterByName } from './restaurant/restaurant.pipes';
import { RestaurantService } from './restaurant/restaurant.service';
import { DishComponentForm } from './dish/dish.component.form';
import { DishComponentIndex } from './dish/dish.component.index';
import { DishFilterByName } from './dish/dish.pipes';
import { DishService } from './dish/dish.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RestaurantComponentForm,
    RestaurantComponentIndex,
    RestaurantFilterByName,
    DishComponentForm,
    DishComponentIndex,
    DishFilterByName
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    NgxCurrencyModule,
    routing,
    MenuModule
  ],
  providers: [RestaurantService, DishService, { provide: LOCALE_ID, useValue: "pt-BR" }],
  bootstrap: [AppComponent]
})
export class AppModule { }