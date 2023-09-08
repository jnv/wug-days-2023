using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MeowsApi;

public class ProduceResponseTypeModelProvider : IApplicationModelProvider
{
    // ...
    public int Order => 3;

    public void OnProvidersExecuted(ApplicationModelProviderContext context)
    {
    }

    public void OnProvidersExecuting(ApplicationModelProviderContext context)
    {
        foreach (ControllerModel controller in context.Result.Controllers)
        {
            foreach (ActionModel action in controller.Actions)
            {
                // https://stackoverflow.com/a/59515170
                Type? returnType = null;
                if (action.ActionMethod.ReturnType.GenericTypeArguments.Any())
                {
                    if (action.ActionMethod.ReturnType.GenericTypeArguments[0].GetGenericArguments().Any())
                    {
                        returnType = action.ActionMethod.ReturnType.GenericTypeArguments[0].GetGenericArguments()[0];
                    }
                }

                var methodVerbs = action.Attributes.OfType<HttpMethodAttribute>().SelectMany(x => x.HttpMethods).ToHashSet();
                bool actionParametersExist = action.Parameters.Any();

                if (actionParametersExist)
                {
                    action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
                }

                if (methodVerbs.Contains("POST"))
                {
                    AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status201Created);
                    AddProducesResponseTypeAttribute(action, null, StatusCodes.Status400BadRequest);
                }
                else
                {
                    AddProducesResponseTypeAttribute(action, returnType, StatusCodes.Status200OK);
                }
            }

        }
    }

    private static void AddProducesResponseTypeAttribute(ActionModel action, Type? returnType, int statusCodeResult)
    {
        action.Filters.Add(returnType != null
            ? new ProducesResponseTypeAttribute(returnType, statusCodeResult)
            : new ProducesResponseTypeAttribute(statusCodeResult));
    }
}