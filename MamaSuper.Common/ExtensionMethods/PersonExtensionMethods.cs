using MamaSuper.Common.Models;

namespace MamaSuper.Common.ExtensionMethods
{
    public static class PersonExtensionMethods
    {
        public static bool IsPermittedToEnter(this Person person, out string prohibitionReason)
        {
            bool isPermitted = true;
            prohibitionReason = string.Empty;

            if (person.BodyTemperature > 38)
            {
                prohibitionReason += $"Body temperature ({person.BodyTemperature}°) should be under 38 degrees. ";
                isPermitted = false;
            }

            if (!person.HasMask)
            {
                prohibitionReason += "Person mask is missing. ";
                isPermitted = false;
            }

            if (person.ShouldIsolate)
            {
                prohibitionReason += "Person should be isolated. ";
                isPermitted = false;
            }

            return isPermitted;
        }
    }
}
