namespace Gamer.Framework.Factories;

public static class BusinessObjectFactory
{

    public static T Create<T>() where T : BusinessObject, new()
    {
        var businessObject = new T
        {
            Id = IdService.GetId()
        };
       return businessObject;
    }

}

public static class IdService
{
    
    private static int id;

    public static int GetId()
    {
        return id++;
    }

}