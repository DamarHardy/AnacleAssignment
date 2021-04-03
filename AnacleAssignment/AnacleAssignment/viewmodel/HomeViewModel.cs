using AnacleAssignment.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnacleAssignment.viewmodel
{
    public class HomeViewModel
    {
        public async Task<int> inputData(string name, string email, string number, double temp, DateTime date)
        {
            User user = new User();
            user.name = name;
            user.email = email;
            user.number = number;
            user.temp = temp;
            user.date = date;

            int returnCode = await App.Database.SaveUserAsync(user);

            return returnCode;
        }

        internal bool authenticateAdmin(string password)
        {
            if(password == "oooo")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}