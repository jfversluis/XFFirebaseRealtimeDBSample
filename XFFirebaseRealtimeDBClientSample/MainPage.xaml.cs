using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Shared;
using Xamarin.Forms;

namespace XFFirebaseRealtimeDBClientSample
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<MyDatabaseRecord> DatabaseItems { get; set; } = new ObservableCollection<MyDatabaseRecord>();

        FirebaseClient firebaseClient = new FirebaseClient("TODO");

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

            
            var collection = firebaseClient
                .Child("Records")
                .AsObservable<MyDatabaseRecord>()
                .Subscribe((dbevent) =>
                    {
                        if (dbevent.Object != null)
                        {
                            DatabaseItems.Add(dbevent.Object);
                        }
                    });
        }
    }
}
