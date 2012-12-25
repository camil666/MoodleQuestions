namespace MoodleQuestions.Generics
{
    public abstract class GenericPresenter<TView, TModel>
        where TModel : new()
    {
        #region Properties

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        protected TModel Model { get; private set; }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        protected TView View { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericPresenter{TView,TModel}" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        protected GenericPresenter(TView view)
        {
            View = view;
            Model = new TModel();
        }

        #endregion
    }
}