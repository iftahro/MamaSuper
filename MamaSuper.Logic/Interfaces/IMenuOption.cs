namespace MamaSuper.Logic.Interfaces
{
    public interface IMenuOption
    {
        /// <summary>
        /// The option description for the choice menu 
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The action the action preforms
        /// </summary>
        void Action();
    }
}