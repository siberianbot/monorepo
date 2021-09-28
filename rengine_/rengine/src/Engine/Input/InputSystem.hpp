#ifndef RENGINE_SRC_ENGINE_INPUTSYSTEM_HPP
#define RENGINE_SRC_ENGINE_INPUTSYSTEM_HPP

#include <cstdint>
#include <functional>
#include <map>
#include <string>
#include <vector>

#include "InputTypes.hpp"
#include "../../Common/ISingleton.hpp"

namespace rengine
{
    /// Input subsystem.
    /// Provides bindings of inputs (and input accords) to actions.
    class InputSystem : public ISingleton<InputSystem>
    {
    public:
        /// Returns input definition by input accord.
        /// \param accord Input accord.
        /// \return Input definition.
        input_def_t getInputDefinition(const input_accord_t &accord);

        /// Adds binding.
        /// \param inputDef Input definition.
        /// \param callback Callback function.
        void addBinding(const input_def_t &inputDef, const std::function<void()> &callback);

        /// Removes all bindings related to input definition.
        /// \param inputDef Input definition.
        void removeBindings(const input_def_t &inputDef);

        /// Invokes all bindings.
        void invokeBindings();

        /// Resets all bindings.
        void resetBindings();

        /// Gets state of input by input definition.
        /// \param inputDef Input definition.
        /// \return Input state.
        InputState getState(const input_def_t &inputDef);

        /// Sets state of input.
        /// \param inputDef Input definition.
        /// \param state Input state.
        /// \return Previous state of accord.
        InputState updateState(const input_def_t &inputDef, const InputState &state);

        /// Resets states of all inputs.
        void resetStates();

    private:
        uint32_t _inputIds = 0;
        std::vector<input_def_t> _inputs;
        std::vector<input_bind_t> _bindings;
        std::map<std::uint32_t, InputState> _states;
    };
}

#endif //RENGINE_SRC_ENGINE_INPUTSYSTEM_HPP
