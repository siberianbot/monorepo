list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Win32Viewport.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Win32Viewport.hpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Win32Viewport.WndProc.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Win32ViewportManager.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Win32ViewportManager.hpp")

set(SRC ${SRC} PARENT_SCOPE)