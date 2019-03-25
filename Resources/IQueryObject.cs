namespace CarRent.Resources
{
    public interface IQueryObject
    {
         int Page { get; set; }

         int PageSize { get; set; }
    }
}