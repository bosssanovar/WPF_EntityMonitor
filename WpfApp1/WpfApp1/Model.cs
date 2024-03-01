using Entity;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using Usecase;

namespace WpfApp1
{
    public class Model
    {
        public bool IsAutoSave { get; set; }

        public ReactivePropertySlim<XXEntity> Entity { get; } = new ReactivePropertySlim<XXEntity>();

        private readonly SaveLoadUsecase _saveLoadUsecase;

        private readonly InitUsecase _initUsecase;

        public Model(SaveLoadUsecase saveLoadUsecase, InitUsecase initUsecase)
        {
            _saveLoadUsecase = saveLoadUsecase;
            _initUsecase = initUsecase;

            LoadEntity();
            Entity.Subscribe(x =>
            {
                if (IsAutoSave)
                {
                    Debug.WriteLine("Auto Save");

                    _saveLoadUsecase.Save(x);
                }
            });
        }

        private void LoadEntity()
        {
            Debug.WriteLine("LoadEntity");

            Entity.Value = _saveLoadUsecase.Load();
        }

        internal void Init()
        {
            Debug.WriteLine("Init");

            _initUsecase.Init();
            LoadEntity();
        }

        internal void Save()
        {
            Debug.WriteLine("Save");

            _saveLoadUsecase.Save(Entity.Value);
        }

        internal void ForceNotify()
        {
            Entity.ForceNotify();
        }
    }
}
