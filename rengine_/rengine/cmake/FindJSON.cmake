# TODO: add git check https://cliutils.gitlab.io/modern-cmake/chapters/projects/submodule.html

set(JSON_DIR "extern/json")

add_subdirectory("${JSON_DIR}")

include_directories("${JSON_DIR}/single_include")