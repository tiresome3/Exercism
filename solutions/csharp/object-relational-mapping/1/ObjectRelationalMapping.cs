public class Orm : IDisposable
{
    private Database database;

    public void Dispose()
    {
        this.database.Dispose();
    }
    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        this.database.BeginTransaction();
    }

    public void Write(string data)
    {
        try
        {
            this.database.Write(data);
        } catch
        {
            this.database.Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            this.database.EndTransaction();
        } catch
        {
            this.database.Dispose();
        }
    }
}
