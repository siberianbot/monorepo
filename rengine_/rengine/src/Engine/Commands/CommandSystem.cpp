#include "CommandSystem.hpp"

#include "../../Utils/Assert.hpp"
#include "../../Utils/String.hpp"

namespace rengine
{
    GENERATE_SINGLETON_INSTANCE(CommandSystem);

    void CommandSystem::addCommand(const std::string &name, const std::function<void()> &fn)
    {
        if (!safeAssert(!_commands.contains(name),
                        "Command System", format("command with name \"%0\" already exists.", name)))
        {
            return;
        }

        _commands[name] = fn;
    }

    void CommandSystem::invokeCommand(const std::string &name) const
    {
        if (!safeAssert(_commands.contains(name),
                        "Command System", format("command with name \"%0\" is not exists.", name)))
        {
            return;
        }

        auto asd = _commands[name];
    }
}