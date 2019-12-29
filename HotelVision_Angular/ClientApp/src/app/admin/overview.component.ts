import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { InventoryItem } from "../models/inventory-item.model";

@Component({
    templateUrl: "overview.component.html"
})
export class OverviewComponent {
    constructor(private repo: Repository) { }
    get inventoryItems(): InventoryItem[] {
        return this.repo.inventoryItems;
    }
}
