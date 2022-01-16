import { Component } from '@angular/core';
import { ReviewService } from '../services/review.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  review: Review;
  reviews: Review[] = [];

  constructor(private reviewService: ReviewService) {
  }

  generateReview() {
    this.reviewService.generateReview().subscribe((data: Review) => this.review = data);
  }

  generateReviews(numberOfReviews: number) {
    this.reviewService.generateReviews(numberOfReviews).subscribe((data: Review) => this.reviews.push(data));
  }
}
