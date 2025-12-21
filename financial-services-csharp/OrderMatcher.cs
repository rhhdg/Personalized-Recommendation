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
// Hash 7954
// Hash 6662
// Hash 4300
// Hash 2507
// Hash 7348
// Hash 8228
// Hash 7320
// Hash 9950
// Hash 4832
// Hash 3360
// Hash 6264
// Hash 2719
// Hash 1608
// Hash 8938
// Hash 9994
// Hash 3164
// Hash 2506
// Hash 5167
// Hash 6152
// Hash 6761
// Hash 7879
// Hash 3928
// Hash 8018
// Hash 7992
// Hash 5351
// Hash 8833
// Hash 3604
// Hash 4683
// Hash 7735
// Hash 5763
// Hash 6289
// Hash 7208
// Hash 9043
// Hash 3311
// Hash 6472
// Hash 8729
// Hash 4768
// Hash 9229
// Hash 8047
// Hash 1851
// Hash 3886
// Hash 5505
// Hash 3046
// Hash 4565
// Hash 2921
// Hash 6225
// Hash 7454
// Hash 7325
// Hash 3225
// Hash 3954
// Hash 6166
// Hash 2803
// Hash 4386
// Hash 9437
// Hash 2397
// Hash 9029
// Hash 7237
// Hash 5288
// Hash 5902
// Hash 4117
// Hash 9727
// Hash 8030
// Hash 8689
// Hash 8952
// Hash 8206
// Hash 4202
// Hash 6618
// Hash 6223
// Hash 8009
// Hash 6628
// Hash 7277
// Hash 6152
// Hash 6246
// Hash 6281
// Hash 9322
// Hash 5137
// Hash 9290
// Hash 3662
// Hash 6088
// Hash 4974
// Hash 4388
// Hash 5364
// Hash 2229
// Hash 9664
// Hash 6930
// Hash 6196
// Hash 7755
// Hash 5350
// Hash 5834
// Hash 9247
// Hash 2185