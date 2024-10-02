using LeaveManagment.Mvc.Contratcs;
using Hanssens;
using System.Reflection.Metadata;
using Hanssens.Net;

namespace LeaveManagment.Mvc.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        LocalStorage _localStorage;
        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "LEAVEMANAGMENT"
            };
            _localStorage = new LocalStorage(config);
        }

        public void SetStorageValue<T>(string key, T storageValue)
        {
            _localStorage.Store(key, storageValue);
            _localStorage.Persist();
        }


        public T GetStorageValue<T>(string key)
        {
            return _localStorage.Get<T>(key);
        }
        public bool Exists(string key)
        {
            return _localStorage.Exists(key);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _localStorage.Remove(key);
            }
        }

    }
}
