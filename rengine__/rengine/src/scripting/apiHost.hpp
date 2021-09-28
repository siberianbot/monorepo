#ifndef RENGINE_SRC_SCRIPTING_APIHOST_HPP
#define RENGINE_SRC_SCRIPTING_APIHOST_HPP

#include <coreclr_delegates.h>

namespace rengine
{
    class apiHost
    {
    public:
        static apiHost &instance();

        void init(char_t *assemblyPath);

    private:
        apiHost() = default;
    };
}

#endif //RENGINE_SRC_SCRIPTING_APIHOST_HPP
