using System.Reflection;

namespace UTMMAX.Mvc.Extensions.Errors;

public static class ApiErrorCodeComposer
{
    private static readonly IDictionary<string, ApiArea> ControllerNameMapping = new Dictionary<string, ApiArea>();

    public static void InitAssemblyScan(Assembly assembly)
    {
        var newApiControllers = assembly.GetTypes()
            .ToList();

        foreach (var controller in newApiControllers)
        {
            var areaAttribute = controller.GetCustomAttribute<ApiAreaAttribute>();
            if (areaAttribute == null)
            {
                continue;
            }

            if (!ControllerNameMapping.ContainsKey(controller.FullName))
            {
                ControllerNameMapping.Add(controller.FullName, new ApiArea(areaAttribute.Name));
            }

            var methods = controller.GetMethods();
            foreach (var action in methods)
            {
                var actionAttribute = action.GetCustomAttribute<ApiActionAttribute>();
                if (actionAttribute == null)
                {
                    continue;
                }

                ControllerNameMapping[controller.FullName].MethodMapping.Add(action.Name, actionAttribute.Name);
            }
        }
    }

    public static string GetAreaName(TypeInfo info)
    {
        return ControllerNameMapping.TryGetValue(info.FullName, out var area) ? area.AreaName : "area";
    }

    public static string GetActionName(MethodInfo info)
    {
        if (ControllerNameMapping.TryGetValue(info.DeclaringType.FullName, out var area))
        {
            if (area.MethodMapping.TryGetValue(info.Name, out var name))
            {
                return name;
            }
        }

        return "action";
    }

    public class ApiArea
    {
        public ApiArea(string areaName)
        {
            AreaName = areaName;
            MethodMapping = new Dictionary<string, string>();
        }

        public string                      AreaName      { get; }
        public IDictionary<string, string> MethodMapping { get; }
    }
}