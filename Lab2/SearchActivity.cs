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
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchLayout);
            Button btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnSearch.Click += BtnSearch_Click;
            
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txtTaskId);
            string task = dbr.GetTaskById(int.Parse(txtId.Text));
            Toast.MakeText(this, task, ToastLength.Short).Show();
        }
    }
}