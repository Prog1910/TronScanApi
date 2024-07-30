namespace TronScanApi.Models;

public class TransactionSecurityDto
{
	public bool RiskToken { get; set; }

	public bool ZeroTransfer { get; set; }

	public bool RiskAddress { get; set; }

	public bool SameTailAttach { get; set; }

	public bool RiskTransaction { get; set; }
}