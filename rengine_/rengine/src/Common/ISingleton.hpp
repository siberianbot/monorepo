#ifndef RENGINE_SRC_COMMON_ISINGLETON_HPP
#define RENGINE_SRC_COMMON_ISINGLETON_HPP

namespace rengine
{
    /// Interface of singleton.
    /// \tparam TSingleton Type of singleton.
    template<class TSingleton>
    class ISingleton
    {
    public:
        /// Returns single instance of TSingleton.
        /// \return Instance of TSingleton.
        static TSingleton *instance();

    protected:
        static TSingleton *_instance;
    };

    template<class TSingleton>
    TSingleton *ISingleton<TSingleton>::instance()
    {
        if (_instance == nullptr)
        {
            _instance = new TSingleton();
        }

        return _instance;
    }
}

/// Generates instance for singleton (for compiler uses).
/// \param TYPE Type of singleton.
/// \note TYPE should be derived from ISingleton.
/// \note Also this thing will be marked as incorrect 'cause we access
/// to protected _instance.
#define GENERATE_SINGLETON_INSTANCE(TYPE) TYPE *TYPE::_instance

#endif //RENGINE_SRC_COMMON_ISINGLETON_HPP