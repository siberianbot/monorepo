import unittest
import src.md2site as md2site
import pathlib


class test_build_output_path(unittest.TestCase):
  def test_only_input_path(self):
    input_path = pathlib.Path("foo/bar/")

    result = md2site.build_output_path(input_path, None, None)

    self.assertEquals(input_path, result)

  def test_input_path_with_root_path(self):
    root_path = pathlib.PurePath("foo/")
    input_path = pathlib.Path("foo/bar/")

    result = md2site.build_output_path(input_path, root_path, None)

    self.assertEquals(input_path, result)

  def test_input_path_with_target_root_path(self):
    input_path = pathlib.Path("foo/bar/")
    target_root_path = pathlib.PurePath("bar/")

    result = md2site.build_output_path(input_path, None, target_root_path)

    self.assertEquals(target_root_path, result)

  def test_input_path_with_current_root_and_target_root_paths(self):
    input_path = pathlib.Path("foo/bar/")
    current_root_path = pathlib.PurePath("foo/")
    target_root_path = pathlib.PurePath("bar/")

    result = md2site.build_output_path(
        input_path, current_root_path, target_root_path)

    self.assertEquals(pathlib.PurePath("bar/bar/"), result)
