import { Component, OnInit, ViewChild } from '@angular/core';
import { ItemsGroupComponent } from '../items-group/items-group.component';

@Component({
  selector: 'app-fast-random',
  templateUrl: './fast-random.component.html',
  styleUrls: ['./fast-random.component.scss']
})
export class FastRandomComponent implements OnInit {

  public newValue = '';

  @ViewChild(ItemsGroupComponent)
  private itemsGroup: ItemsGroupComponent;

  constructor() { }

  ngOnInit() {
  }

  public add() {
    this.itemsGroup.add(this.newValue);
    this.newValue = '';
    this.itemsGroup.refreshSelectAll();
  }
}
