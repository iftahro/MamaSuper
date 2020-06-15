using MamaSuper.Common.Models;

namespace MamaSuper.Logic.ExtensionMethods
{
    public static class PersonExtensionMethods
    {
        // Max body temperature allowed by the coronavirus instructions
        private const int MAX_BODY_TEMPERATURE = 38;

        /// <summary>
        /// Checks if the person is permitted to enter public places (coronavirus wise)
        /// </summary>
        /// <param name="person">The person to be checked</param>
        /// <param name="prohibitionReason">The prohibition reason if not permitted</param>
        /// <returns>Is the person permitted</returns>
        public static bool IsPermittedToEnter(this Person person, out string prohibitionReason)
        {
            var isPermitted = true;
            prohibitionReason = string.Empty;

            if (person.BodyTemperature > MAX_BODY_TEMPERATURE)
            {
                prohibitionReason += $"Body temperature ({person.BodyTemperature}°) should be under 38 degrees. ";
                isPermitted = false;
            }

            if (!person.HasMask)
            {
                prohibitionReason += "Mask is missing. ";
                isPermitted = false;
            }

            if (person.ShouldIsolate)
            {
                prohibitionReason += "Should be isolated. ";
                isPermitted = false;
            }

            return isPermitted;
        }
    }
}
