using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DB_LAB.ORM;

namespace DB_LAB
{
    [Activity(Label = "Details")]
    public class DetailsActivity : Activity
    {
        int Id { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Details);
            // Create your application here

            Id = Intent.GetIntExtra("position", -1);

            //Toast.MakeText(this, Id.ToString(), ToastLength.Short).Show();
            EditText txtManufact = FindViewById<EditText>(Resource.Id.txtManufacturer);
            EditText txtModel = FindViewById<EditText>(Resource.Id.txtModel);
            EditText txtAndrVers = FindViewById<EditText>(Resource.Id.txtAndrVers);
            EditText txtWWW = FindViewById<EditText>(Resource.Id.txtWWW);


            DBRepository dbr = new DBRepository();
            ToDoTasks item = dbr.GetTaskById(Id);
            txtManufact.Text = item.Manufacturer;
            txtModel.Text = item.Model;
            txtAndrVers.Text = item.Android;
            txtWWW.Text = item.WWW;


            Button btnWWW = FindViewById<Button>(Resource.Id.btnWWW);
            btnWWW.Click += BtnWWW_Click;

            Button btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            btnCancel.Click += BtnCancel_Click;

            Button btnConfirm = FindViewById<Button>(Resource.Id.btnConfirm);
            btnConfirm.Click += BtnConfirm_Click;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            this.Finish();

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {

            EditText txtManufact = FindViewById<EditText>(Resource.Id.txtManufacturer);
            EditText txtModel = FindViewById<EditText>(Resource.Id.txtModel);
            EditText txtAndrVers = FindViewById<EditText>(Resource.Id.txtAndrVers);
            EditText txtWWW = FindViewById<EditText>(Resource.Id.txtWWW);

            DBRepository dbr = new DBRepository();
            ToDoTasks item = dbr.GetTaskById(Id);

            item.Manufacturer = txtManufact.Text;
            item.Model = txtModel.Text;
            item.Android = txtAndrVers.Text;
            item.WWW = txtWWW.Text;

            dbr.UpdateRecord(Id, item);
            StartActivity(typeof(MainActivity));
            this.Finish();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            this.Finish();
        }

        private void BtnWWW_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var item = dbr.GetTaskById(Id);
            var uri = Android.Net.Uri.Parse(item.WWW);
            var intent = new Intent(Intent.ActionView, uri);
            try
            {
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }

        }
    }
}