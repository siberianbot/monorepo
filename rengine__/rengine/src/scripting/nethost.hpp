#ifndef RENGINE_SRC_SCRIPTING_NETHOST_HPP
#define RENGINE_SRC_SCRIPTING_NETHOST_HPP

#include <string>

#include <hostfxr.h>
#include <coreclr_delegates.h>

namespace rengine
{
    class nethost
    {
    public:
        static nethost &instance();

        void init();

        void shutdown();

        void *getApiMethod(char_t *typeName, char_t *methodName, char_t *delegateType);

    private:
        hostfxr_initialize_for_runtime_config_fn initializeFn = nullptr;
        hostfxr_set_error_writer_fn setErrorWriterFn = nullptr;
        hostfxr_get_runtime_delegate_fn getRuntimeDelegateFn = nullptr;
        hostfxr_close_fn shutdownFn = nullptr;

        load_assembly_and_get_function_pointer_fn loadAssemblyAndGetFunctionPointerFn = nullptr;

        hostfxr_handle hostfxrHandle = nullptr;

        static void writeError(const char_t *message);
    };
}

#endif //RENGINE_SRC_SCRIPTING_NETHOST_HPP
