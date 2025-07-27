using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchediQ
{
    public class QTaskWorkerCollection : List<QTaskWorker>
    {
        /// <summary>
        /// ランダム変数
        /// </summary>
        static Random _Rand = new Random();

        public QTaskWorkerCollection()
        {

        }

        public QTaskWorkerCollection(IEnumerable<QTaskWorker> workers) : base(workers)
        {

        }

        /// <summary>
        /// ランダムなインデックスを取得する関数
        /// </summary>
        /// <param name="maxValue">インデックス最大値</param>
        /// <returns>ランダムな値0～maxValue-1の範囲</returns>
        private static int GetRandomIndex(int maxValue)
        {
            return _Rand.Next(0, maxValue);
        }

        /// <summary>
        /// 総作業時間の算出
        /// </summary>
        /// <param name="qTaskWorker">作業者割り当て後のタスク割り当てリスト</param>
        /// <returns>総作業時間</returns>
        public static int CalcEndTime(List<QTaskWorker> qTaskWorker)
        {
            Dictionary<string, int> workerTime = new Dictionary<string, int>();
            Dictionary<string, int> procTime = new Dictionary<string, int>();
            Dictionary<string, int> prodTime = new Dictionary<string, int>();

            foreach (var result in qTaskWorker)
            {
                if (workerTime.ContainsKey(result.WorkerId))
                {
                    workerTime[result.WorkerId] += result.WorkTime;
                }
                else
                {
                    workerTime.Add(result.WorkerId, result.WorkTime);
                }

                if (procTime.ContainsKey(result.ProcessName))
                {
                    procTime[result.ProcessName] += result.WorkTime;
                }
                else
                {
                    procTime.Add(result.ProcessName, result.WorkTime);
                }

                if (prodTime.ContainsKey(result.ProductionId))
                {
                    prodTime[result.ProductionId] += result.WorkTime;
                }
                else
                {
                    prodTime.Add(result.ProductionId, result.WorkTime);
                }


                int tmpTime = 0;
                if (workerTime[result.WorkerId] > procTime[result.ProcessName])
                {
                    tmpTime = workerTime[result.WorkerId];
                }
                else
                {
                    tmpTime = procTime[result.ProcessName];
                }

                if (prodTime[result.ProductionId] > tmpTime)
                {
                    tmpTime = prodTime[result.ProductionId];
                }

                workerTime[result.WorkerId] = tmpTime;
                procTime[result.ProcessName] = tmpTime;
                prodTime[result.ProductionId] = tmpTime;
            }

            return prodTime.Values.Max();
        }

        /// <summary>
        /// 総作業時間の算出
        /// </summary>
        /// <returns>総作業時間</returns>
        public int CalcEndTime()
        {
            return CalcEndTime(this);
        }


        /// <summary>
        /// 二つのリストを交叉させる
        /// </summary>
        /// <param name="qTaskWorkerA">要素A</param>
        /// <param name="qTaskWorkerB">要素B</param>
        /// <param name="index">交叉位置</param>
        /// <returns>交叉結果</returns>
        public static (List<QTaskWorker>, List<QTaskWorker>) Cross(List<QTaskWorker> qTaskWorkerA, List<QTaskWorker> qTaskWorkerB, int index)
        {

            List<QTaskWorker> ret = new List<QTaskWorker>();
            List<QTaskWorker> ret2 = new List<QTaskWorker>();

            ret.AddRange(qTaskWorkerA.GetRange(0, index));
            ret.AddRange(qTaskWorkerB.GetRange(index, qTaskWorkerA.Count - index));
            ret2.AddRange(qTaskWorkerB.GetRange(0, index));
            ret2.AddRange(qTaskWorkerA.GetRange(index, qTaskWorkerA.Count - index));

            return (ret, ret2);
        }


        /// <summary>
        /// 作業者割り当ての自動計算処理
        /// </summary>
        /// <returns></returns>
        public static QTaskWorkerCollection CreateTaskWorker(List<QTask> tasks, List<QSkillmap> skills)
        {
            QTaskWorkerCollection list = new QTaskWorkerCollection();

            // タスク数分ループする
            foreach (var task in tasks)
            {
                // スキルマップから製品名と工程名が合致する作業者リストを取得する
                var tmp = (from x in skills
                           where x.ProductionName == task.ProductionName && x.ProcessName == task.ProcessName
                           select x).ToList();

                // 作業者リストからランダムに作業者を選択するためのインデックス
                var index = GetRandomIndex(tmp.Count);

                // 作業者を割り当てたタスクのセット
                QTaskWorker result = new QTaskWorker(task, tmp.ElementAt(index).WorkerId, tmp.ElementAt(index).WorkTime);
                list.Add(result);
            }

            // 作業者を割り当てたタスク一覧
            return list;
        }
    }
}
