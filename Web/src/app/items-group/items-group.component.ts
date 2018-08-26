import { Component, OnInit, Input } from '@angular/core';
import { CheckBoxViewModel } from '../model/checkBoxViewModel';
import { SelectableItem } from '../model/selectableItem';
import { MatSelectionListChange } from '@angular/material/list';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { Require } from '../../utils/require';
import { LoggingService } from '../services/logging.service';

@Component({
  selector: 'app-items-group',
  templateUrl: './items-group.component.html',
  styleUrls: ['./items-group.component.scss']
})
export class ItemsGroupComponent implements OnInit {

  @Input()
  public name: string;

  @Input()
  public items: string[];

  public itemsViewModel = new Array<SelectableItem>();
  public selectAll = new CheckBoxViewModel();

  constructor(private logger: LoggingService) { }

  ngOnInit() {
    this.logger.debug(`Initializing ItemsGroupComponent of name '${this.name}'.`);

    if (this.items != null) {
      for (const item of this.items) {
        this.add(item);
      }
    }

    this.refreshSelectAll();
  }

  public remove(index: number) {
    Require.notNull(index, 'index');

    this.logger.debug(`ItemsGroupComponent: Removing item of index ${index}.`);
    this.itemsViewModel.splice(index, 1);
  }

  public onSelectAllChange(event: MatCheckboxChange) {
    Require.notNull(event, 'event');
    Require.notNull(event.checked, 'event.checked');

    this.logger.debug(`ItemsGroupComponent: Select all value: ${event.checked}.`);
    for (const item of this.itemsViewModel) {
      item.isSelected = event.checked;
    }
  }

  public refreshSelectAll() {
    this.logger.debug('ItemsGroupComponent: Refreshing state of select all checkbox.');

    let allSelected = true;
    let allNotSelected = true;

    for (const item of this.itemsViewModel) {
      if (item.isSelected) {
        allNotSelected = false;
      } else {
        allSelected = false;
      }
    }

    if (allNotSelected) {
      this.selectAll.setValue(false);
    } else if (allSelected) {
      this.selectAll.setValue(true);
    } else {
      this.selectAll.setValue(null);
    }
  }

  public onItemSelectionChanged(event: MatSelectionListChange) {
    Require.notNull(event, 'event');
    Require.notNull(event.option, 'event.option');
    Require.notNull(event.option.value, 'event.option.value');
    Require.notNull(event.option.selected, 'event.option.selected');

    const option = event.option;
    const index = option.value as number;

    this.logger.debug(`ItemsGroupComponent: Item of index ${index} changed selection to '${option.selected}'.`);

    const item = this.itemsViewModel[index];
    item.isSelected = option.selected;

    this.refreshSelectAll();
  }

  public add(value: string) {
    Require.notEmptyString(value, 'value');

    this.logger.debug(`ItemsGroupComponent: Adding new item: '${value}'.`);

    const viewModel = new SelectableItem();
    viewModel.isSelected = true;
    viewModel.name = value;
    this.itemsViewModel.push(viewModel);
  }

  public get selectedItems(): string[] {
    return this.itemsViewModel
      .filter(i => i.isSelected)
      .map(i => i.name);
  }
}
