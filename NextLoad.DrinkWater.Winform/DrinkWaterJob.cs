using System;
using System.Collections.Generic;
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
                FrmMain frm = new FrmMain();
                frm.NotifyMsg();
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(@"C:\log.txt", e.Message);
            }

        }
    }
}
