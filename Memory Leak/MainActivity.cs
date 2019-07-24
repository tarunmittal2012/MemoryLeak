using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Memory_Leak.Interfaces;
using System;
using Memory_Leak.Model;
using System.Drawing;
using Android.Content;
using Android.Support.V4.Content;

namespace Memory_Leak
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private readonly IMemoryService memory;
        TextView freeMemory, usedMemory, heapMemory, maxMemory, heapUsage, totalUsage;
        Button refresh;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);
            
            InitViews();
         //   RefreshScreen();
            refresh.Click += Refresh_Click;
           
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Toast.MakeText(ApplicationContext, "Button is clicked", ToastLength.Long).Show();
            RefreshScreen();
        }

        private void InitViews()
        {
            freeMemory = FindViewById<TextView>(Resource.Id.free_memory);
            usedMemory = FindViewById<TextView>(Resource.Id.used_memory);
            heapMemory = FindViewById<TextView>(Resource.Id.heap_memory);
            maxMemory = FindViewById<TextView>(Resource.Id.max_memory);
            heapUsage = FindViewById<TextView>(Resource.Id.heap_usage);
            totalUsage = FindViewById<TextView>(Resource.Id.total_usage);
            refresh = FindViewById<Button>(Resource.Id.refresh_button);
        }

        private void RefreshScreen()
        {
            usedMemory.Text = "";
            freeMemory.Text = "";
            heapMemory.Text = "";
            maxMemory.Text = "";
            heapUsage.Text = "";
            totalUsage.Text = "";

            usedMemory.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.black)));
            freeMemory.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.black)));
            heapMemory.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.black)));
            maxMemory.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.black)));
            heapUsage.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.black)));
            totalUsage.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.black)));


            if (memory != null)
            {
                MemoryInfo info = memory.GetInfo();
                if (info != null)
                {
                    usedMemory.Text = string.Format("{0:N}", info.UsedMemory);
                    freeMemory.Text = string.Format("{0:N}", info.FreeMemory);
                    heapUsage.Text = string.Format("{0:N}", info.TotalMemory);

                    maxMemory.Text = string.Format("{0:N}", info.MaxMemory);
                    heapUsage.Text = string.Format("{0:P}", info.HeapUsage());
                    totalUsage.Text = string.Format("{0:P}", info.Usage());



                    if (info.Usage() > 0.8)
                    {
                        freeMemory.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.red)));
                        usedMemory.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.red)));
                        totalUsage.SetTextColor(new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.red)));



                    }
                }
            }

        }
    }
}