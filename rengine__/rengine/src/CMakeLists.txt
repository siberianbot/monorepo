list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/main.cpp")

add_subdirectory("common")
add_subdirectory("rendering")
add_subdirectory("scripting")
add_subdirectory("system")
add_subdirectory("utils")

set(SRC ${SRC} PARENT_SCOPE)