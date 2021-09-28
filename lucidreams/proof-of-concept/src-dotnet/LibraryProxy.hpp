#ifndef ENGINE_SRC_DOTNET_LIBRARYPROXY_HPP
#define ENGINE_SRC_DOTNET_LIBRARYPROXY_HPP

#include <string>
#include <Windows.h>

class LibraryProxy
{
private:
    HMODULE _module;

public:
    explicit LibraryProxy(const std::wstring &path);
    ~LibraryProxy();

    void *get(const std::string &name);
};


#endif //ENGINE_SRC_DOTNET_LIBRARYPROXY_HPP
