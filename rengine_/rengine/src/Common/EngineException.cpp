#include "EngineException.hpp"

#include "Log.hpp"

namespace rengine
{
    EngineException::EngineException(const std::string &source, const std::string &msg) : std::exception(msg.c_str())
    {
        Log::instance()->critical(source, msg);
    }
}