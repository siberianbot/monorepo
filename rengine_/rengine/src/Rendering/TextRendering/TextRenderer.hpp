#ifndef RENGINE_SRC_RENDERING_TEXTRENDERER_HPP
#define RENGINE_SRC_RENDERING_TEXTRENDERER_HPP

#include <memory>

#include "../Shader.hpp"
#include "../../Common/ISingleton.hpp"
#include "../../Extern/FreeTypeLibraryWrapper.hpp"

namespace rengine
{
    class TextRenderer : public ISingleton<TextRenderer>
    {
    public:
        void init();

        void terminate();

    private:
        std::shared_ptr<Shader> _textRenderingShader;
    };
}

#endif //RENGINE_SRC_RENDERING_TEXTRENDERER_HPP
