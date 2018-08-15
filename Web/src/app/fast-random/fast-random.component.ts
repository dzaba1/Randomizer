import { Component, OnInit } from '@angular/core';
import { SelectableItem } from '../model/selectableItem';

@Component({
  selector: 'app-fast-random',
  templateUrl: './fast-random.component.html',
  styleUrls: ['./fast-random.component.scss']
})
export class FastRandomComponent implements OnInit {

  public items = new Array<SelectableItem>();
  public newValue = '';

  constructor() { }

  ngOnInit() {
  }

  public add() {
    const newItem = new SelectableItem();
    newItem.isSelected = true;
    newItem.name = this.newValue;
    this.items.push(newItem);
    this.newValue = '';
  }

  public remove(index: number) {
    this.items.splice(index, 1);
  }
}
