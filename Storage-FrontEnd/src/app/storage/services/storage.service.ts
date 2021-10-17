import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RESULT_ITEMS } from '../mock/mock-resultItem';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ResultItem } from '../models/resultItem';

@Injectable()
export class StorageService {
  constructor(private http: HttpClient) {

  }

  getItems() {
    return this.http.get<ResultItem[]>('http://localhost:25616/Storage')
      .toPromise();

    //return Promise.resolve(RESULT_ITEMS);
  }
}
