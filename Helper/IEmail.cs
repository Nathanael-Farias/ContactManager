namespace AuthSystem.Helper
{
    public interface IEmail
    {
        
        bool Send(string email , string assunto, string message);

    }
}