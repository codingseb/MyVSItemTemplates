using Autofac;
using Autofac.Core.Resolving.Pipeline;

namespace $rootnamespace$;

/// <summary>
/// To specify how to build our application with dependency injection
/// and get the container
/// </summary>
public static class $fileinputname$
{
    /// <summary>
    /// The container of DI structure
    /// </summary>
    public static IContainer Container { get; } = Build();

    private static IContainer Build()
    {
        var builder = new ContainerBuilder();

        // To add global middleware
        builder.ComponentRegistryBuilder.Registered += (sender, args) =>
        {
            args.ComponentRegistration.PipelineBuilding += (_, pipeline) =>
            {
                pipeline.Use(new OnActivationCallInitMiddleware());
                // pipeline.Use(new ConfigurableResolveMiddleware(PipelinePhase.Activation, context =>
                // {

                // }));
            };
        };

        // builder
            // .RegisterType<Config>()
            // .AsSelf()
            // .ConfigurePipeline(pipeline => pipeline.Use(new MakeOnPropertyChangedPersistentMiddleware()))
            // .SingleInstance();

        return builder.Build();
    }
}
