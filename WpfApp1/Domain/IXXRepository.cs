using Entity;

namespace Repository
{
    public interface IXXRepository
    {
        void Save(XXEntity entity);
        XXEntity Load();
    }
}
