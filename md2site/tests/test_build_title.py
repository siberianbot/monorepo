import unittest
import src.md2site as md2site
import pathlib


class test_build_title(unittest.TestCase):
  def test_no_lang_same_path(self):
    name = "file"
    path = "/foo/bar/{}".format(name)

    result = md2site.build_title(
        name, None, pathlib.PurePath(path), pathlib.PurePath(path), {})

    self.assertEqual(result, "/{}".format(name))

  def test_with_same_lang_same_path(self):
    name = "file"
    lang = "lang"
    path = "/foo/bar/{}".format(name)
    options = {
        "primary_lang": lang
    }

    result = md2site.build_title(
        name, lang, pathlib.PurePath(path), pathlib.PurePath(path), options)

    self.assertEqual(result, "/{}".format(name))

  def test_with_custom_lang_same_path(self):
    name = "file"
    lang = "lang1"
    path = "/foo/bar/{}".format(name)
    options = {
        "primary_lang": "lang2"
    }

    result = md2site.build_title(
        name, lang, pathlib.PurePath(path), pathlib.PurePath(path), options)

    self.assertEqual(result, "/{}.{}".format(name, lang))

  def test_no_lang_with_subpath(self):
    name = "file"
    root = "/foo/bar/"
    path = "/foo/bar/baz/{}".format(name)

    result = md2site.build_title(
        name, None, pathlib.PurePath(path), pathlib.PurePath(root), {})

    self.assertEqual(result, "/baz/{}".format(name))

  def test_with_custom_separator(self):
    name = "file"
    root = "/foo/bar/"
    path = "/foo/bar/baz/{}".format(name)
    options = {
        "title_separator": "#"
    }

    result = md2site.build_title(
        name, None, pathlib.PurePath(path), pathlib.PurePath(root), options)

    self.assertEqual(result, "#baz#{}".format(name))
