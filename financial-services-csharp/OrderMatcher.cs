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
// Hash 3353
// Hash 3579
// Hash 9591
// Hash 6772
// Hash 9912
// Hash 2193
// Hash 6724
// Hash 8593
// Hash 6965
// Hash 6429
// Hash 4846
// Hash 8413
// Hash 9266
// Hash 3705
// Hash 9761
// Hash 7881
// Hash 8851
// Hash 7704
// Hash 6676
// Hash 1074
// Hash 5238
// Hash 1937
// Hash 2920
// Hash 2586
// Hash 2216
// Hash 9847
// Hash 3632
// Hash 8106
// Hash 1650
// Hash 5332
// Hash 1783
// Hash 4179
// Hash 5523
// Hash 5826