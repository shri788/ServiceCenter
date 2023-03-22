using ServiceCenterReception.Entity;

namespace ServiceCenterReception.DTO
{
    public class ServiceDTOwithPagination
    {
        public long totalCount { get; set; }

        public long totalPages { get; set; }

        public long currentPage { get; set; }

        public List<ServiceDTO>? customersList { get; set; }
    }
}
