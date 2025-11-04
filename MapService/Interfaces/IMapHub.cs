using MagicOnion;
using MapService.DTO.Requests;
using MapService.DTO.Responses;

namespace MapService.Interfaces;

public interface IMapHub : IStreamingHub<IMapHub, IMapHubReceiver>
{
    Task<PlaceObjectResponse> PlaceObjectAsync(PlaceObjectRequest request);
    
    Task<GetObjectsInAreaResponse> GetObjectsInAreaAsync(GetObjectsInAreaRequests request);
    
    Task<GetTerritoriesInAreaResponse> GetTerritoriesInAreaAsync(GetTerritoriesInAreaRequest request);
    
    Task<DeleteObjectResponse> DeleteObjectAsync(DeleteObjectRequest request);
}

public interface IMapHubReceiver
{
    void OnMapEvent();
}