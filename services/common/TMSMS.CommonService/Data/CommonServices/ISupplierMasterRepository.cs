using TMSMS.CommonService;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMSMS.CommonService.CommonServices
{
    public partial interface ISupplierMasterRepository : IRepository<SupplierMaster, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? name = null,
            SupplierType? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            SupplierStatus? supplierStatus = null,
            bool? preffered = null,
            int? countryId = null,
            int? supplierServiceTypeId = null,
            CancellationToken cancellationToken = default);
        Task<SupplierMasterWithNavigationProperties> GetWithNavigationPropertiesAsync(
            int id,
            CancellationToken cancellationToken = default
        );

        Task<List<SupplierMasterWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? name = null,
            SupplierType? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            SupplierStatus? supplierStatus = null,
            bool? preffered = null,
            int? countryId = null,
            int? supplierServiceTypeId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<SupplierMaster>> GetListAsync(
                    string? filterText = null,
                    string? name = null,
                    SupplierType? type = null,
                    string? contactName = null,
                    string? contactEmail = null,
                    string? dialCode = null,
                    string? contactPhone = null,
                    SupplierStatus? supplierStatus = null,
                    bool? preffered = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            SupplierType? type = null,
            string? contactName = null,
            string? contactEmail = null,
            string? dialCode = null,
            string? contactPhone = null,
            SupplierStatus? supplierStatus = null,
            bool? preffered = null,
            int? countryId = null,
            int? supplierServiceTypeId = null,
            CancellationToken cancellationToken = default);
    }
}