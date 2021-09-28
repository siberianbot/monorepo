#include "StringFormat.hpp"

#include "TemplateUtils.hpp"

namespace lucidreams
{
    static const char FORMAT_CHAR = '%';
    static const wchar_t FORMAT_WIDE_CHAR = L'%';

    template<typename TStrChar, typename TValue>
    std::basic_string<TStrChar> toString(const TValue &value) {
        std::basic_stringstream<TStrChar> ss;
        ss << value;
        return ss.str();
    }

    template<typename TStrChar, typename TValue>
    std::basic_string<TStrChar> toHexString(const TValue &value) {
        std::basic_stringstream<TStrChar> ss;
        ss << std::hex << value;
        return ss.str();
    }

    template<typename TStrChar>
    std::basic_string<TStrChar> vformat(const std::basic_string<TStrChar> &fmt, const std::vector<std::basic_string<TStrChar>> &args) {
        if (args.empty())
        {
            return fmt;
        }

        std::basic_stringstream<TStrChar> resultBuffer;
        std::basic_stringstream<TStrChar> argNumBuffer;
        std::basic_string<TStrChar> argNumStr;
        int argNum;
        bool isFormatting = false;
        TStrChar formatChar = isWideCharType<TStrChar>::VALUE ? FORMAT_WIDE_CHAR : FORMAT_CHAR;

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
                    argNumBuffer.str(std::basic_string<TStrChar>());
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

    template<typename TStrChar, typename Arg, typename... Args>
    std::basic_string<TStrChar> vformat(const std::basic_string<TStrChar> &fmt, std::vector<std::basic_string<TStrChar>> &vargs, Arg &&arg, Args &&... args) {
        vargs.push_back(toString<TStrChar, Arg>(std::forward<Arg>(arg)));
        return vformat(fmt, vargs, std::forward<Args>(args)...);
    }

    template<typename TStrChar, typename Arg, typename... Args>
    std::basic_string<TStrChar> format(const std::basic_string<TStrChar> &fmt, Arg &&arg, Args &&... args) {
        std::vector<std::string> vargs;
        return vformat(fmt, vargs, std::forward<Arg>(arg), std::forward<Args>(args)...);
    }

}