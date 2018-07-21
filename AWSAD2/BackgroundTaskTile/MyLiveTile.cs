using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Networking.Connectivity;
using Windows.UI.Notifications;

namespace BackgroundTaskTile
{
    public sealed class MyLiveTile : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral task = taskInstance.GetDeferral();
            this.UpdateLiveTile();
            task.Complete();
        }

        private void UpdateLiveTile()
        {
            var tileTemplate = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text03);
            var tileContent = tileTemplate.SelectNodes("tile/visual/binding/text");
            var network = NetworkInformation.GetInternetConnectionProfile();
            tileContent[0].InnerText = (network == null) ? "Disconnect" : network.GetNetworkConnectivityLevel().ToString();
            tileContent[1].InnerText = DateTime.Now.ToString("MM/dd/yyyy");
            tileContent[2].InnerText = DateTime.Now.ToString("HH:mm:ss");

            var updateTile = TileUpdateManager.CreateTileUpdaterForApplication();
            updateTile.Update(new TileNotification(tileTemplate));
        }
    }
}