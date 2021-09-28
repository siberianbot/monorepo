#ifndef RENGINE_SRC_ENGINE_INPUT_INPUTTYPES_HPP
#define RENGINE_SRC_ENGINE_INPUT_INPUTTYPES_HPP

#include <functional>
#include <string>

namespace rengine
{
    /// Enumeration of input modifiers (Control, Alt, Shift, etc).
    enum class InputModifier : uint8_t
    {
        None = 0,
        Ctrl = 1,
        Alt = 2,
        Shift = 4,
        Super = 8
    };

    /// Enumeration of input codes for each keyboard key.
    enum class InputCode : uint32_t
    {
        Unknown,
        // ALPHABET
        A, B, C, D, E, F,
        G, H, I, J, K, L,
        M, N, O, P, Q, R,
        S, T, U, V, W, X,
        Y, Z,
        // DIGITS
        _0, _1, _2, _3, _4,
        _5, _6, _7, _8, _9,
        // SYMBOLS
        GraveAccent, Minus, Equal,
        LeftBracket, RightBracket, Backslash,
        Semicolon, Apostrophe,
        Comma, Period, Slash,
        // FUNCTIONAL KEYS
        F1, F2, F3, F4, F5, F6,
        F7, F8, F9, F10, F11, F12,
        // CONTROL KEYS
        Escape,
        PrintScreen, ScrollLock, PauseBreak,
        LeftControl, RightControl,
        LeftAlt, RightAlt,
        Super, Menu,
        // TYPING KEYS
        Tab, CapsLock,
        LeftShift, RightShift,
        Backspace, Enter, Space,
        // NAVIGATION KEYS
        Insert, Home, PageUp,
        Delete, End, PageDown,
        Up, Down, Left, Right,
        // NUMERIC KEYS
        NumLock,
        Num0, Num1, Num2, Num3, Num4,
        Num5, Num6, Num7, Num8, Num9,
        NumDecimal, NumEnter, NumPlus,
        NumMinus, NumAsterisk, NumSlash,
    };

    /// Input accord.
    /// A pair of input code and its modifiers.
    typedef struct InputAccord
    {
        /// Input code.
        InputCode code;
        /// Input modifiers.
        InputModifier mods;

        /// Returns accord code.
        /// \return Accord code.
        [[nodiscard]]
        std::string accordCode() const;

        /// Returns display name of accord.
        /// \return Display name.
        [[nodiscard]]
        std::string accordName() const;
    } input_accord_t;

    /// Enumeration of input states (pressed or not).
    enum class InputState
    {
        NotPressed,
        Pressed
    };

    /// Input definition structure which is used for identify any input accord.
    /// Also, it is used for parsing inputs.
    typedef struct InputDefinition
    {
        /// Identity of input definition. Unique through all definitions.
        std::uint32_t id;
        /// Input accord.
        input_accord_t accord;
    } input_def_t;

    /// Input binding structure which is used for storing any binding callback.
    typedef struct InputBinding
    {
        /// Input definition identity.
        std::uint32_t inputDefId;
        /// Callback function.
        std::function<void()> callback;
    } input_bind_t;

    /// Returns input accord from accord code.
    /// \param accordCode Accord code (like "Ctrl-A" or anything else).
    /// \return Input accord.
    input_accord_t fromAccordCode(const std::string &accordCode);

    /// Logical OR operator for InputModifier.
    /// \param lhs First modifier.
    /// \param rhs Second modifier
    /// \return Logical disjunction of two input modifiers.
    InputModifier operator|(const InputModifier &lhs, const InputModifier &rhs);

    /// Logical OR operator for InputModifier.
    /// \param lhs First modifier.
    /// \param rhs Second modifier
    /// \return Logical disjunction of two input modifiers.
    InputModifier &operator|=(InputModifier &lhs, const InputModifier &rhs);

    /// Logical AND operator for InputModifier.
    /// \param lhs First modifier.
    /// \param rhs Second modifier
    /// \return Logical conjunction of two input modifiers.
    InputModifier operator&(const InputModifier &lhs, const InputModifier &rhs);
}

#endif //RENGINE_SRC_ENGINE_INPUT_INPUTTYPES_HPP
