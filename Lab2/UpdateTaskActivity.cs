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
    [Activity(Label = "UpdateTaskActivity")]
    public class UpdateTaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UpdateTaskLayout);
            Button btnSerach = FindViewById<Button>(Resource.Id.btnSearch);
            btnSerach.Click += BtnSerach_Click;

            //update button click

            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnUpdate.Click += BtnUpdate_Click;
        }



        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskID);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            DBRepository dbr = new DBRepository();
            string result = dbr.UpdateRecord(int.Parse(txtId.Text), txtTask.Text);
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void BtnSerach_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskID);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            txtTask.Text = dbr.GetTaskById(int.Parse(txtId.Text));
        }
    }
}