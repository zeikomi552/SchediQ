using SchediQ;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace SchediQGui.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        #region タスクリスト
        /// <summary>
        /// タスクリスト
        /// </summary>
        ObservableCollection<QTask> _QTaskList = new ObservableCollection<QTask>();
        /// <summary>
        /// タスクリスト
        /// </summary>
        public ObservableCollection<QTask> QTaskList
        {
            get
            {
                return _QTaskList;
            }
            set
            {
                if (_QTaskList == null || !_QTaskList.Equals(value))
                {
                    _QTaskList = value;
                    NotifyPropertyChanged("QTaskList");
                }
            }
        }
        #endregion
        #region 終了時間
        /// <summary>
        /// 終了時間
        /// </summary>
        int _EndTime = 0;
        /// <summary>
        /// 終了時間
        /// </summary>
        public int EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                if (!_EndTime.Equals(value))
                {
                    _EndTime = value;
                    NotifyPropertyChanged("EndTime");
                }
            }
        }
        #endregion
        #region スキルマップリスト
        /// <summary>
        /// スキルマップリスト
        /// </summary>
        ObservableCollection<QSkillmap> _QSkillmapList = new ObservableCollection<QSkillmap>();
        /// <summary>
        /// スキルマップリスト
        /// </summary>
        public ObservableCollection<QSkillmap> QSkillmapList
        {
            get
            {
                return _QSkillmapList;
            }
            set
            {
                if (_QSkillmapList == null || !_QSkillmapList.Equals(value))
                {
                    _QSkillmapList = value;
                    NotifyPropertyChanged("QSkillmapList");
                }
            }
        }
        #endregion
        #region 作業リスト
        /// <summary>
        /// 作業リスト
        /// </summary>
        ObservableCollection<QTaskWorkerCollection> _QTaskWorkerCollectionList = new ObservableCollection<QTaskWorkerCollection>();
        /// <summary>
        /// 作業リスト
        /// </summary>
        public ObservableCollection<QTaskWorkerCollection> QTaskWorkerCollectionList
        {
            get
            {
                return _QTaskWorkerCollectionList;
            }
            set
            {
                if (_QTaskWorkerCollectionList == null || !_QTaskWorkerCollectionList.Equals(value))
                {
                    _QTaskWorkerCollectionList = value;
                    NotifyPropertyChanged("QTaskWorkerCollectionList");
                }
            }
        }
        #endregion

        #region 選択作業リスト
        /// <summary>
        /// 選択作業リスト
        /// </summary>
        QTaskWorkerCollection _SelectedQTaskWorkerCollection = new QTaskWorkerCollection();
        /// <summary>
        /// 選択作業リスト
        /// </summary>
        public QTaskWorkerCollection SelectedQTaskWorkerCollection
        {
            get
            {
                return _SelectedQTaskWorkerCollection;
            }
            set
            {
                if (_SelectedQTaskWorkerCollection == null || !_SelectedQTaskWorkerCollection.Equals(value))
                {
                    _SelectedQTaskWorkerCollection = value;
                    NotifyPropertyChanged("SelectedQTaskWorkerCollection");
                }
            }
        }
        #endregion
        #region 世代リスト
        /// <summary>
        /// 世代リスト
        /// </summary>
        ObservableCollection<QTaskGeneration> _GenerationList = new ObservableCollection<QTaskGeneration>();
        /// <summary>
        /// 世代リスト
        /// </summary>
        public ObservableCollection<QTaskGeneration> GenerationList
        {
            get
            {
                return _GenerationList;
            }
            set
            {
                if (_GenerationList == null || !_GenerationList.Equals(value))
                {
                    _GenerationList = value;
                    NotifyPropertyChanged("GenerationList");
                }
            }
        }
        #endregion
        #region 選択世代
        /// <summary>
        /// 選択世代
        /// </summary>
        QTaskGeneration _SelectedGeneration = new QTaskGeneration();
        /// <summary>
        /// 選択世代
        /// </summary>
        public QTaskGeneration SelectedGeneration
        {
            get
            {
                return _SelectedGeneration;
            }
            set
            {
                if (_SelectedGeneration == null || !_SelectedGeneration.Equals(value))
                {
                    _SelectedGeneration = value;
                    NotifyPropertyChanged("SelectedGeneration");
                }
            }
        }
        #endregion


        public void Init()
        {
            this.QTaskList = new ObservableCollection<QTask>(CreateSampleTask());
            this.QSkillmapList = new ObservableCollection<QSkillmap>(CreateSkillmaps());

            var tmp = QSimulator.CreateGeneration(this.QTaskList.ToList(), this.QSkillmapList.ToList(), 100);
            var result = (from x in tmp orderby x.CalcEndTime() select x).ToList();

            this.GenerationList.Add(new QTaskGeneration(result));

            Debug.WriteLine(result.ElementAt(0).CalcEndTime());

            for (int i = 0; i < 100; i++)
            {
                tmp = QSimulator.CreateNextGeneration(tmp, 100);
                result = (from x in tmp orderby x.CalcEndTime() select x).ToList();
                this.GenerationList.Add(new QTaskGeneration(result));
            }
        }

        public void Calc()
        {
            if(SelectedQTaskWorkerCollection != null && this.SelectedQTaskWorkerCollection.Count > 0)
            {
                this.EndTime = SelectedQTaskWorkerCollection.CalcEndTime();
            }
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



        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
