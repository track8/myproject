using System;

using AppKit;
using Foundation;

namespace myproject
{
    public partial class ViewController : NSViewController
    {
        System.Timers.Timer timer;
        int timerRemainSeconds;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        NSObject NSWindowDidResizeNotificationObject;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NSWindowDidResizeNotificationObject = NSNotificationCenter.DefaultCenter.AddObserver(new NSString("NSWindowDidResizeNotification"), ResizeObserver, null);

            timerRemainSeconds = InitialRemainSeconds;
            this.label2.StringValue = timerString;

            timer = new System.Timers.Timer();
            timer.Enabled = false;
            timer.Interval = 1000;
            timer.Elapsed += (sender, e) =>
            {
                if (timerRemainSeconds <= 0)
                {
                    timer.Stop();
                }

                InvokeOnMainThread(() => this.label2.StringValue = timerString);

                timerRemainSeconds -= 1;
            };
        }

        partial void startButton_clicked(NSObject sender)
        {
            this.timer.Enabled = true;
        }

        partial void stopButton_clicked(NSObject sender)
        {
            this.timer.Enabled = false;
        }

        partial void resetButton_clicked(NSObject sender)
        {
            timerRemainSeconds = InitialRemainSeconds;
            this.label2.StringValue = this.timerString;
        }

        private string timerString
        {
            get { return (new TimeSpan(0, 0, timerRemainSeconds)).ToString(("c")); }
        }

        private int InitialRemainSeconds
        {
            get
            {
                try
                {
                    return Convert.ToInt32(minuteTextBox.StringValue) * 60;
                }
                catch
                {
                    return 30 * 60;
                }
            }
        }

        public void ResizeObserver(NSNotification notify)
        {
            var r = this.View.Frame;
            Console.WriteLine("{0}:{1}:{2}", notify.Name, r.Height, r.Width);
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
