#include <iostream>

#include "LibraryProxy.hpp"
#include "../extern/dotnet/hostfxr.h"
#include "../extern/dotnet/coreclr_delegates.h"

void writeError(const wchar_t *msg)
{
    std::wcout << msg << std::endl;
}

typedef int (*invokeDelegateFn)();

int main()
{
    wchar_t* hostfxrPath = L"D:/Projects/lucidreams/redist-x86/dotnet/host/fxr/5.0.7/hostfxr.dll";
    wchar_t* runtimeConfigPath = L"D:/Projects/lucidreams/redist-x86/dotnet/sdk/5.0.301/dotnet.runtimeconfig.json";

    LibraryProxy hostfxrProxy = LibraryProxy(hostfxrPath);

    hostfxr_initialize_for_runtime_config_fn hostInitFn = (hostfxr_initialize_for_runtime_config_fn) hostfxrProxy.get("hostfxr_initialize_for_runtime_config");
    hostfxr_close_fn hostCloseFn = (hostfxr_close_fn) hostfxrProxy.get("hostfxr_close");
    hostfxr_get_runtime_delegate_fn hostGetDelegateFn = (hostfxr_get_runtime_delegate_fn) hostfxrProxy.get("hostfxr_get_runtime_delegate");
    hostfxr_set_error_writer_fn hostSetErrorWriter = (hostfxr_set_error_writer_fn) hostfxrProxy.get("hostfxr_set_error_writer");
    hostfxr_handle hostHandle;

    if (hostInitFn(runtimeConfigPath, nullptr, &hostHandle) != 0)
    {
        throw;
    }

    hostSetErrorWriter(writeError);

    int32_t result;

    load_assembly_and_get_function_pointer_fn loadAssemblyAndGetFunctionPtrDelegate = nullptr;
    result = hostGetDelegateFn(hostHandle, hdt_load_assembly_and_get_function_pointer, (void**)&loadAssemblyAndGetFunctionPtrDelegate);
    if (result != 0)
    {
        throw;
    }

    get_function_pointer_fn *getFunctionPtrDelegate = nullptr;
    result = hostGetDelegateFn(hostHandle, hdt_get_function_pointer, (void**)&getFunctionPtrDelegate);
    if (result != 0)
    {
        throw;
    }

    invokeDelegateFn invokeDelegate = nullptr;
    result = loadAssemblyAndGetFunctionPtrDelegate(L"EngineManaged.dll", L"EngineManaged.ManagedClass, EngineManaged", L"Invoke", UNMANAGEDCALLERSONLY_METHOD, nullptr, (void**)&invokeDelegate);
    if (result != 0)
    {
        throw;
    }

    invokeDelegate();

    hostCloseFn(hostHandle);
}
