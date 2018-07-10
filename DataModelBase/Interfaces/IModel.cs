using DataModelBase.Definitions;

namespace DataModelBase.Interfaces
{
    public interface IModel
    {
        /// <summary>
        /// The Id that will be used to reference the object in a datastore
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The current state of the model
        /// </summary>
        ModelStates State { get; }

    }
}
