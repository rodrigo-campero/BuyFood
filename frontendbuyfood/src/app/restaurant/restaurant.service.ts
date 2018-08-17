import { Http, Headers, Response } from '@angular/http';
import { Restaurant } from './restaurant.domain';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

@Injectable()
export class RestaurantService {
    http: Http;
    headers: Headers;
    url: string = 'https://localhost:5001/api/v1/restaurant';

    constructor(http: Http) {
        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json')
    }

    add(restaurant: Restaurant): Observable<Response> {
        console.log(JSON.stringify(restaurant))
        if (restaurant.restaurantId) {
            return this.http.put(this.url, JSON.stringify(restaurant), { headers: this.headers });
        }
        return this.http.post(this.url, JSON.stringify(restaurant), { headers: this.headers });
    }

    remove(restaurant: Restaurant): Observable<Response> {
        return this.http.delete(`${this.url}/${restaurant.restaurantId}`)
    }

    getById(id: string): Observable<Restaurant> {
        return this.http.get(`${this.url}/${id}`)
            .map(res => res.json())
    }

    getAll(search: string = ''): Observable<Restaurant[]> {
        return this.http.get(`${this.url}/${search}`)
            .map(res => res.json());
    }
}