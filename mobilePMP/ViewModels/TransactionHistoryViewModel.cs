using mobilePMP.Services;
using ReactiveUI;
namespace mobilePMP.ViewModels
{
    public class TransactionHistoryViewModel : BaseViewModel
    {
        private readonly ITransactionHistoryService _transactionHistoryService;

        public TransactionHistoryViewModel(ITransactionHistoryService transactionHistoryService)
        {
            _transactionHistoryService = transactionHistoryService;
            Title = "Transacciones";
        }

        public ReactiveList<TransactionViewModel> Transactions => _transactionHistoryService.Transactions;
    }
}
