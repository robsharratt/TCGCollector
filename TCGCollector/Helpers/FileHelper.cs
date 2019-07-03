using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TCGCollector.Helpers
{
    public class FileHelper
    {
        public string webRootFolder;
        public string appRootFolder;


        public FileHelper(IHostingEnvironment env)
        {
            webRootFolder = env.WebRootPath;
            appRootFolder = env.ContentRootPath;
        }

        //    public static string GetAppFolder()
        //    {
        //        string appRootPath;
        //        IHostingEnvironment env;
        //        appRootPath = env.ContentRootPath;
        //        return appRootPath;
        //}

        //    public static string GetWebRootFolderPath()
        //    {

        //    }

        //    public void SaveFileToAppFolder(string appVirtualFolderPath, string fileName string jsonContent)
        //    {
        //        var pathToFile = appRootFolder + appVirtualFolderPath.Replace("/", Path.DirectorySeparatorChar.ToString())
        //        + fileName;

        //        using (StreamWriter s = File.CreateText(pathToFile))
        //        {
        //            await s.WriteAsync(jsonContent);
        //        }

        //}

        //public void SaveFileToWwwFolder(string virtualFolderPath, string fileName string jsonContent)
        //{
        //    var pathToFile = hostingEnvironment.MapPath(virtualFolderPath) + fileName;

        //    using (StreamWriter s = File.CreateText(pathToFile))
        //    {
        //        await s.WriteAsync(jsonContent);
        //    }

        //}
    }
}