using System.Collections.Generic;

namespace MontyHallParadox
{
    public class Game
    {
        private int _selectedDoorIndex = -1;
        private int _openedDoor = -1;
        private IList<Door> _doors;

        public Game(int doorsNumber = 3)
        {
            InitializeGame(doorsNumber);
        }        
                     

        public void SelectDoor(int doorIndex)
        {
            _selectedDoorIndex = doorIndex;
        }

        public int OpenLooseDoorExceptSelected()
        {
            //find all loose-doors indeces
            IList<int> looseDoorsIndices = new List<int>();
            for (int i = 0; i < _doors.Count; i++)
            {
                if (_doors[i].Result == Result.Win || i == _selectedDoorIndex)
                    continue;

                looseDoorsIndices.Add(i);
            }

            var random = RandomProvider.GetRandom();
            var openinDoorIndexIndex = random.Next(looseDoorsIndices.Count);

            int openingDoorIndex = looseDoorsIndices[openinDoorIndexIndex];
            _openedDoor = openingDoorIndex;

            return _openedDoor;
        }

        public IList<int> GetAvailableDoorsIndeces()
        {
            var availableDoorsIndices = new List<int>();
            for(int i = 0; i < _doors.Count; i++)
            {
                if (i == _openedDoor || i == _selectedDoorIndex)
                    continue;

                availableDoorsIndices.Add(i);
            }
            return availableDoorsIndices;
        }

        public Result FinishGame()
        {
            return _doors[_selectedDoorIndex].Result;
        }

        private void InitializeGame(int doorsNumber)
        {
            var random = RandomProvider.GetRandom();
            int prizeDoorNumber = random.Next(doorsNumber);

            var doors = new List<Door>(doorsNumber);

            for (int doorNumber = 0; doorNumber < doorsNumber; doorNumber++)
            {
                Result doorResult = doorNumber == prizeDoorNumber
                    ? Result.Win
                    : Result.Loose;

                doors.Add(new Door(doorResult));
            }

            _doors = doors;
        }
    }
}
