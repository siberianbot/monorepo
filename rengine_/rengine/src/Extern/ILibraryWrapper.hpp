#ifndef RENGINE_SRC_EXTERN_ILIBRARYWRAPPER_HPP
#define RENGINE_SRC_EXTERN_ILIBRARYWRAPPER_HPP

#include "../Common/ISingleton.hpp"

namespace rengine
{
    /// Interface of library wrapper.
    /// \tparam TLibraryWrapper Type of library wrapper.
    template<class TLibraryWrapper>
    class ILibraryWrapper : public ISingleton<TLibraryWrapper>
    {
    public:
        /// Initializes library.
        virtual void init() = 0;

        /// Terminates library.
        virtual void terminate() = 0;
    };
}

#endif //RENGINE_SRC_EXTERN_ILIBRARYWRAPPER_HPP
