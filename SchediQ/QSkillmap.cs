using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchediQ
{
    /// <summary>
    /// スキルマップクラス
    /// </summary>
    public class QSkillmap
    {
        /// <summary>
        /// 製品名
        /// </summary>
        public string ProductionName { get; } = string.Empty;

        /// <summary>
        /// 工程名
        /// </summary>
        public string ProcessName { get; } = string.Empty;

        /// <summary>
        /// 作業者Id
        /// </summary>
        public string WorkerId { get; } = string.Empty;

        /// <summary>
        /// 作業時間
        /// </summary>
        public int WorkTime { get; } = 0;

        public QSkillmap(string prodName, string procName, string workerId, int workTime)
        {
            this.ProductionName = prodName;
            this.ProcessName = procName;
            this.WorkerId = workerId;
            this.WorkTime = workTime;
        }
    }
}
