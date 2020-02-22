using System;

namespace MontyHallParadox
{
    public class RandomProvider
    {
        private static Random _instance;               
        public static Random GetRandom()
        {
            if(_instance == null)
            {
                _instance = new Random(DateTimeOffset.Now.Millisecond);
            }

            return _instance;
        }
    }
}
