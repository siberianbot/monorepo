import unittest
import src.md2site as md2site


class test_build_filename(unittest.TestCase):

  def test_success_no_lang_defaults(self):
    filename = "filename"
    ext = "html"

    result = md2site.build_filename(filename, None, None)

    split = result.split(".")

    self.assertEqual(len(split), 2)
    self.assertEqual(split[-1], ext)
    self.assertEqual(split[0], filename)

  def test_success_with_lang_defaults(self):
    filename = "filename"
    ext = "html"
    lang = "lang"

    result = md2site.build_filename(filename, lang, None)

    split = result.split(".")

    self.assertEqual(len(split), 3)
    self.assertEqual(split[-1], ext)
    self.assertEqual(split[-2], lang)
    self.assertEqual(split[0], filename)

  def test_success_with_default_lang_and_options(self):
    filename = "filename"
    ext = "html"
    lang = "ln"

    result = md2site.build_filename(filename, lang, {
        "primary_lang": lang
    })

    split = result.split(".")

    self.assertEqual(len(split), 2)
    self.assertEqual(split[-1], ext)
    self.assertEqual(split[0], filename)

  def test_success_with_custom_lang_and_options(self):
    filename = "filename"
    ext = "html"
    lang = "lang1"

    result = md2site.build_filename(filename, lang, {
        "primary_lang": "lang2"
    })

    split = result.split(".")

    self.assertEqual(len(split), 3)
    self.assertEqual(split[-1], ext)
    self.assertEqual(split[-2], lang)
    self.assertEqual(split[0], filename)

  def test_success_with_custom_extension_in_options(self):
    filename = "filename"
    ext = "ext"

    result = md2site.build_filename(filename, None, {
        "output_ext": ext
    })

    split = result.split(".")

    self.assertEqual(len(split), 2)
    self.assertEqual(split[-1], ext)
    self.assertEqual(split[0], filename)
