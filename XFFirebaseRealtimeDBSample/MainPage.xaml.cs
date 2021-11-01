using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Xamarin.Forms;
using Shared;
using Firebase.Database;

namespace XFFirebaseRealtimeDBSample
{
    
    public partial class MainPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("TODO");

        public MainPage()
        {
            InitializeComponent();

            
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            firebaseClient.Child("Records").PostAsync(new MyDatabaseRecord
            {
                MyProperty = recordData.Text
            });

            recordData.Text = "";
        }
    }
}
