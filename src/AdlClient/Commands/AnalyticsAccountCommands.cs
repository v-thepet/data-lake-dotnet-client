
namespace AdlClient.Commands
{
    public class AnalyticsAccountCommands
    {
        public readonly AnalyticsAccountRef AnalyticsAccount;
        public readonly AnalyticsRestClients RestClients;
        public readonly LinkedStoreCommands LinkedStorage;

        public AnalyticsAccountCommands(AnalyticsAccountRef account, AnalyticsRestClients restclients)
        {
            this.AnalyticsAccount = account;
            this.RestClients = restclients;
            this.LinkedStorage  = new LinkedStoreCommands(account,restclients);
        }

        public void Update(
            Microsoft.Azure.Management.DataLake.Analytics.Models.DataLakeAnalyticsAccountUpdateParameters parameters)
        {
            this.RestClients._AdlaAccountMgmtRest.UpdateAccount(AnalyticsAccount, parameters);
        }
    }
}