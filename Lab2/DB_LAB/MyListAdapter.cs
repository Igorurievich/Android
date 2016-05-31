using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using DB_LAB.ORM;

namespace DB_LAB
{
    class MyListViewAdapter : BaseAdapter<ToDoTasks>
    {
        private List<ToDoTasks> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context, List<ToDoTasks> items)
        {
            mItems = items;
            mContext = context;
        }

        public override ToDoTasks this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.ListView, null, false);
            }
            if (mItems[position] != null)
            {
                TextView txtManufacturer = row.FindViewById<TextView>(Resource.Id.txtMan);
                txtManufacturer.Text = mItems[position].Manufacturer;

                TextView txtModel = row.FindViewById<TextView>(Resource.Id.txtMod);
                txtModel.Text = mItems[position].Model;
            }


            //TextView txtAge = row.FindViewById<TextView>(Resource.Id.txtAge);
            //txtAge.Text = mItems[position].Age;

            //TextView txtGender = row.FindViewById<TextView>(Resource.Id.txtGender);
            //txtGender.Text = mItems[position].Gender;

            return row;
        }
    }
}