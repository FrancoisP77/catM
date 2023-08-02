import { Component, OnDestroy, OnInit } from '@angular/core';
import { Cat } from '../Models/cat';
import { CatService } from 'src/app/Services/CatService';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-catlist',
  templateUrl: './catlist.component.html',
  styleUrls: ['./catlist.component.css']
})
export class CatlistComponent implements OnInit, OnDestroy {
  public allCats : Cat[] = [];
  catSubscription: Subscription = null!;

  constructor(private _catService: CatService) {}
  
  ngOnInit(): void {
    /* We may want to add some paging here. */
    this.loadAllCats();
  }
  ngOnDestroy(): void {
    this.catSubscription.unsubscribe();
  }

  public loadAllCats()
  {
    this.catSubscription = this._catService.getAll().subscribe({
      next: cats => {
        this.allCats = cats;
      },
      error: err => alert(err)
    });
  }
}