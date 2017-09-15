namespace Wheres_My_Well.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("HN98msV10u9nSX6Ee9af~0hJ9QopgHR6M28wCyAQnag~AknHU6a4TbO_6W2GN3ISdY880SKvrpfR1abuKJEzt2uoLo_RbxTx07Ss99l3Zpvd");
            LoadApplication(new Wheres_My_Well.App());
        }
    }
}
