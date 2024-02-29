using Entity;
using Repository;

namespace Usecase
{
    public class SaveLoadUsecase(IXXRepository repository)
    {
        private readonly IXXRepository repository = repository;

        public void Save(XXEntity entity)
        {
            repository.Save(entity);
        }

        public XXEntity Load()
        {
            return repository.Load();
        }
    }
}
