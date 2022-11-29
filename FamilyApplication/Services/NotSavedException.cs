namespace FamilyApplication.Services
{
    public class NotSavedException : ApplicationException
    {
        public NotSavedException() : base("The entry was not saved")
        {

        }
    }
}
