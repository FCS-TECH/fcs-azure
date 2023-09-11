namespace FCS.Lib.Azure;

public class AzureConfigStore
{
    public AzureConfigStore(string baseUrl, string tenantId, string environment,
        string api, string apiGroup, string apiVersion,
        string ledgerId, string oDataVersion)
    {
        BaseUrl = baseUrl;
        TenantId = tenantId;
        Environment = environment;
        Api = api;
        ApiGroup = apiGroup;
        ApiVersion = apiVersion;
        LedgerId = ledgerId;
        ODataVersion = oDataVersion;
    }

    protected string BaseUrl { get; set; }
    protected string TenantId { get; }
    protected string Environment { get; set; }
    protected string Api { get; set; }
    protected string ApiGroup { get; set; }
    protected string ApiVersion { get; set; }
    protected string LedgerId { get; set; }
    protected string ODataVersion { get; set; }

    public string InnoClientApiEndpoint()
    {
        return $"{BaseUrl}/{TenantId}/{Environment}/api/{Api}/{ApiGroup}/{ApiVersion}/companies({LedgerId})";
    }

    public string InnoClientOAuthEndpoint()
    {
        return $"{BaseUrl}/{TenantId}/{Environment}/{ODataVersion}/Company('{LedgerId}')";
    }
}