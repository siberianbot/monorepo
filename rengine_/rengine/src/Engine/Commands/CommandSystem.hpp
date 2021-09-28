#ifndef RENGINE_SRC_ENGINE_COMMANDS_COMMANDSYSTEM_HPP
#define RENGINE_SRC_ENGINE_COMMANDS_COMMANDSYSTEM_HPP

#include <cstdint>
#include <functional>
#include <map>
#include <string>

#include "../../Common/ISingleton.hpp"

namespace rengine
{
    class CommandSystem : public ISingleton<CommandSystem>
    {
    public:
        void addCommand(const std::string &name, const std::function<void()> &fn);

        void invokeCommand(const std::string &name) const;

    private:
        std::unordered_map<std::string, std::function<void()>> _commands;
    };
}

#endif //RENGINE_SRC_ENGINE_COMMANDS_COMMANDSYSTEM_HPP
