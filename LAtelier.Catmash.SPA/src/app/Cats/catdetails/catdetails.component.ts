import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Cat } from '../Models/cat';

@Component({
  selector: 'app-catdetails',
  templateUrl: './catdetails.component.html',
  styleUrls: ['./catdetails.component.css']
})
export class CatdetailsComponent {
  @Input() currentCat! : Cat;
  @Output() voteClicked: EventEmitter<string> = new EventEmitter<string>();

  onClick(id: string): void {
    this.voteClicked.emit(id);
  }
}
