namespace LeaveManagment.Mvc.Contratcs
{
    public interface ILocalStorageService
    {
        void SetStorageValue<T>(string key,T storageValue);
        T GetStorageValue<T>(string key);
        bool Exists(string key);
        void ClearStorage(List<string> keys);
    }
}
