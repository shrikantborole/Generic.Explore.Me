using Generic.Common.Interface.Explore.Me.Model;
using Generic.Common.Interface.Explore.Me.Repo;

namespace Generic.Common.Implementation.Explore.Me
{
    //Added constraint because each and every class using ListRepository be derived from the IEntity
    //This is because, you have used the id for seclect and other operations.
    public class ListRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _list;
        public ListRepository()
        {
            _list = new List<T>();
        }
        public void Add(T item)
        {
            _list.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _list;
        }

        //As we have IEntity contraint, hence we are able to filter it based on ID
        public T GetById(int id)
        {
            return _list.Single(item => item.Id == id);
        }

        public void Remove(T item)
        {
            _list.Remove(item);
        }

        public void Save()
        {
            // Everything is saved already in the List<T>
        }
    }
}
