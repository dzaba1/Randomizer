import { Component, OnInit } from '@angular/core';
import { SelectableItem } from '../model/selectableItem';
import { CheckBoxViewModel } from '../model/checkBoxViewModel';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatSelectionListChange } from '@angular/material/list';

@Component({
  selector: 'app-fast-random',
  templateUrl: './fast-random.component.html',
  styleUrls: ['./fast-random.component.scss']
})
export class FastRandomComponent implements OnInit {

  public items = new Array<SelectableItem>();
  public newValue = '';
  public selectAll = new CheckBoxViewModel();

  constructor() { }

  ngOnInit() {
  }

  public add() {
    const newItem = new SelectableItem();
    newItem.isSelected = true;
    newItem.name = this.newValue;

    this.items.push(newItem);
    this.newValue = '';
    this.refreshSelectAll();
  }

  public remove(index: number) {
    this.items.splice(index, 1);
  }

  public onSelectAllChange(event: MatCheckboxChange) {
    for (const item of this.items) {
      item.isSelected = event.checked;
    }
  }

  private refreshSelectAll() {
    let allSelected = true;
    let allNotSelected = true;

    for (const item of this.items) {
      if (item.isSelected) {
        allNotSelected = false;
      } else {
        allSelected = false;
      }
    }

    if (allSelected) {
      this.selectAll.setValue(true);
    } else if (allNotSelected) {
      this.selectAll.setValue(false);
    } else {
      this.selectAll.setValue(null);
    }
  }

  public onItemSelectionChanged(event: MatSelectionListChange) {
    const option = event.option;
    const item = this.items[option.value];
    item.isSelected = option.selected;

    this.refreshSelectAll();
  }
}
