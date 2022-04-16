namespace Autofac_ClassLibrary.Utilities;

public interface IDataAccess
{
    void LoadData();
    void SaveData(string name);
}