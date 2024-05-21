
namespace Architecture
{
    public abstract class Repository
    {
        public virtual void Initialize() { }

        public virtual void OnCreate() { }

        public virtual void OnStart() { }

        public abstract void Save();
    }

}
