import { Component, OnInit, ViewChild } from '@angular/core';
import { ItemsGroupComponent } from '../items-group/items-group.component';
import { RandomService } from '../services/random.service';
import { DateTimeService } from '../services/date-time.service';
import { LoggingService } from '../services/logging.service';

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
    private dateTime: DateTimeService,
    private logger: LoggingService) { }

  ngOnInit() {
    this.logger.debug('Initializing FastRandomComponent');
  }

  public add() {
    this.logger.debug('FastRandomComponent: Adding a new item');
    this.itemsGroup.add(this.newValue);
    this.newValue = '';
    this.itemsGroup.refreshSelectAll();
  }

  public randomize() {
    this.logger.debug('FastRandomComponent: Randomizing');
    const items = this.itemsGroup.selectedItems;
    if (items.length > 0) {
      this.clickCount++;
      const index = this.random.next(0, items.length);
      this.timeStamp = this.dateTime.getNow();
      this.winner = items[index];
    }
  }
}
