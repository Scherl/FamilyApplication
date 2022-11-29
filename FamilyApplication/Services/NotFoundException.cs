namespace FamilyApplication.Services
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() : base("Entry not found")
        {

        }
    }
}
