namespace Abstract_Classes_ClassLibrary
{
    public interface IDataAccess
    {
        public string LoadConnectionString(string name);
        public void LoadData(string sql);
        public void SaveData(string sql);
    }
}
