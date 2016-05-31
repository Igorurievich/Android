using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DB_LAB.ORM;

namespace DB_LAB
{
    [Activity(Label = "DB_LAB", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);
            //create the database
            Button btnCreateDB = FindViewById<Button>(Resource.Id.btnCreateDB);
            btnCreateDB.Click += btnCreateDB_Click;

            //to create the tables 
            Button btnCreateTable = FindViewById<Button>(Resource.Id.btnCreateTable);
            btnCreateTable.Click += btnCreateTable_Click;

            Button btnAddRecord = FindViewById<Button>(Resource.Id.btnInsert);
            btnAddRecord.Click += btnAddRecord_Click;

            //To retrieve the data 
            Button btnGetAll = FindViewById<Button>(Resource.Id.btnGetData);
            btnGetAll.Click += BtnGetAll_Click;

            //retrieve specific record 
            Button btnGetById = FindViewById<Button>(Resource.Id.btnGetDataByID);
            btnGetById.Click += BtnGetById_Click;

            //To update the record
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnUpdate.Click += BtnUpdate_Click;

            //To delete the record 
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Click += BtnDelete_Click;

        }

        

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RemoveTaskActivity));
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(UpdateTaskActivity));
        }

        private void BtnGetById_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SearchActivity));
        }

        private void BtnGetAll_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.GetAllRecords();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InsertTaskActivity));
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateTable();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateDB();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}

