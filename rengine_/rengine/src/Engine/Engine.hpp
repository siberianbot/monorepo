#ifndef RENGINE_SRC_ENGINE_ENGINE_HPP
#define RENGINE_SRC_ENGINE_ENGINE_HPP

#include <string>
#include <vector>

#include "../Common/ISingleton.hpp"

namespace rengine
{
    /// Engine initialization arguments.
    typedef struct EngineArgs
    {
        int argc;
        char **argv;
    } engine_args_t;

    /// Engine main class.
    /// Uses for initialization of all subsystem or their termination.
    class Engine : public ISingleton<Engine>
    {
    public:
        /// Initializes all engine subsystems and goes into infinite loop.
        /// \param args Engine initialization arguments.
        [[noreturn]]
        void run(const engine_args_t &args);

        /// Stops engine with defined return code.
        /// \param returnCode Return code.
        [[noreturn]]
        void exit(const int &returnCode);
    };
}

#endif //RENGINE_SRC_ENGINE_ENGINE_HPP
