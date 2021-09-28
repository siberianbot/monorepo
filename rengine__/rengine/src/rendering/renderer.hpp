#ifndef RENGINE_SRC_RENDERING_RENDERER_HPP
#define RENGINE_SRC_RENDERING_RENDERER_HPP

namespace rengine
{
    class renderer
    {
    public:
        static renderer &instance();

        void init();

        void render();

    private:
        renderer() = default;
    };
}

#endif //RENGINE_SRC_RENDERING_RENDERER_HPP
