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
using Memory_Leak.Interfaces;
using Memory_Leak.Model;

namespace Memory_Leak.Services
{
   
    
    class AndroidMemoryService : IMemoryService
    {
        Context memoryInfo;
        public AndroidMemoryService( Context context)
        {
            memoryInfo = context;
        }


        #region IMemoryService implementation

        public MemoryInfo GetInfo()
        {
            return MemoryHelper.GetMemoryInfo(memoryInfo);
        }

        #endregion
    }
}