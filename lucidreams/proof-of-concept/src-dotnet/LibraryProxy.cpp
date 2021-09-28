#include "LibraryProxy.hpp"

LibraryProxy::LibraryProxy(const std::wstring &path) : _module(LoadLibrary(path.c_str()))
{
    //
}

LibraryProxy::~LibraryProxy()
{
    FreeLibrary(_module);
}

void *LibraryProxy::get(const std::string &name)
{
    return reinterpret_cast<void *>(GetProcAddress(_module, name.c_str()));
}
