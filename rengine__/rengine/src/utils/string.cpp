#include "string.hpp"

namespace rengine
{
    static const char *STR_TRUE = "true";
    static const char *STR_FALSE = "false";
    static const char CH_FORMAT = '%';

    template<>
    std::string toString<bool>(const bool &value)
    {
        return value ? STR_TRUE : STR_FALSE;
    }

    template<>
    std::string toString<std::string>(const std::string &value)
    {
        return value;
    }

    std::string vformat(const std::string &fmt, const std::vector<std::string> &args)
    {
        if (args.empty())
        {
            return fmt;
        }

        std::stringstream resultBuffer;
        std::stringstream argNumBuffer;
        std::string argNumStr;
        int argNum;
        bool isFormatting = false;

        for (char ch : fmt)
        {
            if (isFormatting)
            {
                if (std::isdigit(ch))
                {
                    argNumBuffer << ch;
                }
                else
                {
                    if (ch != CH_FORMAT)
                    {
                        isFormatting = false;
                    }

                    argNumStr = argNumBuffer.str();
                    if (!argNumStr.empty() && (argNum = std::stoi(argNumStr)) < args.size())
                    {
                        resultBuffer << args[argNum];
                    }
                    else
                    {
                        resultBuffer << CH_FORMAT << argNumBuffer.str();
                    }

                    if (ch != CH_FORMAT)
                    {
                        resultBuffer << ch;
                    }
                }
            }
            else
            {
                if (ch == CH_FORMAT)
                {
                    isFormatting = true;
                    argNumBuffer.str(std::string());
                }
                else
                {
                    resultBuffer << ch;
                }
            }
        }

        if (isFormatting)
        {
            argNumStr = argNumBuffer.str();
            if (!argNumStr.empty() && (argNum = std::stoi(argNumStr)) < args.size())
            {
                resultBuffer << args[argNum];
            }
            else
            {
                resultBuffer << CH_FORMAT << argNumBuffer.str();
            }
        }

        return resultBuffer.str();
    }
}