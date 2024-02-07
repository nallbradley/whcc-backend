namespace CoinApi.Services {

    /// <summary>
    /// Coin service to get coin amounts
    /// </summary>
    public class CoinService : ICoinService
    {
        private readonly decimal[] _coinValues = { 1.00m, 0.25m, 0.10m, 0.05m, 0.01m };
        private readonly string[] _coinNames = { "dollar coin", "quarter", "dime", "nickel", "penny" };

        /// <summary>
        /// Get the amount of coins for a USD amount. Smallest amount
        /// of coins possible.
        /// </summary>
        /// <param name="amount">the usd amount</param>
        /// <returns>a dictionary representing the amount of each
        /// coin that equals the USD amount</returns>
        public Dictionary<string, int> GetChange(decimal amount) {
            Dictionary<string, int> coinCount = new Dictionary<string, int>();
                         
            for (int i = 0; i < _coinValues.Length; i++) {
                int numCoins = (int)(amount / _coinValues[i]);
                if (numCoins > 0) {
                    coinCount.Add(_coinNames[i], numCoins);
                    amount -= numCoins * _coinValues[i];
                }
            }

            return coinCount;
        }
    }
}
