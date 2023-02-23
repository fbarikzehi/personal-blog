namespace Data.Persistence
{
    internal interface ICommand<TModel>
    {
       TModel Create(TModel model);
       TModel Update();
       TModel Delete();
       TModel Get(TModel model);
       IEnumerable<TModel> ReadMany();

    }
}