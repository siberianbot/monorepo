#include "InputTypes.hpp"

#include <regex>
#include <sstream>

#include "InputCodes.hpp"
#include "InputNames.hpp"
#include "../../Common/Log.hpp"
#include "../../Utils/String.hpp"

/// Generates switch label which writes some input in string stream.
/// \param ss String stream.
/// \param caseLabel Case label.
/// \param ssInput String stream input.
#define SWITCH_CASE_GENERATOR(ss, caseLabel, ssInput) \
    case caseLabel:         \
        ss << ssInput;      \
        break;

/// Generates compare of string and returns result code.
/// \param str Input string.
/// \param compareWithStr String to compare with.
/// \param resultCode Result input code.
#define INPUT_STR_CASE_GENERATOR(str, compareWithStr, resultCode) \
    if (str == compareWithStr)  \
    {                           \
        return resultCode;      \
    }

namespace rengine
{
    inline static void applyModifiersCode(const InputModifier &mods, std::stringstream &ss)
    {
        if ((mods & InputModifier::Ctrl) != InputModifier::None)
        {
            ss << RENGINE_INPUT_CODE_MOD_CONTROL;
        }

        if ((mods & InputModifier::Alt) != InputModifier::None)
        {
            ss << RENGINE_INPUT_CODE_MOD_ALT;
        }

        if ((mods & InputModifier::Shift) != InputModifier::None)
        {
            ss << RENGINE_INPUT_CODE_MOD_SHIFT;
        }

        if ((mods & InputModifier::Super) != InputModifier::None)
        {
            ss << RENGINE_INPUT_CODE_MOD_SUPER;
        }
    }

    inline static void applyModifiersName(const InputModifier &mods, std::stringstream &ss)
    {
        if ((mods & InputModifier::Ctrl) != InputModifier::None)
        {
            ss << RENGINE_INPUT_NAME_MOD_CONTROL;
        }

        if ((mods & InputModifier::Alt) != InputModifier::None)
        {
            ss << RENGINE_INPUT_NAME_MOD_ALT;
        }

        if ((mods & InputModifier::Shift) != InputModifier::None)
        {
            ss << RENGINE_INPUT_NAME_MOD_SHIFT;
        }

        if ((mods & InputModifier::Super) != InputModifier::None)
        {
            ss << RENGINE_INPUT_NAME_MOD_SUPER;
        }
    }

    // TODO: rename to exclude tautology
    inline static void applyCodeCode(const InputCode &code, std::stringstream &ss)
    {
        switch (code)
        {
            // ALPHABET
            SWITCH_CASE_GENERATOR(ss, InputCode::A, RENGINE_INPUT_CODE_KEY_A)
            SWITCH_CASE_GENERATOR(ss, InputCode::B, RENGINE_INPUT_CODE_KEY_B)
            SWITCH_CASE_GENERATOR(ss, InputCode::C, RENGINE_INPUT_CODE_KEY_C)
            SWITCH_CASE_GENERATOR(ss, InputCode::D, RENGINE_INPUT_CODE_KEY_D)
            SWITCH_CASE_GENERATOR(ss, InputCode::E, RENGINE_INPUT_CODE_KEY_E)
            SWITCH_CASE_GENERATOR(ss, InputCode::F, RENGINE_INPUT_CODE_KEY_F)
            SWITCH_CASE_GENERATOR(ss, InputCode::G, RENGINE_INPUT_CODE_KEY_G)
            SWITCH_CASE_GENERATOR(ss, InputCode::H, RENGINE_INPUT_CODE_KEY_H)
            SWITCH_CASE_GENERATOR(ss, InputCode::I, RENGINE_INPUT_CODE_KEY_I)
            SWITCH_CASE_GENERATOR(ss, InputCode::J, RENGINE_INPUT_CODE_KEY_J)
            SWITCH_CASE_GENERATOR(ss, InputCode::K, RENGINE_INPUT_CODE_KEY_K)
            SWITCH_CASE_GENERATOR(ss, InputCode::L, RENGINE_INPUT_CODE_KEY_L)
            SWITCH_CASE_GENERATOR(ss, InputCode::M, RENGINE_INPUT_CODE_KEY_M)
            SWITCH_CASE_GENERATOR(ss, InputCode::N, RENGINE_INPUT_CODE_KEY_N)
            SWITCH_CASE_GENERATOR(ss, InputCode::O, RENGINE_INPUT_CODE_KEY_O)
            SWITCH_CASE_GENERATOR(ss, InputCode::P, RENGINE_INPUT_CODE_KEY_P)
            SWITCH_CASE_GENERATOR(ss, InputCode::Q, RENGINE_INPUT_CODE_KEY_Q)
            SWITCH_CASE_GENERATOR(ss, InputCode::R, RENGINE_INPUT_CODE_KEY_R)
            SWITCH_CASE_GENERATOR(ss, InputCode::S, RENGINE_INPUT_CODE_KEY_S)
            SWITCH_CASE_GENERATOR(ss, InputCode::T, RENGINE_INPUT_CODE_KEY_T)
            SWITCH_CASE_GENERATOR(ss, InputCode::U, RENGINE_INPUT_CODE_KEY_U)
            SWITCH_CASE_GENERATOR(ss, InputCode::V, RENGINE_INPUT_CODE_KEY_V)
            SWITCH_CASE_GENERATOR(ss, InputCode::W, RENGINE_INPUT_CODE_KEY_W)
            SWITCH_CASE_GENERATOR(ss, InputCode::X, RENGINE_INPUT_CODE_KEY_X)
            SWITCH_CASE_GENERATOR(ss, InputCode::Y, RENGINE_INPUT_CODE_KEY_Y)
            SWITCH_CASE_GENERATOR(ss, InputCode::Z, RENGINE_INPUT_CODE_KEY_Z)
            // DIGITS
            SWITCH_CASE_GENERATOR(ss, InputCode::_0, RENGINE_INPUT_CODE_KEY_0)
            SWITCH_CASE_GENERATOR(ss, InputCode::_1, RENGINE_INPUT_CODE_KEY_1)
            SWITCH_CASE_GENERATOR(ss, InputCode::_2, RENGINE_INPUT_CODE_KEY_2)
            SWITCH_CASE_GENERATOR(ss, InputCode::_3, RENGINE_INPUT_CODE_KEY_3)
            SWITCH_CASE_GENERATOR(ss, InputCode::_4, RENGINE_INPUT_CODE_KEY_4)
            SWITCH_CASE_GENERATOR(ss, InputCode::_5, RENGINE_INPUT_CODE_KEY_5)
            SWITCH_CASE_GENERATOR(ss, InputCode::_6, RENGINE_INPUT_CODE_KEY_6)
            SWITCH_CASE_GENERATOR(ss, InputCode::_7, RENGINE_INPUT_CODE_KEY_7)
            SWITCH_CASE_GENERATOR(ss, InputCode::_8, RENGINE_INPUT_CODE_KEY_8)
            SWITCH_CASE_GENERATOR(ss, InputCode::_9, RENGINE_INPUT_CODE_KEY_9)
            // SYMBOLS
            SWITCH_CASE_GENERATOR(ss, InputCode::GraveAccent, RENGINE_INPUT_CODE_KEY_GRAVE_ACCENT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Minus, RENGINE_INPUT_CODE_KEY_MINUS)
            SWITCH_CASE_GENERATOR(ss, InputCode::Equal, RENGINE_INPUT_CODE_KEY_EQUAL)
            SWITCH_CASE_GENERATOR(ss, InputCode::LeftBracket, RENGINE_INPUT_CODE_KEY_LEFT_BRACKET)
            SWITCH_CASE_GENERATOR(ss, InputCode::RightBracket, RENGINE_INPUT_CODE_KEY_RIGHT_BRACKET)
            SWITCH_CASE_GENERATOR(ss, InputCode::Backslash, RENGINE_INPUT_CODE_KEY_BACKSLASH)
            SWITCH_CASE_GENERATOR(ss, InputCode::Semicolon, RENGINE_INPUT_CODE_KEY_SEMICOLON)
            SWITCH_CASE_GENERATOR(ss, InputCode::Apostrophe, RENGINE_INPUT_CODE_KEY_APOSTROPHE)
            SWITCH_CASE_GENERATOR(ss, InputCode::Comma, RENGINE_INPUT_CODE_KEY_COMMA)
            SWITCH_CASE_GENERATOR(ss, InputCode::Period, RENGINE_INPUT_CODE_KEY_PERIOD)
            SWITCH_CASE_GENERATOR(ss, InputCode::Slash, RENGINE_INPUT_CODE_KEY_SLASH)
            // FUNCTIONAL KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::F1, RENGINE_INPUT_CODE_KEY_F1)
            SWITCH_CASE_GENERATOR(ss, InputCode::F2, RENGINE_INPUT_CODE_KEY_F2)
            SWITCH_CASE_GENERATOR(ss, InputCode::F3, RENGINE_INPUT_CODE_KEY_F3)
            SWITCH_CASE_GENERATOR(ss, InputCode::F4, RENGINE_INPUT_CODE_KEY_F4)
            SWITCH_CASE_GENERATOR(ss, InputCode::F5, RENGINE_INPUT_CODE_KEY_F5)
            SWITCH_CASE_GENERATOR(ss, InputCode::F6, RENGINE_INPUT_CODE_KEY_F6)
            SWITCH_CASE_GENERATOR(ss, InputCode::F7, RENGINE_INPUT_CODE_KEY_F7)
            SWITCH_CASE_GENERATOR(ss, InputCode::F8, RENGINE_INPUT_CODE_KEY_F8)
            SWITCH_CASE_GENERATOR(ss, InputCode::F9, RENGINE_INPUT_CODE_KEY_F9)
            SWITCH_CASE_GENERATOR(ss, InputCode::F10, RENGINE_INPUT_CODE_KEY_F10)
            SWITCH_CASE_GENERATOR(ss, InputCode::F11, RENGINE_INPUT_CODE_KEY_F11)
            SWITCH_CASE_GENERATOR(ss, InputCode::F12, RENGINE_INPUT_CODE_KEY_F12)
            // CONTROL KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::Escape, RENGINE_INPUT_CODE_KEY_ESCAPE)
            SWITCH_CASE_GENERATOR(ss, InputCode::PrintScreen, RENGINE_INPUT_CODE_KEY_PRINTSCREEN)
            SWITCH_CASE_GENERATOR(ss, InputCode::ScrollLock, RENGINE_INPUT_CODE_KEY_SCROLLLOCK)
            SWITCH_CASE_GENERATOR(ss, InputCode::PauseBreak, RENGINE_INPUT_CODE_KEY_PAUSEBREAK)
            SWITCH_CASE_GENERATOR(ss, InputCode::LeftControl, RENGINE_INPUT_CODE_KEY_LEFT_CTRL)
            SWITCH_CASE_GENERATOR(ss, InputCode::RightControl, RENGINE_INPUT_CODE_KEY_RIGHT_CTRL)
            SWITCH_CASE_GENERATOR(ss, InputCode::LeftAlt, RENGINE_INPUT_CODE_KEY_LEFT_ALT)
            SWITCH_CASE_GENERATOR(ss, InputCode::RightAlt, RENGINE_INPUT_CODE_KEY_RIGHT_ALT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Super, RENGINE_INPUT_CODE_KEY_SUPER)
            SWITCH_CASE_GENERATOR(ss, InputCode::Menu, RENGINE_INPUT_CODE_KEY_MENU)
            // TYPING KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::Tab, RENGINE_INPUT_CODE_KEY_TAB)
            SWITCH_CASE_GENERATOR(ss, InputCode::CapsLock, RENGINE_INPUT_CODE_KEY_CAPSLOCK)
            SWITCH_CASE_GENERATOR(ss, InputCode::LeftShift, RENGINE_INPUT_CODE_KEY_LEFT_SHIFT)
            SWITCH_CASE_GENERATOR(ss, InputCode::RightShift, RENGINE_INPUT_CODE_KEY_RIGHT_SHIFT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Backspace, RENGINE_INPUT_CODE_KEY_BACKSPACE)
            SWITCH_CASE_GENERATOR(ss, InputCode::Enter, RENGINE_INPUT_CODE_KEY_ENTER)
            SWITCH_CASE_GENERATOR(ss, InputCode::Space, RENGINE_INPUT_CODE_KEY_SPACE)
            // NAVIGATION KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::Insert, RENGINE_INPUT_CODE_KEY_INSERT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Home, RENGINE_INPUT_CODE_KEY_HOME)
            SWITCH_CASE_GENERATOR(ss, InputCode::PageUp, RENGINE_INPUT_CODE_KEY_PAGEUP)
            SWITCH_CASE_GENERATOR(ss, InputCode::Delete, RENGINE_INPUT_CODE_KEY_DELETE)
            SWITCH_CASE_GENERATOR(ss, InputCode::End, RENGINE_INPUT_CODE_KEY_END)
            SWITCH_CASE_GENERATOR(ss, InputCode::PageDown, RENGINE_INPUT_CODE_KEY_PAGEDOWN)
            SWITCH_CASE_GENERATOR(ss, InputCode::Up, RENGINE_INPUT_CODE_KEY_UP)
            SWITCH_CASE_GENERATOR(ss, InputCode::Down, RENGINE_INPUT_CODE_KEY_DOWN)
            SWITCH_CASE_GENERATOR(ss, InputCode::Left, RENGINE_INPUT_CODE_KEY_LEFT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Right, RENGINE_INPUT_CODE_KEY_RIGHT)
            // NUMERIC KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::NumLock, RENGINE_INPUT_CODE_KEY_NUMLOCK)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num0, RENGINE_INPUT_CODE_KEY_NUMPAD_0)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num1, RENGINE_INPUT_CODE_KEY_NUMPAD_1)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num2, RENGINE_INPUT_CODE_KEY_NUMPAD_2)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num3, RENGINE_INPUT_CODE_KEY_NUMPAD_3)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num4, RENGINE_INPUT_CODE_KEY_NUMPAD_4)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num5, RENGINE_INPUT_CODE_KEY_NUMPAD_5)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num6, RENGINE_INPUT_CODE_KEY_NUMPAD_6)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num7, RENGINE_INPUT_CODE_KEY_NUMPAD_7)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num8, RENGINE_INPUT_CODE_KEY_NUMPAD_8)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num9, RENGINE_INPUT_CODE_KEY_NUMPAD_9)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumDecimal, RENGINE_INPUT_CODE_KEY_NUMPAD_DECIMAL)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumEnter, RENGINE_INPUT_CODE_KEY_NUMPAD_ENTER)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumPlus, RENGINE_INPUT_CODE_KEY_NUMPAD_PLUS)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumMinus, RENGINE_INPUT_CODE_KEY_NUMPAD_MINUS)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumAsterisk, RENGINE_INPUT_CODE_KEY_NUMPAD_ASTERISK)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumSlash, RENGINE_INPUT_CODE_KEY_NUMPAD_SLASH)

            case InputCode::Unknown:
            default:
                break;
        }
    }

    inline static void applyCodeName(const InputCode &code, std::stringstream &ss)
    {
        switch (code)
        {
            // ALPHABET
            SWITCH_CASE_GENERATOR(ss, InputCode::A, RENGINE_INPUT_NAME_KEY_A)
            SWITCH_CASE_GENERATOR(ss, InputCode::B, RENGINE_INPUT_NAME_KEY_B)
            SWITCH_CASE_GENERATOR(ss, InputCode::C, RENGINE_INPUT_NAME_KEY_C)
            SWITCH_CASE_GENERATOR(ss, InputCode::D, RENGINE_INPUT_NAME_KEY_D)
            SWITCH_CASE_GENERATOR(ss, InputCode::E, RENGINE_INPUT_NAME_KEY_E)
            SWITCH_CASE_GENERATOR(ss, InputCode::F, RENGINE_INPUT_NAME_KEY_F)
            SWITCH_CASE_GENERATOR(ss, InputCode::G, RENGINE_INPUT_NAME_KEY_G)
            SWITCH_CASE_GENERATOR(ss, InputCode::H, RENGINE_INPUT_NAME_KEY_H)
            SWITCH_CASE_GENERATOR(ss, InputCode::I, RENGINE_INPUT_NAME_KEY_I)
            SWITCH_CASE_GENERATOR(ss, InputCode::J, RENGINE_INPUT_NAME_KEY_J)
            SWITCH_CASE_GENERATOR(ss, InputCode::K, RENGINE_INPUT_NAME_KEY_K)
            SWITCH_CASE_GENERATOR(ss, InputCode::L, RENGINE_INPUT_NAME_KEY_L)
            SWITCH_CASE_GENERATOR(ss, InputCode::M, RENGINE_INPUT_NAME_KEY_M)
            SWITCH_CASE_GENERATOR(ss, InputCode::N, RENGINE_INPUT_NAME_KEY_N)
            SWITCH_CASE_GENERATOR(ss, InputCode::O, RENGINE_INPUT_NAME_KEY_O)
            SWITCH_CASE_GENERATOR(ss, InputCode::P, RENGINE_INPUT_NAME_KEY_P)
            SWITCH_CASE_GENERATOR(ss, InputCode::Q, RENGINE_INPUT_NAME_KEY_Q)
            SWITCH_CASE_GENERATOR(ss, InputCode::R, RENGINE_INPUT_NAME_KEY_R)
            SWITCH_CASE_GENERATOR(ss, InputCode::S, RENGINE_INPUT_NAME_KEY_S)
            SWITCH_CASE_GENERATOR(ss, InputCode::T, RENGINE_INPUT_NAME_KEY_T)
            SWITCH_CASE_GENERATOR(ss, InputCode::U, RENGINE_INPUT_NAME_KEY_U)
            SWITCH_CASE_GENERATOR(ss, InputCode::V, RENGINE_INPUT_NAME_KEY_V)
            SWITCH_CASE_GENERATOR(ss, InputCode::W, RENGINE_INPUT_NAME_KEY_W)
            SWITCH_CASE_GENERATOR(ss, InputCode::X, RENGINE_INPUT_NAME_KEY_X)
            SWITCH_CASE_GENERATOR(ss, InputCode::Y, RENGINE_INPUT_NAME_KEY_Y)
            SWITCH_CASE_GENERATOR(ss, InputCode::Z, RENGINE_INPUT_NAME_KEY_Z)
            // DIGITS
            SWITCH_CASE_GENERATOR(ss, InputCode::_0, RENGINE_INPUT_NAME_KEY_0)
            SWITCH_CASE_GENERATOR(ss, InputCode::_1, RENGINE_INPUT_NAME_KEY_1)
            SWITCH_CASE_GENERATOR(ss, InputCode::_2, RENGINE_INPUT_NAME_KEY_2)
            SWITCH_CASE_GENERATOR(ss, InputCode::_3, RENGINE_INPUT_NAME_KEY_3)
            SWITCH_CASE_GENERATOR(ss, InputCode::_4, RENGINE_INPUT_NAME_KEY_4)
            SWITCH_CASE_GENERATOR(ss, InputCode::_5, RENGINE_INPUT_NAME_KEY_5)
            SWITCH_CASE_GENERATOR(ss, InputCode::_6, RENGINE_INPUT_NAME_KEY_6)
            SWITCH_CASE_GENERATOR(ss, InputCode::_7, RENGINE_INPUT_NAME_KEY_7)
            SWITCH_CASE_GENERATOR(ss, InputCode::_8, RENGINE_INPUT_NAME_KEY_8)
            SWITCH_CASE_GENERATOR(ss, InputCode::_9, RENGINE_INPUT_NAME_KEY_9)
            // SYMBOLS
            SWITCH_CASE_GENERATOR(ss, InputCode::GraveAccent, RENGINE_INPUT_NAME_KEY_GRAVE_ACCENT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Minus, RENGINE_INPUT_NAME_KEY_MINUS)
            SWITCH_CASE_GENERATOR(ss, InputCode::Equal, RENGINE_INPUT_NAME_KEY_EQUAL)
            SWITCH_CASE_GENERATOR(ss, InputCode::LeftBracket, RENGINE_INPUT_NAME_KEY_LEFT_BRACKET)
            SWITCH_CASE_GENERATOR(ss, InputCode::RightBracket, RENGINE_INPUT_NAME_KEY_RIGHT_BRACKET)
            SWITCH_CASE_GENERATOR(ss, InputCode::Backslash, RENGINE_INPUT_NAME_KEY_BACKSLASH)
            SWITCH_CASE_GENERATOR(ss, InputCode::Semicolon, RENGINE_INPUT_NAME_KEY_SEMICOLON)
            SWITCH_CASE_GENERATOR(ss, InputCode::Apostrophe, RENGINE_INPUT_NAME_KEY_APOSTROPHE)
            SWITCH_CASE_GENERATOR(ss, InputCode::Comma, RENGINE_INPUT_NAME_KEY_COMMA)
            SWITCH_CASE_GENERATOR(ss, InputCode::Period, RENGINE_INPUT_NAME_KEY_PERIOD)
            SWITCH_CASE_GENERATOR(ss, InputCode::Slash, RENGINE_INPUT_NAME_KEY_SLASH)
            // FUNCTIONAL KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::F1, RENGINE_INPUT_NAME_KEY_F1)
            SWITCH_CASE_GENERATOR(ss, InputCode::F2, RENGINE_INPUT_NAME_KEY_F2)
            SWITCH_CASE_GENERATOR(ss, InputCode::F3, RENGINE_INPUT_NAME_KEY_F3)
            SWITCH_CASE_GENERATOR(ss, InputCode::F4, RENGINE_INPUT_NAME_KEY_F4)
            SWITCH_CASE_GENERATOR(ss, InputCode::F5, RENGINE_INPUT_NAME_KEY_F5)
            SWITCH_CASE_GENERATOR(ss, InputCode::F6, RENGINE_INPUT_NAME_KEY_F6)
            SWITCH_CASE_GENERATOR(ss, InputCode::F7, RENGINE_INPUT_NAME_KEY_F7)
            SWITCH_CASE_GENERATOR(ss, InputCode::F8, RENGINE_INPUT_NAME_KEY_F8)
            SWITCH_CASE_GENERATOR(ss, InputCode::F9, RENGINE_INPUT_NAME_KEY_F9)
            SWITCH_CASE_GENERATOR(ss, InputCode::F10, RENGINE_INPUT_NAME_KEY_F10)
            SWITCH_CASE_GENERATOR(ss, InputCode::F11, RENGINE_INPUT_NAME_KEY_F11)
            SWITCH_CASE_GENERATOR(ss, InputCode::F12, RENGINE_INPUT_NAME_KEY_F12)
            // CONTROL KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::Escape, RENGINE_INPUT_NAME_KEY_ESCAPE)
            SWITCH_CASE_GENERATOR(ss, InputCode::PrintScreen, RENGINE_INPUT_NAME_KEY_PRINTSCREEN)
            SWITCH_CASE_GENERATOR(ss, InputCode::ScrollLock, RENGINE_INPUT_NAME_KEY_SCROLLLOCK)
            SWITCH_CASE_GENERATOR(ss, InputCode::PauseBreak, RENGINE_INPUT_NAME_KEY_PAUSEBREAK)
            SWITCH_CASE_GENERATOR(ss, InputCode::LeftControl, RENGINE_INPUT_NAME_KEY_LEFT_CTRL)
            SWITCH_CASE_GENERATOR(ss, InputCode::RightControl, RENGINE_INPUT_NAME_KEY_RIGHT_CTRL)
            SWITCH_CASE_GENERATOR(ss, InputCode::LeftAlt, RENGINE_INPUT_NAME_KEY_LEFT_ALT)
            SWITCH_CASE_GENERATOR(ss, InputCode::RightAlt, RENGINE_INPUT_NAME_KEY_RIGHT_ALT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Super, RENGINE_INPUT_NAME_KEY_SUPER)
            SWITCH_CASE_GENERATOR(ss, InputCode::Menu, RENGINE_INPUT_NAME_KEY_MENU)
            // TYPING KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::Tab, RENGINE_INPUT_NAME_KEY_TAB)
            SWITCH_CASE_GENERATOR(ss, InputCode::CapsLock, RENGINE_INPUT_NAME_KEY_CAPSLOCK)
            SWITCH_CASE_GENERATOR(ss, InputCode::LeftShift, RENGINE_INPUT_NAME_KEY_LEFT_SHIFT)
            SWITCH_CASE_GENERATOR(ss, InputCode::RightShift, RENGINE_INPUT_NAME_KEY_RIGHT_SHIFT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Backspace, RENGINE_INPUT_NAME_KEY_BACKSPACE)
            SWITCH_CASE_GENERATOR(ss, InputCode::Enter, RENGINE_INPUT_NAME_KEY_ENTER)
            SWITCH_CASE_GENERATOR(ss, InputCode::Space, RENGINE_INPUT_NAME_KEY_SPACE)
            // NAVIGATION KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::Insert, RENGINE_INPUT_NAME_KEY_INSERT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Home, RENGINE_INPUT_NAME_KEY_HOME)
            SWITCH_CASE_GENERATOR(ss, InputCode::PageUp, RENGINE_INPUT_NAME_KEY_PAGEUP)
            SWITCH_CASE_GENERATOR(ss, InputCode::Delete, RENGINE_INPUT_NAME_KEY_DELETE)
            SWITCH_CASE_GENERATOR(ss, InputCode::End, RENGINE_INPUT_NAME_KEY_END)
            SWITCH_CASE_GENERATOR(ss, InputCode::PageDown, RENGINE_INPUT_NAME_KEY_PAGEDOWN)
            SWITCH_CASE_GENERATOR(ss, InputCode::Up, RENGINE_INPUT_NAME_KEY_UP)
            SWITCH_CASE_GENERATOR(ss, InputCode::Down, RENGINE_INPUT_NAME_KEY_DOWN)
            SWITCH_CASE_GENERATOR(ss, InputCode::Left, RENGINE_INPUT_NAME_KEY_LEFT)
            SWITCH_CASE_GENERATOR(ss, InputCode::Right, RENGINE_INPUT_NAME_KEY_RIGHT)
            // NUMERIC KEYS
            SWITCH_CASE_GENERATOR(ss, InputCode::NumLock, RENGINE_INPUT_NAME_KEY_NUMLOCK)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num0, RENGINE_INPUT_NAME_KEY_NUMPAD_0)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num1, RENGINE_INPUT_NAME_KEY_NUMPAD_1)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num2, RENGINE_INPUT_NAME_KEY_NUMPAD_2)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num3, RENGINE_INPUT_NAME_KEY_NUMPAD_3)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num4, RENGINE_INPUT_NAME_KEY_NUMPAD_4)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num5, RENGINE_INPUT_NAME_KEY_NUMPAD_5)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num6, RENGINE_INPUT_NAME_KEY_NUMPAD_6)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num7, RENGINE_INPUT_NAME_KEY_NUMPAD_7)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num8, RENGINE_INPUT_NAME_KEY_NUMPAD_8)
            SWITCH_CASE_GENERATOR(ss, InputCode::Num9, RENGINE_INPUT_NAME_KEY_NUMPAD_9)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumDecimal, RENGINE_INPUT_NAME_KEY_NUMPAD_DECIMAL)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumEnter, RENGINE_INPUT_NAME_KEY_NUMPAD_ENTER)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumPlus, RENGINE_INPUT_NAME_KEY_NUMPAD_PLUS)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumMinus, RENGINE_INPUT_NAME_KEY_NUMPAD_MINUS)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumAsterisk, RENGINE_INPUT_NAME_KEY_NUMPAD_ASTERISK)
            SWITCH_CASE_GENERATOR(ss, InputCode::NumSlash, RENGINE_INPUT_NAME_KEY_NUMPAD_SLASH)

            case InputCode::Unknown:
            default:
                ss << RENGINE_INPUT_NAME_KEY_UNKNOWN;
                break;
        }
    }

    inline static InputModifier extractModifier(std::string &accordCode)
    {
        static std::string regexStr = format("%0|%1|%2|%3",
                                             RENGINE_INPUT_CODE_MOD_CONTROL,
                                             RENGINE_INPUT_CODE_MOD_ALT,
                                             RENGINE_INPUT_CODE_MOD_SHIFT,
                                             RENGINE_INPUT_CODE_MOD_SUPER);
        static std::regex regex(regexStr, std::regex::optimize | std::regex::icase);

        InputModifier mods = InputModifier::None;
        std::smatch matches;

        // TODO: remove hardcoded offsets
        while (std::regex_search(accordCode, matches, regex))
        {
            size_t offset;
            std::string matchStr = matches[0].str();
            InputModifier matchedMod = InputModifier::None;

            if (matchStr == RENGINE_INPUT_CODE_MOD_CONTROL)
            {
                matchedMod = InputModifier::Ctrl;
                offset = 5;
            }
            else if (matchStr == RENGINE_INPUT_CODE_MOD_ALT)
            {
                matchedMod = InputModifier::Alt;
                offset = 4;
            }
            else if (matchStr == RENGINE_INPUT_CODE_MOD_SHIFT)
            {
                matchedMod = InputModifier::Shift;
                offset = 6;
            }
            else if (matchStr == RENGINE_INPUT_CODE_MOD_SUPER)
            {
                matchedMod = InputModifier::Super;
                offset = 6;
            }

            if (matchedMod != InputModifier::None)
            {
                mods |= matchedMod;
                accordCode = accordCode.substr(offset);
            }
            else
            {
                Log::instance()->warning("Input System", "Unknown modifier code: %0", matchStr);
            }
        }

        return mods;
    }

    inline static InputCode extractCode(std::string &accordCode)
    {
        // ALPHABET
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_A, InputCode::A)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_B, InputCode::B)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_C, InputCode::C)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_D, InputCode::D)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_E, InputCode::E)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F, InputCode::F)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_G, InputCode::G)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_H, InputCode::H)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_I, InputCode::I)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_J, InputCode::J)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_K, InputCode::K)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_L, InputCode::L)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_M, InputCode::M)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_N, InputCode::N)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_O, InputCode::O)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_P, InputCode::P)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_Q, InputCode::Q)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_R, InputCode::R)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_S, InputCode::S)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_T, InputCode::T)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_U, InputCode::U)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_V, InputCode::V)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_W, InputCode::W)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_X, InputCode::X)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_Y, InputCode::Y)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_Z, InputCode::Z)
        // DIGITS
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_0, InputCode::_0)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_1, InputCode::_1)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_2, InputCode::_2)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_3, InputCode::_3)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_4, InputCode::_4)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_5, InputCode::_5)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_6, InputCode::_6)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_7, InputCode::_7)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_8, InputCode::_8)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_9, InputCode::_9)
        // SYMBOLS
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_GRAVE_ACCENT, InputCode::GraveAccent)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_MINUS, InputCode::Minus)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_EQUAL, InputCode::Equal)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_LEFT_BRACKET, InputCode::LeftBracket)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_RIGHT_BRACKET, InputCode::RightBracket)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_BACKSLASH, InputCode::Backslash)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_SEMICOLON, InputCode::Semicolon)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_APOSTROPHE, InputCode::Apostrophe)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_COMMA, InputCode::Comma)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_PERIOD, InputCode::Period)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_SLASH, InputCode::Slash)
        // FUNCTIONAL KEYS
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F1, InputCode::F1)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F2, InputCode::F2)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F3, InputCode::F3)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F4, InputCode::F4)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F5, InputCode::F5)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F6, InputCode::F6)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F7, InputCode::F7)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F8, InputCode::F8)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F9, InputCode::F9)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F10, InputCode::F10)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F11, InputCode::F11)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_F12, InputCode::F12)
        // CONTROL KEYS
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_ESCAPE, InputCode::Escape)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_PRINTSCREEN, InputCode::PrintScreen)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_SCROLLLOCK, InputCode::ScrollLock)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_PAUSEBREAK, InputCode::PauseBreak)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_LEFT_CTRL, InputCode::LeftControl)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_RIGHT_CTRL, InputCode::RightControl)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_LEFT_ALT, InputCode::LeftAlt)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_RIGHT_ALT, InputCode::RightAlt)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_SUPER, InputCode::Super)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_MENU, InputCode::Menu)
        // TYPING KEYS
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_TAB, InputCode::Tab)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_CAPSLOCK, InputCode::CapsLock)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_LEFT_SHIFT, InputCode::LeftShift)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_RIGHT_SHIFT, InputCode::RightShift)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_BACKSPACE, InputCode::Backspace)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_ENTER, InputCode::Enter)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_SPACE, InputCode::Space)
        // NAVIGATION KEYS
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_INSERT, InputCode::Insert)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_HOME, InputCode::Home)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_PAGEUP, InputCode::PageUp)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_DELETE, InputCode::Delete)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_END, InputCode::End)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_PAGEDOWN, InputCode::PageDown)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_UP, InputCode::Up)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_DOWN, InputCode::Down)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_LEFT, InputCode::Left)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_RIGHT, InputCode::Right)
        // NUMERIC KEYS
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMLOCK, InputCode::NumLock)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_0, InputCode::Num0)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_1, InputCode::Num1)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_2, InputCode::Num2)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_3, InputCode::Num3)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_4, InputCode::Num4)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_5, InputCode::Num5)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_6, InputCode::Num6)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_7, InputCode::Num7)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_8, InputCode::Num8)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_9, InputCode::Num9)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_DECIMAL, InputCode::NumDecimal)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_ENTER, InputCode::NumEnter)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_PLUS, InputCode::NumPlus)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_MINUS, InputCode::NumMinus)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_ASTERISK, InputCode::NumAsterisk)
        INPUT_STR_CASE_GENERATOR(accordCode, RENGINE_INPUT_CODE_KEY_NUMPAD_SLASH, InputCode::NumSlash)

        return InputCode::Unknown;
    }

    std::string InputAccord::accordCode() const
    {
        std::stringstream ss;

        applyModifiersCode(mods, ss);
        applyCodeCode(code, ss);

        return ss.str();
    }

    std::string InputAccord::accordName() const
    {
        std::stringstream ss;

        applyModifiersName(mods, ss);
        applyCodeName(code, ss);

        return ss.str();
    }

    input_accord_t fromAccordCode(const std::string &accordCode)
    {
        std::string uppercaseCode = toUpper(accordCode);

        input_accord_t accord;
        accord.mods = extractModifier(uppercaseCode);
        accord.code = extractCode(uppercaseCode);

        return accord;
    }

    InputModifier operator|(const InputModifier &lhs, const InputModifier &rhs)
    {
        return static_cast<InputModifier>(static_cast<uint8_t>(lhs) | static_cast<uint8_t>(rhs));
    }

    InputModifier &operator|=(InputModifier &lhs, const InputModifier &rhs)
    {
        lhs = lhs | rhs;

        return lhs;
    }

    InputModifier operator&(const InputModifier &lhs, const InputModifier &rhs)
    {
        return static_cast<InputModifier>(static_cast<uint8_t>(lhs) & static_cast<uint8_t>(rhs));
    }
}
