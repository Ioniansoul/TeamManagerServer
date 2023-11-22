namespace TeamManagerServer.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto newTransaction);
        Task<ServiceResponse<List<GetTransactionDto>>> GetTransactions();
        Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id);
        Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto updatedTransaction);
        Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int id);
    }
}