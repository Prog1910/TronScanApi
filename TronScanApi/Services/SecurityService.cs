using Microsoft.Extensions.Options;
using System.Runtime.Serialization;
using TronScanApi.Models;

public class SecurityService : ISecurityService
{
	private readonly HttpClient _httpClient;

	public SecurityService(HttpClient httpClient, IOptions<TronScanApiOptions> options)
	{
		_httpClient = httpClient;
		_httpClient.DefaultRequestHeaders.Add("apikey", options.Value.ApiKey);
		_httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
	}

	public async Task<TransactionSecurityDto> GetTransactionDetails(string transactionHash)
	{
		string requestUri = $"{_httpClient.BaseAddress}/security/transaction/data?hashes={transactionHash}";
		var response = await _httpClient.GetAsync(requestUri);

		response.EnsureSuccessStatusCode();
		var transactionDetailsCollection = await response.Content.ReadFromJsonAsync<IDictionary<string, TransactionSecurityDto>>()
			?? throw new SerializationException();

		var transactionDetails = new TransactionSecurityDto();
		transactionDetailsCollection.TryGetValue(transactionHash, out transactionDetails);
		return transactionDetails ?? throw new Exception();
	}
}