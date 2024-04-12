using NBomber.CSharp;
using NBomber.Contracts;

Console.WriteLine("Hello, World!");

var scenario = Scenario.Create("MultiThread", scenectx =>
{
    int threadIndex = scenectx.ScenarioInfo.InstanceNumber;
    int callIndex = (int)scenectx.InvocationNumber - 1;

    scenectx.Logger.Warning($"THREAD INDEX {threadIndex} CALL INDEX {callIndex}");
    
    return Task.FromResult(Response.Ok() as IResponse);
})
.WithLoadSimulations(
    Simulation.IterationsForConstant(copies: 4, iterations: 4)
)
.WithoutWarmUp();

NBomberRunner.RegisterScenarios(scenario).Run();
