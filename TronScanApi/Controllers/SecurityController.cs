using Microsoft.AspNetCore.Mvc;

namespace TronScanApi.Controllers;

[ApiController]
[Route("api/")]
public class SecurityController : ControllerBase
{
	private readonly ISecurityService _tronScanService;

	public SecurityController(ISecurityService tronScanService) => _tronScanService = tronScanService;

	[HttpGet("{transactionHash}")]
	public async Task<IActionResult> GetTransactionSecurity(string transactionHash)
	{
		var transactionDetails = await _tronScanService.GetTransactionDetails(transactionHash);
		return Ok(transactionDetails);
	}
}