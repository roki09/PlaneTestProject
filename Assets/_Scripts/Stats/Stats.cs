
using System;

namespace Architecture
{
    public static class Stats
    {

        public static event Action OnStatsInializeEvent;

        public static int score
        {
            get
            {
                CheckClass();
                return statsInteractor.score;
            }
        }
        public static bool isInitialized { get; private set; }

        private static StatsInteractor statsInteractor;

        public static void Initialize (StatsInteractor interactor)
        {
            statsInteractor = interactor;
            isInitialized = true;

            OnStatsInializeEvent?.Invoke();
        }

        public static void CompareScore()
        {
            CheckClass();
            statsInteractor.CompareScore();
        }

        public static void AddCoins(object sender, int value)
        {
            CheckClass();
            statsInteractor.AddScore(sender, value);
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
