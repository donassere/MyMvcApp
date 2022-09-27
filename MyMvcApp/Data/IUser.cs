namespace MyMvcApp.Data
{
  
    public interface IUser<TModel> where TModel : class
    {
        List<TModel> GetAll();

        TModel GetById(int id);

        TModel Add(TModel model);
        TModel GetByFirstName(string name);
        TModel GetByMail(string mail);

        int Commit();
    }
}
