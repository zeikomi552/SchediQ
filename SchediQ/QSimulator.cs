using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchediQ
{
    public class QSimulator
    {


        static Random _Rand = new Random();

        private static List<QTaskWorkerCollection> Sort(List<QTaskWorkerCollection> items)
        {
            return (from x in items
                    orderby x.CalcEndTime()
                    select x).ToList();
        }

        /// <summary>
        /// 1世代目の作成
        /// </summary>
        /// <param name="tasks">タスクリスト</param>
        /// <param name="skills">スキルリスト</param>
        /// <param name="geneCount">当世代の要素数</param>
        /// <returns>当世代のリスト</returns>
        public static List<QTaskWorkerCollection> CreateGeneration(List<QTask> tasks, List<QSkillmap> skills, int geneCount)
        {
            List<QTaskWorkerCollection> gene = new List<QTaskWorkerCollection>();

            for (int iCnt = 0; iCnt < geneCount; iCnt++)
            {
                QTaskWorkerCollection test = QTaskWorkerCollection.CreateTaskWorker(tasks, skills);
                gene.Add(test);
            }

            return gene;
        }

        /// <summary>
        /// 次の世代の作成
        /// </summary>
        /// <param name="items">前の世代のリスト</param>
        /// <param name="max">次世代の最大値</param>
        /// <returns>次の世代のリスト</returns>
        public static List<QTaskWorkerCollection> CreateNextGeneration(List<QTaskWorkerCollection> items, int max)
        {
            var selectGeneration = Sort(items).GetRange(0, max);


            List<QTaskWorkerCollection> nextGene = new List<QTaskWorkerCollection>();

            while (nextGene.Count < items.Count)
            {
                int index1 = _Rand.Next(0, max);
                int index2 = _Rand.Next(0, max);
                int slesh = _Rand.Next(0, selectGeneration.ElementAt(index1).Count);

                var (tmp1, tmp2) = QTaskWorkerCollection.Cross(selectGeneration.ElementAt(index1), selectGeneration.ElementAt(index2), slesh);
                nextGene.Add(new QTaskWorkerCollection(tmp1.ToList()));
                nextGene.Add(new QTaskWorkerCollection(tmp2.ToList()));
            }
            nextGene.AddRange(items);

            return Sort(nextGene).GetRange(0, max);
        }
    }
}
