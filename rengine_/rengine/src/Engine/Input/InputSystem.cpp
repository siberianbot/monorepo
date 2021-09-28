#include "InputSystem.hpp"

#include <algorithm>
#include <sstream>

namespace rengine
{
    GENERATE_SINGLETON_INSTANCE(InputSystem);

    input_def_t InputSystem::getInputDefinition(const input_accord_t &accord)
    {
        auto iterator = std::find_if(_inputs.begin(), _inputs.end(), [&accord](const input_def_t &inputDef)
        {
            return inputDef.accord.code == accord.code &&
                   inputDef.accord.mods == accord.mods;
        });

        if (iterator != _inputs.end())
        {
            return *iterator;
        }

        input_def_t newDefinition = { ++_inputIds, accord };

        _inputs.push_back(newDefinition);

        return newDefinition;
    }

    void InputSystem::addBinding(const input_def_t &inputDef, const std::function<void()> &callback)
    {
        input_bind_t newBinding = { inputDef.id, callback };

        _bindings.push_back(newBinding);
    }

    void InputSystem::removeBindings(const input_def_t &inputDef)
    {
        _bindings.erase(std::remove_if(_bindings.begin(), _bindings.end(), [&inputDef](const input_bind_t &binding)
        {
            return binding.inputDefId == inputDef.id;
        }));
    }

    void InputSystem::invokeBindings()
    {
        for (auto input : _states)
        {
            if (input.second == InputState::NotPressed)
            {
                continue;
            }

            for (const auto &binding : _bindings)
            {
                if (binding.inputDefId == input.first)
                {
                    binding.callback();
                }
            }
        }
    }

    void InputSystem::resetBindings()
    {
        _bindings.clear();
    }

    InputState InputSystem::getState(const input_def_t &inputDef)
    {
        return _states[inputDef.id];
    }

    InputState InputSystem::updateState(const input_def_t &inputDef, const InputState &state)
    {
        InputState previousState = InputState::NotPressed;

        if (_states.contains(inputDef.id))
        {
            previousState = _states[inputDef.id];
        }

        _states[inputDef.id] = state;

        return previousState;
    }

    void InputSystem::resetStates()
    {
        _states.clear();
    }
}
