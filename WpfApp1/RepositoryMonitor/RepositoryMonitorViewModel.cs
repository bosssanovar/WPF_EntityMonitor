using Entity;
using Reactive.Bindings;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMonitor
{
    public partial class RepositoryMonitorView : INotifyPropertyChanged
    {
#pragma warning disable CS0067 // イベント 'RepositoryMonitorView.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'RepositoryMonitorView.PropertyChanged' は使用されていません

        readonly IXXRepository _repository;
        XXEntity? _presentEntity;

        public ReactiveCollection<Item> Items { get; } = [];

        public AsyncReactiveCommand ClearCommand { get; } = new AsyncReactiveCommand();

        private void DetectDifference()
        {
            _presentEntity ??= _repository.Load();

            var nowEntity = _repository.Load();

            if (_presentEntity.Text != nowEntity.Text)
            {
                Items.Insert(0, new Item("Text", nowEntity.Text.Content));
            }

            if (_presentEntity.Number != nowEntity.Number)
            {
                Items.Insert(0, new Item("Number", nowEntity.Number.Content.ToString()));
            }

            if (_presentEntity.Bool != nowEntity.Bool)
            {
                Items.Insert(0, new Item("Bool", nowEntity.Bool.Content.ToString()));
            }

            if (_presentEntity.SomeEnum != nowEntity.SomeEnum)
            {
                Items.Insert(0, new Item("SomeEnum", nowEntity.SomeEnum.Content.GetText()));
            }

            _presentEntity = nowEntity;
        }
    }
}
