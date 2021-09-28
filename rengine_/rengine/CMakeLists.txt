cmake_minimum_required(VERSION 3.16)
project("rengine"
        VERSION 0.1
        DESCRIPTION "A game engine")

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_MODULE_PATH "${CMAKE_MODULE_PATH};${CMAKE_CURRENT_SOURCE_DIR}/cmake")
set(SRC)

add_definitions(-DRENGINE_VERSION="${PROJECT_VERSION}")

#find_package(ASSIMP) todo
find_package(FREETYPE2)
find_package(GLFW3)
find_package(GLAD)
find_package(GLM)
find_package(JSON)
find_package(STB)

list(APPEND SRC ${GLAD_LIB_SRC})
add_subdirectory("src")

add_executable(rengine ${SRC})
target_compile_options(rengine PUBLIC -Wall)
target_link_libraries(rengine glfw ${GLFW_LIBRARIES} freetype ${FREETYPE_LIBRARIES})