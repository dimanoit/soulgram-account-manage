using MediatR;

namespace Soulgram.AccountManage.Appliaction.Commands;

public class TestCommand : IRequest
{
    
}

public class TestCommandHandler : IRequestHandler<TestCommand>
{
    public Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Handled");
        return Unit.Task;
    }
}