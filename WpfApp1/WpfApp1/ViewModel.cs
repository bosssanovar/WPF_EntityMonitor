using Entity;
using Reactive.Bindings;
using System.ComponentModel;

namespace WpfApp1
{
    public partial class MainWindow : INotifyPropertyChanged
    {
#pragma warning disable CS0067 // イベント 'MainWindow.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindow.PropertyChanged' は使用されていません

        private readonly Model _model;

        public bool IsAutoSave
        {
            get { return _model.IsAutoSave; }
            set
            {
                _model.IsAutoSave = value;
            }
        }

        public ReactivePropertySlim<string> Text { get; }
        public ReactivePropertySlim<int> Number { get; }
        public ReactivePropertySlim<bool> Bool { get; }
        public ReactivePropertySlim<SomeEnum> SomeEnum { get; }

        public AsyncReactiveCommand InitCommand { get; }
        public AsyncReactiveCommand SaveCommand { get; }

        public ReactivePropertySlim<List<ComboBoxItemDisplayValue<SomeEnum>>> ComboBoxItems { get; private set; }

        private void InitComboBoxItems()
        {
#pragma warning disable IDE0028 // コレクションの初期化を簡略化します
            var comboBoxItemList = new List<ComboBoxItemDisplayValue<SomeEnum>>();
#pragma warning restore IDE0028 // コレクションの初期化を簡略化します
            comboBoxItemList.Add(new ComboBoxItemDisplayValue<SomeEnum>(Entity.SomeEnum.Dog, Entity.SomeEnum.Dog.GetText()));
            if (Bool.Value)
            {
                comboBoxItemList.Add(new ComboBoxItemDisplayValue<SomeEnum>(Entity.SomeEnum.Cat, Entity.SomeEnum.Cat.GetText()));
            }
            comboBoxItemList.Add(new ComboBoxItemDisplayValue<SomeEnum>(Entity.SomeEnum.Elephant, Entity.SomeEnum.Elephant.GetText()));
            comboBoxItemList.Add(new ComboBoxItemDisplayValue<SomeEnum>(Entity.SomeEnum.Pig, Entity.SomeEnum.Pig.GetText()));

            ComboBoxItems.Value = new List<ComboBoxItemDisplayValue<SomeEnum>>(comboBoxItemList);
        }

        private void InitMediator()
        {
            Bool.Subscribe(x =>
            {
                InitComboBoxItems();
            });
        }
    }
}
