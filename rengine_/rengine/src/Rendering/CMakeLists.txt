list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Framebuffer.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Mesh.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/MeshFactory.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/MeshStorage.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Renderer.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Shader.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/ShaderFactory.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/VertexBuffer.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Viewport.cpp")

add_subdirectory("TextRendering")
add_subdirectory("Texturing")

set(SRC ${SRC} PARENT_SCOPE)