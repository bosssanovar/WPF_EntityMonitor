using Entity;
using Microsoft.Extensions.DependencyInjection;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Repository;
using RepositoryMonitor;
using System.Diagnostics;
using System.Windows;
using Usecase;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RepositoryMonitorView _repositoryMonitorView;

        public MainWindow()
        {
            // DI
            var services = new ServiceCollection();
            services.AddSingleton<IXXRepository, InMemoryXXRepository>();
            services.AddTransient<SaveLoadUsecase>();
            services.AddTransient<InitUsecase>();
            services.AddTransient<Model>();
            services.AddTransient<RepositoryMonitorView>();
            var provider = services.BuildServiceProvider();

            _model = provider.GetRequiredService<Model>();

            _repositoryMonitorView = provider.GetRequiredService<RepositoryMonitorView>();

            Text = _model.Entity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Text.Content,
                x =>
                {
                    Debug.WriteLine("Text ConvertBack");

                    var currected = TextVO.CurrectValue(x);
                    _model.Entity.Value.Text = new(currected);

                    _model.ForceNotify();

                    return _model.Entity.Value;
                });

            Number = _model.Entity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Number.Content,
                x =>
                {
                    Debug.WriteLine("Number ConvertBack");

                    var currected = NumberVO.CurrectValue(x);
                    _model.Entity.Value.Number = new(currected);

                    _model.ForceNotify();

                    return _model.Entity.Value;
                });

            Bool = _model.Entity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.Bool.Content,
                x =>
                {
                    Debug.WriteLine("Bool ConvertBack");

                    var currected = BoolVO.CurrectValue(x);
                    _model.Entity.Value.Bool = new(currected);

                    _model.ForceNotify();

                    return _model.Entity.Value;
                });

            SomeEnum = _model.Entity.ToReactivePropertySlimAsSynchronized(
                x => x.Value,
                x => x.SomeEnum.Content,
                x =>
                {
                    Debug.WriteLine("SomeEnum ConvertBack");

                    var currected = SomeEnumVO.CurrectValue(x);
                    _model.Entity.Value.SomeEnum = new(currected);

                    _model.ForceNotify();

                    return _model.Entity.Value;
                });

            InitCommand = new AsyncReactiveCommand();
            InitCommand.Subscribe(async () =>
            {
                await Task.Delay(500);

                _model.Init();
            });

            SaveCommand = new AsyncReactiveCommand();
            SaveCommand.Subscribe(async () =>
            {
                await Task.Delay(500);

                _model.Save();
            });

            ComboBoxItems = new ReactivePropertySlim<List<ComboBoxItemDisplayValue<SomeEnum>>>();
            InitComboBoxItems();

            InitMediator();

            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            _repositoryMonitorView.Owner = this;
            _repositoryMonitorView.Show();
        }
    }
}