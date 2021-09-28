#include "IDynamicLibraryProxy.hpp"

#include <utility>

#include <lucidreams/Utils/StringFormat.hpp>

#include "../Utils/StringUtils.hpp"

namespace lucidreams
{
    IDynamicLibraryProxy::IDynamicLibraryProxy(WideString name) : _wsName(std::move(name)), _mbName(toMultibyte(name))
    {
        //
    }

    MbString IDynamicLibraryProxy::getDisplayName() const
    {
        return format<char>("%0 proxy", this->_mbName);
    }
}