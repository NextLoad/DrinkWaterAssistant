using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace NextLoad.DrinkWater.Winform
{
    public class DrinkWaterJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                FrmMain.CreateFrm().NotifyMsg();
            }
            catch (Exception e)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                System.IO.File.AppendAllText(Path.Combine(path, "LogFile", "log.txt"), e.Message);
            }

        }
    }
}
