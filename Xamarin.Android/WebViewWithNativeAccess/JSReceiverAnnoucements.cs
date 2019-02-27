using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Java.Interop;
using PtuDocsMvvm.Fragements;
using PtuDocsMvvm.Plugins;

namespace PtuDocsMvvm.JSReceiver
{
    public class JSReceiverAnnoucements : Java.Lang.Object
    {
        Context _context;
        private TaskPlugin _taskPlugin = new TaskPlugin();

        public JSReceiverAnnoucements(Context context)
        {
            _context = context;
        }

        //public JSReceiverAnnoucements(Context context, TaskPlugin taskPlugin)
        //{
        //    _context = context;
        //    _taskPlugin = taskPlugin;
        //}

        [Export]//[Export("ShowToast")]
        [JavascriptInterface]
        public void DownloadFile(string Message)
        {
            _taskPlugin.ShowToast(Message);
        }
    }
}