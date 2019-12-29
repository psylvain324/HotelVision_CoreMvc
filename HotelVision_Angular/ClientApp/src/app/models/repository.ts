import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core'; 
import { Filter, Pagination } from "./configClasses.repository";
import { InventoryItem } from "./inventory-item.model";

const inventoryItemsUrl = "/Api/Inventory";

@Injectable()
export class Repository {
	private filterObject = new Filter();
	private paginationObject = new Pagination();

	constructor(private http: HttpClient) {
        this.filter.related = true;
        this.getInventoryItems();
    }

  getInventoryItem(id: number) {
      this.http.get(inventoryItemsUrl + "/" + id)
          .subscribe(response => { this.inventoryItem = response });
  }

  getInventoryItems(_related = false) {
	  let url = inventoryItemsUrl + "?related=" + this.filter.related;
    if (this.filter.category) {
        url += "&category=" + this.filter.category;
    }
    if (this.filter.search) {
        url += "&search=" + this.filter.search;
    }
	  url += "&metadata=true";
      this.http.get<any>(url)
          .subscribe(response => {
              this.inventoryItems = response.data;
              this.categories = response.categories;
              this.pagination.currentPage = 1;
          });
	}

	createInventoryItem(invItem: InventoryItem) {
		let data = {
            id: invItem.Id ? invItem.Id : 0,
            category: invItem.CategoryName,
            currentStock: invItem.CurrentStock,
            capacity: invItem.Capacity,
            remainingStock: invItem.RemainingStock,
            stockPercent: invItem.StockPercent,
            unitCost: invItem.UnitCost,
            totalCost: invItem.TotalCost,
            restockScheduled: invItem.RestockScheduled,
            restockScheduleDate: invItem.RestockScheduleDate,
            lastRestockDate: invItem.LastRestockDate,
            lastModifiedDate: invItem.LastModifiedDate
		};
		this.http.post<number>(inventoryItemsUrl, data)
			.subscribe(response => {
        invItem.Id = response;
        this.inventoryItems.push(invItem);
			});
	}

	replaceInventoryItem(invItem: InventoryItem) {
    let data = {
        id: invItem.Id ? invItem.Id : 0,
        category: invItem.CategoryName,
        currentStock: invItem.CurrentStock,
        capacity: invItem.Capacity,
        remainingStock: invItem.RemainingStock,
        stockPercent: invItem.StockPercent,
        unitCost: invItem.UnitCost,
        totalCost: invItem.TotalCost,
        restockScheduled: invItem.RestockScheduled,
        restockScheduleDate: invItem.RestockScheduleDate,
        lastRestockDate: invItem.LastRestockDate,
        lastModifiedDate: invItem.LastModifiedDate
    };
    this.http.put(inventoryItemsUrl + "/" + invItem.Id, data)
			  .subscribe(_response => this.getInventoryItems());
	}

	updateInventoryItem(id: number, changes: Map<string, any>) {
		let patch = [];
		changes.forEach((value, key) =>
    patch.push({ op: "replace", path: key, value: value }));
        this.http.patch(inventoryItemsUrl + "/" + id, patch)
          .subscribe(_response => this.getInventoryItems());
  }

  deleteInventoryItem(id: number) {
      this.http.delete(inventoryItemsUrl + "/" + id)
          .subscribe(_response => this.getInventoryItems());
	}

	storeSessionData(dataType: string, data: any) {
		return this.http.post("/Api/Session/" + dataType, data)
			.subscribe(_response => { });
    }

	getSessionData(dataType: string): any {
		return this.http.get("/Api/Session/" + dataType);
	}

  categories: string[] = [];
  inventoryItems: InventoryItem[] = [];
  inventoryItem: InventoryItem;
	
	get filter(): Filter {
		return this.filterObject;
	}
	get pagination(): Pagination {
		return this.paginationObject;
	}
}
