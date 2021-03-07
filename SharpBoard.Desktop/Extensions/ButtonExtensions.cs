using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SharpBoard.Desktop.Extensions
{
    public static class ButtonExtensions
    {
        public static async Task DisableForRun(this Button button, Func<Task> action)
        {
            button.IsEnabled = false;

            try
            {
                await action();
            }
            finally
            {
                button.IsEnabled = true;
            }
        }
    }
}
