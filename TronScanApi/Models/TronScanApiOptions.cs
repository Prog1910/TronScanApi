namespace TronScanApi.Models;

public sealed class TronScanApiOptions
{
	public const string SectionName = "TronScanApi";
	public string ApiKey { get; init; } = string.Empty;
	public string BaseUrl { get; init; } = string.Empty;
}