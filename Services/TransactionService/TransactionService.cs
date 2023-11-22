namespace TeamManagerServer.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TransactionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto newTransaction)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var transaction = _mapper.Map<Transaction>(newTransaction);
                    _context.Transactions.Add(transaction);
                    await _context.SaveChangesAsync();
                    dbTransaction.Commit();
                }

                catch (Exception)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "An unknown error has occurred.";
                    dbTransaction.Rollback();
                }
            }

            serviceResponse.Data = 
                await _context.Transactions
                .Select(c => _mapper.Map<GetTransactionDto>(c))
                .ToListAsync();
                
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> DeleteTransaction(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            
            try
           { 
                var transaction =
                    await _context.Transactions
                    .FirstOrDefaultAsync(c => c.TransactionId == id);

                if(transaction is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Transaction not found.";
                    return serviceResponse;
                }

                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();    

                serviceResponse.Data = 
                    await _context.Transactions
                    .Select(c => _mapper.Map<GetTransactionDto>(c))
                    .ToListAsync();       
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();
            
            try
            {
                var transaction =
                    await _context.Transactions
                    .FirstOrDefaultAsync(c => c.TransactionId == id);

                if(transaction is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Transaction not found.";
                    return serviceResponse;
                }

                serviceResponse.Data = _mapper.Map<GetTransactionDto>(transaction);  
            }   

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> GetTransactions()
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            
            var transactions =
                await _context.Transactions
                .Select(c => _mapper.Map<GetTransactionDto>(c))
                .ToListAsync();
            
            if(transactions.Count == 0)
            {
                serviceResponse.Message = "No transactions found.";
            }

            serviceResponse.Data = transactions;                
                
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto updatedTransaction)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();
            using (var dbTransaction = _context.Database.BeginTransaction())    
            {        
                try
                {            
                    var transaction = 
                        await _context.Transactions
                        .FirstAsync(c => c.TransactionId == updatedTransaction.TransactionId);        

                    _mapper.Map(updatedTransaction, transaction);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<GetTransactionDto>(transaction);    
                    dbTransaction.Commit();
                }      

                catch
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "An unknown error has occurred.";
                    dbTransaction.Rollback();
                }
            }

            return serviceResponse;
        }
    }
}