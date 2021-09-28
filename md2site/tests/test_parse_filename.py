import unittest
import src.md2site as md2site


class test_parse_filename(unittest.TestCase):

  def test_success_no_lang(self):
    source = "filename.ext"
    parsed = md2site.parse_filename(source)

    self.assertEqual(parsed["filename"], "filename")
    self.assertEqual(parsed["ext"], "ext")
    self.assertFalse(parsed["lang"])

  def test_success_with_lang(self):
    source = "filename.lang.ext"
    parsed = md2site.parse_filename(source)

    self.assertEqual(parsed["filename"], "filename")
    self.assertEqual(parsed["ext"], "ext")
    self.assertEqual(parsed["lang"], "lang")

  def test_success_many_dots_no_lang(self):
    source = "filename.........ext"
    parsed = md2site.parse_filename(source)

    self.assertEqual(parsed["filename"], "filename........")
    self.assertEqual(parsed["ext"], "ext")
    self.assertFalse(parsed["lang"])

  def test_success_many_dots_with_lang(self):
    source = "filename........lang.ext"
    parsed = md2site.parse_filename(source)

    self.assertEqual(parsed["filename"], "filename.......")
    self.assertEqual(parsed["ext"], "ext")
    self.assertEqual(parsed["lang"], "lang")

  def test_failure_empty_filename_arg(self):
    with self.assertRaises(ValueError):
      md2site.parse_filename("")

  def test_failure_empty_ext(self):
    with self.assertRaises(ValueError):
      md2site.parse_filename("filename.")

  def test_failure_empty_filename(self):
    with self.assertRaises(ValueError):
      md2site.parse_filename(".ext")
