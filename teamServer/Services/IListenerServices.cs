using teamServer.Models;

namespace teamServer.Services
{
    //inteface : https://www.geeksforgeeks.org/c-sharp-interface/
    public interface IListenerServices
    {
        void AddListener(Listener listener);

        //Ienumerable: provide flexibility in data type of list
        IEnumerable<Listener> GetListeners();

        Listener GetListener(string name);
        void RemoveListener(Listener listener);
    }

    public class ListenerServices : IListenerServices
    {
        private readonly List<Listener> _listeners;
        public void AddListener(Listener listener)
        {
            _listeners.Add(listener);
        }

        public Listener GetListener(string name)
        {
            return GetListeners().FirstOrDefault(l => l.Name.Equals(name));
        }

        public IEnumerable<Listener> GetListeners()
        {
            return _listeners;
        }

        public void RemoveListener(Listener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
