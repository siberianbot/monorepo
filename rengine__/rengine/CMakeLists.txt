cmake_minimum_required(VERSION 3.17)
project(rengine)

set(CMAKE_CXX_STANDARD 20)
set(SRC)

# TODO GLFW module search
set(GLFW_DIR "${CMAKE_CURRENT_LIST_DIR}/deps/glfw")
add_subdirectory("${GLFW_DIR}")
include_directories("${GLFW_DIR}/include")

# TODO GLAD module search
set(GLAD_DIR "${CMAKE_CURRENT_LIST_DIR}/deps/glad")
include_directories("${GLAD_DIR}/include")
list(APPEND SRC "${GLAD_DIR}/src/glad.c")

# TODO .NET Host module search
set(NETHOST_DIR "${CMAKE_CURRENT_LIST_DIR}/deps/dotnet-dist/packs/Microsoft.NETCore.App.Host.win-x86/5.0.0-rc.1.20451.14/runtimes/win-x86/native")
include_directories("${NETHOST_DIR}")
link_directories("${NETHOST_DIR}")
find_library(NETHOST_LIB nethost REQUIRED PATHS "${NETHOST_DIR}")

# TODO GLM
set(GLM_DIR "${CMAKE_CURRENT_LIST_DIR}/deps/glm")
add_subdirectory("${GLM_DIR}")
include_directories("${GLM_DIR}/include")

add_subdirectory("src")

add_executable(rengine ${SRC})
target_compile_options(rengine PUBLIC -Wall)

target_link_libraries(rengine
        glfw ${GLFW_LIBRARIES}
        nethost ${NETHOST_LIB}
        glm::glm
)