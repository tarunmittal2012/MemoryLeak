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

namespace Memory_Leak.Model
{
    class MemoryInfo
    {
        public long FreeMemory { get; set; }
        public long MaxMemory { get; set; }
        public long TotalMemory { get; set; }

        public long UsedMemory
        {
            get
            {
                return (TotalMemory - FreeMemory);
            }
        }

        public double HeapUsage()
        {
            return (double)(UsedMemory) / (double)TotalMemory;
        }

        public double Usage()
        {
            return (double)(UsedMemory) / (double)MaxMemory;
        }
    }
}