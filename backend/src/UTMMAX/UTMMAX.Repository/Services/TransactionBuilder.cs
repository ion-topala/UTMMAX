using System.Collections.Concurrent;

namespace UTMMAX.Repository.Services
{
    internal class TransactionBuilder : ITransactionBuilder
    {
        private readonly DataContext             _context;
        private readonly ConcurrentQueue<Action> _onCompleteActions = new ConcurrentQueue<Action>();

        public TransactionBuilder(DataContext context)
        {
            _context = context;
        }

        public ITransaction Begin()
        {
            return new Transaction(_context.Database.BeginTransaction(), OnTransactionFinish);
        }

        public bool IsInTransaction()
        {
            return _context.Database.CurrentTransaction != null;
        }

        public void ScheduleOnTransactionComplete(Action action)
        {
            _onCompleteActions.Enqueue(action);
        }

        private void OnTransactionFinish(bool success)
        {
            if (success)
            {
                while (!_onCompleteActions.IsEmpty)
                {
                    if (_onCompleteActions.TryDequeue(out var action))
                    {
                        action();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            _onCompleteActions.Clear();
        }
    }
}