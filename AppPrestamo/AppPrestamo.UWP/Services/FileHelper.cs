using AppPrestamo.Services;
using AppPrestamo.UWP.Services;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
[assembly: Dependency(typeof(FileHelper))]
namespace AppPrestamo.UWP.Services
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
        }
    }
}
