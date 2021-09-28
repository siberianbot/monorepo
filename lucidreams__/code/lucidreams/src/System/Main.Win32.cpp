#include <lucidreams/Engine.hpp>

#ifdef WIN32

#include <vector>

#include <Windows.h>

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PWSTR lpCmdLine, int nCmdShow)
{
    int argc;
    wchar_t** argv = CommandLineToArgvW(lpCmdLine, &argc);
    std::vector<lucidreams::WideString> args;

    for (int i = 0; i < argc; ++i)
    {
        args.emplace_back(argv[i]);
    }

    lucidreams::run(args);
}

#endif