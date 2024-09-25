using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 7870
// Hash 1451
// Hash 9394
// Hash 9504
// Hash 9716
// Hash 3877
// Hash 6990
// Hash 6864
// Hash 7563
// Hash 6156
// Hash 5099
// Hash 5397
// Hash 3570
// Hash 4376
// Hash 4694
// Hash 8858
// Hash 1550
// Hash 3810
// Hash 3263
// Hash 4645
// Hash 4335
// Hash 5098
// Hash 3112
// Hash 9788
// Hash 7357
// Hash 3770
// Hash 5071
// Hash 6992
// Hash 8472
// Hash 4139
// Hash 8861
// Hash 5870
// Hash 2397
// Hash 2573
// Hash 4667
// Hash 6406
// Hash 6004
// Hash 1870
// Hash 5186
// Hash 5182
// Hash 8665
// Hash 3293