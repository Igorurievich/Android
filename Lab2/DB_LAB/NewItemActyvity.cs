using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DB_LAB.ORM;

namespace DB_LAB
{
    [Activity(Label = "Add new item:")]
    public class NewItemActivity : Activity
    {
        int Id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddNewPhone);

            Id = Intent.GetIntExtra("position", -1);

            //Toast.MakeText(this, Id.ToString(), ToastLength.Short).Show();
            Button btnNewCancel = FindViewById<Button>(Resource.Id.btnNewCancel);
            btnNewCancel.Click += BtnNewCancel_Click;

            Button btnNewConfirm = FindViewById<Button>(Resource.Id.btnNewConfirm);
            btnNewConfirm.Click += BtnNewConfirm_Click;
        }

        private void BtnNewConfirm_Click(object sender, EventArgs e)
        {
            EditText txtNewManufact = FindViewById<EditText>(Resource.Id.txtNewManufacturer);
            EditText txtNewModel = FindViewById<EditText>(Resource.Id.txtNewModel);
            EditText txtNewAndrVers = FindViewById<EditText>(Resource.Id.txtNewAndrVers);
            EditText txtNewWWW = FindViewById<EditText>(Resource.Id.txtNewWWW);
            DBRepository dbr = new DBRepository();

            string result = dbr.InsertRecord(txtNewManufact.Text, txtNewModel.Text, txtNewAndrVers.Text, txtNewWWW.Text);

            StartActivity(typeof(MainActivity));
        }
        private void BtnNewCancel_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            this.Finish();
        }
    }
}