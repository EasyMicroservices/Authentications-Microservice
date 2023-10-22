using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class ServicePermissionController : SimpleQueryServiceController<ServicePermissionEntity, AddServicePermissionRequestContract, ServicePermissionContract, ServicePermissionContract, long>
    {
        public ServicePermissionController(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        [HttpPost]
        public async Task<ListMessageContract<ServicePermissionContract>> GetAllPermissionsBy(ServicePermissionRequestContract request, CancellationToken cancellationToken)
        {
            request.RoleName.ThrowIfNullOrEmpty(nameof(request.RoleName));

            var roles = await UnitOfWork.GetReadableOf<RoleEntity>()
                .Include(x => x.Children)
                .ThenInclude(x => x.Children)
                .ThenInclude(x => x.Children)
                .ThenInclude(x => x.Children)
                .Where(x => x.Name == request.RoleName)
                .Select(x => x.Id)
                .ToArrayAsync(cancellationToken);

            var servicePermissions = await UnitOfWork.GetReadableOf<RoleServicePermissionEntity>()
                .Include(x => x.ServicePermission)
                .Where(x => roles.Contains(x.RoleId) && (x.ServicePermission.MicroserviceName == null || x.ServicePermission.MicroserviceName == request.MicroserviceName))
                .Select(x => x.ServicePermission)
                .ToListAsync (cancellationToken);

            return UnitOfWork.GetMapper().MapToList<ServicePermissionContract>(servicePermissions.Distinct());
        }
    }
}
