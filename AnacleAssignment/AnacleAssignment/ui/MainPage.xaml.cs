using AnacleAssignment.ui;
using AnacleAssignment.viewmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnacleAssignment.ui
{
    public partial class MainPage : ContentPage
    {
        private HomeViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new HomeViewModel();
        }

        private void date_set_btn_Clicked(object sender, EventArgs e)
        {
            date_picker.Focus();
        }

        private void temp_stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (temp_stepper.Value >= 37.5)
            {
                temperature_text.TextColor = Color.Red;
                input_btn.BackgroundColor = Color.Red;
            }
            else
            {
                temperature_text.TextColor = Color.Green;
                input_btn.BackgroundColor = Color.Green;
            }
        }

        private async void input_btn_Clicked(object sender, EventArgs e)
        {
            string name = name_entry.Text;
            string email = email_entry.Text;
            string number = contact_entry.Text;
            double temp = temp_stepper.Value;
            DateTime date = date_picker.Date;

            if(name!=null && IsValidEmail(email) && number != null)
            {
                int result = await viewModel.inputData(name, email, number, temp, date);
                if (result != -1)
                {
                    await DisplayAlert("Success", "Visitor Added to the Database", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Visitor could not be added to the Database", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please input a valid and complete data", "OK");
            }            
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            string password = await DisplayPromptAsync("Admin Access", "Please Input Password", initialValue:"oooo");
            if(password != null)
            {
                if (viewModel.authenticateAdmin(password))
                {
                    await Shell.Current.GoToAsync(nameof(UserList));
                }
                else
                {
                    await DisplayAlert("Error", "Password is invalid", "OK");
                }
            }
        }
    }
}
