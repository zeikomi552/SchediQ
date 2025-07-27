using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchediQ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchediQ.Tests
{
    [TestClass()]
    public class QSimulatorTests
    {
        [TestMethod()]
        public void QSimulatorTest()
        {
            var task = CreateSampleTask();
            var maps = CreateSkillmaps();

            var tmp = QSimulator.CreateGeneration(task, maps, 100);
            var result = (from x in tmp orderby x.CalcEndTime() select x).ToList();
            Debug.WriteLine(result.ElementAt(0).CalcEndTime());

            for (int i = 0; i < 100; i++)
            {
                tmp = QSimulator.CreateNextGeneration(tmp, 100);
                result = (from x in tmp orderby x.CalcEndTime() select x).ToList();
                Debug.WriteLine(result.ElementAt(0).CalcEndTime());
            }

            Assert.Fail();
        }


        List<QTask> CreateSampleTask()
        {

            //Console.WriteLine("Hello, World!");

            var tasks = new List<QTask>();

            tasks.Add(new QTask("00001", "製品A", "工程3"));
            tasks.Add(new QTask("00001", "製品A", "工程4"));
            tasks.Add(new QTask("00001", "製品A", "工程5"));
            tasks.Add(new QTask("00001", "製品A", "工程6"));
            tasks.Add(new QTask("00001", "製品A", "工程7"));

            tasks.Add(new QTask("00002", "製品A", "工程1"));
            tasks.Add(new QTask("00002", "製品A", "工程2"));
            tasks.Add(new QTask("00002", "製品A", "工程3"));
            tasks.Add(new QTask("00002", "製品A", "工程4"));
            tasks.Add(new QTask("00002", "製品A", "工程5"));
            tasks.Add(new QTask("00002", "製品A", "工程6"));
            tasks.Add(new QTask("00002", "製品A", "工程7"));

            tasks.Add(new QTask("00003", "製品B", "工程1"));
            tasks.Add(new QTask("00003", "製品B", "工程2"));
            tasks.Add(new QTask("00003", "製品B", "工程3"));
            tasks.Add(new QTask("00003", "製品B", "工程4"));
            tasks.Add(new QTask("00003", "製品B", "工程5"));
            tasks.Add(new QTask("00003", "製品B", "工程6"));
            tasks.Add(new QTask("00003", "製品B", "工程7"));

            tasks.Add(new QTask("00004", "製品B", "工程1"));
            tasks.Add(new QTask("00004", "製品B", "工程2"));
            tasks.Add(new QTask("00004", "製品B", "工程3"));
            tasks.Add(new QTask("00004", "製品B", "工程4"));
            tasks.Add(new QTask("00004", "製品B", "工程5"));
            tasks.Add(new QTask("00004", "製品B", "工程6"));
            tasks.Add(new QTask("00004", "製品B", "工程7"));

            tasks.Add(new QTask("00005", "製品C", "工程1"));
            tasks.Add(new QTask("00005", "製品C", "工程3"));
            tasks.Add(new QTask("00005", "製品C", "工程4"));
            tasks.Add(new QTask("00005", "製品C", "工程5"));
            tasks.Add(new QTask("00005", "製品C", "工程6"));
            tasks.Add(new QTask("00005", "製品C", "工程7"));
            return tasks;
        }

        List<QSkillmap> CreateSkillmaps()
        {
            var skillmap = new List<QSkillmap>();
            #region 作業者A
            skillmap.Add(new QSkillmap("製品A", "工程1", "作業者A", 10));
            skillmap.Add(new QSkillmap("製品A", "工程2", "作業者A", 20));
            skillmap.Add(new QSkillmap("製品A", "工程3", "作業者A", 30));
            skillmap.Add(new QSkillmap("製品A", "工程4", "作業者A", 25));
            skillmap.Add(new QSkillmap("製品A", "工程5", "作業者A", 20));
            skillmap.Add(new QSkillmap("製品A", "工程6", "作業者A", 10));
            skillmap.Add(new QSkillmap("製品A", "工程7", "作業者A", 15));

            skillmap.Add(new QSkillmap("製品B", "工程1", "作業者A", 10));
            skillmap.Add(new QSkillmap("製品B", "工程2", "作業者A", 20));
            skillmap.Add(new QSkillmap("製品B", "工程3", "作業者A", 30));
            skillmap.Add(new QSkillmap("製品B", "工程4", "作業者A", 25));
            skillmap.Add(new QSkillmap("製品B", "工程5", "作業者A", 20));
            skillmap.Add(new QSkillmap("製品B", "工程6", "作業者A", 10));
            skillmap.Add(new QSkillmap("製品B", "工程7", "作業者A", 15));

            skillmap.Add(new QSkillmap("製品C", "工程1", "作業者A", 10));
            skillmap.Add(new QSkillmap("製品C", "工程2", "作業者A", 20));
            skillmap.Add(new QSkillmap("製品C", "工程3", "作業者A", 30));
            skillmap.Add(new QSkillmap("製品C", "工程4", "作業者A", 25));
            skillmap.Add(new QSkillmap("製品C", "工程5", "作業者A", 20));
            skillmap.Add(new QSkillmap("製品C", "工程6", "作業者A", 10));
            skillmap.Add(new QSkillmap("製品C", "工程7", "作業者A", 15));
            #endregion

            #region 作業者B
            skillmap.Add(new QSkillmap("製品A", "工程1", "作業者B", 10));
            skillmap.Add(new QSkillmap("製品A", "工程2", "作業者B", 20));
            skillmap.Add(new QSkillmap("製品A", "工程3", "作業者B", 30));
            skillmap.Add(new QSkillmap("製品A", "工程4", "作業者B", 25));

            skillmap.Add(new QSkillmap("製品B", "工程1", "作業者B", 10));
            skillmap.Add(new QSkillmap("製品B", "工程2", "作業者B", 20));
            skillmap.Add(new QSkillmap("製品B", "工程3", "作業者B", 30));
            skillmap.Add(new QSkillmap("製品B", "工程4", "作業者B", 25));

            skillmap.Add(new QSkillmap("製品C", "工程1", "作業者B", 10));
            skillmap.Add(new QSkillmap("製品C", "工程2", "作業者B", 20));
            skillmap.Add(new QSkillmap("製品C", "工程3", "作業者B", 30));
            skillmap.Add(new QSkillmap("製品C", "工程4", "作業者B", 25));
            #endregion

            #region 作業者C
            skillmap.Add(new QSkillmap("製品A", "工程4", "作業者C", 25));
            skillmap.Add(new QSkillmap("製品A", "工程5", "作業者C", 20));
            skillmap.Add(new QSkillmap("製品A", "工程6", "作業者C", 10));
            skillmap.Add(new QSkillmap("製品A", "工程7", "作業者C", 15));

            skillmap.Add(new QSkillmap("製品B", "工程4", "作業者C", 25));
            skillmap.Add(new QSkillmap("製品B", "工程5", "作業者C", 20));
            skillmap.Add(new QSkillmap("製品B", "工程6", "作業者C", 10));
            skillmap.Add(new QSkillmap("製品B", "工程7", "作業者C", 15));

            skillmap.Add(new QSkillmap("製品C", "工程4", "作業者C", 25));
            skillmap.Add(new QSkillmap("製品C", "工程5", "作業者C", 20));
            skillmap.Add(new QSkillmap("製品C", "工程6", "作業者C", 10));
            skillmap.Add(new QSkillmap("製品C", "工程7", "作業者C", 15));
            #endregion

            return skillmap;
        }


    }
}