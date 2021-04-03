using AnacleAssignment.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnacleAssignment.ui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserList : ContentPage
    {
        List<User> safeUsers = new List<User>();
        List<User> unsafeUser = new List<User>();
        public UserList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<User> users = await App.Database.GetUsersAsync();
            safeUsers = new List<User>();
            unsafeUser = new List<User>();
            foreach (var user in users)
            {
                if(user.temp < 37.5)
                {
                    safeUsers.Add(user);
                }
                else
                {
                    unsafeUser.Add(user);
                }
            }
            userCollection.ItemsSource = safeUsers.OrderBy(i => i.date).ToList();
            userCollection.HeightRequest = safeUsers.Count * 80 + safeUsers.Count * 2 * 5;
            userCollectionunSafe.ItemsSource = unsafeUser.OrderBy(i => i.date).ToList();
            userCollectionunSafe.HeightRequest = unsafeUser.Count * 80 + unsafeUser.Count * 2 * 5;
        }

        private void date_switch_Toggled(object sender, ToggledEventArgs e)
        {
            userCollection.ItemsSource = safeUsers.OrderByDescending(i => i.date).ToList();
            userCollection.HeightRequest = safeUsers.Count * 80 + safeUsers.Count * 2 * 5;
            userCollectionunSafe.ItemsSource = unsafeUser.OrderByDescending(i => i.date).ToList();
            userCollectionunSafe.HeightRequest = unsafeUser.Count * 80 + unsafeUser.Count * 2 * 5;
        }

        private void temp_switch_Toggled(object sender, ToggledEventArgs e)
        {
            userCollection.ItemsSource = safeUsers.OrderByDescending(i => i.temp).ToList();
            userCollection.HeightRequest = safeUsers.Count * 80 + safeUsers.Count * 2 * 5;
            userCollectionunSafe.ItemsSource = unsafeUser.OrderByDescending(i => i.temp).ToList();
            userCollectionunSafe.HeightRequest = unsafeUser.Count * 80 + unsafeUser.Count * 2 * 5;
        }
    }
}