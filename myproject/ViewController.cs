using System;

using AppKit;
using Foundation;

namespace myproject
{
    public partial class ViewController : NSViewController
    {
        System.Timers.Timer timer;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var seconds = 60 * 1;

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += (sender, e) =>
            {
                var ts = new TimeSpan(0, 0, seconds -= 1);

                if (ts.TotalSeconds <= 0)
                {
                    timer.Stop();
                }

                InvokeOnMainThread(() => this.label.Title = ts.ToString("c"));
            };
            timer.Start();
		}

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
