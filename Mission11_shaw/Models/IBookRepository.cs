namespace Mission11_shaw.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
