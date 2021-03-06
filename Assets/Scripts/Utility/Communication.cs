using com.application.models;
using com.application.utility;
using System.Collections.Generic;

namespace com.application.communication
{
    /// <summary>
    /// Singleton Class for accessing all the notifiers.
    /// </summary>
    public class Communication : Singleton<Communication>
    {
        public Notifier<ProductModel> ShowProductDetails = new Notifier<ProductModel>();
        public Notifier<CategoryFilter> ApplyFilterNotifier = new Notifier<CategoryFilter>();
    }
}
