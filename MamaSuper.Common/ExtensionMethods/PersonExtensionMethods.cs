using MamaSuper.Common.Models;

namespace MamaSuper.Common.ExtensionMethods
{
    /// <summary>
    /// Person model extension methods 
    /// </summary>
    public static class PersonExtensionMethods
    {
        /// <summary>
        /// Checks if the person is permitted to enter public places (coronavirus wise)
        /// </summary>
        /// <param name="person">The person to be checked</param>
        /// <param name="prohibitionReason">The prohibition reason if not permitted</param>
        /// <returns>Is the person permitted</returns>
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
