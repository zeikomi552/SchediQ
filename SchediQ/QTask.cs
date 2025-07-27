using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchediQ
{
    public class QTask
    {
        /// <summary>
        /// 製品識別子（製品シリアル等）
        /// </summary>
        public string ProductionId { get; } = string.Empty;

        /// <summary>
        /// 製品名
        /// </summary>
        public string ProductionName { get; } = string.Empty;

        /// <summary>
        /// 工程名
        /// </summary>
        public string ProcessName { get; } = string.Empty;

        public QTask(string prodId, string prodName, string procName)
        {
            ProductionId = prodId;
            ProductionName = prodName;
            ProcessName = procName;
        }
    }
}
