namespace Kuhpik
{
    public enum GameStateID
    {
        // Don't change int values in the middle of development.
        // Otherwise all of your settings in inspector can be messed up.

        Loading = 3,
        Initialization = 4,
        Game = 6,
        Shared = 10

        // Extend just like that
        //
        // Revive = 100,
        // QTE = 200
    }
}