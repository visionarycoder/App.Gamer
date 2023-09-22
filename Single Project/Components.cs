using Microsoft.EntityFrameworkCore;

namespace Gamer;

internal class Client
{

    internal class Content
    {

        internal class Contract
        {

            internal class Models
            {

            }

            internal interface IContentClient
            {

            }

        }

        internal class Service
        {

            internal class Models
            {

            }

            internal class ContentClient : Contract.IContentClient
            {

            }

        }

    }

}

internal class Component

{

    internal class Access
    {

        internal class Players
        {

        }

        internal class Games
        {

        }

    }

    internal class Engine
    {

        internal class GamePlayRule
        {

            internal class Contract
            {

                internal class Models
                {

                }

                public interface IGamePlayRuleEngine
                {

                }

            }

            internal class Service
            {

                internal class Helpers
                {

                }

                public class GamePlayRuleEngine
                {

                }

            }

        }

    }

    internal class Manager
    {

        internal class Content
        {

            internal class Contract
            {

                internal class Models
                {

                }

                public interface IContentManager
                {

                }

            }

            internal class Service
            {

                internal class Helpers
                {

                }

                public class ContentManager
                {

                }

            }

        }

        internal class Admin
        {

            internal class Contract
            {

                internal class Models
                {

                }

                public interface IAdminManager
                {

                }

            }

            internal class Service
            {

                internal class Helpers
                {

                }

                public class AdminManager : Contract.IAdminManager
                {

                }

            }

        }

    }

}

internal class Ifx
{

    internal class Persistence
    {

        internal class PersistenceObject
        {
        
            public int Id { get; set; }
            public Guid Uuid { get; set; }
            public string CreatedBy { get; set; } = string.Empty;
            public DateTime CreatedOnUtc { get; set; }
            public string UpdatedBy { get; set; } = string.Empty;
            public DateTime UpdatedOnUtc { get; set; }

        }

    }

    internal class Service
    {

        internal class ServiceObject
        {
            
            public Guid InstanceId { get; } = Guid.NewGuid();


        }

    }

}

internal class Data
{

    internal class GamerDb
    {

        internal class Models
        {

        }

        internal class GamerContext : DbContext
        {

        }

    }

    internal class SecurityDb
    {

        internal class Models
        {

        }

        internal class SecurityContext : DbContext
        {

        }

    }

    internal class RuleDb
    {

        internal class Models
        {
            
            
        }

        internal class RuleContext : DbContext
        {

        }

    }

}