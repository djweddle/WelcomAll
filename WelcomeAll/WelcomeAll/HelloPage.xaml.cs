using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WelcomeAll
{
    public partial class HelloPage : ContentPage
    {
        public HelloPage()
        {
            InitializeComponent();    
            

                   
        }

        //async 
        void OnButtonClicked(object sender, EventArgs args)
        {
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            if (adapter == null)
                throw new Exception("No Bluetooth adapter found.");

            if (!adapter.IsEnabled)
                throw new Exception("Bluetooth adapter is not enabled.");

            var listOfDevices = adapter.BondedDevices;
            if (listOfDevices.Count > 0)
            {
                foreach (var bluetoothDevice in listOfDevices)
                {
                    string deviceName = bluetoothDevice.Name;
                    Button l = new Button();
                    l.Text = deviceName;
                    l.Clicked += L_Clicked;
                    this.stlDevices.Children.Add(l);
                    
                    //UUID = bluetoothDevice.GetUuids().ElementAt(0);
                    //if (!deviceDictionary.ContainsKey(bluetoothDevice.Name))
                    //    deviceDictionary.Add(bluetoothDevice.Name, bluetoothDevice.Address);
                }
                this.bttChangeName.IsVisible = false;
            }

            //this.labBother.Text = this.txtTitle.Text.Trim() + " Shane!";
            //this.labBother.IsVisible = true;
            //Button button = (Button)sender;
            //await DisplayAlert("Clicked!",
            //    "The button labeled '" + button.Text + "' has been clicked",
            //    "OK");
        }

        private void L_Clicked(object sender, EventArgs e)
        {
            this.stlDevices.IsVisible = false;
            this.stlDir.IsVisible = true;
        }

        //protected void OnTextChange(object sender, EventArgs e)
        //{
        //    //if(this.txtTitle.Text.Trim() != "")
        //    //{
        //    //    bttChangeName.IsEnabled = true;
        //    //}
        //}
    }
}
