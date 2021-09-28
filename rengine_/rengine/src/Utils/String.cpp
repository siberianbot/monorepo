#include "String.hpp"

#include <algorithm>

namespace rengine
{
    template<>
    std::string toString<bool>(const bool &value)
    {
        return value ? "true" : "false";
    }

    template<>
    std::string toString<std::string>(const std::string &value)
    {
        return value;
    }

    std::string vformat(const std::string &fmt, const std::vector<std::string> &args)
    {
        static const char formatChar = '%';

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
                    if (ch != formatChar)
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
                        resultBuffer << formatChar << argNumBuffer.str();
                    }

                    if (ch != formatChar)
                    {
                        resultBuffer << ch;
                    }
                }
            }
            else
            {
                if (ch == formatChar)
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
                resultBuffer << formatChar << argNumBuffer.str();
            }
        }

        return resultBuffer.str();
    }

    std::string toUpper(const std::string &str)
    {
        std::string uppercase = str;

        std::transform(uppercase.begin(), uppercase.end(), uppercase.begin(),
                       [](char ch) { return std::toupper(ch); });

        return uppercase;
    }
}