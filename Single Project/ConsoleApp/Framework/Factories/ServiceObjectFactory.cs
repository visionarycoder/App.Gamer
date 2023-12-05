using Gamer.Framework.Base;

namespace Gamer.Framework.Factories;

public static class ServiceObjectFactory
{

    private static int id;

    public static T Create<T>() where T : ServiceObject<T>, new()
    {
        var businessObject = new T
        {
           Id = IdService.GetId()
        };
        return businessObject;
    }

}