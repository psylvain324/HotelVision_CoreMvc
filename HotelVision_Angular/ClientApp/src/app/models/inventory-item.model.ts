export class InventoryItem {
    constructor(
      public Id?: number,
      public CategoryName?: string,
      public CurrentStock?: number,
      public Capacity?: number,
      public RemainingStock?: number,
      public StockPercent?: number,
      public UnitCost?: number,
      public TotalCost?: number,
      public RestockScheduled?: boolean,
      public RestockScheduleDate?: Date,
      public LastRestockDate?: Date,
      public LastModifiedDate?: Date) { }
	}