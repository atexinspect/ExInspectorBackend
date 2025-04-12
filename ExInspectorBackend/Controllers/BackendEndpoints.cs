using ExInspectorBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ExInspectorBackend.Controllers
{
    public static class BackendEndpoints
    {

        public static void MapBackendEndpoints(this IEndpointRouteBuilder routes)
        {

            //----------------------------------------------------------------------------------------------------

            routes.MapDelete("/api/ExInspectorBackend", async (AppDbContext db) =>
            {
                await db.Asset.ExecuteDeleteAsync();
                await db.AssetType.ExecuteDeleteAsync();
                await db.Location.ExecuteDeleteAsync();
                await db.LocationSystems.ExecuteDeleteAsync();
                await db.LotDetails.ExecuteDeleteAsync();
                await db.LotSchedules.ExecuteDeleteAsync();
                await db.Manufacturers.ExecuteDeleteAsync();
                await db.MembershipRoles.ExecuteDeleteAsync();
                await db.MembershipTasks.ExecuteDeleteAsync();
                await db.MembershipUsers.ExecuteDeleteAsync();
                await db.MembershipUsersInRoles.ExecuteDeleteAsync();
                await db.Schedules.ExecuteDeleteAsync();
                await db.WorkOrders.ExecuteDeleteAsync();
                return Results.Ok();
            });

            //----------------------------------------------------------------------------------------------------

        }

    }

}
