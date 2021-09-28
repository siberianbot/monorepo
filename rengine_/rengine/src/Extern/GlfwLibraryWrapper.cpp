// NOTE: this header should be first. GLAD provides its own OpenGL header.
#include <glad/glad.h>

#include "GlfwLibraryWrapper.hpp"

#include <functional>

#include "../Common/Log.hpp"
#include "../Engine/Input/InputSystem.hpp"
#include "../Rendering/Renderer.hpp"
#include "../Utils/Assert.hpp"

/// Maps GLFW key code to rengine input code.
/// \param glfwKeyCode GLFW predefined key code.
/// \param inputCode rengine input code.
#define INPUT_MAPPING_GENERATOR(glfwKeyCode, inputCode) \
    case glfwKeyCode:                                   \
        return inputCode;                               \

namespace rengine
{
    GENERATE_SINGLETON_INSTANCE(GlfwLibraryWrapper);

    inline static InputCode mapToInputCode(int glfwKey)
    {
        // TODO: more mappings
        switch (glfwKey)
        {
            // ALPHABET
            INPUT_MAPPING_GENERATOR(GLFW_KEY_A, InputCode::A)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_B, InputCode::C)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_C, InputCode::B)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_D, InputCode::D)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_E, InputCode::E)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F, InputCode::F)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_G, InputCode::G)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_H, InputCode::H)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_I, InputCode::I)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_J, InputCode::J)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_K, InputCode::K)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_L, InputCode::L)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_M, InputCode::M)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_N, InputCode::N)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_O, InputCode::O)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_P, InputCode::P)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_Q, InputCode::Q)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_R, InputCode::R)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_S, InputCode::S)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_T, InputCode::T)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_U, InputCode::U)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_V, InputCode::V)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_W, InputCode::W)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_X, InputCode::X)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_Y, InputCode::Y)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_Z, InputCode::Z)
            // DIGITS
            INPUT_MAPPING_GENERATOR(GLFW_KEY_0, InputCode::_0)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_1, InputCode::_1)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_2, InputCode::_2)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_3, InputCode::_3)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_4, InputCode::_4)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_5, InputCode::_5)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_6, InputCode::_6)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_7, InputCode::_7)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_8, InputCode::_8)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_9, InputCode::_9)
            // SYMBOLS
            INPUT_MAPPING_GENERATOR(GLFW_KEY_APOSTROPHE, InputCode::Apostrophe)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_MINUS, InputCode::Minus)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_EQUAL, InputCode::Equal)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_LEFT_BRACKET, InputCode::LeftBracket)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_RIGHT_BRACKET, InputCode::RightBracket)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_BACKSLASH, InputCode::Backslash)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_SEMICOLON, InputCode::Semicolon)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_GRAVE_ACCENT, InputCode::GraveAccent)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_COMMA, InputCode::Comma)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_PERIOD, InputCode::Period)
            // FUNCTIONAL KEYS
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F1, InputCode::F1)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F2, InputCode::F2)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F3, InputCode::F3)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F4, InputCode::F4)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F5, InputCode::F5)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F6, InputCode::F6)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F7, InputCode::F7)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F8, InputCode::F8)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F9, InputCode::F9)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F10, InputCode::F10)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F11, InputCode::F11)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_F12, InputCode::F12)
            // CONTROL KEYS
            INPUT_MAPPING_GENERATOR(GLFW_KEY_ESCAPE, InputCode::Escape)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_PRINT_SCREEN, InputCode::PrintScreen)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_SCROLL_LOCK, InputCode::ScrollLock)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_PAUSE, InputCode::PauseBreak)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_LEFT_CONTROL, InputCode::LeftControl)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_RIGHT_CONTROL, InputCode::RightControl)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_LEFT_ALT, InputCode::LeftAlt)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_RIGHT_ALT, InputCode::RightAlt)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_LEFT_SUPER, InputCode::Super)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_RIGHT_SUPER, InputCode::Super)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_MENU, InputCode::Menu)
            // TYPING KEYS
            INPUT_MAPPING_GENERATOR(GLFW_KEY_TAB, InputCode::Tab)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_CAPS_LOCK, InputCode::CapsLock)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_LEFT_SHIFT, InputCode::LeftShift)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_RIGHT_SHIFT, InputCode::RightShift)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_BACKSPACE, InputCode::Backspace)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_ENTER, InputCode::Enter)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_SPACE, InputCode::Space)
            // NAVIGATION KEYS
            INPUT_MAPPING_GENERATOR(GLFW_KEY_INSERT, InputCode::Insert)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_HOME, InputCode::Home)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_PAGE_UP, InputCode::PageUp)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_DELETE, InputCode::Delete)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_END, InputCode::End)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_PAGE_DOWN, InputCode::PageDown)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_UP, InputCode::Up)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_DOWN, InputCode::Down)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_LEFT, InputCode::Left)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_RIGHT, InputCode::Right)
            // NUMERIC KEYS
            INPUT_MAPPING_GENERATOR(GLFW_KEY_NUM_LOCK, InputCode::NumLock)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_0, InputCode::Num0)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_1, InputCode::Num1)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_2, InputCode::Num2)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_3, InputCode::Num3)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_4, InputCode::Num4)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_5, InputCode::Num5)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_6, InputCode::Num6)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_7, InputCode::Num7)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_8, InputCode::Num8)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_9, InputCode::Num9)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_DECIMAL, InputCode::NumDecimal)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_ENTER, InputCode::NumEnter)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_ADD, InputCode::NumPlus)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_SUBTRACT, InputCode::NumMinus)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_MULTIPLY, InputCode::NumAsterisk)
            INPUT_MAPPING_GENERATOR(GLFW_KEY_KP_DIVIDE, InputCode::NumSlash)

            default:
                return InputCode::Unknown;
        }
    }

    inline static InputModifier mapToInputModifier(int glfwMods, InputCode inputCode)
    {
        // siberianbot: excludes mods parsing for mod keys.
        if (inputCode == InputCode::LeftShift ||
            inputCode == InputCode::RightShift ||
            inputCode == InputCode::LeftControl ||
            inputCode == InputCode::RightControl ||
            inputCode == InputCode::LeftAlt ||
            inputCode == InputCode::RightAlt ||
            inputCode == InputCode::Super)
        {
            return InputModifier::None;
        }

        InputModifier modifier = InputModifier::None;

        if (glfwMods & GLFW_MOD_CONTROL)
        {
            modifier |= InputModifier::Ctrl;
        }

        if (glfwMods & GLFW_MOD_ALT)
        {
            modifier |= InputModifier::Alt;
        }

        if (glfwMods & GLFW_MOD_SHIFT)
        {
            modifier |= InputModifier::Shift;
        }

        if (glfwMods & GLFW_MOD_SUPER)
        {
            modifier |= InputModifier::Super;
        }

        return modifier;
    }

    void GlfwLibraryWrapper::init()
    {
        engineAssert(glfwInit() == GLFW_TRUE, "GLFW", "initialization failed");

        initWindow();
        initGlad();
    }

    void GlfwLibraryWrapper::terminate()
    {
        glfwDestroyWindow(_window);

        glfwTerminate();
    }

    void GlfwLibraryWrapper::makeContextCurrent()
    {
        glfwMakeContextCurrent(_window);
    }

    bool GlfwLibraryWrapper::isContextAlive() const
    {
        return !glfwWindowShouldClose(_window);
    }

    point_t GlfwLibraryWrapper::getContextSize() const
    {
        rengine::point_t size;

        glfwGetWindowSize(_window, &size.x, &size.y);

        return size;
    }

    void GlfwLibraryWrapper::refresh()
    {
        glfwPollEvents();
        glfwSwapBuffers(_window);
    }

    void GlfwLibraryWrapper::initWindow()
    {
        glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
        glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 6);
        glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
        glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);

        _window = glfwCreateWindow(800, 600, "rengine", nullptr, nullptr);
        engineAssert(_window != nullptr, "GLFW", "window is not created");

        glfwSetKeyCallback(_window, GlfwLibraryWrapper::windowKeyCallback);
    }

    void GlfwLibraryWrapper::initGlad()
    {
        makeContextCurrent();
        engineAssert(gladLoadGLLoader((GLADloadproc) glfwGetProcAddress), "GLAD", "initialization failed");
    }

    void GlfwLibraryWrapper::windowKeyCallback(GLFWwindow *window, int key, int scancode, int action, int mods)
    {
        InputState state;

        switch (action)
        {
            case GLFW_PRESS:
            case GLFW_REPEAT:
                state = InputState::Pressed;
                break;

            case GLFW_RELEASE:
                state = InputState::NotPressed;
                break;

            default:
                throw;
        }

        InputCode code = mapToInputCode(key);
        InputModifier modifiers = mapToInputModifier(mods, code);
        InputAccord accord = {code, modifiers};

        input_def_t inputDef = InputSystem::instance()->getInputDefinition(accord);
        InputState previousInputState = InputSystem::instance()->updateState(inputDef, state);

        if (state != previousInputState)
        {
            Log::instance()->debug("GLFW", "%0 accord %1 (%2)",
                                   state == InputState::Pressed ? "pressed" : "unpressed",
                                   accord.accordName(),
                                   accord.accordCode());
        }
    }
}