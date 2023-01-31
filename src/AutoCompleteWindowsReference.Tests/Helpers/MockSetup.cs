using System;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace AutoCompleteWindowsReference.Tests.Helpers
{
    public static class MockSetup
    {
        public static void Init()
        {
            try
            {
                MockForms.Init();
                Application.Current = new App();
            }
            catch (Exception ex)
            {
                throw new Exception("Mock Setup Failed", ex);
            }
        }
    }
}
