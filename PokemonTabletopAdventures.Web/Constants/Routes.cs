namespace PokemonTabletopAdventures.Web.Constants;

public static class Routes
{
    public const string ApiRootUrl = nameof(ApiRootUrl);
    public const string PokemonForms = "api/v2/pokedex";
    #if DEBUG
    public const string PtaRoot = "/";
    #else
    public const string PtaRoot = "/pokemon-tabletop-adventures/";
    #endif
}
