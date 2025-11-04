using MagicOnion.Server.Hubs;
using MapLib.Core.Interfaces;
using MapLib.Core.Models.ObjectModel;
using MapService.DTO.Requests;
using MapService.DTO.Responses;
using MapService.Interfaces;

namespace MapService.Services;

public class MapHubService
    (
        IGameService gameService
        ) : StreamingHubBase<IMapHub, IMapHubReceiver>, IMapHub
{
    public async Task<PlaceObjectResponse> PlaceObjectAsync(PlaceObjectRequest request)
    {
        var result = await gameService.PlaceObject(request.X, request.Y, (ObjectType)request.ObjectType);

        return new PlaceObjectResponse()
        {
            ObjectId = result.Item1,
            ObjectType = (int)result.Item2,
        };
    }

    public async Task<GetObjectsInAreaResponse> GetObjectsInAreaAsync(GetObjectsInAreaRequests request)
    {
        var result = await gameService.GetObjectsInArea(request.X1, request.X2, request.Y1, request.Y2);
        var items = result.Select(m => new GetObjectsInAreaResponse.ObjectItem()
        {
            Id = m.Id,
            Type = (int)m.Type,
            X = m.X,
            Y = m.Y,
        }).ToList();

        return new GetObjectsInAreaResponse()
        {
            Items = items,
        };
    }

    public Task<GetTerritoriesInAreaResponse> GetTerritoriesInAreaAsync(GetTerritoriesInAreaRequest request)
    {
        return Task.Run(() =>
        {
            var items = gameService.GetTerritoriesInArea(request.X1, request.X2, request.Y1, request.Y2)
                .Select(m => new GetTerritoriesInAreaResponse.TerritoryItem()
                {
                    Id = m.Id,
                    BordersInfo = new GetTerritoriesInAreaResponse.TerritoryItem.BordersInfoItem()
                    {
                        Height = m.BordersInfo.Height,
                        Width = m.BordersInfo.Width,
                        OffsetX = m.BordersInfo.OffsetX,
                        OffsetY = m.BordersInfo.OffsetY,
                    }
                }).ToList();

            return new GetTerritoriesInAreaResponse()
            {
                Items = items
            };
        });
    }

    public async Task<DeleteObjectResponse> DeleteObjectAsync(DeleteObjectRequest request)
    {
        var objectId = await gameService.DeleteObject(request.ObjectId);

        return new DeleteObjectResponse()
        {
            ObjectId = objectId
        };
    }
}