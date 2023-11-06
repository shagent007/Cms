﻿using Cms.Shared.Shared;
using Cms.Shared.Shared.Entities;

namespace Cms.ECommerce.Modules.CommodityCategory.Entities;

public class CommodityCategory:Entity
{
    public long CategoryId { get; set; }
    public Category.Entities.Category Category { get; set; } = new();
    public long CommodityId { get; set; }
    public Commodity.Entities.Commodity Commodity { get; set; } = new();
    
    protected override int GetClassId() => ClassNames.CommodityCategory;
}