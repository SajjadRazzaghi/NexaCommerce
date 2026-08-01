
namespace NexaCommerce.Modules.Catalog.Infrastructure.Services
{
    public class ProductSnapshotDto
    {
        private Guid id;
        private object name;
        private decimal price;
        private bool isActive;

        public ProductSnapshotDto(Guid id, object name, decimal price, bool isActive)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.isActive = isActive;
        }
    }
}