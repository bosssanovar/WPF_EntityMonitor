using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RepositoryMonitor
{
    /// <summary>
    /// RepositoryMonitorView.xaml の相互作用ロジック
    /// </summary>
    public partial class RepositoryMonitorView : Window
    {
        // タイマのインスタンス
        private readonly DispatcherTimer _timer;

        public RepositoryMonitorView(IXXRepository repository)
        {
            _repository = repository;

            // タイマのインスタンスを生成
            _timer = new DispatcherTimer(); // 優先度はDispatcherPriority.Background

            ClearCommand.Subscribe(async _ =>
            {
                await Task.Delay(100);

                Items.Clear();
            });

            InitializeComponent();

            SetupTimer();
        }

        // タイマを設定する
        private void SetupTimer()
        {
            // インターバルを設定
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            // タイマメソッドを設定
            _timer.Tick += new EventHandler(MyTimerMethod);
            // タイマを開始
            _timer.Start();

            // 画面が閉じられるときに、タイマを停止
            Closing += new CancelEventHandler(StopTimer);
        }

        private void MyTimerMethod(object? sender, EventArgs e)
        {
            DetectDifference();
        }

        // タイマを停止
        private void StopTimer(object? sender, CancelEventArgs e)
        {
            _timer.Stop();
        }
    }
}
