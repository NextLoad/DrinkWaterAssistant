using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace NextLoad.DrinkWater.Winform
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public void NotifyMsg()
        {
            this.notifyIcon1.Icon = NextLoad.DrinkWater.Winform.Properties.Resources.hot_drink_128px_1231620_easyicon_net;
            this.notifyIcon1.ShowBalloonTip(10000, "温馨提示", "到喝水时间了,该喝水了...", ToolTipIcon.Info);
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = true;//在通知区显示Form的Icon
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = NextLoad.DrinkWater.Winform.Properties.Resources.hot_drink_128px_1231620_easyicon_net;
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.ShowInTaskbar = false;
            string msg = ConfigurationManager.AppSettings["msg"];
            this.notifyIcon1.ShowBalloonTip(10000, "温馨提示", msg, ToolTipIcon.Info);
            StartScheduleJob();
        }

        private void StartScheduleJob()
        {
            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jdBossReport = new JobDetailImpl("jbDw", typeof(DrinkWaterJob));
            string cron = ConfigurationManager.AppSettings["cron"];
            CronScheduleBuilder cronScheduleBuilder = CronScheduleBuilder.CronSchedule(cron);
            //CronScheduleBuilder cronScheduleBuilder = CronScheduleBuilder.CronSchedule("* * * * * ? *");
            IMutableTrigger triggerBossReport = cronScheduleBuilder.Build();
            triggerBossReport.Key = new TriggerKey("triggerTest");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            sched.Start();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            System.Environment.Exit(0);
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
