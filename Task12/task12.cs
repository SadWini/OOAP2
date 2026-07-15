using System;
using System.Reflection;
using System.Text.Json;

namespace OOAP_Course2
{
    public abstract class General
    {
        public static void AssignmentAttempt<T>(ref T target, General source) where T : class
        {
            target = source as T;
        }
    }

    public abstract class Any : General
    {
        protected Any() : base() 
        { 
        }
    }

}