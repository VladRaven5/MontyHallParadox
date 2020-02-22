namespace MontyHallParadox.Players
{
    public class SwitchPlayer : PlayerBase
    {
        protected override void OnLooseDoorOpened(Game game)
        {
            var otherAvailableDoorsIndeces = game.GetAvailableDoorsIndeces();
            var newSelectionDoorIndex = RandomSelectDoorIndex(otherAvailableDoorsIndeces);
            game.SelectDoor(newSelectionDoorIndex);
        }
    }
}
