import { Http, Headers, Response } from '@angular/http';
import { Dish } from './dish.domain';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

@Injectable()
export class DishService {
    http: Http;
    headers: Headers;
    url: string = 'https://localhost:5001/api/v1/dish';

    constructor(http: Http) {
        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json')
    }

    add(dish: Dish): Observable<Response> {
        if (dish.dishId) {
            return this.http.put(this.url, JSON.stringify(dish), { headers: this.headers });
        }
        return this.http.post(this.url, JSON.stringify(dish), { headers: this.headers });
    }

    remove(dish: Dish): Observable<Response> {
        return this.http.delete(`${this.url}/${dish.dishId}`)
    }

    getById(id: string): Observable<Dish> {
        return this.http.get(`${this.url}/${id}`)
            .map(res => res.json())
    }

    getAll(search: string = ''): Observable<Dish[]> {
        return this.http.get(`${this.url}/${search}`)
            .map(res => res.json());
    }
}