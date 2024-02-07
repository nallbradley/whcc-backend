namespace CoinApi.Services {
    public interface ICoinService 
    {
        /// <summary>
        /// Get the amount of coins for a USD amount. Smallest amount
        /// of coins possible.
        /// </summary>
        /// <param name="amount">the usd amount</param>
        /// <returns>a dictionary representing the amount of each
        /// coin that equals the USD amount</returns>
        public Dictionary<string, int> GetChange(decimal amount);
    }
}
