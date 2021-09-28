import unittest
import src.md2site as md2site


class test_get_option(unittest.TestCase):

  def test_success_empty_options_from_defaults(self):
    for key in md2site.defaults.keys():
      self.assertEqual(md2site.get_option({}, key), md2site.defaults.get(key))

  def test_success_with_options_and_defaults(self):
    options = {"option": "option"}

    for key in md2site.defaults.keys():
      self.assertEqual(md2site.get_option(
          options, key), md2site.defaults.get(key))

  def test_success_from_options(self):
    options: dict = {}

    for key in md2site.defaults.keys():
      options[key] = key

    for key in md2site.defaults.keys():
      self.assertEqual(md2site.get_option(options, key), key)

  def test_no_key(self):
    key = "ItIsNotExistingKey"
    self.assertEqual(md2site.get_option({}, key), None)
