#include "apiHost.hpp"

#include "./nethost.hpp"

namespace rengine
{
    typedef struct bootstrapInitParams
    {
        char_t* assemblyPathPtr;
    } bootstrap_init_params_t;

    typedef void (CORECLR_DELEGATE_CALLTYPE *bootstrapInitFn)(const bootstrap_init_params_t &initParams);

    apiHost &apiHost::instance()
    {
        static apiHost instance;
        return instance;
    }

    void apiHost::init(char_t *assemblyPath)
    {
        bootstrapInitFn bootstrapInit = static_cast<bootstrapInitFn>(nethost::instance().getApiMethod(
            L"rengine.API.Internal.Bootstrap, rengine.API", L"Init", (char_t*)-1));

        bootstrapInit({
            .assemblyPathPtr = assemblyPath
        });
    }
}
