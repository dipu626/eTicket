using Microsoft.AspNetCore.Mvc;

namespace eticket.Helper
{
    public static class ControllerHelper
    {
        public static string GetControllerName(Type controller)
        {
            string controllerName = controller.Name.Replace("Controller", "");
            return controllerName;
        }
    }
}
