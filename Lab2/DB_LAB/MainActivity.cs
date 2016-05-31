using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DB_LAB.ORM;
using System.Collections.Generic;

namespace DB_LAB
{
    [Activity(Label = "Lab 4-5 Bodia", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<ToDoTasks> dbRecords;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            DBRepository dbr = new DBRepository();
            var result = dbr.CreateDB();
            result = dbr.CreateTable();
            
            dbRecords = dbr.GetAllRecords();


            ListView mListView; mListView = FindViewById<ListView>(Resource.Id.myListView);

            MyListViewAdapter adapter = new MyListViewAdapter(this, dbRecords);
            mListView.Adapter = adapter;

            mListView.ItemClick += MListView_ItemClick;
            mListView.ItemLongClick += MListView_ItemLongClick;

            Button btnNewItem = FindViewById<Button>(Resource.Id.btnNewItem);
            btnNewItem.Click += BtnNewItem_Click;
        }

        private void MListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            DBRepository dbr = new DBRepository();
            dbr.RemoveTask(dbRecords[e.Position].Id);
            OnCreate(new Bundle());
        }

        protected override void OnResume()
        {
            base.OnResume();

        }
        protected override void OnPostResume()
        {
            base.OnPostResume();
        }

        private void BtnNewItem_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NewItemActivity));
        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("position", dbRecords[e.Position].Id);
            StartActivity(intent);
        }
    }
}

