namespace FamilyApplication.Services
{
    public class CategoryNotExistException : ApplicationException
    {
        public CategoryNotExistException() : base("The category does not exist. Please choose an existing category")
        {

        }
    }
}
