using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LED_ON_OFF
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            initializeGpio();

        }

        GpioPin pin1, pin2;

        private void Sw1_Toggled(object sender, RoutedEventArgs e)
        {
            if (Sw1.IsOn)
            {
                pin1.Write(GpioPinValue.High);
            }
            else
            {
                pin1.Write(GpioPinValue.Low);

            }
        }

        private void Sw2_Toggled(object sender, RoutedEventArgs e)
        {
            if (Sw2.IsOn)
            {
                pin2.Write(GpioPinValue.High);
            }
            else
            {
                pin2.Write(GpioPinValue.Low);

            }
        }

        void initializeGpio()
        {
            var _gpio = GpioController.GetDefault();
            GpioController Null = null;
            if(_gpio !=Null)
            {
                var msg = new Windows.UI.Popups.MessageDialog("GPIO Found OK").ShowAsync();
                pin1 = _gpio.OpenPin(20);
                pin2 = _gpio.OpenPin(21);

                pin1.SetDriveMode(GpioPinDriveMode.Output);
                pin2.SetDriveMode(GpioPinDriveMode.Output);
                pin1.Write(GpioPinValue.Low);
                pin2.Write(GpioPinValue.Low);


            }
            else
            {
                var msg = new Windows.UI.Popups.MessageDialog("Sorry Can't find GPIO Port's").ShowAsync();

            }

        }

    }
}
