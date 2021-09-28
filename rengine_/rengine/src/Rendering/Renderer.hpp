#ifndef RENGINE_SRC_RENDERING_RENDERER_HPP
#define RENGINE_SRC_RENDERING_RENDERER_HPP

#include <cstdint>
#include <memory>

#include "Shader.hpp"
#include "Viewport.hpp"
#include "../Common/ISingleton.hpp"

namespace rengine
{
    /// Main rendering subsystem.
    /// Performs most of rendering tasks.
    class Renderer : public ISingleton<Renderer>
    {
    public:
        /// Initializes rendering subsystem: loads rendering shader.
        void init();

        /// Terminates rendering subsystem.
        void terminate();

        /// Renders all mesh.
        /// \param viewport Viewport.
        void render(const viewport_t &viewport) const;

        // TODO: possibly, it is not a good place to store such things.
        std::uint32_t maxTextureSize() const;

    private:
        std::shared_ptr<Shader> _renderingShader;
    };
}

#endif //RENGINE_SRC_RENDERING_RENDERER_HPP
