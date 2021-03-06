﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive.Internal
{
    internal static class TaskExtensions
    {
        public static Task SafeObserve(this Task task)
        {
            return task.ContinueWith(t =>
            {
                try
                {
                    var exception = t.Exception;
                    if(exception!=null)
                        Trace.TraceWarning(exception.ToString()); // probably wil never run
                }
                catch (Exception e)
                {
                    Trace.TraceWarning(e.ToString());
                }
            });
        }
    }
}
