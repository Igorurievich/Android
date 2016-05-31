using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DB_LAB.ORM;

namespace DB_LAB
{
    [Activity(Label = "RemoveTaskActivity")]
    public class RemoveTaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RemoveTaskLayout);
            Button btnRemove = FindViewById<Button>(Resource.Id.btnDelete);
            btnRemove.Click += BtnRemove_Click;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtTaskId = FindViewById<EditText>(Resource.Id.txtTaskId);
            string result = dbr.RemoveTask(int.Parse(txtTaskId.Text));
            Toast.MakeText(this, result, ToastLength.Short).Show();



        }
    }
}