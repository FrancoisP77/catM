import { HttpClient } from "@angular/common/http";
import { Observable, catchError, tap, throwError, map } from "rxjs";
import { Cat } from "../Cats/Models/cat";
import { Inject, Injectable } from "@angular/core";
import { API_URL } from "src/common.settings";

@Injectable({
    providedIn: 'root'
})
export class CatService {
    /* We may want to generate a client from the swagger */
    private _catEndpoint = "/api/v1/cats/";
    private _randomMashEndpoint = "/api/v1/cats/RandomMash/";
    private _voteEndpoint = "/api/v1/cats/{id}/vote";
    private _totalVotesEndpoint = "/api/v1/cats/TotalVotes";

    constructor(
        @Inject(API_URL) private _baseUrl: string,
        private _httpClient: HttpClient
    ) {}

    getAll(): Observable<Cat[]> {
        return this._httpClient.get<Cat[]>(this._baseUrl + this._catEndpoint).pipe(
            tap(x => console.log(JSON.stringify(x))), // Great for debugging but not mandatory
            catchError(errorResponse => {
               console.error(errorResponse.error.message);
               return throwError(() => errorResponse.error.message)
            })
        )
    }

    getRandomMash(): Observable<Cat[]> {
        return this._httpClient.get<Cat[]>(this._baseUrl + this._randomMashEndpoint).pipe(
            tap(x => console.log(JSON.stringify(x))), // Great for debugging but not mandatory
            catchError(errorResponse => {
               console.error(errorResponse.error.message);
               return throwError(() => errorResponse.error.message)
            })
        )
    }

    Vote(id: string): Observable<void> {
        return this._httpClient.post<any>((this._baseUrl + this._voteEndpoint).replace("{id}", id), null).pipe(
            catchError(errorResponse => {
                console.error(errorResponse.error.message);
                return throwError(() => errorResponse.error.message)
             })
        );
    }

    GetTotalVotes(): Observable<number> {
        return this._httpClient.get<number>((this._baseUrl + this._totalVotesEndpoint)).pipe(
            catchError(errorResponse => {
                console.error(errorResponse.error.message);
                return throwError(() => errorResponse.error.message)
             })
        );
    }
}