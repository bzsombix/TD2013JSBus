namespace JSBus.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/JSBus")
                .Include("~/Scripts/JSBus/TransportInterfaces.js")
                .Include("~/Scripts/JSBus/LocalStorageStore.js")
                .Include("~/Scripts/JSBus/LocalStorageQueue.js")
                .Include("~/Scripts/JSBus/Bus.js")
                .Include("~/Scripts/JSBus/SignalRSendTransport.js")
                .Include("~/Scripts/JSBus/SignalRSubscribeTransport.js")
            );

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
        }
    }
}