using System;
using System.Threading;
using System.Windows;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UIDataTestMethodAttribute : DataTestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            TestResult[] result = null;

            var ar = new AutoResetEvent(false);

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                try
                {
                    result = base.Execute(testMethod);
                }
                finally
                {
                    ar.Set();                    
                }
            });

            ar.WaitOne();

            return result;
        }
    }
}