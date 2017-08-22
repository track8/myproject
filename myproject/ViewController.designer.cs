// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace myproject
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSTextField label2 { get; set; }

        [Outlet]
        AppKit.NSTextField minuteTextBox { get; set; }

        [Outlet]
        AppKit.NSButton ResetButton { get; set; }

        [Outlet]
        AppKit.NSButton StartButton { get; set; }

        [Outlet]
        AppKit.NSButton StopButton { get; set; }

        [Action ("resetButton_clicked:")]
        partial void resetButton_clicked (Foundation.NSObject sender);

        [Action ("startButton_clicked:")]
        partial void startButton_clicked (Foundation.NSObject sender);

        [Action ("stopButton_clicked:")]
        partial void stopButton_clicked (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (label2 != null) {
                label2.Dispose ();
                label2 = null;
            }

            if (StartButton != null) {
                StartButton.Dispose ();
                StartButton = null;
            }

            if (StopButton != null) {
                StopButton.Dispose ();
                StopButton = null;
            }

            if (ResetButton != null) {
                ResetButton.Dispose ();
                ResetButton = null;
            }

            if (minuteTextBox != null) {
                minuteTextBox.Dispose ();
                minuteTextBox = null;
            }
        }
    }
}
