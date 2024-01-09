using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class ServicePermissionController : SimpleQueryServiceController<ServicePermissionEntity, AddServicePermissionRequestContract, ServicePermissionContract, ServicePermissionContract, long>
    {
        public ServicePermissionController(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ListMessageContract<ServicePermissionContract>> GetAllPermissionsBy(ServicePermissionRequestContract request, CancellationToken cancellationToken)
        {
            request.RoleName.ThrowIfNullOrEmpty(nameof(request.RoleName));

            var roles = await UnitOfWork.GetReadableOf<RoleEntity>()
                .Include(x => x.Parents)
                .Include(x => x.Children)
                .ToArrayAsync(cancellationToken);
            var roleIds = GetIds(roles.Where(x => x.Name.Equals(request.RoleName, StringComparison.OrdinalIgnoreCase)), new List<long>(), new HashSet<RoleEntity>());
            var servicePermissions = await UnitOfWork.GetReadableOf<RoleServicePermissionEntity>()
                .Include(x => x.ServicePermission)
                .Where(x => roleIds.Contains(x.RoleId) && (x.ServicePermission.MicroserviceName == null || x.ServicePermission.MicroserviceName == request.MicroserviceName))
                .Select(x => x.ServicePermission)
                .ToListAsync(cancellationToken);
            if (request.UniqueIdentity.HasValue())
                servicePermissions = servicePermissions.Where(x => x.UniqueIdentity.StartsWith(request.UniqueIdentity + "-")).ToList();
            return UnitOfWork.GetMapper().MapToList<ServicePermissionContract>(servicePermissions.Distinct());
        }

        long[] GetIds(IEnumerable<RoleEntity> roles, List<long> result, HashSet<RoleEntity> checkedList)
        {
            roles = roles.Distinct().Where(x => x != null);
            if (!roles.Any())
                return new long[0];
            var items = roles.ToList();
            foreach (var item in items)
            {
                checkedList.Add(item);
            }
            result.AddRange(items.Select(x => x.Id));
            result.AddRange(GetIds(items.SelectMany(x => x.Children.Select(p => p.Parent))
                .Where(x => !checkedList.Contains(x)), result, checkedList));
            return result.Distinct().ToArray();
        }
    }
}
