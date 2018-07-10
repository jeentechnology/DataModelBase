using DataModelBase.Interfaces;
using DataModelBase.Definitions;
using Newtonsoft.Json;

namespace DataModelBase.Models
{
    public abstract class ModelBase<T> : IModel
    {
        public string Id { get; set; }

        public ModelStates State { get; private set; }

        private ModelStates restoreState;

        /// <summary>
        /// Called by a property when the status is changed
        /// </summary>
        public void PropertyChanged()
        {
            if (State == ModelStates.NoChange)
                State = ModelStates.Updated;
        }

        /// <summary>
        /// Called by a child ctor for the initial setup of the model
        /// </summary>
        protected void SetupModel(bool isNew)
        {
            if (isNew)
                State = ModelStates.New;
            else
                State = ModelStates.NoChange;
        }

        /// <summary>
        /// Reset the state of the model typically used after hydrating or deserializing
        /// </summary>
        /// <param name="isNew"></param>
        public void ResetState(bool isNew)
        {
            SetupModel(isNew);
        }

        /// <summary>
        /// Sets the state to deleted and updates the restore state in case the delete needs to be undone.
        /// </summary>
        public void Delete()
        {
            restoreState = State;
            State = ModelStates.Deleted;
        }

        /// <summary>
        /// Restores a deleted model to what it was when it was deleted.
        /// </summary>
        public void Restore()
        {
            if (State == ModelStates.Deleted)
                State = restoreState;
        }

        /// <summary>
        /// Manages serializing the child class into a json string as its too string method
        /// </summary>
        protected string HandleToString(T item)
        {
            return JsonConvert.SerializeObject(item);
        }
    }
}
