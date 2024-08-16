using cli.Authentication;

namespace cli;

class Program
{
    static async Task Main(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            Console.WriteLine("Please provide an argument: 'AppInstallationToken' or 'PersonalAccessToken'");
            return;
        }

        var approach = "default";

        if (args.Length > 1)
        {
            if (args[1] == "builder" || args[1] == "default")
            {
                approach = args[1];
            }
            else
            {
                Console.WriteLine("Invalid argument. Please provide 'builder' or 'default'");
                return;
            }
        }

        switch (args[0])
        {
            case "AppInstallationToken":
                await AppInstallationToken.Run(approach);
                break;
            case "PersonalAccessToken":
                await PersonalAccessToken.Run(approach);
                break;
            default:
                Console.WriteLine("Invalid argument. Please provide 'AppInstallationToken' or 'PersonalAccessToken'");
                break;
        }
    }
}
