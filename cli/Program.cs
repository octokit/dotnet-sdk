using cli.Authentication;

namespace cli;

class Program
{
    static async Task Main(string[] args)
    {
        if (args != null && args.Length == 0)
        {
            Console.WriteLine("Please provide an argument: 'AppInstallationToken' or 'PersonalAccessToken'");
            return;
        }

        switch (args[0])
        {
            case "AppInstallationToken":
                await AppInstallationToken.Run();
                break;
            case "PersonalAccessToken":
                await PersonalAccessToken.Run();
                break;
            default:
                Console.WriteLine("Invalid argument. Please provide 'AppInstallationToken' or 'PersonalAccessToken'");
                break;
        }
    }
}
