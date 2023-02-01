using Common;
using System;

namespace BusinessLogic
{
    public class ReportManager : IReportManager
    {
        public void PrintInfo(string info)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.File.WriteAllText(path + "/report.txt", info);
        }
    }
}
