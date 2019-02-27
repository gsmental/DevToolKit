using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using PtuDocsMvvm.JSReceiver;
using PtuDocsMvvm.Share.ViewModels;

namespace PtuDocsMvvm.Fragements
{
    public class AnnoucementsFragment : BaseFragment<AnnoucementsViewModel>
    {
        protected override int FragmentId => Resource.Layout.AnnoucementsFragment;

        public static AnnoucementsFragment NewInstance() => new AnnoucementsFragment { Arguments = new Bundle() };



        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.AnnoucementsFragment, container, false);

            WebView webView;
            webView = view.FindViewById<WebView>(Resource.Id.webView);
            webView.SetWebChromeClient(new WebChromeClient());
            webView.Settings.DomStorageEnabled = true;
            webView.Settings.JavaScriptEnabled = true;
            webView.AddJavascriptInterface(new JSReceiverAnnoucements(Context), "JSRAnnoucements");
            webView.LoadUrl(this.ViewModel.WebUrl);
            return view;
        }
    }
}