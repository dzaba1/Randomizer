import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-fast-random',
  templateUrl: './fast-random.component.html',
  styleUrls: ['./fast-random.component.scss']
})
export class FastRandomComponent implements OnInit {

  public items = new Array<string>();
  public newValue = '';

  constructor() { }

  ngOnInit() {
  }

  public add() {
    this.items.push(this.newValue);
    this.newValue = '';
  }

  public remove(index: number) {
    this.items.splice(index, 1);
  }
}
