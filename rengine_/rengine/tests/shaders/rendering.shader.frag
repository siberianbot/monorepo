#version 460

struct vertex_t
{
    vec3 position;
    vec3 normal;
    vec3 color;
    vec2 texture;
};

layout (location = 0) in vertex_t vertex;

layout (location = 0) out vec4 fragmentColor;

uniform sampler2D texture0;

void main()
{
    fragmentColor = texture(texture0, vertex.texture) * vec4(vertex.color, 1.0f);
}