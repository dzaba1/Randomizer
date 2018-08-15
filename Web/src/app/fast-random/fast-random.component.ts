import { Component, OnInit, ViewChild } from '@angular/core';
import { ItemsGroupComponent } from '../items-group/items-group.component';
import { RandomService } from '../services/random.service';
import { DateTimeService } from '../services/date-time.service';

@Component({
  selector: 'app-fast-random',
  templateUrl: './fast-random.component.html',
  styleUrls: ['./fast-random.component.scss']
})
export class FastRandomComponent implements OnInit {

  public newValue = '';
  public winner: string;
  public clickCount = 0;
  public timeStamp: Date;

  @ViewChild(ItemsGroupComponent)
  private itemsGroup: ItemsGroupComponent;

  constructor(private random: RandomService,
    private dateTime: DateTimeService) { }

  ngOnInit() {
  }

  public add() {
    this.itemsGroup.add(this.newValue);
    this.newValue = '';
    this.itemsGroup.refreshSelectAll();
  }

  public randomize() {
    const items = this.itemsGroup.selectedItems;
    if (items.length > 0) {
      this.clickCount++;
      const index = this.random.next(0, items.length);
      this.timeStamp = this.dateTime.getNow();
      this.winner = items[index];
    }
  }
}
