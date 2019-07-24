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
using Memory_Leak.Model;

namespace Memory_Leak.Interfaces
{
    interface IMemoryService
    {
        MemoryInfo GetInfo();
    }
}