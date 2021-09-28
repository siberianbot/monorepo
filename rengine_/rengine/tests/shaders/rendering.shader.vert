#version 460

struct vertex_t
{
    vec3 position;
    vec3 normal;
    vec3 color;
    vec2 texture;
};

layout (location = 0) in vec3 in_Position;
layout (location = 1) in vec3 in_Normal;
layout (location = 2) in vec3 in_Color;
layout (location = 3) in vec2 in_Texture;

layout (location = 0) out vertex_t vertex;

uniform mat4 transform;

void main()
{
    vertex = vertex_t(in_Position, in_Normal, in_Color, in_Texture);

    gl_Position = transform * vec4(vertex.position, 1.0f);
}