#ifndef RENGINE_COMMON_ENGINE_HPP
#define RENGINE_COMMON_ENGINE_HPP

#include <memory>
#include <string>
#include <vector>

#include "../system/window.hpp"

namespace rengine
{
    typedef struct engineRuntimeParams
    {
        std::vector<std::string> args;
    } engine_runtime_params_t;

    class engine
    {
    public:
        static engine &instance();

        [[noreturn]]
        void run(const engine_runtime_params_t &params);

        [[noreturn]]
        void shutdown(bool isFailure);

        [[nodiscard]]
        std::weak_ptr<window> getWindow() const { return _window; }

    private:
        std::shared_ptr<window> _window;

        engine();
    };
}

#endif //RENGINE_COMMON_ENGINE_HPP
