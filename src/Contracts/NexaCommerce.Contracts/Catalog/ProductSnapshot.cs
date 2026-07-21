namespace NexaCommerce.Contracts.Catalog;

public sealed record ProductSnapshot(
    Guid ProductId,
    Guid ProductVariantId,
    string Name,
    string Sku,
    decimal Price,
    bool IsPublished,
    int StockQuantity);
