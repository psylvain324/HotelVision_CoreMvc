import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html'
})
export class BanquetComponent {
  public banquets: Banquet[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Banquet[]>(baseUrl + '/Api/Banquets').subscribe(result => {
      this.banquets = result;
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
}