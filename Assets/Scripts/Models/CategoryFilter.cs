namespace com.application.models
{
    /// <summary>
    /// Datamodel for Category. Used by filter notifier.
    /// </summary>
    public class CategoryFilter
    {
        public CategoryFilter(string category, string subcategory)
        {
            Category = category;
            SubCategory = subcategory;
        }
        public string Category { get; private set; }
        public string SubCategory { get; private set; }
    }
}
