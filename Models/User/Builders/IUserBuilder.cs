namespace SmmEvaApi.Models.User.Builders
{
    public interface IUserBuilder
    {
        User Build(string email);
    }
}