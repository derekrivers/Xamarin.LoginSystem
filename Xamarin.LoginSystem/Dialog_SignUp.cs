
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace Xamarin.LoginSystem
{

    public class OnSignUpEventArg : EventArgs
    {
        private string mFirstName;
        private string mEmail;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value;}
        }

        public string Email
        {
            get { return mEmail;}
            set { mEmail = value; }
        }

        public string Password
        {
            get { return mPassword;  }
            set { mPassword = value; }
        }

        public OnSignUpEventArg(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }

    public class Dialog_SignUp : DialogFragment
    {

        private EditText mTxtFirstName;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private Button mBtnSignUp;


        public event EventHandler<OnSignUpEventArg> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            mBtnSignUp.Click += (object sender, EventArgs e) =>
            {
                //User has clicked teh sign up button

                mOnSignUpComplete.Invoke(this, new OnSignUpEventArg(mTxtFirstName.Text, mTxtEmail.Text, mTxtPassword.Text));

                this.Dismiss();
                
            };

            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible

            base.OnActivityCreated(savedInstanceState);

            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}