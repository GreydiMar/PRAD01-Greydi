﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PRAD01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMaps : ContentPage
    {
        public PageMaps()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var location = await Geolocation.GetLocationAsync();

            if (location != null)
            {
                var pin = new Pin()
                {
                    Position = new Position(location.Latitude, location.Longitude),
                    Label = "Some Pin!"
                };
                mapa.Pins.Add(pin);

                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMeters(100.00)));
            }
;        }
    }
}