
using System;

namespace Architecture
{
    public static class Bank
    {

        public static event Action OnBankInializeEvent;

        public static int coins
        {
            get
            {
                CheckClass();
                return bankInteractor.coins;
            }
        }
        public static bool isInitialized { get; private set; }

        private static BankInteractor bankInteractor;

        public static void Initialize (BankInteractor interactor)
        {
            bankInteractor = interactor;
            isInitialized = true;

            OnBankInializeEvent?.Invoke();
        }

        public static bool IsEnougthCoins(int value)
        {
            CheckClass();
            return bankInteractor.IsEnougthCoins(value);
        }

        public static void AddCoins(object sender, int value)
        {
            CheckClass();
            bankInteractor.AddCoins(sender, value);
        }

        public static void SpendCoins(object sender, int value)
        {
            CheckClass();
            bankInteractor.SpendCoins(sender, value);
        }

        private static void CheckClass()
        {
            if(!isInitialized)
            {
                throw new System.Exception("Bank is not initialize yet");
            }
        }
    }

}
