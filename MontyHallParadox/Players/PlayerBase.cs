using System.Collections.Generic;

namespace MontyHallParadox.Players
{
    public abstract class PlayerBase
    {
        public virtual void Play(Game game)
        {
            var availableDoorsIndeces = game.GetAvailableDoorsIndeces();
            var firstSelectedDoorIndex = RandomSelectDoorIndex(availableDoorsIndeces);
            game.SelectDoor(firstSelectedDoorIndex);
            var openedDoor = game.OpenLooseDoorExceptSelected();
            OnLooseDoorOpened(game);
        }

        protected abstract void OnLooseDoorOpened(Game game);

        protected int RandomSelectDoorIndex(IList<int> doorIndexes)
        {
            var random = RandomProvider.GetRandom();
            var selectedDoorIndexIndex = random.Next(doorIndexes.Count);
            return doorIndexes[selectedDoorIndexIndex];
        }
    }
}
