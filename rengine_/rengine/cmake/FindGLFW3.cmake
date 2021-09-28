# TODO: add git check https://cliutils.gitlab.io/modern-cmake/chapters/projects/submodule.html

set(GLFW3_DIR "extern/glfw3")

add_subdirectory("${GLFW3_DIR}")
include_directories("${GLFW3_DIR}/include")