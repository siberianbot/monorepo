import unittest
from unittest.mock import patch, MagicMock
import src.md2site as md2site
import pathlib


class test_process_args(unittest.TestCase):
  @patch("os.path.isfile")
  @patch("os.path.isdir")
  def test_paths_only_valid_files(self, mock_isdir: MagicMock, mock_isfile: MagicMock):
    args = [
        "foo/bar.md",
        "foo/baz.md",
        "foo.md"
    ]

    mock_isfile.return_value = True
    mock_isdir.return_value = False

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), len(args))
    self.assertEqual(len(options), 0)

  @patch("os.path.isfile")
  @patch("os.path.isdir")
  def test_paths_only_valid_directories(self, mock_isdir: MagicMock, mock_isfile: MagicMock):
    args = [
        "foo/bar/",
        "foo/baz/",
        "foo/"
    ]

    mock_isfile.return_value = False
    mock_isdir.return_value = True

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), len(args))
    self.assertEqual(len(options), 0)

  @patch("os.path.isfile")
  @patch("os.path.isdir")
  def test_paths_only_valid_directories_and_files(self, mock_isdir: MagicMock, mock_isfile: MagicMock):
    args = [
        "foo/bar.md",
        "foo/baz.md",
        "foo.md",
        "foo/bar/",
        "foo/baz/",
        "foo/"
    ]

    mock_isfile.return_value = True
    mock_isdir.return_value = True

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), len(args))
    self.assertEqual(len(options), 0)

  @patch("os.path.isfile")
  @patch("os.path.isdir")
  def test_invalid_path(self, mock_isdir: MagicMock, mock_isfile: MagicMock):
    arg = "foo/bar.md"

    mock_isfile.return_value = False
    mock_isdir.return_value = False

    with self.assertRaises(ValueError, msg="provided path is invalid: {}".format(arg)):
      md2site.process_args([arg])

  @patch("os.path.isfile")
  def test_template_file_option_with_valid_file(self, mock_isfile: MagicMock):
    template_file = "foo/bar.html"
    args = [
        "--template-file",
        template_file
    ]

    mock_isfile.return_value = True

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), 0)
    self.assertEqual(len(options), 1)
    self.assertEqual(options.get("template_file"), template_file)

  @patch("os.path.isfile")
  def test_template_file_option_with_invalid_file(self, mock_isfile: MagicMock):
    template_file = "foo/bar.html"
    args = [
        "--template-file",
        template_file
    ]

    mock_isfile.return_value = False

    with self.assertRaises(ValueError, msg="path to template file is invalid"):
      md2site.process_args(args)

  def test_primary_lang_option_with_valid_value(self):
    primary_lang = "lang"
    args = [
        "--primary-lang",
        primary_lang
    ]

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), 0)
    self.assertEqual(len(options), 1)
    self.assertEqual(options.get("primary_lang"), primary_lang)

  def test_primary_lang_option_with_invalid_value(self):
    primary_lang = "####"
    args = [
        "--primary-lang",
        primary_lang
    ]

    with self.assertRaises(ValueError, msg="primary language does not match to regex \"[a-zA-Z]+\""):
      md2site.process_args(args)

  def test_output_ext_option_with_valid_value(self):
    output_ext = "ext"
    args = [
        "--output-ext",
        output_ext
    ]

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), 0)
    self.assertEqual(len(options), 1)
    self.assertEqual(options.get("output_ext"), output_ext)

  def test_output_ext_option_with_invalid_value(self):
    output_ext = "####"
    args = [
        "--output-ext",
        output_ext
    ]

    with self.assertRaises(ValueError, msg="output extension does not match to regex \"[a-zA-Z0-9]+\""):
      md2site.process_args(args)

  def test_output_directory_option_with_valid_path(self):
    output_directory = "foo/bar"
    args = [
        "--output-directory",
        output_directory
    ]

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), 0)
    self.assertEqual(len(options), 1)
    self.assertEqual(options.get("output_directory"), output_directory)

  def test_multiple_options(self):
    output_directory = "foo/bar"
    primary_lang = "lang"
    output_ext = "ext"
    args = [
        "--output-directory",
        output_directory,
        "--primary-lang",
        primary_lang,
        "--output-ext",
        output_ext
    ]

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), 0)
    self.assertEqual(len(options), 3)
    self.assertEqual(options.get("output_directory"), output_directory)
    self.assertEqual(options.get("output_ext"), output_ext)
    self.assertEqual(options.get("primary_lang"), primary_lang)

  @patch("os.path.isfile")
  @patch("os.path.isdir")
  def test_multiple_options_mixed_with_paths(self, mock_isdir: MagicMock, mock_isfile: MagicMock):
    output_directory = "foo/bar"
    primary_lang = "lang"
    output_ext = "ext"
    args = [
        "--output-directory",
        output_directory,
        "foo/bar",
        "--primary-lang",
        primary_lang,
        "foo/baz",
        "--output-ext",
        output_ext,
        "foo/"
    ]

    mock_isdir = True
    mock_isfile = False

    paths, options = md2site.process_args(args)

    self.assertEqual(len(paths), 3)
    self.assertEqual(len(options), 3)
    self.assertEqual(options.get("output_directory"), output_directory)
    self.assertEqual(options.get("output_ext"), output_ext)
    self.assertEqual(options.get("primary_lang"), primary_lang)
