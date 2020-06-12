namespace MamaSuper.Common.Interfaces
{
    /// <summary>
    /// Represents an option in a menu
    /// </summary>
    public interface IMenuOption
    {
        /// <summary>
        /// The option description for the choice menu 
        /// </summary>
        string Description { get;}

        /// <summary>
        /// The action the option preforms
        /// </summary>
        void Action();
    }
}