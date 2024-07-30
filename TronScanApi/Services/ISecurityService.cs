using TronScanApi.Models;

public interface ISecurityService
{
	Task<TransactionSecurityDto> GetTransactionDetails(string transactionHash);
}