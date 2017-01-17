using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace Xamarin.LoginSystem
{
    [Activity(Label = "Xamarin.LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private Button mButtonSignUp;
        private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView (Resource.Layout.Main);

            mButtonSignUp = FindViewById<Button>(Resource.Id.btnSignUp);

            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            mButtonSignUp.Click += (object sender, EventArgs args) =>
            {
                // Pull up the Dialog.

                FragmentTransaction transaction = FragmentManager.BeginTransaction();

                Dialog_SignUp signUpDialog = new Dialog_SignUp();

                signUpDialog.Show(transaction, "dialog_fragment");

                signUpDialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete;
         
            };
        }

        private void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArg e)
        {

            mProgressBar.Visibility = ViewStates.Visible;

            System.Threading.Thread thread = new System.Threading.Thread(ActLikeARequest);

            thread.Start();


        }

        public void ActLikeARequest()
        {
            System.Threading.Thread.Sleep(3000);

            RunOnUiThread(() =>
            {
                mProgressBar.Visibility = ViewStates.Invisible;
            });
        }
    }
}

