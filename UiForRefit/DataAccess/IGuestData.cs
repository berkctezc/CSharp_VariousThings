namespace UiForRefit.DataAccess;

public interface IGuestData
{
	[Get("/Guests")]
	Task<List<GuestModel>> GetGuests();

	[Get("/Guests/{id}")]
	Task<List<GuestModel>> GetGuest(int id);

	[Post("/Guests")]
	Task<List<GuestModel>> CreateGuest([Body] GuestModel guest);

	[Put("/Guests/{id}")]
	Task<List<GuestModel>> UpdateGuest(int id, [Body] GuestModel guest);

	[Delete("/Guests/{id}")]
	Task<List<GuestModel>> DeleteGuest(int id);
}