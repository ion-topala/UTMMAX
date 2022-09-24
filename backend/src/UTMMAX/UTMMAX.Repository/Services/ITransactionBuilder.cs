namespace UTMMAX.Repository.Services
{
    public interface ITransactionBuilder
    {
        ITransaction Begin();
        bool         IsInTransaction();
        void         ScheduleOnTransactionComplete(Action action);
    }
}