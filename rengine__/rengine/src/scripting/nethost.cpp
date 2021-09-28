#include "nethost.hpp"

#include <Windows.h>
#include <nethost.h>

#include "../utils/assert.hpp"

namespace rengine
{
    nethost &nethost::instance()
    {
        static nethost instance;
        return instance;
    }

    void nethost::init()
    {
        char_t path[4096];
        size_t pathSize = 4096;

        engineAssert(get_hostfxr_path(path, &pathSize, nullptr) == 0, "nethost: initialization failed");

        HMODULE hostFxrLib = LoadLibraryW(path);
        initializeFn = (hostfxr_initialize_for_runtime_config_fn)GetProcAddress(hostFxrLib, "hostfxr_initialize_for_runtime_config");
        setErrorWriterFn = (hostfxr_set_error_writer_fn)GetProcAddress(hostFxrLib, "hostfxr_set_error_writer");
        getRuntimeDelegateFn = (hostfxr_get_runtime_delegate_fn)GetProcAddress(hostFxrLib, "hostfxr_get_runtime_delegate");
        shutdownFn = (hostfxr_close_fn)GetProcAddress(hostFxrLib, "hostfxr_close");

        engineAssert(initializeFn && setErrorWriterFn && getRuntimeDelegateFn && shutdownFn, "nethost: functions are not loaded");

        setErrorWriterFn(nethost::writeError);

        engineAssert(
            initializeFn(L"D:\\rengine\\rengine\\deps\\dotnet-dist\\sdk\\5.0.100-rc.1.20452.10\\dotnet.runtimeconfig.json", nullptr, &hostfxrHandle) == 0,
            "nethost: failed to init .NET runtime"
        );

        engineAssert(
            getRuntimeDelegateFn(hostfxrHandle, hdt_load_assembly_and_get_function_pointer, reinterpret_cast<void **>(&loadAssemblyAndGetFunctionPointerFn)) == 0,
            "nethost: failed to init .NET runtime"
        );

        shutdownFn(hostfxrHandle);
    }

    void nethost::shutdown()
    {
        // TODO: there should be some logic?
    }

    void *nethost::getApiMethod(char_t* typeName, char_t* methodName, char_t *delegateType)
    {
        void* delegate = nullptr;

        engineAssert(loadAssemblyAndGetFunctionPointerFn(L"rengine.API.dll", typeName, methodName, delegateType, nullptr, &delegate) == 0, "nethost: failed to get delegate");
        engineAssert(delegate, "nethost: failed to get delegate");

        return delegate;
    }

    void nethost::writeError(const char_t *message)
    {
        // TODO: remove, or use it to write errors in log.
        (void)message;
    }
}