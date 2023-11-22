

namespace TeamnManagerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> AddTransaction(AddTransactionDto newTransaction)
        {
            return Ok(await _transactionService.AddTransaction(newTransaction));
        } 

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> GetTransactions()
        {
            return Ok(await _transactionService.GetTransactions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> GetTransactionById(int id)
        {
            return Ok(await _transactionService.GetTransactionById(id));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> UpdateTransaction(UpdateTransactionDto updatedTransaction)
        {
            return Ok(await _transactionService.UpdateTransaction(updatedTransaction));
        } 

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetTransactionDto>>>> DeleteTransaction(int id)
        {
            return Ok(await _transactionService.DeleteTransaction(id));
        } 
    }
}