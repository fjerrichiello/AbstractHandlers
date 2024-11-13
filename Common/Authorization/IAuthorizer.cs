namespace Common.Authorization;

public interface IAuthorizer<in TParameters>
{
    AuthorizationResult Authorize(
        TParameters parameters);
}