using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchediQ
{
    public class QTaskWorker
    {
        /// <summary>
        /// 作業者Id
        /// </summary>
        public string WorkerId { get; }

        QTask Task { get; }

        /// <summary>
        /// 製品識別子（製品シリアル等）
        /// </summary>
        public string ProductionId { get { return Task.ProductionId; } }

        /// <summary>
        /// 製品名
        /// </summary>
        public string ProductionName { get { return Task.ProductionName; } }

        /// <summary>
        /// 工程名
        /// </summary>
        public string ProcessName { get { return Task.ProcessName; } }
        /// <summary>
        /// 作業時間
        /// </summary>
        public int WorkTime { get; }

        public QTaskWorker(QTask task, string worker_id, int workTime)
        {
            WorkerId = worker_id;
            Task = task;
            WorkTime = workTime;
        }
    }
}
