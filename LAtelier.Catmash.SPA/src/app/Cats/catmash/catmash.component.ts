import { Component, OnDestroy, OnInit } from '@angular/core';
import { Cat } from '../Models/cat';
import { CatService } from 'src/app/Services/CatService';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-catmash',
  templateUrl: './catmash.component.html',
  styleUrls: ['./catmash.component.css']
})
export class CatmashComponent implements OnInit, OnDestroy {
  public randomcatMash: Cat[] = [];
  public totalVotes: number = 0;

  catSubscription: Subscription = null!;

  constructor(private _catService: CatService) {}

  ngOnInit(): void {
    this.loadCatMash();
  }

  voteClicked(id: string): void {
    /* We may want to prevent double clicking */
    this._catService.Vote(id).subscribe({error: err => alert(err)});
    this.loadCatMash();
  }

  ngOnDestroy(): void {
    this.catSubscription.unsubscribe();
  }

  loadCatMash(): void
  {
    this.catSubscription = this._catService.getRandomMash().subscribe({
      next: cats => {
        this.randomcatMash = cats;
        
        this.catSubscription = this._catService.GetTotalVotes().subscribe({
          next: totalVotes => {
            this.totalVotes = totalVotes;
          },
          error: err => alert(err)
        });
      },
      error: err => alert(err)
    });
  }
}
