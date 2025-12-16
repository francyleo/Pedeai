namespace Pedeai.App.Shared.Interfaces
{
  public interface ICommandHandler<TCommand, TResult>
  {
    public Task<TResult> ExecuteAsync(TCommand command);
  }
}