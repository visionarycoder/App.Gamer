namespace Gamer.Framework.Factories;

public static class IdService
{
    
    private static int id;

    public static int GetId()
    {
        return id++;
    }

}