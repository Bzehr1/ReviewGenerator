import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ReviewService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'http://localhost:7568/api/reviews';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public generateReview() {
    return this.http.get(this.accessPointUrl + '/generate', { headers: this.headers });
  }

  public generateReviews(numberOfReviews: number) {
    return this.http.get(this.accessPointUrl + '/generate/' + numberOfReviews, { headers: this.headers });
  }
}
