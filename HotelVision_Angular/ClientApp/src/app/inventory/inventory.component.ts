import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html'
})
export class InventoryComponent {
  public items: InventoryItem[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<InventoryItem[]>(baseUrl + '/Api/InventoryItems').subscribe(result => {
      this.items = result;
    }, error => console.error(error));
  }
}

interface InventoryItem {
  Id: number;
  CategoryName: string;
  CurrentStock: number;
  Capacity: number;
  RemainingStock: number;
  StockPercent: number;
  UnitCost: number;
  TotalCost: number;
  RestockScheduled: boolean;
  RestockScheduleDate: Date;
  LastRestockDate: Date;
  LastModifiedDate: Date;
}
